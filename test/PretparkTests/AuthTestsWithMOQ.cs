namespace PretparkTests;
using Pretpark.Auth;

public class AuthTestWithMOQ{
    private Mock<IUserContext> UserContextMoq = new Mock<IUserContext>();
    private Mock<IUser> UserMoq = new Mock<IUser>();
    private Mock<IEmail> EmailMoq = new Mock<IEmail>();    
    private Mock<IUserService> UserServiceMoq = new Mock<IUserService>();

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void MOQAssertTokenExpirationForVerification(bool expired){
        //Arrange
        GebruikerService Gservice = new GebruikerService();
        Gservice.Context = UserContextMoq.Object;
        Gservice.emailService = EmailMoq.Object;
        

        String Wachtwoord = "TomStinks";
        String Email = "Gary@Brannan";
        UserContextMoq.Setup(user => user.GetGebruiker(0)).Returns(new Gebruiker(Email,Wachtwoord));
        UserContextMoq.Setup(userAmt => userAmt.AantalGebruikers()).Returns(1);

        Gebruiker myTestUser = Gservice.Registreer(Email,Wachtwoord);
        myTestUser.EmailService = EmailMoq.Object;
        DateTime myTestDate;

        //Act
        if(expired){
            myTestDate = DateTime.Now.AddDays(3);
        }
        else{
            myTestDate = DateTime.Now;
        }
        VerificatieToken myTestToken = myTestUser.generateNewToken();
        myTestToken.VerloopDatum = myTestDate;
        myTestToken.Token = "12345";

        bool result = !Gservice.Verifieer(Email, "12345");

        //Assert
        Assert.Equal(expired,result);

    }



}