namespace server.Entities
{
    public partial class Metadatum
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