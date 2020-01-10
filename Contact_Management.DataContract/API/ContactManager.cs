using Contact_Management.DataContract.DAL.Repository;
using Contact_Management.DataContract.DTO;
using Contact_Management.DataContracts.Infrastructure;
using System.Linq;

namespace Contact_Management.DataContracts.API
{
    public class ContactManager
    {

        public IQueryable<ContactDTO> GetAllContacts()
        {
            using (CMRepository repo = new CMRepository())
            {
                return repo.GetAllContacts();
            }
        }

        public ContactDTO GetContactById(int Id)
        {
            using (CMRepository repo = new CMRepository())
            {
                return repo.GetContactById(Id);
            }
        }

        public SaveChangeEnum AddContact(ContactDTO _ContactDTO)
        {
            using (CMRepository repo = new CMRepository())
            {
                return repo.AddContact(_ContactDTO);
            }
        }

        public SaveChangeEnum UpdateContact(ContactDTO _ContactDTO)
        {
            using (CMRepository repo = new CMRepository())
            {
                return repo.UpdateContact(_ContactDTO);
            }
        }

        public SaveChangeEnum DeleteContact(int Id)
        {
            using (CMRepository repo = new CMRepository())
            {
                return repo.DeleteContact(Id);
            }
        }
    }
}
