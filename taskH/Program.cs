using System;

namespace taskH
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            // Если входные данные неверные, то выводим "wrong" и завершаем программу.
            if (!int.TryParse(Console.ReadLine(), out number) || (number < 2) || (number >= 2000000000))
            {
                Console.WriteLine("wrong");
                return;
            }
            Console.WriteLine(IsPrime(number) ? "prime" : "composite");
        }

        /// <summary>
        /// Метод проверяет простое ли число.
        /// </summary>
        /// <param name="number">проверяемое число</param>
        /// <returns>true, если число простое, false, если нет</returns>
        private static bool IsPrime(int number)
        {
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) 
                    return false;
            }
            return true;
        }
    } 
}