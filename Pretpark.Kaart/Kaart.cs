namespace Pretpark;

public class Kaart{
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



public abstract class KaartItem : Tekenbaar{
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

public struct Coordinaat{
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
