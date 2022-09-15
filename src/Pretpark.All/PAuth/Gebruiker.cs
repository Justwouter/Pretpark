namespace Pretpark.Auth;

public class Gebruiker{
    public VerificatieToken? verificatie;

    public bool isVerified = false;
    public string Wachtwoord {get; set;}
    public string Email {get;set;}

    public Gebruiker(String email, String Wachtwoord){
        this.Email = email;
        this.Wachtwoord = Wachtwoord;
        String RandomToken = new Random().Next().ToString();
        this.verificatie = new VerificatieToken(RandomToken);
        new EmailService().Email("Please verify your account with this token: "+ RandomToken, email);
        
    }

    public string getToken(){
        if(verificatie == null){
            return "";
        }
        return verificatie.Token;
    }

    public bool Geverifieerd(){
        return isVerified;
    }
}