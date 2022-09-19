namespace Pretpark.Auth;

public class Gebruiker : IUser{
    public VerificatieToken? verificatie;

    public bool isVerified = false;
    public string Wachtwoord {get; set;}
    public string Email {get;set;}

    public Gebruiker(String email, String Wachtwoord){
        this.Email = email;
        this.Wachtwoord = Wachtwoord;
        this.generateNewToken();
    }

    public string getToken(){
        if(verificatie == null || verificatie.VerloopDatum < DateTime.Now){
            return "";
        }
        return verificatie.Token;
    }

    public bool Geverifieerd(){
        return isVerified;
    }

    public void generateNewToken(){
        String RandomToken = new Random().Next().ToString();
        this.verificatie = new VerificatieToken(RandomToken);
        GebruikerService.emailService.Email("Please verify your account with this token: "+ RandomToken, this.Email);
    }
}