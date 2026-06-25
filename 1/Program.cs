using System;


namespace _1
{
    internal class Program
    {
        static void Main()
        {
            Random rnd = new Random();

            Console.WriteLine("Введите размер матрицы");

            int total = Convert.ToInt32(Console.ReadLine().Trim());

            int[,] array = new int[total, total];

            for (int i = 0; i < total; i++)
            {
                for (int j = 0; j < total; j++)
                {
                    int number = rnd.Next(0, 100);
                    if (number <= 70)
                    {
                        array[i, j] = 1;
                    }
                }
            }
            PrintArray(array, total);
            Console.WriteLine();

            ProcessRows(array, total);

            PrintArray(array, total);
        }

        static void PrintArray(int[,] arr, int size)
        {
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    Console.Write(arr[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
        static void ProcessRows(int[,] arr, int n)
        {
            for (int r = 0; r < n; r++)
            {
                bool allOnes = true;
                for (int c = 0; c < n; c++)
                {
                    if (arr[r, c] != 1)
                    {
                        allOnes = false;
                        break;
                    }
                }

                if (allOnes)
                {
                    for (int k = n - 1; k > 0; k--)
                    {
                        for (int c = 0; c < n; c++)
                        {
                            arr[k, c] = arr[k - 1, c];
                        }
                    }
                    for (int c = 0; c < n; c++)
                    {
                        arr[0, c] = 0;
                    }
                    return;
                }
            }
        }
    }


}
