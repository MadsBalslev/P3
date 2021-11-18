namespace server.Entities
{
    public partial class Institution
    {
        public object ToJSON()
        {
            return new
            {
                institutionId = this.Id,
                name = this.Name,
                admin = new
                {
                    id = this.AdminNavigation.Id,
                    // name = $"{this.AdminNavigation.FirstName} {this.AdminNavigation.LastName}"
                },
            };
        }
    }
}