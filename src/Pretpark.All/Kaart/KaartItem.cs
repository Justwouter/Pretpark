namespace Pretpark.Kaart;

public abstract class KaartItem : Tekenbaar{
    private Coordinaat _locatie;
    private Coordinaat Locatie {get { return _locatie;} set {
        if((value.X >= 0) && (value.X <= kaart.Breedte) && (value.Y >= 0) && (value.Y <= kaart.Hoogte)){
            _locatie = value;
        }}}
    private Kaart kaart;

    public KaartItem(Kaart kaart, Coordinaat _locatie){
        this.kaart = kaart;
        this.Locatie = _locatie;
        //kaart.VoegItemToe(this);
    }
    
    public void TekenConsole(ConsoleTekener t){
        t.SchrijfOp(this._locatie, Karakter.ToString());
    }
    public abstract char Karakter{get;}
}