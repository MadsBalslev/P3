namespace server.Entities
{
    public partial class Poster
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
                    name = this.InstitutionNavigation.Name,
                };
            }
        }

        public object ToJSON()
        {
            return new
            {
                Id = this.Id,
                name = this.Name,
                image = this.ImageUrl,
                institution = getInst()
            };
        }
    }
}