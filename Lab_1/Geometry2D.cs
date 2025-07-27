namespace Geometry2D
{
    public class Point2D
    {
        public int x { get; }
        public int y { get; }

        public Point2D(int X=0, int Y=0)
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
        
        public static bool operator ==(Point2D pointA, Point2D pointB)
        {
            return pointA.x == pointB.x & pointA.y == pointB.y;
        }
        
        public static bool operator !=(Point2D pointA, Point2D pointB)
        {
            return pointA.x != pointB.y || pointA.y != pointB.y;
        }
        
        public override string ToString()
        {
            return $"Point2D({x}, {y})";
        }
    }

    public class Vector2D
    {
        public int x { get; private set; }
        public int y { get; private set; }
        
        public Vector2D(int X=0, int Y=0)
        {
            x = X;
            y = Y;
        }
        
        // Конструктор через точки (вызывает основной конструктор)
        public Vector2D(Point2D start, Point2D end) : this(end.x - start.x, end.y - start.y) // Цепочка вызовов
        {
        }

        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return x;
                    case 1: return y;
                    default: throw new IndexOutOfRangeException("Индекс может быть 0 или 1");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    default: throw new IndexOutOfRangeException("Индекс может быть 0 или 1");
                            
                }
            }
        }
        
        // Итерация вектора
        public IEnumerator<int> GetEnumerator()
        {
            yield return x;
            yield return y;
        }
        
        // Строковое представление вектора
        public override string ToString()
        {
            return $"Vector2D({x}, {y})";
        }
        
        // Модуль вектора (abs)
        public double GetLength()
        {
            return Math.Sqrt(x*x + y*y);
        }
        
        // Сложение векторов
        public static Vector2D operator +(Vector2D vectorA, Vector2D vectorB)
        {
            return new Vector2D(vectorA.x + vectorB.x, vectorA.y + vectorB.y);
        } 
        
        // Вычитание векторов
        public static Vector2D operator -(Vector2D vectorA, Vector2D vectorB)
        {
            return new Vector2D(vectorA.x - vectorB.x, vectorA.y - vectorB.y);
        }
       
        // Умножение вектора на число
        public static Vector2D operator *(Vector2D vector, int number)
        {
            return new Vector2D(vector.x * number, vector.y * number);
        }
        
        public static Vector2D operator *(int number, Vector2D vector)
        {
            return new Vector2D(vector.x * number, vector.y * number);
        }
        
        // Деление вектора на число
        public static Vector2D operator /(Vector2D vector, int number)
        {
            if (number == 0)
                throw new DivideByZeroException();
            return new Vector2D(vector.x / number , vector.y / number);
        }
        
        // Сравнение векторов на эквивалентность
        public static bool operator ==(Vector2D vectorA, Vector2D vectorB)
        {
            return vectorA.x == vectorB.x & vectorA.y == vectorB.y;
        }
        
        public static bool operator !=(Vector2D vectorA, Vector2D vectorB)
        {
            return vectorA.x != vectorB.x || vectorA.y != vectorB.y;
        }
        
        // Скалярное умножение векторов
        public static int operator *(Vector2D vectorA, Vector2D vectorB)
        {
            return vectorA.x * vectorB.x + vectorA.y * vectorB.y;
        }

        public static int ScalarProduct(Vector2D vectorA, Vector2D vectorB)
        {
            return vectorA.x * vectorB.x + vectorA.y * vectorB.y;
        }
        
        public int ScalarProduct(Vector2D otherVector)
        {
            return this.x * otherVector.x + this.y * otherVector.y;
        }
        
        // Векторное произведение векторов (Возвращает значение z координаты результирующего вектора)
        public static int VectorProduct(Vector2D vectorA, Vector2D vectorB)
        {
            return vectorA.x * vectorB.y - vectorA.y * vectorB.x;
        }

        public int VectorProduct(Vector2D otherVector)
        {
            return this.x * otherVector.y - this.y * otherVector.x;
        }
        
        // Смешанное произведение векторов
        public static int MixedProduct(Vector2D vectorA, Vector2D vectorB, Vector2D vectorC)
        {
            return 0; // Все три вектора лежат в одной плоскости => линейно зависимы =>
                      // => определитель, составленный из их координат равен 0
        }
    }
}