using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Classes.Reference;

namespace Repository.Reference
{
    public interface IReferenceRepository: IDisposable
    {
        IQueryable<UserReference> GetUsers();
        IQueryable<StatusReference> GetStatuses();
    }
}
