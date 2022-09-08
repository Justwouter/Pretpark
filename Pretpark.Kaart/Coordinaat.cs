namespace Pretpark.Kaart;

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