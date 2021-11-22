using System;

namespace server.Entities
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
                role = this.Role,
                hashedPswd = this.Password,
                Institution = new {
                    id = this.InstitutionNavigation.Id,
                    name = this.InstitutionNavigation.Name
                }
            };
        }
    }
}