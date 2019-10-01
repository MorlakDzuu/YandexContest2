using System;

namespace taskI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetSalary(GetNumber(10, 100), GetNumber(50, 100), GetNumber(1, 200), GetNumber(2, 10), GetNumber(5, 30)).ToString("F3"));
        }

        /// <summary>
        /// Получение числа в заданном диапозоне из консоли.
        /// </summary>
        /// <param name="bottomLimit">нижняя граница</param>
        /// <param name="upperLimit">верхняя граница</param>
        /// <returns>число</returns>
        private static double GetNumber(int bottomLimit, int upperLimit)
        {
            double number;
            if (!double.TryParse(Console.ReadLine(), out number) || (number < bottomLimit) || (number > upperLimit))
            {
                Console.WriteLine("wrong");
                Environment.Exit(0);
            }
            return number;
        }

        /// <summary>
        /// Метод вычисляет зарплату по определенной формуле.
        /// </summary>
        /// <param name="detailsNorm">норма деталей в день</param>
        /// <param name="detailCost">плата за одну деталь</param>
        /// <param name="doneDetails">сделанные детали за один день</param>
        /// <param name="month">количесвто месяцев</param>
        /// <param name="days">количество рабочих дней в месяце</param>
        /// <returns>зарплата</returns>
        private static double GetSalary(double detailsNorm, double detailCost, double doneDetails, double month, double days)
        {
            double salary = detailsNorm * detailCost;
            if (doneDetails < detailsNorm)
                salary -= (detailsNorm - doneDetails) * 0.5;
            if (doneDetails > detailsNorm)
                salary += (doneDetails - detailsNorm) * 1.25;
            salary *= days * month;
            return salary;
        }
    }
}