using System;
using System.Linq;
using Data.Classes.Reference;
using Context.Reference;

namespace Repository.Reference
{
    public class ReferenceRepository:IDisposable
    {
        private readonly ReferenceContext _context;

        public ReferenceRepository()
        {
            _context = new ReferenceContext();
        }

        public IQueryable<UserReference> Users => _context.Users.AsNoTracking();
        public IQueryable<StatusReference> Statuses => _context.Statuses.AsNoTracking();
        public IQueryable<SampleReference> Samples => _context.Samples.AsNoTracking();

        public void Dispose()
        {
          _context.Dispose();
        } 
    }
}