using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace Contact_Management.Models
{

    public class APIClient
    {
        private readonly string BaseURI = Common.Consumable.WebAddress.GetWebAddress();

        public IEnumerable<ContactModel> GetAllContacts()
        {
            IEnumerable<ContactModel> _ListContactModel = null;
            try
            {
                WebClient client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                client.UseDefaultCredentials = true;
                client.Headers.Add("Content-Type:application/json");
                string apiUrl = BaseURI + "api/contacts/GetAllContacts";

                client.Headers.Add("Accept:application/json");

                var response = client.UploadString(apiUrl, "POST");
                _ListContactModel = JsonConvert.DeserializeObject<IEnumerable<ContactModel>>(response);
            }

            catch
            {
                //Log Errors
            }

            return _ListContactModel;
        }

        public ContactModel GetContactById(int _Id)
        {
            ContactModel _ContactModel = null;
            try
            {
                WebClient client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                client.UseDefaultCredentials = true;
                client.Headers.Add("Content-Type:application/json");
                string apiUrl = BaseURI + "api/contacts/GetContactById";
                client.Headers.Add("Accept:application/json");
                ContactModel model = new ContactModel();
                model.Id = _Id;
                String objectName = JsonConvert.SerializeObject(model);
                var response = client.UploadString(apiUrl, "POST", objectName);
                _ContactModel = JsonConvert.DeserializeObject<ContactModel>(response);
            }
            catch
            {
                //Log Errors
            }

            return _ContactModel;
        }

        public bool CreateContact(ContactModel _ContactModel)
        {
            bool retVal = false;
            try
            {
                WebClient client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                client.UseDefaultCredentials = true;
                client.Headers.Add("Content-Type:application/json");
                string apiUrl = BaseURI + "api/contacts/CreateContact";
                client.Headers.Add("Accept:application/json");
                String objectName = JsonConvert.SerializeObject(_ContactModel);
                var response = client.UploadString(apiUrl, "POST", objectName);
                if (response == "true")
                {
                    retVal = true;
                }
            }
            catch
            {
                //Log Errors
            }

            return retVal;
        }

        public bool UpdateContact(ContactModel _ContactModel)
        {
            bool retVal = false;
            try
            {
                WebClient client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                client.UseDefaultCredentials = true;
                client.Headers.Add("Content-Type:application/json");
                string apiUrl = BaseURI + "api/contacts/UpdateContact";
                client.Headers.Add("Accept:application/json");
                String objectName = JsonConvert.SerializeObject(_ContactModel);
                var response = client.UploadString(apiUrl, "POST", objectName);
                if (response == "true")
                {
                    retVal = true;
                }
            }
            catch
            {
                //Log Errors
            }

            return retVal;
        }

        public bool DeleteContact(int _Id)
        {
            bool retVal = false;
            try
            {
                WebClient client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                client.UseDefaultCredentials = true;
                client.Headers.Add("Content-Type:application/json");
                string apiUrl = BaseURI + "api/contacts/DeleteContact";
                client.Headers.Add("Accept:application/json");
                ContactModel model = new ContactModel();
                model.Id = _Id;
                String objectName = JsonConvert.SerializeObject(model);
                var response = client.UploadString(apiUrl, "POST", objectName);
                if (response == "true")
                {
                    retVal = true;
                }
            }
            catch
            {
                //Log Errors
            }

            return retVal;
        }
    }
}