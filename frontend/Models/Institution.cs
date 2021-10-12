public class Institution
{
    public Institution(string institutionNavn, string admin)
    {
        Navn = institutionNavn;
        Admin = admin;
    }

    public string Navn { get; set; }
    public string Admin { get; set; }


}