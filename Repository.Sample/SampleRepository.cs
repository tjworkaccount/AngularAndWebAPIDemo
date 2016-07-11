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

        public IQueryable<Samples> GetSamples(string userCreated = null, int? statusId = null)
        {
            var predicate = PredicateBuilder.True<Samples>();

            if (statusId != null)
            {
                predicate = predicate.And(r => r.Status.StatusId == (int) statusId);
            }

            if (!string.IsNullOrWhiteSpace(userCreated))
            {
                var inner = PredicateBuilder.False<Samples>();
                inner = inner.Or(i => i.CreatedByUser.FirstName.ToLower().Contains(userCreated.ToLower()));
                inner = inner.Or(i => i.CreatedByUser.LastName.ToLower().Contains(userCreated.ToLower()));
                predicate.And(inner);
            }

            return _sampleContext.Samples.Include(r => r.CreatedByUser).Include(r => r.Status).AsExpandable().Where(predicate);
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
