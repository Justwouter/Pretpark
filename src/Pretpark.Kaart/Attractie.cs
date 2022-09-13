namespace Pretpark.Base;
using Pretpark.Kaart;

public class Attractie : KaartItem{
    private int? _minimaleLengte;
    private int _angstLevel;

    //private string _naam;

    public Attractie(Kaart kaart, Coordinaat _locatie) : base(kaart, _locatie){}

    public override char Karakter {get;} = 'A';

    public int? MinimaleLengte{get{return _minimaleLengte;} set{this._minimaleLengte = value;}}
    public int AngstLevel{get{return _angstLevel;} set{this._angstLevel = value;}}
    //public string Naam{get{return _naam;} set{this._naam = value;}}

}