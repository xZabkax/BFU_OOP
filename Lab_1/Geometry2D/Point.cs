namespace Geometry2D;

public class Point
{
    private int _x;
    private int _y;

    public int X
    {
        get => _x;
        set
        {
            if (value < 0 || value > MaxWidth)
                throw new ArgumentOutOfRangeException($"x должен быть в диапазоне [0, {MaxWidth}]");
            _x = value;
        } 
    }

    public int Y
    {
        get => _y;
        set
        { 
            if (value < 0 || value > MaxHeight)
                throw new ArgumentOutOfRangeException($"y должен быть в диапазоне [0, {MaxHeight}]");
            _y = value;
        } 
    }
    
    private const int MaxWidth = 1920;
    private const int MaxHeight = 1080;
    
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
        
    public static bool operator ==(Point pointA, Point pointB)
    {
        return pointA.X == pointB.X && pointA.Y == pointB.Y;
    }
        
    public static bool operator !=(Point pointA, Point pointB)
    {
        return pointA.X != pointB.X || pointA.Y != pointB.Y;
    }
        
    public override string ToString()
    {
        return $"Point2D({X}, {Y})";
    }
}