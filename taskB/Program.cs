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
            for (int i = 0; i < number.ToString().Length; i++)
            {
                if (int.Parse(number.ToString()[i].ToString()) > (baseNumberSystem - 1))
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
            string numberStr = number.ToString();
            for (int i = 0; i < numberStr.Length; i++)
            {
                result += int.Parse(numberStr[numberStr.Length - i - 1].ToString()) * (int) Math.Pow(baseNumberSystem, i);
            }
            return result;
        }
    }
}