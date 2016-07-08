using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Reference;

namespace Service.Reference
{
    public class StatusService
    {
        private readonly IReferenceRepository referenceRepository;

        public StatusService()
        {
            referenceRepository = new ReferenceRepository();
        }

        public KeyValuePair<int, string>[] GetStatusList()
        {
            try
            {
                var list = new List<KeyValuePair<int, string>>();

                foreach (var status in referenceRepository.GetStatuses())
                {
                    list.Add(new KeyValuePair<int, string>(status.StatusId, status.Status));
                }

                return list.ToArray();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}