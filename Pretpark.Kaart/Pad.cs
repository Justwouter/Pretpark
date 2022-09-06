namespace Pretpark;
public class Pad : Tekenbaar{
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