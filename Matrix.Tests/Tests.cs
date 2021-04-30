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
            MatrixClass<char> genericMatrix = new MatrixClass<char>(5);
            MatrixClass<bool> genericMatrix2 = new MatrixClass<bool>(5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeN()
        {
            int n = -5;
            MatrixClass<int> one = new MatrixClass<int>(n);
            MatrixClass<int> two = new MatrixClass<int>(n);
        }

        [TestMethod]
        public void TimeIsMeasuredCorrectly()
        {

            Random rand = new Random();

            Func<int, int, int[,]> generate = (i, j) => {
                int[,] cMas = new int[i, j];

                for (int l = 0; l < i; l++)
                {
                    for (int m = 0; m < j; m++)
                    {
                        cMas[l, m] = i+j;
                    }
                }
                return cMas;
            };//делегат

            int n = 3;
            MatrixClass<int> A = new MatrixClass<int>(n);
            MatrixClass<int> B = new MatrixClass<int>(n);
            MatrixClass<int> C = new MatrixClass<int>(n);
            Stopwatch sw = new Stopwatch();

            A.Generate(generate, n);
            B.Generate(generate, n);

            sw.Start();
            C = A * B;
            sw.Stop();

            TimeSpan ts = sw.Elapsed;
            double result = ts.Milliseconds / 1000;
            double expected = 0.0001;
            Assert.AreEqual(result,expected,0.0001);




        }

        [TestMethod]
        public void SumTwoMatrisces()
        {
            int n = 4;
            MatrixClass<int> one = new MatrixClass<int>(n);
            MatrixClass<int> two = new MatrixClass<int>(n);
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
            MatrixClass<int> one = new MatrixClass<int>(n);
            MatrixClass<int> two = new MatrixClass<int>(n);
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
