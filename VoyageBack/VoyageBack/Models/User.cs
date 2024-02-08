using Microsoft.AspNetCore.Identity;

namespace VoyageBack.Models
{
    public class User : IdentityUser
    {


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public string Age { get; set; }
        public string Civility { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
       
        public string FileName { get; set; }
        public string LogoFilePath { get; set; }
        public ICollection<Travel> Travels { get; set; }
    }
}
