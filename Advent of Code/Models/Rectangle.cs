namespace Advent_of_Code.Models;
internal class Rectangle : I2dShape
{
    public double X { get; private set; }
    public double Y { get; private set; }

    public Rectangle(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double GetSurfaceArea() => X * Y;
    public double GetCircumfrence() => (X*2) + (Y*2);
}
