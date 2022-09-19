namespace PretparkTests;
using Pretpark.Auth;

public class AuthTestWithMOQ{
    private Mock<IUserContext> UserContextMoq = new Mock<IUserContext>();
    private Mock<IUser> UserMoq = new Mock<IUser>();
    

    [Fact]
    public void MOQAssertRegisterMakesNewUser(){
        UserMoq.Setup(us => us.getToken()).Returns("12345");
        // userList = new List<Gebruiker>(){
        //     UserMoq.Object
        // };

        UserContextMoq.Setup(UCM => UCM.AantalGebruikers()).Returns(2);

        
        

    }

    
    // [Fact]
    // public void AssertRegisterMakesNewUser(){
    //     //Arrange
    //     context.ClearAllData();
    //     String Wachtwoord = "1234";
    //     String Email = "Gary@hello";

    //     //Act
    //     int currentUserAmt = context.AantalGebruikers();
    //     context.NieuweGebruiker(Wachtwoord,Email);
    //     int newUserAmt = context.AantalGebruikers();
    //     //Assert
    //     Assert.Equal(1,newUserAmt);
    // }




}