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
        static int ReadInt(string message = " ") // проверка на правильность ввода числа
        {
            bool isConvert;
            int number;
            do
            {
                Console.WriteLine(message);
                isConvert = int.TryParse(Console.ReadLine(), out number);
                if (!isConvert)
                {
                    Console.WriteLine("Ошибка ввода! Пожалуйста, введите именно целое число!");
                }
            } while (!isConvert);
            return number;
        }
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

                int mark = ReadInt();
                try
                {
                    markArray[i] = new Mark(name, mark);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }

    }
 }
