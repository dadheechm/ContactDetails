using Contact_Management.DataContract.DTO;
using Contact_Management.DataContracts.API;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Contact_Management.Models
{

    public class ContactModel
    {

        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        [MaxLength(50, ErrorMessage = "Max Length is '50'")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        [MaxLength(50, ErrorMessage = "Max Length is '50'")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
        [MaxLength(50, ErrorMessage = "Max Length is '50'")]
        public string Email { get; set; }
        [Display(Name ="Phone Number")]
        [MaxLength(10, ErrorMessage = "Max Length is '10'")]
        [Required(ErrorMessage = "Phone Number is Required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone Number is not valid")]
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }


        ContactManager _ContactManager = new ContactManager();

        //Get All Contact Details
        public List<ContactModel> GetAllContacts()
        {
            IQueryable<ContactDTO> _ListContactDTO = _ContactManager.GetAllContacts();
            List<ContactModel> _ContactDetailList = new List<ContactModel>();
            foreach (var _ContactDTO in _ListContactDTO)
            {
                ContactModel _ContactModel = new ContactModel();
                _ContactModel.FirstName = _ContactDTO.FirstName;
                _ContactModel.LastName = _ContactDTO.LastName;
                _ContactModel.Id = _ContactDTO.Id;
                _ContactModel.Email = _ContactDTO.Email;
                _ContactModel.PhoneNumber = _ContactDTO.PhoneNumber;
                _ContactModel.Status = _ContactDTO.Status;

                _ContactDetailList.Add(_ContactModel);
            }

            return _ContactDetailList;
        }


        //Get Selected Contact Detail
        public ContactModel GetContactById(int _Id)
        {
            ContactDTO _ContactDTO = _ContactManager.GetContactById(_Id);
            ContactModel _ContactModel = new ContactModel();
            _ContactModel.FirstName = _ContactDTO.FirstName;
            _ContactModel.LastName = _ContactDTO.LastName;
            _ContactModel.Id = _ContactDTO.Id;
            _ContactModel.Email = _ContactDTO.Email;
            _ContactModel.PhoneNumber = _ContactDTO.PhoneNumber;
            _ContactModel.Status = _ContactDTO.Status;

            return _ContactModel;

        }

        // Update Contact
        public string UpdateContact(ContactModel _ContactModel)
        {
            ContactDTO _ContactDTO = new ContactDTO();
            _ContactDTO.Id = _ContactModel.Id;
            _ContactDTO.FirstName = _ContactModel.FirstName;
            _ContactDTO.LastName = _ContactModel.LastName;
            _ContactDTO.Email = _ContactModel.Email;
            _ContactDTO.PhoneNumber = _ContactModel.PhoneNumber;
            _ContactDTO.Status = _ContactModel.Status;

            return _ContactManager.UpdateContact(_ContactDTO).ToString();
        }

        //Create a new Contact
        public string CreateContact(ContactModel _ContactModel)
        {
            ContactDTO _ContactDTO = new ContactDTO();
            _ContactDTO.FirstName = _ContactModel.FirstName;
            _ContactDTO.LastName = _ContactModel.LastName;
            _ContactDTO.Id = _ContactModel.Id;
            _ContactDTO.Email = _ContactModel.Email;
            _ContactDTO.PhoneNumber = _ContactModel.PhoneNumber;
            _ContactDTO.Status = true;

            return _ContactManager.AddContact(_ContactDTO).ToString();

        }

        //Delete Contact
        public string DeleteContact(int _Id)
        {
            return _ContactManager.DeleteContact(_Id).ToString();

        }

    }
}