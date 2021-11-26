namespace server.Entities
{
    public partial class Institution
    {
        public object ToJSON()
        {
            return new
            {
                Id = this.Id,
                name = this.Name,
            };
        }
    }
}