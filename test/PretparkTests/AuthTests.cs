namespace PretparkTests;
using Pretpark.Auth;

public class AuthTest{
    public static MockGebruikersContext context = new MockGebruikersContext();
    public static IEmail email = new MockEmailService();


    [Fact]
    public void AssertRegisterMakesNewUser(){
        //Arrange
        context.ClearAllData();
        String Wachtwoord = "1234";
        String Email = "Gary@hello";

        //Act
        int currentUserAmt = context.AantalGebruikers();
        context.NieuweGebruiker(Wachtwoord,Email);
        int newUserAmt = context.AantalGebruikers();
        //Assert
        Assert.Equal(currentUserAmt+1,newUserAmt);
    }

    [Fact]
    public void AssertRegisterRefusesNewUserIfEmailInvalid(){
        //Arrange
        context.ClearAllData();
        String Wachtwoord = "1234";
        String Email = "Gary.hello";

        //Act
        int currentUserAmt = context.AantalGebruikers();
        context.NieuweGebruiker(Wachtwoord,Email);
        int newUserAmt = context.AantalGebruikers();
        //Assert
        Assert.Equal(currentUserAmt,newUserAmt);
    }


    //Shorter version of the above tests
    [Theory]
    [InlineData(1)]
    [InlineData(0)]
    public void AssertRegisterCombinedNewUserValidity(int userAmt){
        //Arrange
        context.ClearAllData();

        String Wachtwoord = "1234";
        String Email = "Gary.hello";
        if(userAmt > 0){
            Email = "Gary@hello";
        }

        //Act
        context.NieuweGebruiker(Wachtwoord,Email);
        int newUserAmt = context.AantalGebruikers();
        //Assert
        Assert.Equal(userAmt,newUserAmt);

    }

    [Fact]
    public void AssertTokenExpirationForVerification(){
        //Arrange
        context.ClearAllData();
        GebruikerService GService = new GebruikerService();
        GService.Context = context;
        GService.emailService = email;

        string token = "12345";
        String Wachtwoord = "1234";
        String Email = "Gary@hello";

        VerificatieToken myTestToken= new VerificatieToken(token);

        context.NieuweGebruiker(Wachtwoord, Email);
        Gebruiker myTestUser = context.GetGebruiker(context.AantalGebruikers()-1);

        DateTime TestTimeFiveSeconds = DateTime.Now;
        
        //Act
        myTestToken.VerloopDatum = TestTimeFiveSeconds;
        myTestUser.verificatie = myTestToken;

        //Assert
        Thread.Sleep(3000);
        Assert.False(GService.Verifieer(Email, token));
    }

    //arrange 
    //act
    //assert
}