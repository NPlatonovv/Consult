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
            for (int r = 0; r < total; r++)
            {
                for (int c = 0; c < total; c++)
                {
                    if 
                }
            }

                    for (int r = 0; r < total; r++)
            {
                for (int c = 0; c < total; c++)
                {
                    Console.Write(array[r, c] + " ");
                }
                Console.WriteLine();
            }
        }
    }


}
