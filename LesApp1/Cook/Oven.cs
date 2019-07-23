using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Примітка. Деякі параметри необхідно коректно заповнювати, а тому необхідно
// виконувати дії над полями, а якщо їм поставити індентифікатор readonly
// то свойства не матимуть доступу до їх редагування

namespace LesApp1.Cook
{
    /// <summary>
    /// Піч
    /// </summary>
    class Oven
    {
        /// <summary>
        /// Мінімальна потужність
        /// </summary>
        private int minPower;
        /// <summary>
        /// Максимальна потужність
        /// </summary>
        private int maxPower;
        /// <summary>
        /// Назва печі
        /// </summary>
        private string name;
        /// <summary>
        /// Поточна потужність (якщо піч увімкнена)
        /// </summary>
        private int currenPower;
        /// <summary>
        /// Таймер на час приготування
        /// </summary>
        private double timer;
        /// <summary>
        /// Дозвіл на приготування
        /// </summary>
        public virtual bool Access { get; set; }

        /// <summary>
        /// Мінімальна потужність
        /// не може бути нижче нуля і більше максимальної потужності
        /// </summary>
        public virtual int MinPower
        {
            get { return minPower; }
            set
            {
                // перевірка на < 0
                if (value < 0)
                {
                    Error();
                    Access &= false;
                }
                else
                {
                    // присвоєння даних
                    minPower = value;
                    Access &= true;
                    // корегування інших характеристик

                    // якщо поточна потужність менша то установлюємо мінімальну
                    if (currenPower < minPower)
                    {
                        currenPower = minPower;
                    }

                    // якщо максимальна потужність менша то встинаовлюємо мінімальну
                    // фізично, це можна пояснити, що приклад працює лише 
                    // на одній потужності і не має регулятора
                    if (maxPower < minPower)
                    {
                        maxPower = minPower;
                    }
                }
            }
        }
        /// <summary>
        /// Максимальна потужність
        /// не може бути нижче нуля і менше мінімальної потужності
        /// </summary>
        public int MaxPower
        {
            get { return maxPower; }
            set
            {
                // перевірка на < 0
                if (value < 0)
                {
                    Error();
                    Access &= false;
                }
                else
                {
                    // присвоєння даних
                    maxPower = value;
                    Access &= true;
                    // корегування інших характеристик

                    // якщо поточна потужність більша то установлюємо максимальну
                    if (currenPower > maxPower)
                    {
                        currenPower = maxPower;
                    }

                    // якщо мінімальна потужність більша то встинаовлюємо максимальну
                    // фізично, це можна пояснити, що приклад працює лише 
                    // на одній потужності і не має регулятора
                    if (maxPower < minPower)
                    {
                        minPower = maxPower;
                    }
                }
            }
        }
        /// <summary>
        /// Поточна потужність (якщо піч увімкнена)
        /// </summary>
        public int CurrentPower
        {
            get { return currenPower; }
            private set
            {
                if (minPower <= value ||
                    value <= maxPower)
                {
                    currenPower = value;
                    Access &= true;
                }
                else
                {
                    Error();
                    Access &= false;
                }
            }
        }
        /// <summary>
        /// Таймер на час приготування, годин
        /// тип double тому, що готування проходить доволі довго, а
        /// задавати в секундах (і тип int) не зручно, тому ефективніше 
        /// задати в годинах дійсними числами
        /// </summary>
        public double Timer
        {
            get { return timer; }
            private set
            {
                // перевірка на < 0
                if (value < 0)
                {
                    Error();
                    Access &= false;
                }
                else
                {
                    timer = value;
                    Access &= true;
                }
            }
        }
        /// <summary>
        /// Назва печі
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (value == string.Empty)
                {
                    Error();
                    Access &= false;
                }
                else
                {
                    name = value;
                    Access &= true;
                }
            }
        }

        /// <summary>
        /// Ініціалізація полів
        /// </summary>
        public Oven()
        {
            //MinPower = 0;
            //MaxPower = 0;       // можливо не робоча, або дані ще не введені
            Name = "Oven";
            //CurrentPower = 0;    // вимкнена
            //Timer = 0;
        }

        /// <summary>
        /// Приготувати
        /// </summary>
        /// <param name="cake">Пиріг</param>
        /// <param name="timer">Час приготуванння</param>
        public virtual void ToCook(Cake cake, double timer)
        {
            // передача часу заданого користувачем печі, тобто вмикаємо піч
            Timer = timer;

            // перевірка температури печі і необхідної для пирога
            if (cake.PowerCooking > MaxPower ||
                cake.PowerCooking < MinPower)
            {
                Console.WriteLine($"\n\tПіч \"{Name}\" не підходить для приготування \"{cake.FullName}\".");
                Access &= false;
            }
            else
            {
                // установка необхідної для приготування температури
                CurrentPower = cake.PowerCooking;
                Access &= true;
            }
        }

        /// <summary>
        /// Виведення сповіщення про хибно введені дані
        /// </summary>
        private void Error()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tЗадані невірні дані.\n");
            Console.ResetColor();
        }

    }
}
