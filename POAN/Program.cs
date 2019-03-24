using System;
using System.Numerics;

namespace POAN
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BigInteger input = BigInteger.Pow(10, 200);

            do
            {
                var result = Per(input);
                // Console.WriteLine($"{input.ToString("x")}\t{result}");
                Console.WriteLine($"{result}");

                input += 1;
            } while (true);

            Console.ReadLine();
        }

        private enum Result
        {
            Contains0,
            NotAscending,
            Complete
        }

        private static Result Per(BigInteger n, BigInteger? startingN = null, int count = 0)
        {
            if (startingN == null)
            {
                startingN = n;
            }

            string nString = n.ToString();

            if (nString.Length == 1)
            {
                Console.WriteLine($"{startingN?.ToString("x")}\t{count}");

                if (count >= 11)
                {
                    Console.WriteLine($"{startingN?.ToString("x")}\t{count}");
                }

                return Result.Complete;
            }

            BigInteger result = 1;

            for (int i = 0; i < nString.Length; i++)
            {
                ushort j = ushort.Parse(nString[i].ToString());

                if (j == 0)
                {
                    return Result.Contains0;
                }

                if (i < nString.Length - 1)
                {
                    if (ushort.Parse(nString[i + 1].ToString()) < j )
                    {
                        // Abort, next number is less than current one
                        return Result.NotAscending;
                    }
                }

                result *= j;
            }

            // Console.WriteLine(result.ToString("x"));
            return Per(result, startingN, count + 1);
        }
    }
}
