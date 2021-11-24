namespace server.Entities
{
    public partial class Metadata
    {
        public object ToJSON()
        {
            return new
            {
                timerValue = this.Timer
            };
        }
    }
}