using System;

namespace taskE
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            // Если входные данные неверные, то выводим "wrong" и завершаем программу.
            if (!int.TryParse(Console.ReadLine(), out n) || (n < 1))
            {
                Console.WriteLine("wrong");
                return;
            }
            int number;
            // Считываем и обрабатываем входящие значения.
            for (int i = 1; i <= n; i++)
            {
                if (!int.TryParse(Console.ReadLine(), out number) || (number < 0))
                {
                    Console.WriteLine("wrong");
                    continue;
                }
                Console.WriteLine(GetFibonachiNumber(number));
            }
        }

        /// <summary>
        /// Метод возвращает число Фибоначи n-го порядка
        /// </summary>
        /// <param name="n">позиция числа в последовательности Фибоначи</param>
        /// <returns>приблизительное число Фибоначи n-го порядка</returns>
        static double GetFibonachiNumber(int n)
        {
            n -= 2;
            int[,] startMatrix = {{0, 1}, {0, 0}};
            int[,] P = {{0, 1}, {1, 1}};
            startMatrix = MatrixMultiplication(startMatrix, MatrixPow(P, n));
            return startMatrix[0, 0] + startMatrix[1, 0]; 
        }

       private static int[,] MatrixPow(int[,] matrix, int n)
        {
            if (n == 0)
                return new [,]{{1, 0}, {0, 1}};
            if (n % 2 == 1)
                return MatrixMultiplication(MatrixPow(matrix, n - 1), matrix); ;
            return MatrixMultiplication(MatrixPow(matrix, n / 2), MatrixPow(matrix, n / 2));
        }

       /// <summary>
       /// Метод перемножает две матрицы размера 2x2.
       /// </summary>
       /// <param name="matrix1"></param>
       /// <param name="matrix2"></param>
       /// <returns></returns>
       private static int[,] MatrixMultiplication(int[,] matrix1, int[,] matrix2)
        {
            int[,] resultMatrix = {{0, 0}, {0, 0}};
            resultMatrix[0, 0] = (int) ((matrix1[0, 0] * matrix2[0, 0] + matrix1[0, 1] * matrix2[1, 0]) % Math.Pow(2, 30));
            resultMatrix[1, 0] = (int) ((matrix1[0, 0] * matrix2[0, 1] + matrix1[0, 1] * matrix2[1, 1]) % Math.Pow(2, 30));
            resultMatrix[0, 1] = (int) ((matrix1[1, 0] * matrix2[0, 0] + matrix1[1, 1] * matrix2[1, 0]) % Math.Pow(2, 30));
            resultMatrix[1, 1] = (int) ((matrix1[1, 0] * matrix2[1, 0] + matrix1[1, 1] * matrix2[1, 1]) % Math.Pow(2, 30));
            return resultMatrix;
        }
    }
}