using System;
using System.Collections.Generic;

namespace Zamka
{
    class Program
    {
        static void Main(string[] args)
        {
            // Zamka 
            // https://open.kattis.com/problems/zamka 
            // simple numerical program
            // ------------------------------------------------------------------------------------

            int myL = EnterIntLD(1);
            int myD = EnterIntLD(myL); // must be L <= D
            int myX = EnterIntX();

            // determine the minimal integer N such that L <= N <= D and the sum of its digits is X
            // determine the minimal integer M such that L <= M <= D and the sum of its digits is X

            var answers = GetNM(myL, myD, myX);

            Console.WriteLine(answers[0]);
            Console.WriteLine(answers[answers.Count-1]);
        }
        private static List<int> GetNM(int L, int D, int X)
        {
            var ans = new List<int>();
            for (int i = L; i <= D; i++)
            {
                if (SumDigits(i) == X)
                    ans.Add(i);
            }
            return ans;
        }
        private static int SumDigits(int num)
        {
            string numStr = num.ToString();
            int sum = 0;
            for (int i = 0; i < numStr.Length; i++)
            {
                sum = sum + int.Parse(char.ToString(numStr[i]));
            }
            return sum;
        }
        private static int EnterIntX()
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (a < 1 || a > 36)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterIntX();
            }
            return a;
        }
        private static int EnterIntLD(int limit)
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (a < 1 || a > 10000|| a<limit)  // must be L <= D
                    throw new ArgumentException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterIntLD(limit);
            }
            return a;
        }
    }
}
