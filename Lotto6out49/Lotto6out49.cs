using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class Lotto6out49
    {
        public static int CheckRightNumber(int[] numberArray, int[] generated)
        {
            int result = 0;

            foreach (int value in numberArray)
            {
                if (IsInArray(value, generated))
                {
                    Console.Write(value + " ");
                    result++;
                }
            }

            Console.WriteLine();

            return result;

        }


        public static bool IsInArray(int number, int[] numberArray)
        {
            bool result = false;

            foreach (int value in numberArray)
            {
                if (number == value)
                {
                    result = true;
                }
            }

            return result;

        }

        public static void DisplayArray(int[] arr)
        {
            foreach (int number in arr)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }

        public static int[] GenerateNumbers()
        {
            Random rand = new Random();
            int i = 0;
            int temp;

            int[] result = new int[6];

            while (i < 6)
            {
                temp = rand.Next(1, 50);
                if (!IsInArray(temp, result))
                {
                    result[i] = temp;
                    i++;
                }
            }

            return result;
        }

        public static bool CheckForDuplicates(int[] numberArray)
        {
            bool result = false;

            for (int i = 0; i < numberArray.Length - 1; i++)
            {
                for (int j = i + 1; j < numberArray.Length; j++)
                {
                    if (numberArray[i] == numberArray[j])
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
