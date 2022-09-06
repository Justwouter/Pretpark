namespace Pretpark;

public class Kaart{
    public readonly int Breedte;
    public readonly int Hoogte = 10;

    public List<KaartItem> _itemsOnChart = new List<KaartItem>();
    public List<Pad> _PathsOnChart = new List<Pad>();

    public Kaart(int Hoogte, int Breedte){
        this.Hoogte = Hoogte;
        this.Breedte = Breedte;
    }

    public void Teken(Tekener t){
        foreach(Pad pad in _PathsOnChart){
            t.Teken(pad);
        }
        foreach(KaartItem item in _itemsOnChart){
            t.Teken(item);
        }
    }

    public void VoegItemToe(KaartItem item){
        _itemsOnChart.Add(item);
    }

    public void VoegPadToe(Pad pad){
        _PathsOnChart.Add(pad);
    }


}



public abstract class KaartItem : Tekenbaar{
    private Coordinaat _locatie;
    public Coordinaat Locatie {get { return _locatie;} set {
        if(value.X >= kaart.Breedte && value.Y >= kaart.Hoogte){
            _locatie = value;
        }}}
    private Kaart kaart;

    public KaartItem(Kaart kaart, Coordinaat _locatie){
        this.kaart = kaart;
        this._locatie = _locatie;
        kaart.VoegItemToe(this);
    }
    
    public void TekenConsole(ConsoleTekener t){
        t.SchrijfOp(this._locatie, Karakter.ToString());
    }
    public abstract char Karakter{get;}
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

    public static Coordinaat operator-(Coordinaat van, Coordinaat naar){
        return new Coordinaat((van.X-naar.X), (van.Y-naar.Y));
    }



    
}