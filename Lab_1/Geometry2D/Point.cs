namespace Geometry2D;

public class Point
{
    public int x { get; set; }
    public int y { get; set; }

    public Point(int X=0, int Y=0)
    {
        const int WIDTH = 1920;
        const int HEIGHT = 1080;

        if (X < 0 || X > WIDTH)
            throw new ArgumentOutOfRangeException($"x должен быть в диапазоне [0, {WIDTH}]");
        if (Y < 0 || Y > HEIGHT)
            throw new ArgumentOutOfRangeException($"y должен быть в диапазоне [0, {HEIGHT}]");
        this.x = X;
        this.y = Y;
    }
        
    public static bool operator ==(Point pointA, Point pointB)
    {
        return pointA.x == pointB.x & pointA.y == pointB.y;
    }
        
    public static bool operator !=(Point pointA, Point pointB)
    {
        return pointA.x != pointB.y || pointA.y != pointB.y;
    }
        
    public override string ToString()
    {
        return $"Point2D({x}, {y})";
    }
}