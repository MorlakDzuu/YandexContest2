using System;

namespace taskA
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString, outputString = "";
            int n;
            int money;
            inputString = Console.ReadLine();
            // Если входные данные неверные, то выводим "wrong" и завершаем программу.
            if (!int.TryParse(inputString, out n) || (n < 1) || (n > 100000))
            {
                Console.WriteLine("wrong");
                return;
            }
            // Считываем входные данные и обрабатываем их.
            for (int i = 1; i <= n ; i++)
            {
                inputString = Console.ReadLine();
                if (inputString.Equals("taxi") && int.TryParse(Console.ReadLine(), out money) &&
                    (money > 0 && money <= 1000000))
                {
                    if (money > 1500)
                        money = (int) Math.Ceiling(money * 0.8);
                    outputString = GetBillNumber(money).ToString();
                }
                else if (inputString.Equals("bus"))
                    outputString = "3";
                if (!outputString.Equals(""))
                    Console.WriteLine(outputString);
                // Если введено неверное значение, то выводим "wrong" и завершаем выполнение программы.
                if (outputString.Equals("") && !inputString.Equals("none"))
                {
                    Console.WriteLine("wrong");
                    return;
                }
                outputString = "";
            }
        }

        /// <summary>
        /// Метод считает количество купюр для набора нужной суммы (купюры номиналом 500, 200, 100).
        /// </summary>
        /// <param name="money">сумма, которую нужно разбить на купюры</param>
        /// <returns>количество купюр</returns>
        private static long GetBillNumber(int money)
        {
            int billNumber = 0;
            billNumber += money / 500;
            money -= billNumber * 500;
            if (money > 400)
                ++billNumber;
            else if (money > 200)
                billNumber += 2;
            else if (money > 0)
                ++billNumber;
            return billNumber;
        }
    }
}
//315 244