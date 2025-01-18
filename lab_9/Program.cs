using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mark mark1 = new Mark(); // замолнение конструктора без параметра
            mark1.Name = "Дисциплина 1";
            mark1.MarkValue = 1;

            Mark mark2 = new Mark("Дисциплина 2", 1); // заполнение конструктора с параметром
            Mark mark3 = new Mark(mark1); // заполнение контруктора копий
            // демонстрация
            Console.WriteLine("Созданные объекты: ");
            Console.WriteLine($"Дисциплина: {mark1.Name}, Оценка: {mark1.MarkValue} ({Mark.translateMark(mark1.MarkValue)})");
            mark2.Print();
            mark3.Print();


            // операции
            mark1 = !mark1;
            mark2 = -mark2;
            mark3 = mark3 / "Новое название дисциплины";
            int mLength = (int)mark3;
            if (mark1) Console.WriteLine(">4");
            else Console.WriteLine("<4");
            bool cMark = mark1 >= mark2;
            bool dMark = mark1 <= mark2;

            // демонстрация
            Console.WriteLine("\nПерегруженные операции: ");
            Console.WriteLine("Изменение регистра: ");
            mark1.Print();
            Console.WriteLine("Обнуление оценки: ");
            mark2.Print();
            Console.WriteLine("Замена названия дисциплины: ");
            mark3.Print();
            Console.WriteLine($"Длина названия дисциплины: {mLength} \n" +
                $"Первая оценка > 2: {cMark}\n" +
                $"Первая оценка < 2: {dMark}\n");
            Console.WriteLine("");
            Console.WriteLine($"Количество созданных объектов: {Mark.getObjectCount()}\n");

            // создание коллекций
            MarkArray markArray = new MarkArray(5, true);
            Console.WriteLine("Массив, заполненный случайными эл: ");
            markArray.PrintArray(); // печать массива со случайными значениями

            Console.WriteLine("\nМассив с вводом с клавиатуры: ");
            MarkArray markArray2 = new MarkArray(2, false);
            for (int i = 0; i < markArray2.Length; i++)
            {
                Console.WriteLine($"Введите название дисциплины {i + 1}: ");
                string name = Console.ReadLine();
                Console.WriteLine($"Введите оценку по дисциплине {i + 1}: (от 0 до 10)");
                int mark = int.Parse(Console.ReadLine());
                markArray2[i] = new Mark(name, mark);
            }
            markArray2.PrintArray();
            MarkArray markArray3 = new MarkArray(markArray); // копия
            Console.WriteLine("\nКопия массива: ");
            markArray3.PrintArray();

            try
            {
                Console.WriteLine("\nЗапись элемента с существующим индексом");
                markArray[1] = mark1;

                Console.WriteLine("\nЗапись элемента с несуществующим индексом");
                markArray[100] = mark1;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
            }

            try
            {
                Console.WriteLine("\nПолучение элемента с существующим индексом");
                markArray[1].Print();

                Console.WriteLine("\nПолучение элемента с несуществующим индексом");
                markArray[100].Print();
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
            }
            FindAboveAverage(markArray); // поиск в коллекции
            Console.WriteLine($"\nКоличество созданных объектов: {Mark.getObjectCount()}");
            Console.WriteLine($"Количество созданных объектов: {MarkArray.getCollectionCount()}");
            Console.ReadLine();
        }
        // уточнить про операции, что негде использовать
        static void FindAboveAverage(MarkArray markArray)
        {
            double average = 0;
            for (int i=0; i < markArray.Length; i++)
            {
                average += markArray[i].MarkValue;
            }
            average /= markArray.Length; // уточнить про среднюю оценку, округление
            Console.WriteLine($"\nСредняя оценка: {average:F2}");
            Console.WriteLine("Дисциплиы с оценкой выше средней: ");

            for (int i = 0;  i < markArray.Length; i++)
            {
                if (markArray[i].MarkValue > average)
                {
                    markArray[i].Print();
                }
            }
        }
    }
}
// спросить: добавить выбор формирования массива