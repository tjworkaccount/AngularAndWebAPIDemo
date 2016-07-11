using System;
using System.Linq;
using Data.Classes.Reference;

namespace Repository.Reference
{
    public interface IReferenceRepository: IDisposable
    {
        IQueryable<UserReference> GetUsers();
        IQueryable<StatusReference> GetStatuses();
    }
}
