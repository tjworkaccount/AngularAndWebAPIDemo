using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data.Classes;

namespace Repository.Sample
{
    public interface ISampleRepository
    {
        IQueryable<Samples> GetSamples(params Expression<Func<Samples, object>>[] includeProperties);
    }
}
