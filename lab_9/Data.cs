using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab_9
{
    public class Data
    {
        public static void Print(Mark mark) // вывод объекта
        {
            Console.WriteLine($"Дисциплина: {mark.Name}, Оценка: {mark.MarkValue} ({Mark.translateMark(mark.MarkValue)})");
        }
        public static void Input(MarkArray markArray)
        {
            for (int i = 0; i < markArray.Length; i++)
            {
                Console.WriteLine($"Введите название дисциплины {i + 1}: ");
                string name = Console.ReadLine();
                Console.WriteLine($"Введите оценку по дисциплине {i + 1}: (от 0 до 10)");
                int mark = int.Parse(Console.ReadLine());
                markArray[i] = new Mark(name, mark);
            }
        }
    }
}
