using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9
{
    public class Mark
    {
        private int mark;
        private string name;
        private static int objectCount = 0;

        public Mark() // конструктор без параметра
        {
            this.mark = 0;
            this.name = "";
            objectCount++;
        }
        public Mark(string name, int mark) // конструктор с параметром
        {
            this.mark = mark;
            this.name = name;
            objectCount++;
        }
        public Mark(Mark obj) // конструктор копий
        {
            this.name = obj.name;
            this.mark = obj.mark;
            objectCount++;
        }
        public string Name // свойство 
        {
            get { return name; } // возврат в программу
            set { name = value; } // запись в объект
        }
        public int MarkValue // свойство оценки
        {
            get { return mark; }
            set
            {
                if (value >= 0 && value <= 10)
                    mark = value;
                else
                    throw new Exception("Оценка должна быть в диапазоне от 0 до 10!"); // вывод ошибки 
            }
        }
        public string translateMark() // метод перевода оценки, относится к объектам
        {
            if (mark > 7) return "Отлично";
            else if (mark > 5 && mark < 8) return "Хорошо";
            else if (mark > 3 && mark < 6) return "Удовлетворительно";
            else return "Неудовлетворительно";
        }
        public static string translateMark(int mark) // статичная функция, обращаемся к классу
        {
            if (mark > 7) return "Отлично";
            else if (mark > 5 && mark < 8) return "Хорошо";
            else if (mark > 3 && mark < 6) return "Удовлетворительно";
            else return "Неудовлетворительно";
        }

        // унарные операции
        public static Mark operator !(Mark m) // изиенение названия дисциплины (перегрузка)
        {
            m.name = m.name.ToUpper();
            return m;
        }
        public static Mark operator -(Mark m) // обнуление оценки 
        {
            m.mark = 0;
            return m;
        }
        // операции приведения типа
        public static explicit operator int(Mark m) // количество букв в названии (явная)
        {
            return m.name.Length;
        }
        public static implicit operator bool(Mark m) // оценка 4 или больше (неявная)
        {
            if (m.mark >= 4) return true;
            else return false;
        }
        // бинарные операции
        public static Mark operator /(Mark m, string newName) // замена названия дисциплины другим
        {
            m.name = newName;
            return m;
        }
        public static bool operator >=(Mark m1, Mark m2) // сравнение оценок
        {
            if (m1.mark >= m2.mark) return true;
            else return false;
        }
        public static bool operator <=(Mark m1, Mark m2) // сравнение оценок
        {
            if (m1.mark <= m2.mark) return true;
            else return false;
        }

        public static bool operator ==(Mark left, Mark right)
        {
            return EqualityComparer<Mark>.Default.Equals(left, right);
        }

        public static bool operator !=(Mark left, Mark right)
        {
            return !(left == right);
        }

        public static int getObjectCount()
        {
            return objectCount;
        }

        public override bool Equals(object obj)
        {
            return obj is Mark mark &&
                   Name == mark.Name &&
                   MarkValue == mark.MarkValue;
        }
    }
}
