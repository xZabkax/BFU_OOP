namespace Geometry2D;

public class Vector
{
    public int X { get; set; }
    public int Y { get; set; }
    
    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    // Конструктор через точки (вызывает основной конструктор)
    public Vector(Point start, Point end) : this(end.X - start.X, end.Y - start.Y) // Цепочка вызовов
    {
    }
    
    //Индексатор
    public int this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return X;
                case 1: return Y;
                default: throw new IndexOutOfRangeException("Индекс может быть 0 или 1");
            }
        }
        set
        {
            switch (index)
            {
                case 0: X = value; break;
                case 1: Y = value; break;
                default: throw new IndexOutOfRangeException("Индекс может быть 0 или 1");
                        
            }
        }
    }
    
    // Итерация вектора
    public IEnumerator<int> GetEnumerator()
    {
        yield return X;
        yield return Y;
    }
    
    // Строковое представление вектора
    public override string ToString()
    {
        return $"Vector2D({X}, {Y})";
    }
    
    public override bool Equals(object obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;

        var other = (Vector) obj;
        return (this.X == other.X) && (this.Y == other.Y);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    // Модуль вектора (abs)
    public double GetLength()
    {
        return Math.Sqrt(X*X + Y*Y);
    }
    
    // Сложение векторов
    public static Vector operator +(Vector vectorA, Vector vectorB)
    {
        return new Vector(vectorA.X + vectorB.X, vectorA.Y + vectorB.Y);
    } 
    
    // Вычитание векторов
    public static Vector operator -(Vector vectorA, Vector vectorB)
    {
        return new Vector(vectorA.X - vectorB.X, vectorA.Y - vectorB.Y);
    }
   
    // Умножение вектора на число
    public static Vector operator *(Vector vector, int number)
    {
        return new Vector(vector.X * number, vector.Y * number);
    }
    
    public static Vector operator *(int number, Vector vector)
    {
        return new Vector(vector.X * number, vector.Y * number);
    }
    
    // Деление вектора на число
    public static Vector operator /(Vector vector, int number)
    {
        if (number == 0)
            throw new DivideByZeroException();
        return new Vector(vector.X / number , vector.Y / number);
    }
    
    // Сравнение векторов на эквивалентность
    public static bool operator ==(Vector vectorA, Vector vectorB)
    {
        if (vectorA is null) return vectorB is null;
        return vectorA.Equals(vectorB);
    }
    
    public static bool operator !=(Vector vectorA, Vector vectorB)
    {
        return !(vectorA == vectorB);
    }
    
    // Скалярное произведение векторов
    public static int ScalarProduct(Vector vectorA, Vector vectorB)
    {
        return vectorA.X * vectorB.X + vectorA.Y * vectorB.Y;
    }
    
    public int ScalarProduct(Vector otherVector)
    {
        return ScalarProduct(this, otherVector);
    }
    
    public static int operator *(Vector vectorA, Vector vectorB)
    {
        return ScalarProduct(vectorA, vectorB);
    }
    
    // Векторное произведение векторов (Возвращает значение z координаты результирующего вектора)
    public static int VectorProduct(Vector vectorA, Vector vectorB)
    {
        return vectorA.X * vectorB.Y - vectorA.Y * vectorB.X;
    }

    public int VectorProduct(Vector otherVector)
    {
        return VectorProduct(this, otherVector);
    }
    
    // Смешанное произведение векторов
    public static int MixedProduct(Vector vectorA, Vector vectorB, Vector vectorC)
    {
        return 0; // Все три вектора лежат в одной плоскости => линейно зависимы =>
                  // => определитель, составленный из их координат равен 0
    }
}