namespace Pretpark.Base;
using Pretpark.Kaart;
using Pretpark.Auth;

public class MainClass{
    public static void Main(String[] args){
        Console.WriteLine("starting Program");
        bool MainLoop = true;
        while(MainLoop){
            Console.WriteLine("1.Kaart\n2.Auth\n0. Exit");
            String userChoice = ConsoleWrapper.ReadLine();
            switch(userChoice){
                case "1":
                    Starter.main(args);
                    break;
                case "2":
                    AuthStart.Start();
                    break;
                default:
                    MainLoop = false;
                    break;
            }

        }

        //Starter.main(args);
        //AuthStart.Start();
    }
}