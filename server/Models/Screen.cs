namespace server.Entities
{
    public partial class Screen
    {
        public object ToJSON()
        {
            return new
            {
                id = this.Id,
                name = this.Name,
                zone = new
                {
                    id = this.Zone,
                    name = this.ZoneNavigation.Name
                }
            };
        }
    }
}