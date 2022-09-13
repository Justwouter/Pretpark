namespace Pretpark.Kaart;

public class Kaart{
    public readonly int Breedte;
    public readonly int Hoogte;

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