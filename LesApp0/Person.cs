using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animal = LesApp0.Zoo.Animal;

namespace LesApp0
{
    /// <summary>
    /// Хазяїн
    /// </summary>
    class Person
    {
        /// <summary>
        /// ПІБ
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Домашній улюбленець
        /// </summary>
        public Animal Animal { get; set; }

        /// <summary>
        /// Гра хазяїна з улюбленцем
        /// </summary>
        /// <param name="person">Хазяїн</param>
        public void PlayWithFriendAnimal(Person person)
        {
            if (person.Animal != null)
            {
                person.Animal.Play();
                person.Animal.Voice();
            }
            else
            {
                Console.WriteLine($"У {person.FullName} немає домашнього улюбленця.");
            }
        }

    }
}
