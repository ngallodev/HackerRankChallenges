using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestBed
{
    class Program
    {

        static int countingValleys(int n, string s)
        {
            int valleyTotal=0;
            bool valleyStart = false;
            int elevation = 0;
            if (s.Length > 0)
            {
                for (int x = 0; x < n; x++)
                {
                    int newElevation = 0;
                    switch (s[x])
                    {
                        case 'D':
                            newElevation = elevation--;
                            break;
                        case 'U':
                            newElevation = elevation++;
                            break;
                        default:
                            break;
                    }
                    if (elevation == 0 && newElevation == -1)
                        valleyStart = true;
                    else if (elevation == -1 && newElevation == 0)
                    {
                        //left a valley, increment counter, set flag to false
                        valleyStart = false;
                        valleyTotal++;
                    }

                }
            }


            return valleyTotal;
        }

        static int sockMerchant(int n, int[] ar)
        {
            if (n > 0)
            {
                Dictionary<int, int> d = new Dictionary<int, int>();
                int pairs = 0;
                for (int x = 0; x < n; x++)
                {
                    if (d.ContainsKey(ar[x]))
                    {
                        d[ar[x]]++;
                    }
                    else
                        d[ar[x]] = 1;
                }
                foreach (KeyValuePair<int, int> kvp in d)
                {
                    pairs += kvp.Value / 2;
                }
                return pairs;
            }
            return 0;
        }

        static void miniMaxSum(int[] arr)
        {
            Array.Sort(arr);
            long min = 0;
            long max = 0;
            
            if (arr.Length > 0)
            {
                    min = arr.Sum();
                min -= arr[arr.Length - 1];
                max = arr.Sum();
                max -= arr[0];
                
            
            }
            Console.WriteLine(min+ " " + max);
        }

        static void staircase(int n)
        {
            for(int x = 0; x < n; x++)
            {
                string output = string.Concat(Enumerable.Repeat(" ", n - (1 + x)));
                output += string.Concat(Enumerable.Repeat("#", x + 1));
                Console.WriteLine(output);
            }

        }

        static void plusMinus(int[] arr)
        {
            decimal pos = 0;
            decimal neg = 0;
            decimal zer = 0;
            if (arr.Length > 0)
            {
                for (int x = 0; x < arr.Length; x++)
                {
                    if (arr[x] < 0)
                        neg++;
                    else if (arr[x] > 0)
                        pos++;
                    else
                        zer++;
                }
                int length = arr.Length;
                pos = pos / length;
                neg = neg / length;
                zer = zer / length;
            }
            Console.WriteLine(pos.ToString("N6"));
            Console.WriteLine(neg.ToString("N6"));
            Console.WriteLine(zer.ToString("N6"));
        }

        public static int diagonalDifference(List<List<int>> arr)
        {
            Console.WriteLine(arr.Count);
            int a = 0;
            int b = 0;
            for(int i = 0; i < arr.Count; i++)
            {
               a += arr[i][i];
               b += arr[i][arr.Count - (1 + i)];
                Console.WriteLine(a.ToString(), b.ToString());
            }
           
            return Math.Abs(a-b);
        }
        // Complete the rotLeft function below.
        static int[] rotLeft(int[] a, int d)
        {
            if (a.Length > 0)
            {
                for (int x = 0; x < d; x++)
                {
                    int temp = a[0];
                    for (int y = 1; y<=a.Length; y++)
                    {
                        if (y == a.Length)
                            a[a.Length-1] = temp;
                        else
                        {
                            a[y - 1] = a[y];
                
                        }
                        //Console.WriteLine("[{0}]", string.Join(", ", a));
                    }

                }
            }
            return a;
        }

        static void Main(string[] args)
        {
            string steps = "DDUUUU";
            Console.WriteLine(countingValleys(6,steps));
            Console.ReadKey();
            int[] socks = { 1, 2, 1, 2, 1, 3, 2 };
            Console.WriteLine(sockMerchant(socks.Length, socks));
            Console.ReadKey();
            staircase(6);
            Console.ReadKey();
            List<List<int>> ml = new List<List<int>>
            {
                new List<int> {1,2,3},
                new List<int> {4,5,6},
                new List<int> {7,8,9}
            };
            int res = diagonalDifference(ml);
            Console.WriteLine("dd = " + res.ToString());
            Console.ReadKey();

            int d = 4;
            int[] a = { 1, 2, 3, 4, 5 };
            int[] result = rotLeft(a, d);

            Console.WriteLine("[{0}]", string.Join(", ", result));
            Console.ReadKey();
        }
    }
}
