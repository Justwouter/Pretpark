namespace Pretpark.Auth;

public interface IUser{
    public string getToken();
    public bool Geverifieerd();
    public VerificatieToken generateNewToken();

}