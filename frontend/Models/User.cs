public class User
{
    public User(string fornavn, string efternavn, string email, string institution, string rolle)
    {
        Fornavn = fornavn;
        Efternavn = efternavn;
        Email = email;
        Institution = institution;
        Rolle = rolle;
    }
    public string Fornavn { get; set; }
    public string Efternavn { get; set; }
    public string Email { get; set; }
    public string Institution { get; set; }
    public string Rolle { get; set; }
}