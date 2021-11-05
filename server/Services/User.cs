namespace server.Models
{
    public partial class User
    {
        public object ToJSON()
        {
            return new
            {
                id = this.Id,
                firstName = this.FirstName,
                lastName = this.LastName,
                email = this.Email,
                phoneNumber = this.PhoneNumber,
                institution = this.Institution,
                role = this.Role,
            };
        }
    }
}