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
    public class MarkArrayUnitTest
    {
        [TestMethod]
        public void Constructor_Default_ZeroLrngth()
        {   //Arrange
            MarkArray markArray = new MarkArray();

            // Act
            int length = markArray.Length;

            // Assert
            Assert.AreEqual(0, length);
        }
        [TestMethod]
        public void Constructor_WithKeyboard_InitializeArrayWithCorrectLength()
        {
            // Arrange
            int size = 5;
            MarkArray markArray = new MarkArray(size, false);

            // Act
            int length = markArray.Length;

            // Assert
            Assert.AreEqual(size, length);
        }

        [TestMethod]
        public void Constructor_WithRandom_InitializeArrayWithRandom()
        {
            // Arrange
            int size = 5;
            MarkArray markArray = new MarkArray(size, true);

            // Act
            int length = markArray.Length;

            // Assert
            Assert.AreEqual(size, length);
            Assert.IsNotNull(markArray[0].Name);
            Assert.IsTrue(markArray[0].MarkValue >= 0 && markArray[0].MarkValue <= 10);
        }

        [TestMethod]
        public void Constructor_Copy_CreateCopy()
        {
            // Arrange
            MarkArray markArray = new MarkArray(3, true);

            // Act
            MarkArray markArraycopy = new MarkArray(markArray);

            // Assert
            Assert.AreEqual(markArray.Length, markArraycopy.Length);

            for (int i = 0; i < markArray.Length; i++)
            {
                Assert.AreEqual(markArray[i], markArraycopy[i]);
            }
        }

        [TestMethod]
        public void GetIndexer_OutOfRange_ThrowIndexOutOfRangeException()
        {
            // Arrange
            MarkArray markArray = new MarkArray(5, false);

            // Act & Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => { Mark mark = markArray[10]; });
        }

        [TestMethod]
        public void GetIndexer_ValidIndex_ReturnCorrectMark()
        {
            // Arrange
            MarkArray markArray = new MarkArray(5, true);
            int index = 2;

            // Act
            Mark mark = markArray[index];

            // Assert
            Assert.IsNotNull(mark);
            Assert.IsTrue(mark.MarkValue >= 0 && mark.MarkValue <= 10);
        }

        [TestMethod]
        public void SetIndexer_ValidIndex_SetCorrectMark()
        {
            // Arrange
            MarkArray markArray = new MarkArray(5, true);
            Mark newMark = new Mark("Дисципл 6", 8);
            int index = 2;

            // Act
            markArray[index] = newMark;
            Mark updatedMark = markArray[index];

            // Assert
            Assert.AreEqual(newMark, updatedMark);
        }

        [TestMethod]
        public void SetIndexer_OutOfRange_ThrowIndexOutOfRangeException()
        {
            // Arrange
            MarkArray markArray = new MarkArray(5, true);
            Mark newMark = new Mark("Дисципл 6", 8);

            // Act & Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => { markArray[10] = newMark; });
        }

        [TestMethod]
        public void GetCollectionCount_Random_Increment()
        {
            // Arrange
            MarkArray markArray = new MarkArray(5, true);
            int initialCount = MarkArray.getCollectionCount();

            // Act
            MarkArray markArray1 = new MarkArray(5, true);


            // Assert
            Assert.AreEqual(++initialCount, MarkArray.getCollectionCount());
        }

        [TestMethod]
        public void GetCollectionCount_Keyboard_WithOutIncrement()
        {
            // Arrange
            MarkArray markArray = new MarkArray(5, true);
            int initialCount = MarkArray.getCollectionCount();

            // Act        
            MarkArray markArray2 = new MarkArray(5, false);

            // Assert
            Assert.AreEqual(initialCount, MarkArray.getCollectionCount());
        }

    }
    
}
        
        
    

