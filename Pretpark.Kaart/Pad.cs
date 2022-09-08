namespace Pretpark.Kaart;
public class Pad : Tekenbaar{
    public Coordinaat van;
    public Coordinaat naar;

    private float? lengteBerekend;
    private List<Coordinaat> CachedItems = new List<Coordinaat>{new Coordinaat(-10,-11),new Coordinaat(-10,-11)};

    public Float Lengte(){
        if(!CachedItems[0].Equals(van) | !CachedItems[1].Equals(naar)){
            var DiffrenceX = Math.Abs(van.X - naar.X); //Side A
            var DiffrenceY = Math.Abs(van.Y - naar.Y); //Side B
            float DiffrenceTotal = (float) Math.Sqrt(DiffrenceX^2 * DiffrenceY^2); //A^2 * B^2 = C^2
            lengteBerekend = DiffrenceTotal;
            CachedItems[0] = this.van;
            CachedItems[1] = this.naar;
            return new Float(DiffrenceTotal);
        }
        return new Float(lengteBerekend);
    }

    public void TekenConsole(ConsoleTekener t){
        Coordinaat verschil = naar - van;
        for (int i = 0; i < 100; i++){
            t.SchrijfOp(van + new Coordinaat((int)(verschil.X * ((float)i / 100)), (int)(verschil.Y * ((float)i / 100))), "#");
        }
        t.SchrijfOp(FindTheMiddle(), Lengte().metSuffixen());
    }

    private Coordinaat FindTheMiddle(){
        var DiffrenceX = Math.Abs(van.X - naar.X); 
        var DiffrenceY = Math.Abs(van.Y - naar.Y);
        return new Coordinaat(DiffrenceX/2, DiffrenceY/2);
    }

    

}

public class Float{
    private float? DigitNum{get;}

    public Float(float? DigitNum){
        this.DigitNum = DigitNum;
    }
    public string metSuffixen(){
        int count = 0;
        List<String> Symbols = new List<string>{"","K","M","B","T"};
        //1 -> 999 1k -> 999k 1m -> 999m
        int i = 1;
        while (true){
            if(this.DigitNum <= i*999){
                String Numbers = (((float)DigitNum)/i*10).ToString("n1");
                return Numbers+Symbols[count];
            }
            
            i *=1000;
            count++;
        }
        

    }
}