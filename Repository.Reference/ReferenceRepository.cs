using System;
using System.Linq;
using Data.Classes.Reference;
using Context.Reference;

namespace Repository.Reference
{
    public class ReferenceRepository:IReferenceRepository, IDisposable
    {
        private readonly ReferenceContext _context;
        private bool isDisposed = false;

        public ReferenceRepository()
        {
            _context = new ReferenceContext();
        }

        ~ReferenceRepository()
        {
            Dispose(false);
        }

        public IQueryable<UserReference> GetUsers() => _context.Users;

        public IQueryable<StatusReference> GetStatuses() => _context.Statuses;

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
                    _context.Dispose();
                }

                isDisposed = true;
            }
        }
    }
}