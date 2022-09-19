namespace Pretpark.Auth;

public class GebruikerContext : IUserContext{

    private List<Gebruiker> currentUsers = new List<Gebruiker>();
    public int AantalGebruikers(){
        return currentUsers.Count();
    }

    public Gebruiker GetGebruiker(int i){
        return currentUsers[i];
    }

    public void NieuweGebruiker(string Wachtwoord, string Email){
        if(Email.Contains("@")){
            currentUsers.Add(new Gebruiker(Email, Wachtwoord));
        }
    }

    public void ClearAllData(){}

}