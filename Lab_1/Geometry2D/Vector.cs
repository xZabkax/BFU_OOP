namespace Geometry2D;

public class Vector
    {
        public int x { get; private set; }
        public int y { get; private set; }
        
        public Vector(int X=0, int Y=0)
        {
            x = X;
            y = Y;
        }
        
        // Конструктор через точки (вызывает основной конструктор)
        public Vector(Point start, Point end) : this(end.x - start.x, end.y - start.y) // Цепочка вызовов
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
        public static Vector operator +(Vector vectorA, Vector vectorB)
        {
            return new Vector(vectorA.x + vectorB.x, vectorA.y + vectorB.y);
        } 
        
        // Вычитание векторов
        public static Vector operator -(Vector vectorA, Vector vectorB)
        {
            return new Vector(vectorA.x - vectorB.x, vectorA.y - vectorB.y);
        }
       
        // Умножение вектора на число
        public static Vector operator *(Vector vector, int number)
        {
            return new Vector(vector.x * number, vector.y * number);
        }
        
        public static Vector operator *(int number, Vector vector)
        {
            return new Vector(vector.x * number, vector.y * number);
        }
        
        // Деление вектора на число
        public static Vector operator /(Vector vector, int number)
        {
            if (number == 0)
                throw new DivideByZeroException();
            return new Vector(vector.x / number , vector.y / number);
        }
        
        // Сравнение векторов на эквивалентность
        public static bool operator ==(Vector vectorA, Vector vectorB)
        {
            return vectorA.x == vectorB.x & vectorA.y == vectorB.y;
        }
        
        public static bool operator !=(Vector vectorA, Vector vectorB)
        {
            return vectorA.x != vectorB.x || vectorA.y != vectorB.y;
        }
        
        // Скалярное умножение векторов
        public static int operator *(Vector vectorA, Vector vectorB)
        {
            return vectorA.x * vectorB.x + vectorA.y * vectorB.y;
        }

        public static int ScalarProduct(Vector vectorA, Vector vectorB)
        {
            return vectorA.x * vectorB.x + vectorA.y * vectorB.y;
        }
        
        public int ScalarProduct(Vector otherVector)
        {
            return this.x * otherVector.x + this.y * otherVector.y;
        }
        
        // Векторное произведение векторов (Возвращает значение z координаты результирующего вектора)
        public static int VectorProduct(Vector vectorA, Vector vectorB)
        {
            return vectorA.x * vectorB.y - vectorA.y * vectorB.x;
        }

        public int VectorProduct(Vector otherVector)
        {
            return this.x * otherVector.y - this.y * otherVector.x;
        }
        
        // Смешанное произведение векторов
        public static int MixedProduct(Vector vectorA, Vector vectorB, Vector vectorC)
        {
            return 0; // Все три вектора лежат в одной плоскости => линейно зависимы =>
                      // => определитель, составленный из их координат равен 0
        }
    }