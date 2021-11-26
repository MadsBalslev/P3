using System;

namespace server.Entities
{
    public partial class User
    {
        private object getInst()
        {
            if (this.Institution == null)
            {
                return new
                {
                    id = 0,
                    name = "No Institution"
                };
            }
            else
            {
                return new
                {
                    id = this.Institution,
                    name = this.InstitutionNavigation.Name
                };
            }
        }

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
                Institution = getInst()
            };
        }
    }
}