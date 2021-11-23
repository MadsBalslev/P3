namespace server.Entities
{
    public partial class Schedule
    {
        public object ToJSON()
        {
            return new
            {
                Id = this.Id,
                PosterId = this.PosterId,
                Name = this.Name,
                StartDate = this.StartDate,
                EndDate = this.EndDate,
                Daily = this.Daily,
                Weekday = this.Weekday,
            };
        }
    }
}