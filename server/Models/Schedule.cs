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
                    image = this.Poster.ImageUrl,
                    name = this.Poster.Name,
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
                id = this.Poster.Id,
                image = this.Poster.ImageUrl,
            };
        }
    }
}