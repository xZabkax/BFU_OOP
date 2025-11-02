using Geometry2D;

Console.WriteLine("Работа с классом Point2D");

var pointA = new Point(10, 20);
var pointB = new Point(10, 20);
var pointC = new Point(4, 9);
//var testPoint = new Point2D(-1, 1);

if (pointA == pointB)
    Console.WriteLine($"Точка A: {pointA}");

if (pointA != pointC)
    Console.WriteLine($"Точка C: {pointC}\n");

Console.WriteLine("Работа с классом Vector2D");

var vectorA = new Vector(2, 4); // Стандартный конструктор
var vectorB = new Vector(pointA, pointC); // Конструктор через точки
var vectorC = new Vector(vectorA[1], vectorB[0]); // Доступ к элементам вектора по индексу

Console.WriteLine($"Вектор B: {vectorB}");
vectorB[1] = 1;
Console.WriteLine($"Замена y с -11 на 1: {vectorB}\n");

Console.WriteLine("Демонстрация итерирования вектора A");
foreach (var coordinate in vectorA)
{
    Console.WriteLine($"Координата: {coordinate}");
}

if (vectorA != vectorB)
{
    Console.WriteLine($"\nМодуль вектора C {vectorC}: {vectorC.GetLength()}\n");
}

Console.WriteLine($"Демонстрация операторов:\n" +
                  $" A * 4: {vectorA*4}\n" +
                  $" A / 2: {vectorA/2}\n" +
                  $" A - B: {vectorA-vectorB}\n" +
                  $" A + C: {vectorA+vectorC}\n");

Console.WriteLine($"Cкалярное произведение векторов A и B: {vectorA*vectorB}");
Console.WriteLine($"Векторное произведение векторов A и B: {Vector.VectorProduct(vectorA, vectorB)}");
Console.WriteLine($"Смешанное произведение векторов A, B и C: {Vector.MixedProduct(vectorA, vectorB, vectorC)}");