namespace VoyageBack.Dtos
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Civility { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Age { get; set; }
        public DateTime DateOfBirthday { get; set; }
       
        public string Email { get; set; }
        public string Password { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string LogoFilePath { get; set; }
        public string FileName { get; set; }
        public IFormFile File { get; set; }
    }
}
