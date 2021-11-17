namespace server.Models
{
    public partial class Institution
    {
        public object ToJSON()
        {
            return new
            {
                id = this.Id,
                name = this.Name,
                admin = new
                {
                    id = this.AdminNavigation.Id,
                    name = $"{this.AdminNavigation.FirstName} {this.AdminNavigation.LastName}"
                },
            };
        }
    }
}