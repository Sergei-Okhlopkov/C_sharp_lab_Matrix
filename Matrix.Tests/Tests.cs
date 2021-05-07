using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using Matrix;
namespace Matrix.Tests
{

    [TestClass]
    public class Tests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckingTypeOfMatrices()
        {
            MatrixClass<char> genericMatrix = new MatrixClass<char>(5, 5);
            MatrixClass<bool> genericMatrix2 = new MatrixClass<bool>(5, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeN()
        {
            int row = -3, col = 2;
            MatrixClass<int> one = new MatrixClass<int>(row, col);
            MatrixClass<int> two = new MatrixClass<int>(row, col);
        }



        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SummDifferentRowsAndColumns()
        {
            MatrixClass<int> one = new MatrixClass<int>(6, 3);
            MatrixClass<int> two = new MatrixClass<int>(3, 6);
            MatrixClass<int> three;
            three = one + two;
        }

        [TestMethod]
        public void SumTwoMatrisces()
        {
            int n = 4;
            MatrixClass<int> one = new MatrixClass<int>(n, n);
            MatrixClass<int> two = new MatrixClass<int>(n, n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    one[i, j] = 1;
                    two[i, j] = 2;
                }
            }
            MatrixClass<int> result = one + two;
            int[,] matrixC = new int[,]
            {
                 {3,3,3,3},
                 {3,3,3,3},
                 {3,3,3,3},
                 {3,3,3,3}

            };

            bool resultValue = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrixC[i, j] != result[i, j])
                    {
                        resultValue = false;
                        break;
                    }
                }
            }
            Assert.AreEqual(resultValue, true);
        }

        [TestMethod]
        public void MultiplyTwoMatrisces()
        {
            int n = 4;
            MatrixClass<int> one = new MatrixClass<int>(n, n);
            MatrixClass<int> two = new MatrixClass<int>(n, n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    one[i, j] = 6;
                    two[i, j] = 2;
                }
            }
            MatrixClass<int> result = one * two;
            int[,] matrixC = new int[,]
            {
                 {48,48,48,48},
                 {48,48,48,48},
                 {48,48,48,48},
                 {48,48,48,48}

            };

            bool resultValue = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrixC[i, j] != result[i, j])
                    {
                        resultValue = false;
                        break;
                    }
                }
            }
            Assert.AreEqual(resultValue, true);
        }
    }
}
