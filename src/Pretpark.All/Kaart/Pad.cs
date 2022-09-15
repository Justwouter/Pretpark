namespace Pretpark.Kaart;

//Might be usefull for debug: give Paths names.
public class Pad : Tekenbaar{
    public Coordinaat van;
    public Coordinaat naar;

    private float lengteBerekend;
    private List<Coordinaat> CachedItems = new List<Coordinaat>{};

    public float Lengte(){
        //Here because sometimes this method gets called before values are Cached and it messes with AddDebug.
        //Also ensured they can never be equal to van/naar.
        if(CachedItems.Count() == 0){
            CachedItems = new List<Coordinaat>{new Coordinaat(this.van.X-1,this.naar.Y-2), new Coordinaat(this.van.X-1,this.naar.Y-2)};
        }

        //Cached items shouldn't be calculated. Don't know if it's faster tho.
        if(!CachedItems[0].Equals(van) || !CachedItems[1].Equals(naar)){
            var DiffrenceX = Math.Abs(van.X - naar.X); //Side A
            var DiffrenceY = Math.Abs(van.Y - naar.Y); //Side B
            float DiffrenceTotal = (float) Math.Sqrt(DiffrenceX^2 * DiffrenceY^2); //A^2 * B^2 = C^2
            lengteBerekend = DiffrenceTotal;
            CachedItems[0] = this.van;
            CachedItems[1] = this.naar;
            return (float)(DiffrenceTotal);
        }
        return (float)(lengteBerekend);
    }

    //Draws the path object to the field of the assigned chart
    public void TekenConsole(ConsoleTekener t){
        Coordinaat verschil = naar - van;
        for (int i = 0; i < 100; i++){
            t.SchrijfOp(van + new Coordinaat((int)(verschil.X * ((float)i / 100)), (int)(verschil.Y * ((float)i / 100))), "#");
        }
        
        t.SchrijfOp(FindTheMiddle(), (1000 * Lengte()).metSuffixen());

        //Custom Debug cords
        t.AddDebug(new Coordinaat((FindTheMiddle().X),FindTheMiddle().Y), CachedItems);
        
    }


    //Finds the point in between two Cords.
    private Coordinaat FindTheMiddle(){
        var DiffrenceX = (int)Math.Round(van.X + (naar.X - van.X) * 0.5); 
        var DiffrenceY = (int)Math.Round(van.Y + (naar.Y - van.Y) * 0.5);
        return new Coordinaat(DiffrenceX, DiffrenceY);
    }

    

}


//Old method w/suffixes higher than k
// public class Float {
//     private float? DigitNum{get;}

//     public Float(float? DigitNum){
//         this.DigitNum = DigitNum;
//     }
//     public string metSuffixen(){
//         int count = 0;
//         List<String> Symbols = new List<string>{"","K","M","B","T"};
//         //1 -> 999 1k -> 999k 1m -> 999m
//         int i = 1;
//         while (true){
//             if(this.DigitNum <= i*999){
//                 String Numbers = (((float)DigitNum)/i*10).ToString("n1");
//                 return Numbers+Symbols[count];
//             }
            
//             i *=1000;
//             count++;
//         }
        

//     }
// }


//Provides an extention method to the float class to convert anything above 1k into the shortend {number:letter} format.
public static class FloatExtention{

    public static string metSuffixen(this float number){
        if(number >= 1000){
            float divider = number/1000;
            String LetterFormat = String.Format("{0:0.0}K",divider);
            return LetterFormat;
        }
        else{
            String LetterFormat = String.Format("{0:0.0}",number);
            return LetterFormat;
        }

    }
}