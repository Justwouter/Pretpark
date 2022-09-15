namespace Pretpark.Auth;

public class AuthStart{
    public static void Start(){
        Console.WriteLine("Starting auth module");
        GebruikerService GS = new GebruikerService();
        
        bool exit = false;
        while(!exit){
            //Console.WriteLine("cls");
            Console.WriteLine("1. inloggen\n2. Registreren\n0. Exit");
        
            String userChoice = ConsoleWrapper.ReadLine();
            if( userChoice == ("1")){
                Console.WriteLine("\n");
                GS.Login(AskUsername(), AskPass());
                ConsoleWrapper.ReadLine();

            }
            else if(userChoice == ("2")){
                Console.WriteLine("\n");
                GS.Registreer(AskUsername(), AskPass());
                ConsoleWrapper.ReadLine();
            }
            else{
                exit = true;
                Console.WriteLine("Exiting now");
                Thread.Sleep(2000);
            }


        }
    }

    private static string AskUsername(){
        Console.WriteLine("Please enter your Email: ");
        return ConsoleWrapper.ReadLine();
    }
    private static string AskPass(){
            Console.WriteLine("Please enter your Password: ");
            return ConsoleWrapper.ReadLine();
    }

    public static void WriteDubug(String text){
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(text);
        Console.ResetColor();
    }


}