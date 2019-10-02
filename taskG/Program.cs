using System;

namespace taskG
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            int accuracyNumber;
            // Если входные данные неверные, то выводим "wrong" и завершаем программу.
            if (!int.TryParse(inputString, out accuracyNumber) || (accuracyNumber < 1) || (accuracyNumber > 255))
            {
                Console.WriteLine("wrong");
                return;
            }
            AccuracyCheck(0, accuracyNumber,accuracyNumber);
        }

        /// <summary>
        /// Метод проверяет входит ли число в полуинтервал.
        /// </summary>
        /// <param name="accuracyNumber">точность</param>
        /// <param name="number">число</param>
        /// <returns>true, если входит, false, если нет</returns>
        private static bool IsInRange(int accuracyNumber, double number)
        {
            bool result;
            double firstLimit = double.Parse((0.1 + ((10.0 / 9.0 -1) * 2 / 1000)).ToString("F" + accuracyNumber));
            double secondLimit = double.Parse((0.121 + ((10.0 / 9.0 -1) * 2 / 1000)).ToString("F" + accuracyNumber));
            result = accuracyNumber > 1 ? (number >= firstLimit) && (number < secondLimit) : (number >= firstLimit) && (number <= secondLimit);
            return result;
        }

        /// <summary>
        /// Метод считывает разряды числа поотдельности и проверяет, входит ли полученное число в массив.
        /// </summary>
        /// <param name="number">число</param>
        /// <param name="accuracyNumber">количество оставшихся разрядов</param>
        /// <param name="allAccuracyNumber">количество всех разрядов</param>
        private static void AccuracyCheck(double number, int accuracyNumber, int allAccuracyNumber)
        {
            double accuracy;
            // Проверяем входные данные.
            if (!double.TryParse(Console.ReadLine(), out accuracy) || (accuracy < 0) || (accuracy > 2))
            {
                Console.WriteLine("wrong");
                Environment.Exit(0);
            }
            // Собираем число.
            number = number * 10 + accuracy;
            accuracyNumber--;
            // Проверяем, входит ли текущее число в полуинтервал.
            if (!IsInRange(allAccuracyNumber - accuracyNumber, number / Math.Pow(10, allAccuracyNumber-accuracyNumber)))
            {
                Console.WriteLine((allAccuracyNumber-accuracyNumber).ToString());
                Environment.Exit(0);
            }
            if (accuracyNumber != 0) 
                AccuracyCheck(number, accuracyNumber, allAccuracyNumber);
            if (IsInRange(allAccuracyNumber - accuracyNumber, number / Math.Pow(10, allAccuracyNumber-accuracyNumber)))
                Console.WriteLine("yes");
            else
                Console.WriteLine(allAccuracyNumber.ToString());
            Environment.Exit(0);
        }
    }
}