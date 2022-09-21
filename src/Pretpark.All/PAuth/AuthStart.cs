namespace Pretpark.Auth;
using System.Diagnostics;
public class AuthStart{
    public static void Start(){
        Console.WriteLine("Starting auth module");
        GebruikerService GS = new GebruikerService();
        
        bool exit = false;
        while(!exit){
            //Console.WriteLine("cls");
            Console.WriteLine("1. inloggen\n2. Registreren\n3. Verifieeren\n0. Exit");
        
            String userChoice = ConsoleWrapper.ReadLine();
            if( userChoice == ("1")){
                Console.WriteLine("\n");
                GS.Login(AskUsername(), AskPass());
                ConsoleWrapper.ReadLine();
                continue;

            }
            else if(userChoice == ("2")){
                Console.WriteLine("\n");
                GS.Registreer(AskUsername(), AskPass());
                ConsoleWrapper.ReadLine();
                continue;
            }
            else if(userChoice == ("3")){
                Console.WriteLine("\n");
                String email = AskUsername();
                if(!GS.Verifieer(email, AskToken())){
                    Console.WriteLine("User with email "+email+" couldn't be verified. Is the token expired?");
                }
                
                ConsoleWrapper.ReadLine();
                continue;

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
    private static string AskToken(){
        Console.WriteLine("Please enter your Token: ");
        return ConsoleWrapper.ReadLine();
        
    }

    public static void WriteDubug(String text){
        Console.ForegroundColor = ConsoleColor.Red;
        //Console.WriteLine(text);
        Console.ResetColor();
        System.Diagnostics.Debug.Print(text);
        
        
    }


}