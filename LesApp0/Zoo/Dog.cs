using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0.Zoo
{
    /// <summary>
    /// Собака
    /// </summary>
    class Dog : Animal
    {
        public override void Play()
        {
            Console.WriteLine("Любить гратись в м'ячик.");
        }

        public override void Voice()
        {
            Console.WriteLine("Гавкає.");
        }
    }
}
