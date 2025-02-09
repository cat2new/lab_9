using lab_9;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class MarkUnitTest
    {
        [TestMethod]
        public void Constructor_Default_InitializeWithZeroMarkAndEmptyName()
        {
            // Arrange
            Mark mark = new Mark();

            // Act & Assert
            Assert.AreEqual(0, mark.MarkValue);
            Assert.AreEqual("", mark.Name);
        }
        [TestMethod]
        public void Constructor_WithParam_InitializeWithValues()
        {
            // Arrange
            Mark mark = new Mark("Дисциплина", 10);

            // Act & Assert
            Assert.AreEqual("Дисциплина", mark.Name);
            Assert.AreEqual(10, mark.MarkValue);
        }

        [TestMethod]
        public void Constructor_Copy_CreateCopy()
        {
            // Arrange
            Mark mark = new Mark("Дисциплина", 9);
            Mark copy = new Mark(mark);

            // Act & Assert
            Assert.AreEqual(mark, copy);
        }
        [TestMethod]
        public void MarkValue_ValidValue()
        {
            // Arrange
            Mark mark = new Mark();

            // Act & Assert
            mark.MarkValue = 10;
            Assert.AreEqual(10, mark.MarkValue);
        }
        [TestMethod]
        public void MarkValue_ThrowExceptionForInvalidValue()
        {
            // Arrange
            Mark mark = new Mark();

            // Act & Assert
            Assert.ThrowsException<Exception>((() => mark.MarkValue = 11));
        }
        [TestMethod]
        public void TranslateMark_Method_ReturnCorrectTranslation()
        {
            // Arrange
            Mark markExcellent = new Mark("Дисциплина", 9);
            Mark markGood = new Mark("Дисциплина", 7);
            Mark markSatisfactory = new Mark("Дисциплина", 5);
            Mark markPoor = new Mark("Дисциплина", 3);

            // Act & Assert
            var excellemntMark = markExcellent.TranslateMark();
            Assert.AreEqual("Отлично", excellemntMark);
            Assert.AreEqual("Хорошо", markGood.TranslateMark());
            Assert.AreEqual("Удовлетворительно", markSatisfactory.TranslateMark());
            Assert.AreEqual("Неудовлетворительно", markPoor.TranslateMark());
        }
        [TestMethod]
        public void TranslateMark_Static_ReturnCorrectTranslation()
        {
            // Act & Assert
            Assert.AreEqual("Отлично", Mark.TranslateMark(9));
            Assert.AreEqual("Хорошо", Mark.TranslateMark(7));
            Assert.AreEqual("Удовлетворительно", Mark.TranslateMark(5));
            Assert.AreEqual("Неудовлетворительно", Mark.TranslateMark(3));
        }
        [TestMethod]
        public void GetObjectCount_ReturnCollection()
        {
            // Arrange
            int initialCount = Mark.GetObjectCount();
            Mark mark1 = new Mark("Дисциплина", 9);
            Mark mark2 = new Mark("Дисциплина", 7);

            // Act
            int count = Mark.GetObjectCount();

            // Assert
            Assert.AreEqual(initialCount + 2, count);
        }

        [TestMethod]
        public void OperatorNot_ConvertNameToUpperCase()
        {
            // Arrange
            Mark mark = new Mark("дисциплина", 7);

            // Act
            mark = !mark;

            // Assert
            Assert.AreEqual("ДИСЦИПЛИНА", mark.Name);
        }
        [TestMethod]
        public void OperatorMinus_ResertMarkToZero()
        {
            // Arrange
            Mark mark = new Mark("дисциплина", 7);

            // Act
            mark = -mark;

            // Assert
            Assert.AreEqual(0, mark.MarkValue);
        }
        [TestMethod]
        public void OperatorSlash_ChangeName()
        {
            // Arrange
            Mark mark = new Mark("дисциплина", 7);

            // Act
            mark = mark / "Новая дисциплина";

            // Assert
            Assert.AreEqual("Новая дисциплина", mark.Name);
        }
        [TestMethod]
        public void OperatorGreaterThanOrEqual_CompareMarks()
        {
            // Arrange
            Mark mark1 = new Mark("Дисциплина", 9);
            Mark mark2 = new Mark("Дисциплина", 7);

            // Act & Assert
            Assert.IsTrue(mark1 >= mark2);
        }
        [TestMethod]
        public void OperatorLessThanOrEqual_CompareMarks()
        {
            // Arrange
            Mark mark1 = new Mark("Дисциплина", 6);
            Mark mark2 = new Mark("Дисциплина", 7);

            // Act & Assert
            Assert.IsTrue(mark1 <= mark2);
        }
        [TestMethod]
        public void OperatorInt_ReturnNameLength()
        {
            // Arrange
            Mark mark = new Mark("Дисциплина", 8);

            // Act
            int length = (int)mark;

            // Assert
            Assert.AreEqual(10, length);
        }
        [TestMethod]
        public void OperatorBool_ReturnTrueForPassingMarks()
        {
            // Arrange
            Mark mark = new Mark("Дисциплина", 4);

            // Act & Assert
            Assert.IsTrue(mark);
        }
    }



}