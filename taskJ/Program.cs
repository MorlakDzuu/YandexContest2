using System;

namespace taskJ
{
    class Program
    {
        static void Main(string[] args)
        {
            int pairCounter = 0;
            int resultG;
            int maxG = int.MinValue;
            double A, B, C, D;
            // Считываем константыне значения.
            A = GetUDouble();
            B = GetUDouble();
            C = GetUDouble();
            D = GetUDouble();
            // Ищем пары x и y.
            for (int x = -50; x <= 50; x++)
            {
                for (int y = -50; y <= 50; y++)
                {
                    resultG = GetG(x, y, A, B, C, D);
                    // Если находим значение, большее всех найденных, то запоминаем его и обнуляем количество пар.
                    if (maxG < resultG)
                    {
                        maxG = resultG;
                        pairCounter = 0;
                    }
                    if (maxG == resultG)
                        ++pairCounter;
                }
            }
            Console.WriteLine(pairCounter);
            Console.WriteLine(maxG);
        }

        
        /// <summary>
        /// Метод позволяет считать из консоли вещественное неотрицательное число.
        /// </summary>
        /// <returns>вещественное неотрицательное число</returns>
        private static double GetUDouble()
        {
            double number;
            if (!double.TryParse(Console.ReadLine(), out number) || (number < 0))
            {
                Console.WriteLine("wrong");
                Environment.Exit(0);
            }

            return number;
        }
        
        // Метод возвращает значение функции F(x, y).
        private static double GetF(int x, int y, double A, double B, double C, double D)
        {
            return A * Math.Sin(B * x) + C * Math.Pow(Math.Cos(D * y), 3);
        }
        
        // Метод возвращает значение функции G.
        private static int GetG(int x, int y, double A, double B, double C, double D)
        {
            return (int) Math.Round(GetF(x, y, A, B, C, D));
        }
    }
}