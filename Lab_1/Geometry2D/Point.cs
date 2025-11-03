namespace Geometry2D;

public class Point
{
    private int _x;
    private int _y;
    
    public static readonly int MaxWidth = 1920;
    public static readonly int MaxHeight = 1080;

    public int X
    {
        get => _x;
        set
        {
            if (value < 0 || value > MaxWidth)
                throw new ArgumentOutOfRangeException(
                    nameof(value),$"{nameof(X)} должен быть в диапазоне [0, {MaxWidth}]");
            _x = value;
        } 
    }

    public int Y
    {
        get => _y;
        set
        { 
            if (value < 0 || value > MaxHeight)
                throw new ArgumentOutOfRangeException(
                    nameof(value), $"{nameof(Y)} должен быть в диапазоне [0, {MaxHeight}]");
            _y = value;
        } 
    }
    
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override bool Equals(object obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;

        var other = (Point) obj;
        return (this.X == other.X) && (this.Y == other.Y);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_x, _y);
    }

    public static bool operator ==(Point pointA, Point pointB)
    {
        if (pointA is null) return pointB is null;
        return pointA.Equals(pointB);
    }
        
    public static bool operator !=(Point pointA, Point pointB)
    {
        return !(pointA == pointB);
    }
        
    public override string ToString()
    {
        return $"Point2D({X}, {Y})";
    }
}