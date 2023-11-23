using Lab1;
using Xunit;

namespace Tests
{
    public class FirstPartTests
    {
        [Fact]
        public void ABOBA()
        {
            Assert.Fail();
        }
        [Theory]
        [InlineData(0, -10)]
        public void IsWrongLengthVectorCreatingFailed(int a, int b)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new FirstPart(a));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new FirstPart(b));
        }

        [Fact]
        public void IsVectorContainsTwoPositives()
        {
            var firstPart = new FirstPart(100);
            var arr = firstPart.Vector.ToArray();
            var i = Array.FindIndex(arr, i => i > 0);
            var j = Array.FindLastIndex(arr, j => j > 0);
            if (i == j) // if no positives or only one
            {
                Assert.ThrowsException<Exception>(() => firstPart.GetSumBetweenPositives());
            } 
            
        }

        [Fact]
        public void IsSumBetweenpositivesValid()
        {
            var firstPart = new FirstPart(100);
            var arr = firstPart.Vector.ToArray();

            var minIndex = Array.FindIndex(arr, i => i > 0);
            var maxIndex = Array.FindIndex(arr, minIndex, i => i > 0);


            var fpSum = firstPart.GetSumBetweenPositives();

            var sum = arr.Skip(minIndex + 1).Take(maxIndex - minIndex - 1).ToList();
            if (sum.Count == 0)
            {
                Assert.Equals(0, fpSum);
            }
            else
            {
                Assert.Equals(sum.Aggregate((a, n) => a + n), fpSum);
            }
        }

        [Fact]
        public void IsMaxAbsValid()
        {
            var firstPart = new FirstPart(100);
            var arr = firstPart.Vector.ToArray();
            
            Assert.Equals(firstPart.GetMaxAbs(), Math.Abs(arr.MaxBy(x => Math.Abs(x))));
        }

        [Fact]
        public void IsMovingZeros()
        {
            var fp = new FirstPart(100);
            
            var sorted = fp.Vector.Where(x => x!= 0).ToList();
            fp.MoveZeros();
            for (var i = 0; i < fp.Vector.Count; i++)
            {
                sorted.Add(0);
            }
            Assert.Equals(sorted, fp.Vector.ToList());
        }


    }
}