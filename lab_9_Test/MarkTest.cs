using lab_9;
namespace lab_9Test
{
    [TestClass]
    public sealed class MarkTest
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
            Mark mark = new Mark("����������", 10);

            // Act & Assert
            Assert.AreEqual("����������", mark.Name);
            Assert.AreEqual(10, mark.MarkValue);
        }

        [TestMethod]
        public void Constructor_Copy_CreateCopy()
        {
            // Arrange
            Mark mark = new Mark("����������", 9);
            Mark copy = new Mark(mark);

            // Act & Assert
            Assert.AreEqual(mark, copy);
        }

        [TestMethod]
        public void MarkValue_ValidValues()
        {
            // Arrange
            Mark mark = new Mark();

            // Act & Assert
            mark.MarkValue = 5;
            Assert.AreEqual(5, mark.MarkValue);

            mark.MarkValue = 10;
            Assert.AreEqual(10, mark.MarkValue);
        }

        [TestMethod]
        public void MarkValue_ThrowExceptionForInvalidValue()
        {
            // Arrange
            Mark mark = new Mark();

            // Act
            Assert.ThrowsException<Exception>(() => { mark.MarkValue = 11; });
        }

        [TestMethod]
        public void TranslateMark_Method_ReturnCorrectTranslation()
        {
            // Arrange
            Mark markExcellent = new Mark("����������", 9);
            Mark markGood = new Mark("����������", 7);
            Mark markSatisfactory = new Mark("����������", 5);
            Mark markPoor = new Mark("����������", 2);

            // Act & Assert
            Assert.AreEqual("�������", markExcellent.translateMark());
            Assert.AreEqual("������", markGood.translateMark());
            Assert.AreEqual("�����������������", markSatisfactory.translateMark());
            Assert.AreEqual("�������������������", markPoor.translateMark());
        }

        [TestMethod]
        public void TranslateMark_Static_ReturnCorrectTranslation()
        {
            // Act & Assert
            Assert.AreEqual("�������", Mark.translateMark(9));
            Assert.AreEqual("������", Mark.translateMark(7));
            Assert.AreEqual("�����������������", Mark.translateMark(5));
            Assert.AreEqual("�������������������", Mark.translateMark(2));
        }

        [TestMethod]
        public void GetObjectCount_ReturnCorrectCount()
        {
            // Arrange
            int initialCount = Mark.getObjectCount();
            Mark mark1 = new Mark("����������1", 9);
            Mark mark2 = new Mark("����������2", 3);

            // Act
            int count = Mark.getObjectCount();

            // Assert
            Assert.AreEqual(initialCount + 2, count);
        }

        [TestMethod]
        public void OperatorNot_ConvertNameToUppercase()
        {
            // Arrange
            Mark mark = new Mark("����������", 5);

            // Act
            mark = !mark;

            // Assert
            Assert.AreEqual("����������", mark.Name);
        }

        [TestMethod]
        public void OperatorMinus_ResetMarkToZero()
        {
            // Arrange
            Mark mark = new Mark("����������", 5);

            // Act
            mark = -mark;

            // Assert
            Assert.AreEqual(0, mark.MarkValue);
        }

        [TestMethod]
        public void OperatorSlash_ChangeName()
        {
            // Arrange
            Mark mark = new Mark("����������", 8);

            // Act
            mark = mark / "���������������";

            // Assert
            Assert.AreEqual("���������������", mark.Name);
        }

        [TestMethod]
        public void OperatorGreaterThanOrEqual_CompareMarks()
        {
            // Arrange
            Mark mark1 = new Mark("����������1", 8);
            Mark mark2 = new Mark("����������2", 7);

            // Act & Assert
            Assert.IsTrue(mark1 >= mark2);
        }

        [TestMethod]
        public void OperatorLessThanOrEqual_CompareMarks()
        {
            // Arrange
            Mark mark1 = new Mark("����������1", 6);
            Mark mark2 = new Mark("����������2", 7);

            // Act & Assert
            Assert.IsTrue(mark1 <= mark2);
        }
        [TestMethod]
        public void OperatorInt_ReturnNameLength()
        {
            // Arrange
            Mark mark = new Mark("����������", 8);

            // Act
            int length = (int)mark;

            // Assert
            Assert.AreEqual(10, length);
        }

        [TestMethod]
        public void OperatorBool_ReturnTrueForPassingMarks()
        {
            // Arrange
            Mark mark = new Mark("����������", 6);

            // Act & Assert
            Assert.IsTrue(mark);
        }
    }
}