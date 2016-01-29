using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatricaTests
{
    [TestClass]
    public class MatricaTest
    {
        [TestMethod]
        public void TestIfPointIsInMatrix_ChecksIfOutOfTheRows()
        {
            int n = 7;
            int i = 3;
            int dx = 2;

            Assert.IsFalse(i + dx > n, "The point is out of the rows!");
        }
        
        [TestMethod]
        public void TestIfPointIsInMatrix_ChecksIfOutOfTheCols()
        {
            int n = 10;
            int y = 1;
            int dy = 4;

            Assert.IsFalse(y + dy > n, "The point is out of the cols!");
        }

        [TestMethod]
        public void TestIfPointIsOutOfMatrixLength_MakaItStartsFromZeroPosition()
        {
            int[,] arr = new int[2,2];
            int x = 1;
            int dirX = 6;
            if (dirX + x > arr.Length)
            {
                dirX = 0;
            }

            Assert.AreEqual(0,dirX);
        }

        [TestMethod]
        public void TestIfPointIsLessThanZero_MakaItStartsFromZeroPosition()
        {
            int x = 1;
            int dirX = -6;

            if (x + dirX < 0)
            {
                dirX = 0;
            }

            Assert.AreEqual(0, dirX );
        }
    }
}
