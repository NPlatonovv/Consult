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
            MatrixProcessor.GenerateWithApprox70Percent(array, total, rnd);



            PrintArray(array, total);
            Console.WriteLine();

            MatrixProcessor.ProcessRows(array, total);

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
        
    }


}
