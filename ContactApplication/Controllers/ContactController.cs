using ContactApi.DataServices;
using ContactUtilities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {


        [HttpGet ("Get")]
        public IEnumerable<Contact> Index()
        {
            try
            {
                DataService objCrd = new DataService();
                IEnumerable<Contact> modelCust = objCrd.GetContactList();
                return modelCust;
            }
            catch
            {
                throw;
            }
        }


        [HttpGet("Details/{id}")]
        public Contact GetContact(int id)
        {
            try
            {
                DataService objCrd = new DataService();
                Contact modelCust = objCrd.GetContactDetails(id);
                return modelCust;
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        [Route("[action]")]
        public int InsertContact([FromBody] Contact objContact)
        {
            try
            {
                DataService objCrd = new DataService();
                int ContactId = objCrd.InsertContact(objContact);
                return ContactId;
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        [Route("[action]")]
        public int UpdateContact(Contact objContact)
        {
            try
            {
                DataService objCrd = new DataService();
                int ContactId = objCrd.UpdateContact(objContact);
                return ContactId;
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("DeleteContact/{id}")]
        public int DeleteContact(long? id)
        {
            try
            {
                DataService objCrd = new DataService();
                int ContactId = objCrd.DeleteContact(id);
                return ContactId;
            }
            catch
            {
                throw;
            }
        }
    }
}
