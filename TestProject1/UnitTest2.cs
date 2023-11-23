using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1;

namespace TestProject1
{
    public class SecondPartTests
    {
        [Fact]
        public void IsGetSmoothingMatrix()
        {
            var sp = new SecondPart(10, 10);
            var actualMatrix = sp.GetSmoothingMatrix();

           // var expectedMatrix = sp.Matrix.OfType<int>().Chunk(sp.Matrix.GetLength(1))
           //                                            .Where(i => i.All(n => n != 0));
            var expectedMatrix = sp.Matrix.OfType<int>().Where(i => i.All(n => n != 0));

            Assert.Equal(actualMatrix.OfType<int>(), expectedMatrix.OfType<int>());
        }

        [Fact]
        public void FindMaxRepeatingValue()
        {
            var sp = new SecondPart(10, 10);
            var actualSum = sp.GetSumUnderDiogSmoothingMatrix();

            var matrix = ;


            int expectedSum = sp.Matrix.OfType<int>()
                                .GroupBy(i => i)
                                .OrderByDescending(g => g.Count())
                                .Select(g => g.Key)
                                .First();


            int expectedSum = sp.Matrix.OfType<int>()
                                .GroupBy(i => i)
                                .OrderByDescending(g => g.Count())
                                .Select(g => g.Key)
                                .First();

            if (expectedMax == 1)
                expectedMax = null;

            Assert.Equal(expectedMax, actualMax);
        }
    }
}