public class CPoster
{
    public CPoster(string PosterName, string StartDate, string EndDate, string url)
    {
        PosterNavn = PosterName;
        StartDato = StartDate;
        SlutDato = EndDate;
        Url = url;
    }
    public string PosterNavn { get; set; }
    public string StartDato { get; set; }
    public string SlutDato { get; set; }
    public string Url {get; set;}
}