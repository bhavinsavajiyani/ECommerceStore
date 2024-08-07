using System.ComponentModel.DataAnnotations;

namespace EComm_Store_Core.Entities.Identity
{
    public class Address
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        [Required]
        public string AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}