namespace server.Models
{
    public partial class Zone
    {
        public object ToJSON()
        {
            return new
            {
                id = this.Id,
                name = this.Name
            };
        }
    }
}