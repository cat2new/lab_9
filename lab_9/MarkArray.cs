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

        public MarkArray() { marks = new Mark[0]; CollectionCount++;  } // коструктор без параметров
        public MarkArray(int size, bool input)
        {
            if (input)
            {
marks = new Mark[size]; 
                Random random = new Random();
                for (int i = 0; i < size; i++)
                {
                    marks[i] = new Mark($"Дисциплина {i+1}");
                }
            }
        }

    }
}
