using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class SecondPart
    {
        private readonly int[,] matrix;

        public SecondPart(int rows, int cols)
        {
            if (rows < 0 || cols < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rows) + " or " + nameof(cols));
            }

            matrix = new int[rows, cols];

            var random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(-10, 10);
                }
            }
        }

        public int[,] Matrix
        {
            get
            {
                return matrix;
            }
        }

        public int[,] GetSmoothingMatrix()
        {
            var smoothingMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            smoothingMatrix[0,0] = (matrix[0, 1] + matrix[1,0])/2;
            smoothingMatrix[0, matrix.GetLength(1)-1] = (matrix[0, matrix.GetLength(1)-2] + matrix[1, matrix.GetLength(1)-1]) / 2;
            smoothingMatrix[matrix.GetLength(0)-1, 0] = (matrix[matrix.GetLength(0) - 1, 1] + matrix[matrix.GetLength(0) - 2, 0]) / 2;
            smoothingMatrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1] = (matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 2] + matrix[matrix.GetLength(0) - 2, matrix.GetLength(1) - 1]) / 2;
            for (int j = 1; j < matrix.GetLength(1)-1; j++)
            {
                smoothingMatrix[0,j] = (matrix[0, j - 1] + matrix[1, j] + matrix[0,j+1])/3;
                smoothingMatrix[matrix.GetLength(0) - 1, j] = (matrix[matrix.GetLength(0) - 1, j - 1] + matrix[matrix.GetLength(0) - 2, j] + matrix[matrix.GetLength(0) - 1, j + 1]) / 3;
            }
         
            for (int j = 1; j < matrix.GetLength(0) - 1; j++)
            {
                smoothingMatrix[j, 0] = (matrix[0, j - 1] + matrix[1, j] + matrix[0, j + 1]) / 3;
                smoothingMatrix[j, matrix.GetLength(1) - 1] = (matrix[matrix.GetLength(0) - 1, j - 1] + matrix[matrix.GetLength(0) - 2, j] + matrix[matrix.GetLength(0) - 1, j + 1]) / 3;
            }

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    smoothingMatrix[i,j] = (matrix[i - 1, j] + matrix[i, j + 1] + matrix[i, j - 1] + matrix[i+1,j]) / 4;         
                }
            }

            return smoothingMatrix;
        }

        public int GetSumUnderDiogSmoothingMatrix()
        {
            int sum = 0;
            GetSmoothingMatrix();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < i; j++)
                {
                    sum += matrix[i, j];
                }
            }

            return sum;
        }

        
    }
}