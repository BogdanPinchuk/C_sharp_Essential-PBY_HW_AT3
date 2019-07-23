using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oven = LesApp1.Cook.Oven;
using ElectricOven = LesApp1.Cook.ElectricOven;
using GasOven = LesApp1.Cook.GasOven;

namespace LesApp1
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // створюємо рецепт пирога
            Cake cake = new Cake()
            {
                // https://www.povarenok.ru/recipes/show/64177/
                FullName = "Сумасшедший пирог", // час приготування 30 - 40 хв
                PowerCooking = 180,
                TimeToCook = 35.0 / 60.0,   // в годинах
                Tolerance = 5.0 / 60.0      // в годинах
            };

            // Маємо кухню з двома пічками
#if true
            Oven[] kitchen = new Oven[]
                {
                new ElectricOven()
                {
                    MinPower = 0,
                    MaxPower = 300,
                    Name = "Electric Oven",
                    IsSpecialDishes = true
                },
                new GasOven()
                {
                    MinPower = 0,
                    MaxPower = 500,
                    Name = "Gas Oven",
                    GasAmount = 33 * 10 * 60    // розраховано на 33 хв
                }
                };
#endif

            // Ставимо пиріг в печі запускаємо таймер
            for (int i = 0; i < kitchen.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("  " + kitchen[i].Name);
                Console.ResetColor();
                // таймер на 38 хв
                kitchen[i].ToCook(cake, 37.0 / 60.0);
                Console.WriteLine();
            }

            // delay
            Console.ReadKey(true);
        }
    }
}
