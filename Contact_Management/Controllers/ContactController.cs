using Contact_Management.Models;
using System;
using System.Web.Http;

namespace Contact_Management.Controllers
{
    [RoutePrefix("api/contacts")]
    public class ContactController : ApiController
    {
        private readonly ContactModel _ContactModel;

        public ContactController()
        {
            _ContactModel = new ContactModel();
        }



        #region Action Methods
    
        [HttpPost]
        [Route("CreateContact")]
        public IHttpActionResult CreateContact([FromBody] ContactModel _Contact)
        {
            try
            {
                if (_Contact == null)
                    return BadRequest();

                if (_ContactModel.CreateContact(_Contact) == "Saved_Successfully")
                {
                    return Ok(true);
                }            

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok(false);
        }

        [HttpPost]
        [Route("UpdateContact")]
        public IHttpActionResult UpdateContact([FromBody] ContactModel _Contact)
        {
            try
            {
                if (_Contact != null)
                {
                    _ContactModel.UpdateContact(_Contact);
                    return Ok(true);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [HttpPost]
        [Route("DeleteContact")]
        public IHttpActionResult DeleteContact([FromBody] ContactModel _Contact)
        {
            try
            {
                if (_Contact.Id > 0)
                {
                    _ContactModel.DeleteContact(_Contact.Id);
                    return Ok(true);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }


        [HttpPost]
        [Route("GetContactById")]
        public IHttpActionResult GetContact([FromBody] ContactModel _Contact)
        {
            try
            {
                if (_Contact.Id > 0)
                {
                    var contact = _ContactModel.GetContactById(_Contact.Id);

                    if (contact != null)
                        return Ok(contact);
                    else
                        return NotFound();
                }
                else
                {
                    return BadRequest("The Contact Id is invalid");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }


        [HttpPost]
        [Route("GetAllContacts")]
        public IHttpActionResult GetAllContacts()
        {
            try
            {
                var allContacts = _ContactModel.GetAllContacts();
                return Ok(allContacts);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }


        #endregion
    }
}
