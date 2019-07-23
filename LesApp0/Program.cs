using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animal = LesApp0.Zoo.Animal;
using Cat = LesApp0.Zoo.Cat;
using Dog = LesApp0.Zoo.Dog;
using Bird = LesApp0.Zoo.Bird;

namespace LesApp0
{
    class Program
    {
        static void Main()
        {
            // Підтримка Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // внесення інформації
            Person[] myFriends = new Person[]
            {
                new Person()
                {
                    FullName = "Bogdan",
                    Animal = new Cat()
                    {
                        Age = 2,
                        NickName = "Barbos"
                    }
                },
                new Person()
                {
                    FullName = "Vlad",
                    Animal = new Dog()
                    {
                        Age = 3,
                        NickName = "Sharic"
                    }
                },
                new Person()
                {
                    FullName = "Vadim",
                    Animal = new Bird()
                    {
                        Age = 1,
                        NickName = "Kesha"
                    }
                },
                new Person()
                {
                    FullName = "Nastya",
                }
            };

            // вивід інформації
            for (int i = 0; i < myFriends.Length; i++)
            {
                new Person().PlayWithFriendAnimal(myFriends[i]);
                Console.WriteLine();
            }

            //delay
            DoExitOrRepeat();
        }

        /// <summary>
        /// Метод виходу або повторення методу Main()
        /// </summary>
        static void DoExitOrRepeat()
        {
            Console.WriteLine("\n\nСпробувати ще раз: [т, н]");
            Console.Write("\t");
            var button = Console.ReadKey(true);

            if ((button.KeyChar.ToString().ToLower() == "т") ||
                (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
            {
                Console.Clear();
                Main();
                // без використання рекурсії
                //Process.Start(Assembly.GetExecutingAssembly().Location);
                //Environment.Exit(0);
            }
            else
            {
                // закриває консоль
                Environment.Exit(0);
            }
        }
    }
}
