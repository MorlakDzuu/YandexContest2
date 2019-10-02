using System;

namespace taskB
{
    class Program
    {
        static void Main(string[] args)
        {
            int baseNumberSystem;
            int number;
            // Если входные данные неверные, то выводим "wrong" и завершаем программу.
            if (!int.TryParse(Console.ReadLine(), out baseNumberSystem) || !int.TryParse(Console.ReadLine(), out number)
                || (baseNumberSystem < 2) || (baseNumberSystem > 9) || (number < 0))
            {
                Console.WriteLine("wrong");
                return;
            }
            // Проверяем, записано ли число в введённой системе счисления.
            for (int i = 0; i < GetNumberLength(number); i++)
            {
                if ((int) (number % Math.Pow(10, i+1) / Math.Pow(10, i)) > (baseNumberSystem - 1))
                {
                    Console.WriteLine("wrong");
                    return;
                }
            }
            Console.WriteLine(GetDecimalNumber(number, baseNumberSystem));
        }
        
        /// <summary>
        /// Метод переводит число в десятичную сиситему счисления.
        /// </summary>
        /// <param name="number">число, которое надо перевести в десятичную систему счисления</param>
        /// <param name="baseNumberSystem">основание системы счисления числа</param>
        /// <returns>число в десятичной системе счислнения</returns>
        private static int GetDecimalNumber(int number, int baseNumberSystem)
        {
            int result = 0;
            for (int i = 0; i < GetNumberLength(number); i++)
            {
                result += (int) (number % Math.Pow(10, i+1) / Math.Pow(10, i)) * (int) Math.Pow(baseNumberSystem, i);
            }
            return result;
        }

        /// <summary>
        /// Метод считает количество разрядов в целом числе.
        /// </summary>
        /// <param name="number">целое число</param>
        /// <returns>количество разрядов</returns>
        private static int GetNumberLength(int number)
        {
            int i = 1;
            int counter = 0;
            while (number / i != 0)
            {
                i *= 10;
                counter++;
            }
            return counter;
        }
    }
}