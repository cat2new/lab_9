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
                $"Первая оценка < 2: {dMark}\n";
            Console.WriteLine("");
            Console.WriteLine($"Количество созданных объектов: {Mark.getObjectCount()}\n");


        }

}
