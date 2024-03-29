﻿using System;
using System.Globalization;
namespace Input
{
    public static class CustomInput
    {
        public static int IntInput(
            string startInput,
            double lowerBoundary = Int32.MinValue,
            double upperBoundary = Int32.MaxValue
            )  // Process input of int parameters
        {
            int output;
            string input;
            bool ok = true;
            bool boundaryOk = true;
            do
            {
                if (ok && boundaryOk)
                {
                    Console.WriteLine(startInput);
                }
                else
                {
                    if (!ok)
                    {
                        Console.WriteLine($"Ошибка: введён не тип int. Повторите ввод");
                    }
                    else if (!boundaryOk)
                    {
                        Console.WriteLine($"Ошибка: число вышло за допустимые границы. Повторите ввод");
                    }
                }
                input = Console.ReadLine().Replace(',', '.');
                ok = int.TryParse(input, out output);
                boundaryOk = output > lowerBoundary && output < upperBoundary;
            } while (!ok || !boundaryOk);
            return output;
        }
    }
}