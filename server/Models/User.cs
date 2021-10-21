namespace server.Models
{
    public class User
    {   
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public int PhoneNumber {get; set;}
        public UserRole Role {get; set;}
        public Institution Institution {get; set;}

        public User(string fName, string lName, string email, int phone, UserRole role, Institution inst)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.Email = email;
            this.PhoneNumber = phone;
            this.Role = role;
            this.Institution = inst;
        }
    }
}