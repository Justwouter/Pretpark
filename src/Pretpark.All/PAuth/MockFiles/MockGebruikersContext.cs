namespace Pretpark.Auth;

public class MockGebruikersContext : IUserContext{

    public List<Gebruiker> allUsers = new List<Gebruiker>();    
    public int AantalGebruikers(){
        return allUsers.Count;
    }
        
    

    public Gebruiker GetGebruiker(int i){
        return allUsers[i];
    }

    public void NieuweGebruiker(string Wachtwoord, string Email)
    {
        allUsers.Add(new Gebruiker(Email, Wachtwoord));
    }

    public void ClearAllData(){
        this.allUsers.Clear();
    }
}