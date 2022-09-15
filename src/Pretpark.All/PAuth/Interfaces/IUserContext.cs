namespace Pretpark.Auth;

public interface IUserContext{

   
    public int AantalGebruikers();

    public Gebruiker GetGebruiker(int i);

    public void NieuweGebruiker(string Wachtwoord, string Email);

    public void ClearAllData();

    
}