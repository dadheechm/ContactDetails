using Contact_Management.DataContract.DAL.Context;
using Contact_Management.DataContract.DAL.Context.Tables;
using Contact_Management.DataContract.DTO;
using Contact_Management.DataContracts.DAL.Repository;
using Contact_Management.DataContracts.Infrastructure;
using System;
using System.Linq;

namespace Contact_Management.DataContract.DAL.Repository
{
    class CMRepository : GenericRepository
    {
        private new readonly CMContext _Context;
        CMContext Model { get { return _Context; } }

        public CMRepository(string connectionStringName): base(connectionStringName)
        {
        }

        public CMRepository(): base(new CMContext())
        {
            this._Context = (CMContext)base._Context;
        }

        public CMRepository(CMContext context): base(context)
        {
            this._Context = context;
        }

        public CMRepository(CMContext context, bool lazyLoading): base(context, lazyLoading: lazyLoading)
        {
            this._Context = context;
        }


        public IQueryable<ContactDTO> GetAllContacts()
        {
            try
            {
                var res =  (from Contact in this.Model.Contact
                        select new ContactDTO
                        {
                            Id = Contact.Id,
                            FirstName = Contact.FirstName,
                            LastName = Contact.LastName,
                            Email = Contact.Email,
                            PhoneNumber = Contact.PhoneNumber,
                            Status = Contact.Status
                        }).ToList().AsQueryable().OrderBy(x => x.Id);

                return res;
            }
            catch (Exception)
            {
                return null;
            }

            
        }

        public ContactDTO GetContactById(int _Id)
        {
            try
            {
                return (from Contacts in this.Model.Contact
                        where Contacts.Id == _Id
                        select new ContactDTO
                        {
                            Id = Contacts.Id,
                            FirstName = Contacts.FirstName,
                            LastName = Contacts.LastName,
                            Email = Contacts.Email,
                            PhoneNumber = Contacts.PhoneNumber,
                            Status = Contacts.Status
                        }).FirstOrDefault();
            }
            catch (Exception)
            {
               return null;
            }
        }

        public SaveChangeEnum AddContact(ContactDTO _ContactDTO)
        {
            SaveChangeEnum retVal = SaveChangeEnum.No_Action;
            try
            {
                this.UnitOfWork.BeginTransaction();
                 Contact _Contact = new Contact();
                _Contact.FirstName = _ContactDTO.FirstName;
                _Contact.LastName = _ContactDTO.LastName;
                _Contact.Email = _ContactDTO.Email;
                _Contact.PhoneNumber = _ContactDTO.PhoneNumber;
                _Contact.Status = _ContactDTO.Status;
                this.Add<Contact>(_Contact);
                this._Context.SaveChanges();
                retVal = this.UnitOfWork.CommitTransaction();

            }
            catch (Exception)
            {
                //Log Errors
            }
            
            return retVal;
        }

        public SaveChangeEnum UpdateContact(ContactDTO _ContactDTO)
        {
            SaveChangeEnum retVal = SaveChangeEnum.No_Action;

            try
            {
                Contact _Contact = (from cd in this.Model.Contact
                                                where cd.Id == _ContactDTO.Id
                                                select cd).FirstOrDefault();

                if (_Contact != null)
                {
                    this.UnitOfWork.BeginTransaction();
                    _Contact.FirstName = _ContactDTO.FirstName;
                    _Contact.LastName = _ContactDTO.LastName;
                    _Contact.Email = _ContactDTO.Email;
                    _Contact.PhoneNumber = _ContactDTO.PhoneNumber;
                    _Contact.Status = _ContactDTO.Status;
                    this.Update<Contact>(_Contact);
                    this._Context.SaveChanges();
                    retVal = this.UnitOfWork.CommitTransaction();

                }
            }
            catch (Exception)
            {

            }
           

            return retVal;
        }

        public SaveChangeEnum DeleteContact(int _Id)
        {
            SaveChangeEnum retVal = SaveChangeEnum.No_Action;
            try
            {
                Contact Contact = (from Contacts in this.Model.Contact
                                               where Contacts.Id == _Id
                                               select Contacts).FirstOrDefault();

                if (Contact != null)
                {
                    this.UnitOfWork.BeginTransaction();
                    this.Delete<Contact>(Contact);
                    this._Context.SaveChanges();
                    retVal = this.UnitOfWork.CommitTransaction();
                }
            }
            catch (Exception)
            {
                //Log Errors
            }

            return retVal;
        }
    }
}
