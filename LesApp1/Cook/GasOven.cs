using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1.Cook
{
    /// <summary>
    /// Газова піч
    /// </summary>
    class GasOven : Oven
    {
        /// <summary>
        /// Кількість газу в балоні, який використовує піч
        /// </summary>
        public int GasAmount { get; set; }
        /// <summary>
        /// Дозвіл на приготування
        /// </summary>
        public override bool Access { get; set; } = true;

        public override void ToCook(Cake cake, double timer)
        {
            // перевірка потужності печі (хоча другий раз вказано температури)
            base.ToCook(cake, timer);

            if (!Access)
            {
                return;
            }

            // розрахунок того часу наскільки хватає балону
            // поділивши об'єм балону на 10 ми дізнаємось кількість
            // секунд, далі поділивши на 60^2 ми переведемо це в години
            double canTime = GasAmount / (10.0 * 3600);

            // аналогічно електричній печі
            // якщо час для приготування прирога дорівнює заданому користувачем
            // з допуском наприкла +- 5% (або певний час), то пиріг можна вважати готовим
            // якщо час для приготування - менше від вказаного і -5% то пиріг - сирий
            // якщо час для приготування - більше від вказаного і +5% то пиріг - згорів

            // отже ми маємо:
            // 1. час за який повинен приготуватися пиріг
            // 2. час який обмежує роботу печі і залежить від об'єму балону
            // 3. час який задав користувач на печі

            // перевірка 1, 2 і 3
            if (cake.TimeToCook > Math.Min(canTime, Timer) + cake.Tolerance)
            {
                // до 1
                Console.WriteLine($"\n\tВаш \"{cake.FullName}\" ще сирий.");
                // перевірка 2 і 3
                if (canTime < Timer)
                {
                    Console.WriteLine($"\tУ Вас закінчився газ.");
                }
            }
            else if (cake.TimeToCook < Math.Min(canTime, Timer) - cake.Tolerance)
            {
                Console.WriteLine($"\n\tВаш \"{cake.FullName}\" вже згорів, викиньте його.");
            }
            else
            {
                Console.WriteLine($"\n\tВаш \"{cake.FullName}\" - готовий.");
                // перевірка 2 і 3
                if (canTime <= Timer)
                {
                    Console.WriteLine($"\tА також у Вас закінчився газ.");
                }
            }
        }
    }
}
