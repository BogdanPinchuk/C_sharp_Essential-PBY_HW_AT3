using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0.Zoo
{
    /// <summary>
    /// Тварини
    /// </summary>
    class Animal
    {
        /// <summary>
        /// Кличка
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// Вік
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Грати
        /// </summary>
        public virtual void Play()
        {
            Console.WriteLine("Грає з твариною.");
        }

        /// <summary>
        /// Звучати
        /// </summary>
        public virtual void Voice()
        {
            Console.WriteLine("Тварина подає голос.");
        }

    }
}
