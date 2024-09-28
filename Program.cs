using System;

public class Matrix
{
    private double[,] data;
    public int Rows { get; }
    public int Columns { get; }

    public Matrix(int rows, int columns)
    {
        if (rows < 1 || columns < 1)
            throw new ArgumentException("Rows and columns must be positive.");

        this.data = new double[rows, columns];
        this.Rows = rows;
        this.Columns = columns;
    }

    // Конструктор копирования
    public Matrix(Matrix other)
    {
        this.data = (double[,])other.data.Clone();
        this.Rows = other.Rows;
        this.Columns = other.Columns;
    }

    // Метод заполнения матрицы случайными числами
    public void FillRandom()
    {
        Random random = new Random();
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                data[i, j] = random.NextDouble();
            }
        }
    }

    // Метод вывода матрицы на печать
    public void Print()
    {
        Console.WriteLine($"{nameof(Matrix)}: {nameof(Rows)}={Rows}, {nameof(Columns)}={Columns}");
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                Console.Write($"{data[i, j]:F2} ");
            }
            Console.WriteLine();
        }
    }

    // Метод сложения матриц
    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Columns != b.Columns)
            throw new InvalidOperationException("Matrices do not have the same dimensions.");

        var result = new Matrix(a);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Columns; j++)
            {
                result.data[i, j] += b.data[i, j];
            }
        }
        return result;
    }

    // Метод умножения матрицы на число
    public static Matrix operator *(Matrix a, double scalar)
    {
        var result = new Matrix(a);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Columns; j++)
            {
                result.data[i, j] *= scalar;
            }
        }
        return result;
    }

    // Метод умножения матриц
    public static Matrix Multiply(Matrix a, Matrix b)
    {
        if (a.Columns != b.Rows)
            throw new InvalidOperationException("The number of columns in A must match the number of rows in B.");

        var result = new Matrix(a.Rows, b.Columns);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < b.Columns; j++)
            {
                for (int k = 0; k < a.Columns; k++)
                {
                    result.data[i, j] += a.data[i, k] * b.data[k, j];
                }
            }
        }
        return result;
    }
}

// Пример использования класса
class Program
{
    static void Main()
    {
        const int ROWS = 3;
        const int COLS = 4;

        var matrixA = new Matrix(ROWS, COLS);
        matrixA.FillRandom();
        matrixA.Print();

        var matrixB = new Matrix(matrixA);
        matrixB.Print();

        var sum = matrixA + matrixB;
        sum.Print();

        var product = matrixA * 5;
        product.Print();

        var c = Matrix.Multiply(matrixA, matrixB);
        c.Print();
    }
}