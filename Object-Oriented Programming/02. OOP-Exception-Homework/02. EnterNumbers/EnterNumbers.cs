﻿using System;
using System.Linq;

namespace _02.EnterNumbers
{
    class EnterNumbers
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];

            for (int i = 0; i < numbers.Length; i++)
            {
                int maxArrayElement = numbers.Max();
                int min = Math.Max(2, maxArrayElement + 1);
                int max = 100 - 10 + i;
                Console.Write("Enter a number: ");
                numbers[i] = ReadNumber(min, max);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("Number: {0}: {1}", i + 1, numbers[i]);
            }
        }

        private static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();

            try
            {
                int num = int.Parse(input);

                if (num < start || num > end)
                {
                    throw new ArgumentOutOfRangeException("input", string.Format("Number should be between {0} and {1}", start, end));   
                }

                return num;
            }
            catch (Exception)
            {
                Console.Write("Number should be in the range [{0} ... {1}]. Please re-enter: ", start, end);
                return ReadNumber(start, end);
            }
        }
    }
}
