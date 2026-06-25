using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1;
using System;

namespace _1.Tests
{
    [TestClass]
    public class MatrixProcessorTests
    {
        [TestMethod]
        public void ProcessRows_WhenFirstRowIsAllOnes_ShiftsDownAndFillsTopWithZeros()
        {
            // Arrange
            int n = 3;
            int[,] matrix = new int[,]
            {
                { 1, 1, 1 },
                { 0, 0, 0 },
                { 1, 0, 1 }
            };

            // Act
            MatrixProcessor.ProcessRows(matrix, n);

            // Assert
            // Первая строка должна быть нулями
            CollectionAssert.AreEqual(new int[] { 0, 0, 0 }, GetRow(matrix, 0));
            // Вторая строка должна быть тем, что было в первой
            CollectionAssert.AreEqual(new int[] { 1, 1, 1 }, GetRow(matrix, 1));
            // Третья строка должна быть тем, что было во второй
            CollectionAssert.AreEqual(new int[] { 0, 0, 0 }, GetRow(matrix, 2));
        }

        [TestMethod]
        public void ProcessRows_WhenMiddleRowIsAllOnes_ShiftsDownAndFillsTopWithZeros()
        {
            // Arrange
            int n = 3;
            int[,] matrix = new int[,]
            {
                { 0, 0, 0 },
                { 1, 1, 1 },
                { 1, 0, 1 }
            };

            // Act
            MatrixProcessor.ProcessRows(matrix, n);

            // Assert
            CollectionAssert.AreEqual(new int[] { 0, 0, 0 }, GetRow(matrix, 0)); // верхняя — нули
            CollectionAssert.AreEqual(new int[] { 0, 0, 0 }, GetRow(matrix, 1)); // была 0-я
            CollectionAssert.AreEqual(new int[] { 1, 1, 1 }, GetRow(matrix, 2)); // была 1-я (все единицы)
        }

        [TestMethod]
        public void ProcessRows_WhenLastRowIsAllOnes_ShiftsDownAndFillsTopWithZeros()
        {
            // Arrange
            int n = 3;
            int[,] matrix = new int[,]
            {
                { 0, 0, 0 },
                { 1, 0, 1 },
                { 1, 1, 1 }
            };

            // Act
            MatrixProcessor.ProcessRows(matrix, n);

            // Assert
            CollectionAssert.AreEqual(new int[] { 0, 0, 0 }, GetRow(matrix, 0));
            CollectionAssert.AreEqual(new int[] { 0, 0, 0 }, GetRow(matrix, 1));
            CollectionAssert.AreEqual(new int[] { 1, 0, 1 }, GetRow(matrix, 2));
        }

        [TestMethod]
        public void ProcessRows_WhenNoRowIsAllOnes_MatrixRemainsUnchanged()
        {
            // Arrange
            int n = 3;
            int[,] original = new int[,]
            {
                { 1, 1, 0 },
                { 0, 1, 1 },
                { 1, 0, 1 }
            };
            int[,] matrix = CloneMatrix(original, n);

            // Act
            MatrixProcessor.ProcessRows(matrix, n);

            // Assert
            for (int r = 0; r < n; r++)
                CollectionAssert.AreEqual(GetRow(original, r), GetRow(matrix, r));
        }

        [TestMethod]
        public void ProcessRows_Handles1x1Matrix_Correctly()
        {
            // Arrange
            int n = 1;
            int[,] matrix = new int[1, 1] { { 1 } };

            // Act
            MatrixProcessor.ProcessRows(matrix, n);

            // Assert: 1x1 из единиц → сдвигается (ничего не меняется по сути), верхняя (она же единственная) становится 0
            Assert.AreEqual(0, matrix[0, 0]);
        }

        // Вспомогательный метод для получения строки как массива
        private int[] GetRow(int[,] matrix, int rowIndex)
        {
            int cols = matrix.GetLength(1);
            int[] row = new int[cols];
            for (int c = 0; c < cols; c++)
                row[c] = matrix[rowIndex, c];
            return row;
        }

        private int[,] CloneMatrix(int[,] source, int n)
        {
            int[,] dest = new int[n, n];
            Array.Copy(source, dest, source.Length);
            return dest;
        }
    }
}
