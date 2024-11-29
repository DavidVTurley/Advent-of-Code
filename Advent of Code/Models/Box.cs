namespace Advent_of_Code.Models;
internal class Box(double x, double y, double z) : I3dShape
{
    public double X { get; private set; } = x;
    public double Y { get; private set; } = y;
    public double Z { get; private set; } = z;

    public Rectangle XY => new(X, Y);
    public Rectangle YZ => new(Y, Z);
    public Rectangle XZ => new(X, Z);

    public double GetVolume() => X * Y * Z;
    public double GetSurfaceArea() => (2 * XY.GetSurfaceArea()) + (2 * XZ.GetSurfaceArea()) + (2 * YZ.GetSurfaceArea());
    public double GetCircumfrence(Rectangle rect) => rect.GetCircumfrence();
}
