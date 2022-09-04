
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
    k.TekenConsole(new ConsoleTekener());
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
    public void Teken(Tekenbaar t){

    }
}

class Kaart{
    public int Breedte;
    public int Hoogte = 10;

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



class KaartItem : Tekenbaar{
    private  Coordinaat _locatie {get { return _locatie;} set {if(value.x)}}

    public KaartItem(Kaart kaart, Coordinaat _locatie){


    }
}

struct Coordinaat{
    public readonly int x;
    public readonly int y;

    public Coordinaat(int x, int y){
        this.x = x;
        this.y = y;
    }

    public static Coordinaat operator+(Coordinaat c1, Coordinaat c2) {
        return new Coordinaat((c1.x+c2.x), (c1.y+c2.y));
    }

    public static bool isInCords(Coordinaat c1, Coordinaat c2){
        if(c2.x < c1.x)
    }
}

class Pad : Tekenbaar{
    public Coordinaat van;
    public Coordinaat naar;

    private float? lengteBerekend;

    public float Lengte(){

    }

    public float Afstand(Coordinaat c){

    }

    public void TekenConsole(ConsoleTekener t){

    }
}