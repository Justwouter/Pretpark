namespace Pretpark.Auth;

public interface IUserService{
    public static IUserContext Context = new GebruikerContext();

    public static IEmail emailService = new EmailService();


    public Gebruiker Registreer(string email, string Wachtwoord);
    public bool Login(string email, string Wachtwoord);

    public bool Verifieer(String email, string Token);


}