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
    public void MOQAssertTokenExpirationForVerification(bool valid){
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

        //Act
        VerificatieToken myTestToken = myTestUser.generateNewToken();
        myTestToken.Token = "12345";

        if(!valid){
            myTestToken.VerloopDatum = DateTime.Now;
        }
        bool result = Gservice.Verifieer(Email, myTestToken.Token);

        //Assert
        Assert.Equal(valid,result);

    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void MOQAssertLoginIsPossible(bool userCanLogin){
        //Arrange
        GebruikerService Gservice = new GebruikerService();
        Gservice.Context = UserContextMoq.Object;
        Gservice.emailService = EmailMoq.Object;

        List<Gebruiker> userList = new List<Gebruiker>();

        

        int userAmt = 5;
        String Email = "Gary@Brannan";
        String Wachtwoord = "TomStinks";

        for(int i=0;i<=userAmt;i++){
            userList.Add(VerifyUsers(new Gebruiker(Email,Wachtwoord+i.ToString())));
        }
        if(userCanLogin){
            userList.Add(VerifyUsers(new Gebruiker(Email, Wachtwoord)));
        }

        UserContextMoq.Setup(userAmt => userAmt.AantalGebruikers()).Returns(userList.Count()); //<- bruh lambdas don't update when a value changes?!
        UserContextMoq.Setup(Context => Context.GetGebruiker(It.IsAny<int>())).Returns<int>(x => userList[x]);

        bool result = Gservice.Login(Email,Wachtwoord);
        
        //Assert
        Assert.Equal(userCanLogin,result);
    }

    public Gebruiker VerifyUsers(Gebruiker user){
        user.isVerified = true;
        return user;
    }




}