using System;

namespace taskC
{
    class Program
    {
        static void Main(string[] args)
        {
            double height, width;
            // Если входные данные неверные, то выводим "wrong" и завершаем программу.
            height = GetInputUDouble();
            if (height == -1)
                return;
            width = GetInputUDouble();
            if (width == -1)
                return;
            Console.WriteLine(GetRectanglePerimeter(height, width).ToString("F3") + " " + 
                              GetRectangleArea(height, width).ToString("F3"));
        }

        /// <summary>
        /// Метод считывает значение из консоли и проверяет его.
        /// </summary>
        /// <returns>udoub</returns>
        private static double GetInputUDouble()
        {
            string inputString;
            inputString = Console.ReadLine();
            if (!CheckInput(inputString))
            {
                Console.WriteLine("wrong");
                return -1;
            }

            return double.Parse(inputString);
        }
        
        /// <summary>
        /// Метод проверяет входные данные.
        /// </summary>
        /// <param name="height">входная строка</param>
        /// <param name="width">входная строка</param>
        /// <returns>true, если входнве данные верны, false, если нет</returns>
        private static bool CheckInput(string numberStr)
        {
            double number;
            return (double.TryParse(numberStr, out number) && (number > 0));
        }

        /// <summary>
        /// Метод вычисляет площадь прямоугольника.
        /// </summary>
        /// <param name="height">высота</param>
        /// <param name="width">ширина</param>
        /// <returns>площадь</returns>
        private static double GetRectangleArea(double height, double width)
        {
            return height * width;
        }
        
        /// <summary>
        /// Метод вычисляет периметр прямоугольника.
        /// </summary>
        /// <param name="height">высота</param>
        /// <param name="width">ширина</param>
        /// <returns>периметр</returns>
        private static double GetRectanglePerimeter(double height, double width) {
            return 2 * (width + height);
        }
    }
}