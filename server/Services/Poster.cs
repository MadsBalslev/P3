namespace server.Models
{
    public partial class Poster
    {
        public object ToJSON()
        {
            return new
            {
                posterId = this.Id,
                name = this.Name,
                startDate = this.StartDate,
                endDate = this.EndDate,
                image = this.ImageUrl,
                createdBy = new {
                    id = this.CreatedBy,
                    name = $"{this.CreatedByNavigation.FirstName} {this.CreatedByNavigation.LastName}"
                },
                institution = new {
                    id = this.CreatedByNavigation.InstitutionNavigation.Id,
                    name = this.CreatedByNavigation.InstitutionNavigation.Name,
                }
            };
        }
    }
}