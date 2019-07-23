using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0.Zoo
{
    /// <summary>
    /// Кіт
    /// </summary>
    class Cat : Animal
    {
        public override void Play()
        {
            Console.WriteLine("Любить гратись з лазерною указкою.");
        }

        public override void Voice()
        {
            Console.WriteLine("Муркає.");
        }
    }
}
