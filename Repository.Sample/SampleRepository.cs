using System;
using System.Data.Entity;
using System.Linq;
using Context.Sample;
using Data.Classes;
using LinqKit;

namespace Repository.Sample
{
    public class SampleRepository: ISampleRepository, IDisposable
    {
        private readonly SampleContext _sampleContext;
        private bool _isDisposed = false;

        public SampleRepository()
        {
            _sampleContext = new SampleContext();
        }

        ~SampleRepository()
        {
            Dispose(false);
        }

        public IQueryable<Samples> GetSamples(int pageNumber, int pageSize, string userCreated, int? statusId, string barcode)
        {
            return  QuerySample(userCreated,statusId,barcode).ToArray().Skip((pageNumber-1)*pageSize).Take(pageSize).AsQueryable();
        }

        public bool IsValid(int pageNumber, int pageSize, string userCreated, int? statusId, string barcode)
        {
            return QuerySample(userCreated, statusId, barcode).ToArray().Skip((pageNumber - 1) * pageSize).Take(pageSize).Any();
        }

        public int GetTotalCount(string userCreated, int? statusId, string barcode)
        {
            return QuerySample(userCreated, statusId, barcode).Count();
        }

        private IQueryable<Samples> QuerySample(string userCreated, int? statusId, string barcode)
        {
            var predicate = PredicateBuilder.True<Samples>();

            if (statusId != null)
            {
                predicate = predicate.And(r => r.Status.StatusId == (int)statusId);
            }

            if (!string.IsNullOrWhiteSpace(userCreated))
            {
                var inner = PredicateBuilder.False<Samples>();

                if (userCreated.Contains(" ") || userCreated.Contains(", "))
                {
                    foreach (var s in userCreated.Split(new[] { ' ', ',' }))
                    {
                        inner = inner.Or(i => i.CreatedByUser.FirstName.ToLower().Contains(s.ToLower()));
                        inner = inner.Or(i => i.CreatedByUser.LastName.ToLower().Contains(s.ToLower()));
                    }
                }

                inner = inner.Or(i => i.CreatedByUser.FirstName.ToLower().Contains(userCreated.ToLower()));
                inner = inner.Or(i => i.CreatedByUser.LastName.ToLower().Contains(userCreated.ToLower()));

                predicate = predicate.And(inner);
            }

            if (!string.IsNullOrWhiteSpace(barcode))
            {
                predicate = predicate.And(i => i.Barcode.Contains(barcode));
            }

            return _sampleContext.Samples.Include(r => r.CreatedByUser).Include(r => r.Status).AsExpandable().Where(predicate);
        }

        public bool InsertSample(int userId, int statusId, string barcode)
        {
            var returnValue = false;

            if (string.IsNullOrWhiteSpace(barcode) || !_sampleContext.Users.Any(i => i.UserId == userId) ||
                !_sampleContext.Statuses.Any(i => i.StatusId == statusId) ||
                _sampleContext.Samples.Any(i => string.Equals(i.Barcode.ToLower(), barcode.ToLower())))
                return false;

            var newSample = new Samples
            {
                StatusId = statusId,
                CreatedBy = userId,
                CreatedAt = DateTime.Now,
                Barcode = barcode,
                SampleId = default(int)
            };

            _sampleContext.Samples.Add(newSample);
            _sampleContext.Entry(newSample).State = EntityState.Added;

            try
            {
                Save();
                returnValue = true;
            }
            catch (Exception)
            {

                returnValue = false;
            }
            
            return returnValue;
        }

        public void Save()
        {
            _sampleContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _sampleContext.Dispose();
                }

                _isDisposed = true;
            }
        }
    }
}
