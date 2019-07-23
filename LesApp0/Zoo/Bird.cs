using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0.Zoo
{
    /// <summary>
    /// Пташка
    /// </summary>
    class Bird : Animal
    {
        public override void Play()
        {
            Console.WriteLine("Любить політати поза кліткою.");
        }

        public override void Voice()
        {
            Console.WriteLine("Цвірінькає.");
        }
    }
}
