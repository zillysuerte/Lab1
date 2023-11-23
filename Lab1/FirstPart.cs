using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class FirstPart
    {
        private readonly int[] array;
        private readonly int maxRange = 10;

        public FirstPart(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            var random = new Random();

            array = new int[length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-maxRange, maxRange);
            }
        }

        public IReadOnlyList<int> Vector
        {
            get
            {
                return array;
            }
        }

        public int GetSumBetweenPositives()
        {
            int sum = 0;
            bool first = false;
            bool second = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    if (first && !second)
                    {
                        second = true;
                        
                    } else if (!first && !second)
                    {
                        first = true;
                    }
                } else if (first && !second)
                {
                    sum += array[i];
                }
            }
            if (first && !second)
            {
                throw new Exception("Не определить сумму между первым и вторым положительным числами - только одно положительное число");
            } else if (!first && !second)
            {
                throw new Exception("Не определить сумму между первым и вторым положительным числами - нет положительных чисел");
            }
            return sum;
        }

        public void MoveZeros()
        {
            int curIndexInStartArray = 0;
            int i = 0;
            while (curIndexInStartArray < array.Length)
            {
                if (array[curIndexInStartArray] == 0 && curIndexInStartArray != array.Length-1)
                {
                    curIndexInStartArray++;
                }
                while (curIndexInStartArray != array.Length-1 && array[curIndexInStartArray] == 0)
                    {
                        curIndexInStartArray++;
                    }
                array[i++] = array[curIndexInStartArray++];
            }
            while (i < array.Length)
            {
                array[i] = 0;
                i++;
            }
            
        }

        public int GetMaxAbs()
        {
            int max = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (max < Math.Abs(array[i]))
                {
                    max = Math.Abs(array[i]);
                }
            }
            return max;
        }
    }
}
