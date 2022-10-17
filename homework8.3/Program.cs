/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
и
1 5 8 5
4 9 4 2
7 2 2 6
2 3 4 7
Их произведение будет равно следующему массиву:
1 20 56 10
20 81 8 6
56 8 4 24
10 6 24 49*/

Console.Write("Ведите кол-во строк первой матрицы: ");
int m = int.Parse(Console.ReadLine() ?? "0");
Console.Write("Ведите кол-во колонн первой матрицы: ");
int n = int.Parse(Console.ReadLine() ?? "0");

Console.Write("Ведите кол-во строк второй матрицы: ");
int a = int.Parse(Console.ReadLine() ?? "0");
Console.Write("Ведите кол-во колонн второй матрицы: ");
int b = int.Parse(Console.ReadLine() ?? "0");

if (n != a || m != b)
    Console.Write("Невозможно найти произведение двух матриц.");
else
{
    int[,] firstArray = new int[m, n];
    int[,] secondArray = new int[a, b];

    FillArray(firstArray);
    FillArray(secondArray);
    PrintArray(firstArray);
    Console.WriteLine();
    PrintArray(secondArray);
    Console.WriteLine();

    if (m >= a)
        PrintArray(MatrixMult(firstArray, secondArray));
    else
        PrintArray(MatrixMult(secondArray,firstArray)); 
}

int[,] MatrixMult(int[,] matrixArrayOne, int[,] matrixArrayTwo)

{
    int[,] thirdArray = new int[matrixArrayTwo.GetLength(1), matrixArrayOne.GetLength(0)];

    for (int i = 0; i < matrixArrayTwo.GetLength(1); i++)
    {
        for (int j = 0; j < matrixArrayOne.GetLength(0); j++)
        {
            int sum = 0;
            for (int k = 0; k < matrixArrayOne.GetLength(1); k++)
            {
                sum = sum + matrixArrayOne[i, k] * matrixArrayTwo[k, j];
                thirdArray[i, j] = sum;
            }
        }
    }
    return thirdArray;
}

void FillArray(int[,] matrixArray)
{
    Random rnd = new Random();
    for (int i = 0; i < matrixArray.GetLength(0); i++)
    {
        for (int j = 0; j < matrixArray.GetLength(1); j++)
        {
            matrixArray[i, j] = rnd.Next(1, 10);
        }
    }
}

void PrintArray(int[,] matrixArray)
{
    for (int i = 0; i < matrixArray.GetLength(0); i++)
    {
        Console.Write("[ ");
        for (int j = 0; j < matrixArray.GetLength(1); j++)
        {
            Console.Write(matrixArray[i, j] + " ");
        }
        Console.Write("]");
        Console.WriteLine();
    }
}