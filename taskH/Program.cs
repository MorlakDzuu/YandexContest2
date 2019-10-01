using System;
using System.Collections;

namespace taskH
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            // Если входные данные неверные, то выводим "wrong" и завершаем программу.
            if (!int.TryParse(Console.ReadLine(), out number) || (number < 2) || (number > 511))
            {
                Console.WriteLine("wrong");
                return;
            }
            BitArray bitArray = GetPrimaryNumbers(number);
            string outputString = bitArray.Get(number) ? "prime" : "composite";
            Console.WriteLine(outputString);
        }

        /// <summary>
        /// Метод инвертирует значение масиива битов на n-ой позиции.
        /// </summary>
        /// <param name="bitArray">массив битов</param>
        /// <param name="n">нужная позиция</param>
        /// <returns><массив битов/returns>
        private static BitArray FlipBitArrayPosition(BitArray bitArray, int n)
        {
            if (bitArray.Get(n))
                bitArray.Set(n, false);
            else
                bitArray.Set(n, true);
            return bitArray;
        }
        
        private static BitArray PreliminarySelection(int upperBound) { 
            BitArray primaryNumbers = new BitArray(upperBound + 1); //создаем битовый массив для хранения факта того, что число является простым
            double upperBoundSqrt = Math.Sqrt(upperBound); 
            for (int x = 1; x <= upperBoundSqrt; x++) { 
                for (int y = 1, n; y <= upperBoundSqrt; y++) {
                /* Существует теорема. Пусть n — натуральное число, которое не делится ни на какой полный квадрат. Тогда
                если n представимо в виде 4k+1, то оно просто тогда и только тогда, когда число натуральных решений уравнения 4x2+y2 = n нечетно.
                если n представимо в виде 6k+1, то оно просто тогда и только тогда, когда число натуральных решений уравнения 3x2+y2 = n нечетно.
                если n представимо в виде 12k-1, то оно просто тогда и только тогда, когда число натуральных решений уравнения 3x2−y2 = n,
                для которых x > y, нечетно.
                ссылка на доказательство http://www.ams.org/journals/mcom/2004-73-246/S0025-5718-03-01501-1/S0025-5718-03-01501-1.pdf
                Я, кончено, старался, но так до конца его и не понял
                Подбираем такие числа x и y, что результат решения уравнений по модулю 12 имеет нужный нам остаток:
                4x^2 + y^2  - остаток 1 или 5
                3x^2 + y^2 - остаток 7
                3x^2 - y^2 - остаток 11;
                если такие числа подобраны, то результат решения помечается, как простое;
                если резутат решения уже помечен(как простое число), то оно помечается, как составное(не простое) */ 
                    n = 4*x*x + y*y;
                    if (((n % 12 == 1) || (n % 12 == 5)) && (n <= upperBound))
                    primaryNumbers = FlipBitArrayPosition(primaryNumbers, n);
                    n -= x*x;
                    if ((n % 12 == 7) && (n <= upperBound))
                        primaryNumbers = FlipBitArrayPosition(primaryNumbers, n);
                    if (x > y) {
                        n -= 2*y*y;
                        if ((n % 12 == 11) && (n <= upperBound))
                            primaryNumbers = FlipBitArrayPosition(primaryNumbers, n); 
                    } 
                } 
            } 
            return primaryNumbers; 
        } 
        private static BitArray PostSelection(BitArray primaryNumbers, int upperBound) { 
            double upperBoundSqrt = Math.Sqrt(upperBound);
            /* Предварительное просеиваение, к сожалению, пропускает числа, кратные квадрату простого числа, поэтому
            мы должны отдельно пометить их, как не простые*/ 
            int   squareOfNumber; 
            for (int number = 5; number <= upperBoundSqrt; number++) { 
                if (primaryNumbers.Get(number)) { 
                    squareOfNumber = number * number; 
                    for (int i = squareOfNumber; i <= upperBound; i += squareOfNumber) 
                        primaryNumbers.Set(i, false); 
                } 
            } 
            return primaryNumbers; 
        }
        
        /// <summary>
        /// Метод находит все простые числа до верхней границы.
        /// </summary>
        /// <param name="upperBound">верхняя граница</param>
        /// <returns>массив битов</returns>
        public static BitArray GetPrimaryNumbers(int upperBound) { 
            BitArray primaryNumbers = PreliminarySelection(upperBound); //предварительно просеиванем числа
            primaryNumbers = PostSelection(primaryNumbers, upperBound); //отсеиванием числа, кратные квадратам простых чисел
            /* Так как мы находим остаток от деления на 12(удвоенное призведение простых чисел 2 и 3), то
             нам нужно пометить их, как заведомо простые числа
            допустим, если бы мы брали остатки деления на 60 ( 2*(2*3*5) ), то мы должны были бы учитывать и 5 */
            if (upperBound >= 2) primaryNumbers.Set(2, true);
            if (upperBound >= 3) primaryNumbers.Set(3, true);
            return primaryNumbers; 
        } 
    } 
}