namespace Pretpark.Auth;

public class VerificatieToken{
    public String Token {get;set;}
    public DateTime VerloopDatum{get;set;}

    public VerificatieToken(String Token){
        this.Token = Token;
        this.VerloopDatum = DateTime.Today.AddDays(3);
    }
    public VerificatieToken(){
        this.Token = "";
        this.VerloopDatum = DateTime.Now;
    }

}