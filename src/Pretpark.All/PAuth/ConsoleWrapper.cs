namespace Pretpark.Auth;

public class ConsoleWrapper{

    public static string ReadLine(){
        var input = Console.ReadLine();
        if(input == null){
            return "";
        }
        return input;
    }
}