namespace PretparkTests;
using Pretpark.Auth;

public class AuthTest{
    public static IUserContext context = new MockGebruikersContext();
    public static IEmail email = new MockEmailService();


    [Fact]
    public void AssertRegisterMakesNewUser(){
        //Arrange
        context.ClearAllData();
        String Wachtwoord = "1234";
        String Email = "Gary@hello";

        //Act

        //Assert
    }


    [Fact]
    public void AssertTokenExpiration(){
        
    }

    //arrange 
    //act
    //assert
}