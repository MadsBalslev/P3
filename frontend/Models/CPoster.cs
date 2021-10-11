public class CPoster
{
    public CPoster(string PosterName, string StartDate, string EndDate)
    {
        PosterNavn = PosterName;
        StartDato = StartDate;
        SlutDato = EndDate;
    }
    public string PosterNavn { get; set; }
    public string StartDato { get; set; }
    public string SlutDato { get; set; }
}