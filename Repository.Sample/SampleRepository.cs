using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Context.Sample;
using Data.Classes;

namespace Repository.Sample
{
    public class SampleRepository: ISampleRepository, IDisposable
    {
        private readonly SampleContext _sampleContext;
        private bool isDisposed = false;

        public SampleRepository()
        {
            _sampleContext = new SampleContext();
        }

        ~SampleRepository()
        {
            Dispose(false);
        }

        public IQueryable<Samples> GetSamples(params Expression<Func<Samples, object>>[] includeProperties)
        {
            IQueryable<Samples> queryable = _sampleContext.Samples;
            foreach (var includes in includeProperties)
            {
                queryable = queryable.Include(includes);
            }

            return queryable.Include(r => r.CreatedByUser).Include(r =>r.Status);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    _sampleContext.Dispose();
                }

                isDisposed = true;
            }
        }
    }
}
