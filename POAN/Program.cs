using System;
using System.Numerics;

namespace POAN
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BigInteger input = BigInteger.Parse("2777777888888999999");

            do
            {
                Per(input);
                input += 1;
            } while (true);

            Console.ReadLine();
        }

        private static void Per(BigInteger n, BigInteger? startingN = null, int count = 0)
        {
            if (startingN == null)
            {
                startingN = n;
            }

            string nString = n.ToString();

            if (nString.Length == 1)
            {
                Console.WriteLine($"{startingN}\t{count}");

                if (count >= 11)
                {
                    Console.WriteLine("Wow");
                }
                return;
            }

            BigInteger result = 1;

            foreach (char digit in nString)
            {
                int j = int.Parse(digit.ToString());
                result *= j;
            }

            //Console.WriteLine(result);
            Per(result, startingN, count + 1);
        }
    }
}
