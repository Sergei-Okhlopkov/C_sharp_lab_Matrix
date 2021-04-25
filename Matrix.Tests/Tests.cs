using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
    }
}
