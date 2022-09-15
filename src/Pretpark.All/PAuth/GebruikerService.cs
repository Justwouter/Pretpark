namespace Pretpark.Auth;

public class GebruikerService{
    public static GebruikerContext Context = new GebruikerContext();
    public static EmailService emailService = new EmailService();
    public Gebruiker Registreer(string email, string Wachtwoord){
        //Gebruiker newUser = new Gebruiker(email,Wachtwoord);
        Context.NieuweGebruiker(Wachtwoord,email);
        Gebruiker newUser = Context.GetGebruiker(Context.AantalGebruikers()-1);
        Verifieer(email, newUser.getToken());
        return newUser;   
    }

    public bool Login(string email, string Wachtwoord){
        for(int i = 0; i < Context.AantalGebruikers();i++){
            Gebruiker target = Context.GetGebruiker(i);
            if(target.Email == email && target.Wachtwoord == Wachtwoord && target.Geverifieerd()){
                AuthStart.WriteDubug("User: "+email+" Has been logged in");
                return true;
            }
        }
        return false;
    }

    public bool Verifieer(String email, string Token){
        for(int i = 0; i < Context.AantalGebruikers();i++){
            Gebruiker target = Context.GetGebruiker(i);
            if(target.Email == email && Token == target.getToken()){
                target.verificatie = null;
                target.isVerified = true;
                AuthStart.WriteDubug("Email: "+email+" with token: "+Token+" is verified");
                return true;
            }
        }
        return false;
    }

}