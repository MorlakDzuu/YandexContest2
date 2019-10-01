using System;

namespace taskD
{
    class Program
    {
        static void Main(string[] args)
        {
            double number;
            int n;
            // Если входные данные неверные, то выводим "wrong" и завершаем программу.
            if (!double.TryParse(Console.ReadLine(), out number) || (number < -1000) || (number > 1000) ||
                !int.TryParse(Console.ReadLine(), out n) || (n < 1) || (n > 1000)) 
                return;
            Console.WriteLine(Sin(number, n).ToString("F3"));
        }

        /// <summary>
        /// Метод вычисляет значение синуса используя разложение в ряд Тейлора.
        /// </summary>
        /// <param name="x">число, синус которого нужно вычислить</param>
        /// <param name="N">точность вычисления</param>
        /// <returns>синус числа</returns>
        private static double Sin(double x, int N)
        {
            double sum = x;
            double number = x;
            for (int i = 1; i <= N; i++)
            {
                number *= - Math.Pow(x, 2) / (2 * i * (2 * i + 1));
                sum += number;
            }
            return sum;
        }
    }
}