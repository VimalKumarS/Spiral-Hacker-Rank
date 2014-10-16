using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpiralCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array2D = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            int r = 3, d = 3, l = 0, u = 0;
            bool rf = true, df = false, lf = false, uf = false;
            int i = 0, j = 0;
            while (true)
            {
                if (j <= r && rf)
                {
                    Console.Write(array2D[i, j] + " ");
                    j++;
                    continue;
                }
                else if (rf)
                {
                    r--;
                    --j;
                    u++;
                    i++;
                    rf = false;
                    df = true;
                }

                if (df && i <= d)
                {

                    Console.Write(array2D[i, j] + " ");
                    i++;
                    continue;
                }
                else if (df)
                {
                    lf = true;
                    df = false;
                    d--;
                    //--j;
                    i--;
                    j--;
                    //l--;
                }

                if (lf && j >= l)
                {

                    Console.Write(array2D[i, j] + " ");
                    j--;
                    continue;
                }
                else if (lf)
                {
                    uf = true;
                    lf = false;
                    l++;
                    i--; j++;
                }
                if (uf && i >= u)
                {

                    Console.Write(array2D[i, j] + " ");
                    i--;
                    continue;
                }
                else if (uf)
                {
                    rf = true;
                    uf = false;
                    u++;
                    j++; i++;
                    // d--;
                }

                if (r < 0)
                {
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}
