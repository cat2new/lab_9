﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9
{
    public class Program
    {
        static void Main(string[] args)
        {
            Mark mark1 = new Mark(); // заполнение конструктора без параметра
            mark1.Name = "Дисциплина 1";
            mark1.MarkValue = 1;

            Mark mark2 = new Mark("Дисциплина 2", 1); // заполнение конструктора с параметром
            Mark mark3 = new Mark(mark1); // заполнение контруктора копий
            // демонстрация
            Console.WriteLine("Созданные объекты: ");
            Console.WriteLine($"Дисциплина: {mark1.Name}, Оценка: {mark1.MarkValue} ({Mark.TranslateMark(mark1.MarkValue)})");
            Data.Print(mark2);
            Data.Print(mark3);


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
            Data.Print(mark1);
            Console.WriteLine("Обнуление оценки: ");
            Data.Print(mark2);
            Console.WriteLine("Замена названия дисциплины: ");
            Data.Print(mark3);
            Console.WriteLine($"Длина названия дисциплины: {mLength} \n" +
                $"Первая оценка больше второй оценки: {cMark}\n" +
                $"Первая оценка меньше второй оценки: {dMark}\n");
            Console.WriteLine("");
            Console.WriteLine($"Количество созданных объектов: {Mark.GetObjectCount()}\n");

            // создание коллекций
            MarkArray markArray = new MarkArray(5, true);
            Console.WriteLine("Массив, заполненный случайными эл: ");
            markArray.PrintArray(); // печать массива со случайными значениями

            Console.WriteLine("\nМассив с вводом с клавиатуры: ");
            MarkArray markArray2 = new MarkArray(2, false);
            Data.Input(markArray2);
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
                Data.Print(markArray[1]);

                Console.WriteLine("\nПолучение элемента с несуществующим индексом");
                Data.Print(markArray[100]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
            }
            FindAboveAverage(markArray); // поиск в коллекции
            Console.WriteLine($"\nКоличество созданных объектов: {Mark.GetObjectCount()}");
            Console.WriteLine($"Количество созданных объектов: {MarkArray.GetCollectionCount()}");
            Console.ReadLine();
        }
        

        public static void FindAboveAverage(MarkArray markArray)
        {
            if (markArray.Length == 0)
            {
                Console.WriteLine("Массив пуст");
                return;
            }

            double average = 0;
            for (int i = 0; i < markArray.Length; i++)
            {
                average += markArray[i].MarkValue;
            }
            average /= markArray.Length;
            average = Math.Round(average, 2); 

            Console.WriteLine($"\nСредняя оценка: {average:F2}");
            Console.WriteLine("Дисциплины с оценкой выше средней: ");

            bool hasAboveAverage = false; 
            for (int i = 0; i < markArray.Length; i++)
            {
                if (markArray[i].MarkValue > average)
                {
                    Data.Print(markArray[i]);
                    hasAboveAverage = true; 
                }
            }

            if (!hasAboveAverage)
            {
                Console.WriteLine("Нет дисциплин с оценкой выше средней");
            }
        }
    }
}
