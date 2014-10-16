using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Numerics;
namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array2D = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            int r=3,d=3,l=0,u=0;
            bool rf=true, df=false, lf=false, uf=false;
            int i = 0, j = 0;
            while (true)
            {
                if (j <= r && rf)
                {
                    Console.Write(array2D[i, j]+" ");
                    j++;
                    continue;
                }
                else if( rf)
                {
                    r--;
                    --j;
                    u++;
                    i++;
                    rf = false;
                    df = true;
                 }

                if (df && i<=d )
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
        public static void hackerrank()
        {
            //int[] input = { 2, 1, 1, 3 };
            int N = Convert.ToInt32(Console.ReadLine());
            BigInteger[] input = new BigInteger[N];
            for (int i = 0; i < N; i++)
            {
                input[i] = Convert.ToInt64(Console.ReadLine().ToString());
            }

            List<long> output = new List<long>();
            Dictionary<BigInteger, BigInteger> countOutput = new Dictionary<BigInteger, BigInteger>();
            long _min = -1, _minCount = -1;
            for (int i = 0; i < input.Length; i++)
            {
                BigInteger result = input[i];


                if (!countOutput.ContainsKey(result))
                {
                    countOutput.Add(result, 1);

                }
                else
                {
                    countOutput[result]++;

                }

                int k = i + 1;
                while (k < input.Length)
                {
                    result = result ^ input[k];
                    k++;
                    if (!countOutput.ContainsKey(result))
                    {
                        countOutput.Add(result, 1);
                    }
                    else
                    {
                        countOutput[result]++;
                    }
                }

            }

            BigInteger max = countOutput.Values.Max();
            BigInteger min = countOutput.Where(kv => kv.Value == max).Select(kvp => kvp.Key).Min();
            Console.WriteLine(min + " " + max);
        }
        private static BigInteger Combination(BigInteger numberupper,BigInteger numberlower)
        {
            BigInteger mult1 = 1;
            if ((numberupper - numberlower) > numberlower)
            {
                for (BigInteger i = numberupper; i > numberupper - numberlower; i--)
                {
                    mult1 = mult1 * i;
                }
                BigInteger mult2 = 1;
                for (BigInteger i = 1; i <= numberlower; i++)
                {
                    mult2 = mult2 * i;
                }
                return ((mult1 / mult2) % 100003);
            }
            else
            {
                for (BigInteger i = numberupper; i > numberlower; i--)
                {
                    mult1 = mult1 * i;
                }
                BigInteger mult2 = 1;
                for (BigInteger i = 1; i <= numberupper - numberlower; i++)
                {
                    mult2 = mult2 * i;
                }
                return ((mult1 / mult2) % 100003);
            }
        }
        private static BigInteger GetFactorial(BigInteger number)
        {
            if (number == 0)
            {
                return 1;
            }
            return number * GetFactorial(number - 1);
        }

        public static bool IsSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    return false;
                }
            }
            return true;
        }
        private static double polarAngle(string p)
        {
            string[] xy = p.Split(' ');
            double angle = Math.Round(Math.Atan2(Convert.ToDouble(xy[1]), Convert.ToDouble(xy[0])) * 180 / Math.PI, 1, MidpointRounding.AwayFromZero);
            return angle >= 0 ? angle : 360 + angle;
        }
    }
}
/*
  // int N = Convert.ToInt32(Console.ReadLine());
            string[] v = { "1 0", "0 -1", "-1 0", "0 1" };
            Dictionary<string, double> input = new Dictionary<string,  double>();
            for (int i = 0; i < 4; i++)
			{
                string str = v[i];//Console.ReadLine().ToString();
                input.Add(str, polarAngle(str));
			}
            foreach (KeyValuePair<string, double> output in input.OrderBy(key => key.Value))
            {
                Console.WriteLine("{0}", output.Key);
            }
 
 */

/*
  //int N = Convert.ToInt32(Console.ReadLine());
            int[] arr = { 1, 5, 4, 3, 2, 6 };
        
            int poss = 0, posl = 1;
            int i = 0; bool bstart = true;
            while (i < arr.Length - 1)
            {
                if (arr[i] < arr[i+1] && bstart)
                {
                   
                    poss = i+1;
                }
                else if (arr[i] > arr[i+1])
                {
                    
                    
                    posl = i+1;
                    bstart = false;
                }
                i++;
            }

            bool sorted;
            //swap
            if (posl - poss == 1)
            {
                int temp = arr[posl];
                arr[posl] = arr[poss];
                arr[poss] = temp;
                sorted = IsSorted(arr);
                if (sorted)
                {
                    Console.WriteLine("yes");
                    Console.WriteLine("swap " + (poss+1)+ " " + (posl+1));
                    return;
                }
            }
            else // reverse array
            {
                int l = poss;
                int k = posl;
                while (l < k)
                {
                    int temp = arr[l];
                    arr[l] = arr[k];
                    arr[k] = temp;
                    l++;
                    k--;
                }
                sorted = IsSorted(arr);
                if (sorted)
                {
                    Console.WriteLine("yes");
                    Console.WriteLine("reverse " + (poss + 1) + " " + (posl + 1));
                    return;
                }
            }
            Console.WriteLine("no");
 
 */

/*
  int numberTest = Convert.ToInt32(Console.ReadLine());
            List<string> strList = new List<string>();
            for (int q = 0; q < numberTest; q++)
            {
                string[] inputStrRC = Console.ReadLine().ToString().Split(' ');
                string[] strInput = new string[Convert.ToInt32(inputStrRC[0])];
                for (int w = 0; w < Convert.ToInt32(inputStrRC[0]); w++)
                {
                    strInput[w] = Console.ReadLine().ToString();
                }

                string[] inputMatchRC = Console.ReadLine().ToString().Split(' ');
                string[] strmatch = new string[Convert.ToInt32(inputMatchRC[0])];
                for (int w = 0; w < Convert.ToInt32(inputMatchRC[0]); w++)
                {
                    strmatch[w] = Console.ReadLine().ToString();
                }
                

                int i = 0, j = 0; bool bflag = false;
                while (i < strInput.Length)
                {
                    int oldindex = strInput[i].IndexOf(strmatch[j]); i++;
                    if (oldindex != -1)
                    {
                        int k = i; j++;
                        while (j < strmatch.Length && k < strInput.Length)
                        {
                            if (strInput[k].Substring(oldindex, strmatch[j].Length).IndexOf(strmatch[j]) != 0)
                            {
                                k++; j = 0;
                                break;
                            }
                            else
                            {
                                j++; k++;


                            }

                        }

                    }
                    if (j == strmatch.Length )
                    {
                        bflag = true;
                        break;
                    }

                }
                if (bflag)
                {
                   strList.Add("YES");
                }
                else
                {
                    strList.Add("NO");
                }
            }

            foreach (var item in strList)
            {
                Console.WriteLine(item);
            }
 
 */