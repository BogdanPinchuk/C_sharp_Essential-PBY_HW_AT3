using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1.Cook
{
    /// <summary>
    /// Електрична піч
    /// </summary>
    class ElectricOven : Oven
    {
        /// <summary>
        /// Чи наявний спеціальний посуд для приготування їжі в такій печі
        /// </summary>
        public bool IsSpecialDishes { get; set; }
        /// <summary>
        /// Дозвіл на приготування
        /// </summary>
        public override bool Access { get; set; } = true;

        /// <summary>
        /// Приготувати
        /// </summary>
        /// <param name="cake"></param>
        /// <param name="timer"></param>
        public override void ToCook(Cake cake, double timer)
        {
            // перевірка температури печі
            base.ToCook(cake, timer);

            // перевірка можливості приготування
            if (!Access)
            {
                return;
            }

            // Перевірка наявності спеціального посуду, тому що наприклад не можна металевий посуд використовувати
            if (!IsSpecialDishes)
            {
                Console.WriteLine($"\n\tВи не можете приготувати {cake.FullName} через відсутність спеціального посуду.");
                return;
            }

            // так як, я вирішив замість int використовувати double
            // то я можу зробити такі перевірки, що є більш реальними
            // якщо час для приготування прирога дорівнює заданому користувачем
            // з допуском наприкла +- 5% (або певний час), то пиріг можна вважати готовим
            // якщо час для приготування - менше від вказаного і -5% то пиріг - сирий
            // якщо час для приготування - більше від вказаного і +5% то пиріг - згорів

            // перевірка
            if (cake.TimeToCook > Timer + cake.Tolerance)
            {
                Console.WriteLine($"\n\tВаш \"{cake.FullName}\" ще сирий, печіть далі.");
            }
            else if (cake.TimeToCook < Timer - cake.Tolerance)
            {
                Console.WriteLine($"\n\tВаш \"{cake.FullName}\" вже згорів, викиньте його.");
            }
            else
            {
                Console.WriteLine($"\n\tВаш \"{cake.FullName}\" - готовий.");
            }
        }
    }
}
