using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestBed
{
    class Program
    {
        public static int pickingNumbers(List<int> a)
        {
            List<int> counter = new List<int>();

            //ar.Add(newList);
            a.Sort();
            //int currentNumber = 0;
            for (int x = 0; x < a.Count; x++)
            {
                List<int> newList = new List<int>();
                newList.Add(a[x]);
                for (int y = x + 1; y < a.Count; y++)
                {
                    if (Math.Abs(a[x] - a[y]) <= 1)
                    {
                        newList.Add(a[y]);
                    }
                }
                counter.Add(newList.Count);

            }
            counter.Sort();
            foreach (int i in counter)
                Console.WriteLine(i);
            //Console.WriteLine(counter.ToString());

            return counter[counter.Count - 1];

        }
        static int birthdayCakeCandles(int[] ar)
        {
            int high = 0;
            int count = 0;

            for(int x = 0; x < ar.Length; x++)
            {
                if (ar[x] > high)
                {
                    high = ar[x];
                    count = 1;
                }
                else if (ar[x] == high)
                    count++;
            }
            return count;
        }

        // Complete the checkMagazine function below.
        static void checkMagazine(string[] magazine, string[] note)
        {
            string result = "No";
            if (magazine.Length >= note.Length)
            {
                Dictionary<string,int> magazineHash = new Dictionary<string, int>();
                foreach(string word in magazine)
                {
                    if (magazineHash.ContainsKey(word))
                        magazineHash[word]++;
                    else
                        magazineHash.Add(word, 1);
                }

                
                result = "Yes";
                foreach(string s in note)
                {
                    //if the word is not in the magazine, or we've used up all instances of the word
                    if (!magazineHash.ContainsKey(s) || magazineHash[s] == 0)
                        result = "No";
                    else
                    {
                        //decrement count of word
                        magazineHash[s]--;
                    }
                }

            }
            Console.WriteLine(result);
        }

        static long repeatedString(string s, long n)
        {
            long numberOfRepeats = n / s.Length;
            long remainder = n % s.Length;
            Console.WriteLine("repeats=" +numberOfRepeats + " remainder="+remainder);
            if (!s.Contains('a'))
                return 0;

            string remString = s.Substring(0, (int)remainder);

            //select characters in string that are 'a'
            IEnumerable<char> stringQuery =
                 from ch in s
                 where ch == 'a'
                 select ch;
            Console.WriteLine("sq.count=" + stringQuery.Count());
            //select characters in sub string that are 'a'
            IEnumerable<char> subStringQuery =
                 from ch in remString
                 where ch == 'a'
                 select ch;
            Console.WriteLine("ssq.count=" + subStringQuery.Count());
            long count = (stringQuery.Count() * numberOfRepeats) + subStringQuery.Count();
   
            return count;
        }

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
        /// Complete the rotLeft function below.
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
            Console.WriteLine("picking numbers");

            Console.ReadKey();
            Console.WriteLine("Birthday cake candles");
            int[] candleArray = { 1, 1, 2, 4, 3, 3, 4 };
            Console.WriteLine("Candles blown {0}",birthdayCakeCandles(candleArray));
            Console.ReadKey();

            Console.WriteLine("checkMagazine - ransom note");
            string[] magazine = { "give", "me", "one", "grand", "today", "night" };
            string[] note = { "give", "one", "grand", "today" };
            checkMagazine(magazine, note);
            Console.ReadKey();
            Console.WriteLine("repeated string"); //repeated string
            string repStringInput = "aba";
            long lengthOfString = 10;
            Console.WriteLine(repeatedString(repStringInput, lengthOfString));
            Console.ReadKey();
            //counting valleys
            string steps = "DDUUUU";
            Console.WriteLine(countingValleys(6,steps));
            Console.ReadKey();
            //sockmerchant
            int[] socks = { 1, 2, 1, 2, 1, 3, 2 };
            Console.WriteLine(sockMerchant(socks.Length, socks));
            Console.ReadKey();
            //staircase
            staircase(6);

            //diagonal difference
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

            //rotate left
            int d = 4;
            int[] a = { 1, 2, 3, 4, 5 };
            int[] result = rotLeft(a, d);

            Console.WriteLine("[{0}]", string.Join(", ", result));
            Console.ReadKey();
        }
    }
}
