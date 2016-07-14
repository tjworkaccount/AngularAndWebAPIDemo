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
        IQueryable<Samples> GetSamples(int pageNumber, int pageSize, string userCreated, int? statusId, string barcode);
        bool InsertSample(int userId, int statusId, string barcode);
        int GetTotalCount(string userCreated, int? statusId, string barcode);
        bool IsValid(int pageNumber, int pageSize, string userCreated, int? statusId, string barcode);
    }
}