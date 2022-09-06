namespace Pretpark;
public class Starter{

    public static void Main(string[] args){
        Kaart k = new Kaart(30, 30);
        Pad p1 = new Pad();
        p1.van = new Coordinaat(2, 5);
        p1.van = new Coordinaat(12, 30);
        k.VoegPadToe(p1);
        Pad p2 = new Pad();
        p2.van = new Coordinaat(26, 4);
        p2.naar = new Coordinaat(10, 5);
        k.VoegPadToe(p2);
        k.VoegItemToe(new Attractie(k, new Coordinaat(15, 15)));
        k.VoegItemToe(new Attractie(k, new Coordinaat(20, 15)));
        k.VoegItemToe(new Attractie(k, new Coordinaat(5, 18)));
        k.Teken(new ConsoleTekener());
        new ConsoleTekener().SchrijfOp(new Coordinaat(0, k.Hoogte + 1), "Deze kaart is schaal 1:1000");
        System.Console.Read();
    }
}

interface Tekenbaar{
    public void TekenConsole(ConsoleTekener t){

    }
}
interface Tekener{
    public void Teken(Tekenbaar t){}
}

class ConsoleTekener : Tekener{
    public void Teken(Tekenbaar t){}

    public void SchrijfOp(Coordinaat Positie, string Text) {
        if (Positie.X < 0 || Positie.Y < 0){
            throw new Exception("Kan niet tekenen in het negatieve!");
        }
        Console.SetCursorPosition(Positie.X, Positie.Y);
        Console.WriteLine(Text);
    }
}

class Kaart{
    public readonly int Breedte;
    public readonly int Hoogte = 10;

    public Kaart(int Hoogte, int Breedte){
        this.Hoogte = Hoogte;
        this.Breedte = Breedte;
    }

    public void Teken(Tekener t){

    }

    public void VoegItemToe(KaartItem item){

    }

    public void VoegPadToe(Pad pad){

    }


}



abstract class KaartItem : Tekenbaar{
    private  Coordinaat _locatie {get { return _locatie;} set {
        if(value.X >= kaart.Breedte && value.Y >= kaart.Hoogte){
            this._locatie = _locatie;
        }}}
    private Kaart kaart;

    public KaartItem(Kaart kaart, Coordinaat _locatie){
        this.kaart = kaart;
        this._locatie = _locatie;
    }
    
    public void TekenConsole(ConsoleTekener t){

    }
}

struct Coordinaat{
    public readonly int X;
    public readonly int Y;

    public Coordinaat(int x, int y){
        this.X = x;
        this.Y = y;
    }

    public static Coordinaat operator+(Coordinaat c1, Coordinaat c2) {
        return new Coordinaat((c1.X+c2.X), (c1.Y+c2.Y));
    }

    
}

class Pad : Tekenbaar{
    public Coordinaat van;
    public Coordinaat naar;

    private float? lengteBerekend;

    public float Lengte(){
        if(lengteBerekend == 0 | lengteBerekend == null){
            int DiffrenceX = Math.Abs(van.X - naar.X); //Side A
            int DiffrenceY = Math.Abs(van.Y - naar.Y); //Side B
            float DiffrenceTotal = (float) Math.Sqrt(DiffrenceX^2 * DiffrenceY^2); //A^2 * B^2 = C^2
            lengteBerekend = DiffrenceTotal;
            return DiffrenceTotal;
        }
        return (float)lengteBerekend;

    }

    public float Afstand(Coordinaat c){

    }

    public void TekenConsole(ConsoleTekener t){

    }
}