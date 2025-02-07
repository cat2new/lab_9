using lab_9;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class ProgramUnitTest
    {
        [TestMethod]
        public void FindAboveAverage_WithArrayWithNoMark()
        {
            // Arrange
            MarkArray markArray = new MarkArray(0, false);

            // Захватываем консольный вывод
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            Program.FindAboveAverage(markArray);

            // Assert
            string result = stringWriter.ToString();
            Assert.IsTrue(result.Contains("Массив пуст"));
        }
        [TestMethod]
        public void FindAboveAverage_WithSingleMark_ShouldNotPrintAboveAverage()
        {
            // Arrange
            MarkArray markArray1 = new MarkArray(1, false);
            markArray1[0] = new Mark("Предмет 1", 5);

            // Захватываем консольный вывод
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            Program.FindAboveAverage(markArray1);

            // Assert
            string result = stringWriter.ToString();
            Assert.IsTrue(result.Contains("Средняя оценка: 5"));
            Assert.IsTrue(result.Contains("Дисциплины с оценкой выше средней:"));
            Assert.IsTrue(result.Contains("Нет дисциплин с оценкой выше средней"));
        }

        [TestMethod]
        public void FindAboveAverage_WithMultipleMarks_ShouldPrintAboveAverageMarks()
        {
            // Arrange
            MarkArray markArray2 = new MarkArray(3, false);
            markArray2[0] = new Mark("Предмет 1", 5);
            markArray2[1] = new Mark("Предмет 2", 7);
            markArray2[2] = new Mark("Предмет 3", 9);

            // Захватываем консольный вывод
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            Program.FindAboveAverage(markArray2);

            // Assert
            string result = stringWriter.ToString();
            Assert.IsTrue(result.Contains("Средняя оценка: 7"));
            Assert.IsTrue(result.Contains("Дисциплины с оценкой выше средней:"));
            Assert.IsFalse(result.Contains("Предмет 1"));
            Assert.IsFalse(result.Contains("Предмет 2"));
            Assert.IsTrue(result.Contains("Предмет 3"));
        }
    }
}
