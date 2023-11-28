using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using Lab1;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Часть 1:");
            Console.Write("Введите размер массива: ");

            int size = int.Parse(Console.ReadLine());

            var firstPart = new FirstPart(size);

            Console.WriteLine("Исходный массив: ");
            PrintVector(firstPart.Vector);

            Console.WriteLine("Сумма между первым и вторым положительными элементами: " + firstPart.GetSumBetweenPositives());

            Console.WriteLine("Максимальный элемент по модулю: " + firstPart.GetMaxAbs());

            firstPart.MoveZeros();
            Console.WriteLine("После перемещения 0:");
            PrintVector(firstPart.Vector);

            Console.WriteLine("Часть 2:");

            var secondPart = new SecondPart(5, 5);
            PrintMatrix(secondPart.Matrix);

            var smoothingMatrix = secondPart.GetSmoothingMatrix();
            Console.WriteLine("Сглаживание матрицы:");
            PrintMatrix(smoothingMatrix);

            Console.WriteLine("Сумма модулей элементов, расположенных ниже главной диагонали в сглаженной матрице: " + secondPart.GetSumUnderDiogSmoothingMatrix());
           Console.ReadKey();
        }

        static void PrintVector(IEnumerable<int> vector)
        {
            Console.WriteLine(string.Join(" ", vector));
        }

        static void PrintMatrix(double[,] matrix)
        {
           // Console.WriteLine(matrix[0, matrix.GetLength(0)-1]);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("  " + matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}