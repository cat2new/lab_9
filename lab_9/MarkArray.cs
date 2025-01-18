using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab_9
{
    internal class MarkArray
    {
        Mark[] marks;
        private static int CollectionCount = 0; // счетчик коллекций

        public MarkArray() { marks = new Mark[0]; CollectionCount++; } // коструктор без параметров
        public MarkArray(int size, bool input) // коструктор с параметром
        {
            if (input)
            {
                marks = new Mark[size];
                Random random = new Random();
                for (int i = 0; i < size; i++)
                {
                    marks[i] = new Mark($"Дисциплина {i + 1}", random.Next(0, 11));
                }
                CollectionCount++;
            }
            else marks = new Mark[size];
        }
        public MarkArray(MarkArray obj) // копии
        {
            marks = new Mark[obj.marks.Length];
            for (int i = 0; i < obj.marks.Length; i++)
            {
                marks[i] = new Mark(obj.marks[i]);
            }
            CollectionCount++;
        }
        public void PrintArray()// печать
        {

            foreach (var mark in marks)
            {
                mark.Print();
            }
        }
        public int Length
        {
            get { return marks.Length; }
        }
        public Mark this[int index] 
        {
            get
            {
                if  (index<0 || index >= marks.Length)
                    throw new IndexOutOfRangeException("Индекс вне диапазона!");
                return marks[index];
            }
            set
            {
                if (index < 0 || index >= marks.Length)
                    throw new IndexOutOfRangeException("Индекс вне диапазона!");
                marks[index] = value;
            }
        }
        public static int getCollectionCount()
        {
            return CollectionCount;
        }

    }
}