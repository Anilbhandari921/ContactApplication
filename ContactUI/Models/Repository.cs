using ContactUI.Services;
using ContactUtilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactUI.Models
{
    public static class Repository
    {

        public static async Task<IEnumerable<Contact>> GetAllContacts()
        {
            string url = "Contact/Get";
            return await APIHelper.HttpGet<IEnumerable<Contact>>(url);
        }
        public static async Task<Contact> GetContactDetails(long? id)
        {
            string url = "Contact/Details/"+id.ToString();
            return await APIHelper.HttpGet<Contact>(url);
        }
        public static async Task<int> Create(Contact contact)
        {
            string url = "Contact/InsertContact";
            return await APIHelper.HttpPost<int>(url,contact);
        }
        public static async Task<int> Update(Contact contact)
        {
            string url = "Contact/UpdateContact";
            return await APIHelper.HttpPost<int>(url, contact);
        }
        public static int DeleteContact(long? id)
        {
            string url = "Contact/DeleteContact/"+id.ToString(); 
            return APIHelper.HttpDelete(url);
        }
    }
}
