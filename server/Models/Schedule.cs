namespace server.Entities
{
    public partial class Schedule
    {
        public object ToJSON()
        {
            return new
            {
                Id = this.Id,
                Poster = new
                {
                    id = this.Poster.Id,
                    url = this.Poster.ImageUrl,
                },
                Name = this.Name,
                StartDate = this.StartDate,
                EndDate = this.EndDate,
                Zone = new
                {
                    id = this.ZoneNavigation.Id,
                    name = this.ZoneNavigation.Name
                },
            };
        }
        public object PosterToJSON()
        {
            return new
            {
                Id = this.Poster.Id,
                ImageUrl = this.Poster.ImageUrl,
            };
        }
    }
}