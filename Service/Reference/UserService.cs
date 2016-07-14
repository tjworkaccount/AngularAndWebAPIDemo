using System.Collections.Generic;
using System.Linq;
using Repository.Reference;

namespace Service.Reference
{
    public class UserService
    {
        private readonly IReferenceRepository _referenceRepository;

        public UserService()
        {
            _referenceRepository = new ReferenceRepository();
        }
        
        public KeyValuePair<int, string>[] GetUsersList()
        {
            var list = new List<KeyValuePair<int, string>>();

            foreach (var userReference in _referenceRepository.GetUsers().ToArray().OrderBy(l=>l.LastName))
            {
                list.Add(new KeyValuePair<int, string>(userReference.UserId, userReference.ToString()));
            }

            return list.ToArray();
        }
    }
}