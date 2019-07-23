using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Примітка. Замість типу int використаний тип double для часу приготування
// TimeCook, це дозволить скористатися допуском на приготування, який буде описаний 
// в класах самих пічок

namespace LesApp1
{
    /// <summary>
    /// Пиріг
    /// </summary>
    class Cake
    {
        /// <summary>
        /// Назва
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Час для приготування пирога, годин
        /// </summary>
        public double TimeToCook { get; set; }
        /// <summary>
        /// Потужність приготування
        /// </summary>
        public int PowerCooking { get; set; }
        /// <summary>
        /// Допуск на приготування пирога, у годинах
        /// </summary>
        public double Tolerance { get; set; }
    }
}
