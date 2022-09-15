namespace Pretpark.Kaart;
public interface Tekenbaar{
    public void TekenConsole(ConsoleTekener t){}
}

public interface Tekener{
    public void Teken(Tekenbaar t){}
}

public class ConsoleTekener : Tekener{
    public void Teken(Tekenbaar t){
        t.TekenConsole(this);
    }
    
    public void SchrijfOp(Coordinaat Positie, string Text) {
        if (Positie.X < 0 || Positie.Y < 0){
            throw new Exception("Kan niet tekenen in het negatieve!");
        }
        Console.SetCursorPosition(Positie.X, Positie.Y);
        Console.WriteLine(Text);
    }

    // public void AddDebug<T>(Coordinaat Positie, List<T> data){
    //     Console.SetCursorPosition(Positie.X, Positie.Y);
    //     data.ForEach(T => Console.WriteLine(T));
    // } Old Version with generic params

    public void AddDebug(Coordinaat Positie, List<Coordinaat> data){
        //Exploring lambdas
        //Console.SetCursorPosition(Positie.X, Positie.Y);
        //Func<Coordinaat,Coordinaat> addToXAxis = x => {return new Coordinaat(x.X+5,x.Y);};
        var BaseOfset = 16;
        Console.ForegroundColor = ConsoleColor.Red;
        data.ForEach(T =>{
            if(T.X > 0 && T.Y>0){
            Console.SetCursorPosition(Positie.X+BaseOfset, Positie.Y);
            Console.WriteLine(T.X);
            Console.SetCursorPosition(Positie.X+(BaseOfset+2), Positie.Y);
            Console.WriteLine(",");
            Console.SetCursorPosition(Positie.X+(BaseOfset+3), Positie.Y);
            Console.WriteLine(T.Y);
            }
        });
        Console.ResetColor();
        //data.ForEach(T => Console.WriteLine(T.X));
    } 
}