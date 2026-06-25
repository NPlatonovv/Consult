using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    public static class MatrixProcessor
    {
        public static void GenerateWithApprox70Percent(int[,] arr, int n, Random rnd)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int number = rnd.Next(0, 100);
                    if (number <= 70)
                    {
                        arr[i, j] = 1;
                    }
                }
            }
        }
        public static void ProcessRows(int[,] arr, int n)
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
