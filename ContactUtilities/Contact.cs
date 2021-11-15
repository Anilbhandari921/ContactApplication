using System.ComponentModel;

namespace ContactUtilities
{
    public class Contact
    {
        public Contact()
        {
            ContactId = 0;
            ContactName = string.Empty;
            ContactEmail = string.Empty;
            ContactCity = string.Empty;
            ContactPhone = string.Empty;
        }
        public Contact(int id, string Name, string Email, string City, string Phone)
        {
            ContactId = (id == 0 ? 55 : id);
            ContactName = Name;
            ContactEmail = Email;
            ContactCity = City;
            ContactPhone = Phone;
        }

        public int ContactId { get; set; }
        [DisplayName("Contact Name")]
        public string ContactName { get; set; }
        [DisplayName("Contact Email")]
        public string ContactEmail { get; set; }
        [DisplayName("Contact City")]
        public string ContactCity { get; set; }
        [DisplayName("Contact Phone")]
        public string ContactPhone { get; set; }

    }
}
