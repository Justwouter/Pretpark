namespace Pretpark.Auth;

public class MockEmailService : IEmail{

    String? Message;
    String? Adress;
    public bool Email(string text, string naarAdres){
        this.Message = text;
        this.Adress = naarAdres;
        if(naarAdres.Contains("@")){
            Console.WriteLine("To "+naarAdres + ": " + text);
            return true;
        }
        return false;
    }
}