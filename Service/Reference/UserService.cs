using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Classes.Reference;
using Repository.Reference;

namespace Service.Reference
{
    public class UserService
    {
        private readonly IReferenceRepository referenceRepository;

        public UserService()
        {
            referenceRepository = new ReferenceRepository();
        }
        
        public KeyValuePair<int, string>[] GetUsersList()
        {
            var list = new List<KeyValuePair<int, string>>();

            foreach (var userReference in referenceRepository.GetUsers().ToList().OrderBy(l=>l.LastName))
            {
                list.Add(new KeyValuePair<int, string>(userReference.UserId, (userReference.LastName + ", " + userReference.FirstName)));
            }

            return list.ToArray();
        }
    }
}