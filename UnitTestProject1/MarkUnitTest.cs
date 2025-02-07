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
            Mark mark = new Mark();

            mark.MarkValue = 10;
            Assert.AreEqual(10, mark.MarkValue);
        }
        [TestMethod]
        public void MarkValue_ThrowExceptionForInvalidValue()
        {
            Mark mark = new Mark();

            Assert.ThrowsException<Exception>((() => mark.MarkValue = 11));
        }
        [TestMethod]
        public void TranslateMark_Method_ReturnCorrectTranslation()
        {
            Mark markExcellent = new Mark("Дисциплина", 9);
            Mark markGood = new Mark("Дисциплина", 7);
            Mark markSatisfactory = new Mark("Дисциплина", 5);
            Mark markPoor = new Mark("Дисциплина", 3);


            var excellemntMark = markExcellent.translateMark();
            Assert.AreEqual("Отлично", excellemntMark);
            Assert.AreEqual("Хорошо", markGood.translateMark());
            Assert.AreEqual("Удовлетворительно", markSatisfactory.translateMark());
            Assert.AreEqual("Неудовлетворительно", markPoor.translateMark());
        }
        [TestMethod]
        public void TranslateMark_Static_ReturnCorrectTranslation()
        {
            Assert.AreEqual("Отлично", Mark.translateMark(9));
            Assert.AreEqual("Хорошо", Mark.translateMark(7));
            Assert.AreEqual("Удовлетворительно", Mark.translateMark(5));
            Assert.AreEqual("Неудовлетворительно", Mark.translateMark(3));
        }
        [TestMethod]
        public void GetObjectCount_ReturnCollection()
        {
            int initialCount = Mark.getObjectCount();
            Mark mark1 = new Mark("Дисциплина", 9);
            Mark mark2 = new Mark("Дисциплина", 7);

            int count = Mark.getObjectCount();

            Assert.AreEqual(initialCount + 2, count);
        }

        [TestMethod]
        public void OperatorNot_ConvertNameToUpperCase()
        {
            Mark mark = new Mark("дисциплина", 7);

            mark = !mark;

            Assert.AreEqual("ДИСЦИПЛИНА", mark.Name);
        }
        [TestMethod]
        public void OperatorMinus_ResertMarkToZero()
        {
            Mark mark = new Mark("дисциплина", 7);

            mark = -mark;

            Assert.AreEqual(0, mark.MarkValue);
        }
        [TestMethod]
        public void OperatorSlash_ChangeName()
        {
            Mark mark = new Mark("дисциплина", 7);

            mark = mark / "Новая дисциплина";

            Assert.AreEqual("Новая дисциплина", mark.Name);
        }
        [TestMethod]
        public void OperatorGreaterThanOrEqual_CompareMarks()
        {
            Mark mark1 = new Mark("Дисциплина", 9);
            Mark mark2 = new Mark("Дисциплина", 7);

            Assert.IsTrue(mark1 >= mark2);
        }
        [TestMethod]
        public void OperatorLessThanOrEqual_CompareMarks()
        {
            Mark mark1 = new Mark("Дисциплина", 6);
            Mark mark2 = new Mark("Дисциплина", 7);

            Assert.IsTrue(mark1 <= mark2);
        }
        [TestMethod]
        public void OperatorInt_ReturnNameLength()
        {
            Mark mark = new Mark("Дисциплина", 8);

            int length = (int)mark;

            Assert.AreEqual(10, length);
        }
        [TestMethod]
        public void OperatorBool_ReturnTrueForPassingMarks()
        {
            Mark mark = new Mark("Дисциплина", 4);

            Assert.IsTrue(mark);
        }
    }



}