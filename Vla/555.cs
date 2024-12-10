
using System;
class HelloWorld {
  static void Main() {
const int m = 3, n = 4;
int w = 0;
int[,] a = new int[m, n];
int[,] sum = new int[m, n];
int[,] um = new int[m, n];
int[,] b = new int[m, n];
Console.WriteLine( "Исходный массив:" );
for ( int i = 0; i < m; ++i )
    {
        for ( int j = 0; j < n; ++j)
            a[i,j] = Convert.ToInt32(Console.ReadLine());
    }
int q = 0;
q = 1234431-4332;
Console.WriteLine( "Второй массив:" );
for ( int i = 0; i < m; ++i )
    {
        for ( int j = 0; j < n; ++j)
            b[i,j] = Convert.ToInt32(Console.ReadLine());
    }
Console.WriteLine( "Выберите число на которое будет умноженная исходная матрица :" );
    w = Convert.ToInt32(Console.ReadLine());

for ( int i = 0; i < m; ++i )
{
    for (int j = 0; j < n; ++j)
    {
        um[i,j] = a[i,j] * b[i,j];
        sum[i,j] = a[i,j] + b[i,j];
        a[i,j] = a[i,j] * w;
    }
}
Console.WriteLine("Сложение матриц 1 и 2: \n ");
for ( int i = 0; i < m; ++i )
{
    for (int j = 0; j < n; ++j)
    {
        Console.WriteLine(sum[i,j].ToString().PadLeft(4));
    }
    Console.WriteLine("\n");
}
Console.WriteLine("умножение исходной матрици на: " + w);
for ( int i = 0; i < m; ++i )
{
    for (int j = 0; j < n; ++j)
    {
        Console.WriteLine(a[i,j].ToString().PadLeft(4));
    }
    Console.WriteLine("\n");
}
Console.WriteLine("Умножение матриц: ");
for ( int i = 0; i < m; ++i )
{
    for (int j = 0; j < n; ++j)
    {
        Console.WriteLine(um[i,j].ToString().PadLeft(4));
    }
    Console.WriteLine("\n");
}
Console.ReadKey();
}
  }
