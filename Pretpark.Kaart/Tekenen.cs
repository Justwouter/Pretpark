namespace Pretpark;
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
}