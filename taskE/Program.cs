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
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            if (n == 2)
                return 1;
            n -= 3;
            int[,] startMatrix = {{0, 0}, {1, 1}};
            int[,] P = {{0, 1}, {1, 1}};
            startMatrix = MatrixMultiplication(startMatrix, MatrixPow(P, n));
            return startMatrix[1, 0] + startMatrix[1, 1]; 
        }

        /// <summary>
        /// Метод возводит матрицу порядка 2x2 в степень n.
        /// </summary>
        /// <param name="matrix">входная матрица порядка 2x2</param>
        /// <param name="n">степень матрицы</param>
        /// <returns>матрица 2x2 порядка n</returns>
       private static int[,] MatrixPow(int[,] matrix, int n)
        {
            if (n == 0)
                return new [,]{{1, 0}, {0, 1}};
            if (n % 2 == 1)
                return MatrixMultiplication(MatrixPow(matrix, n - 1), matrix);
            int[,] tempMatrix = MatrixPow(matrix, n / 2);
            return MatrixMultiplication(tempMatrix, tempMatrix);
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
            resultMatrix[0, 0] = (matrix1[0, 0] * matrix2[0, 0] + matrix1[0, 1] * matrix2[1, 0]) % (1 << 30);
            resultMatrix[1, 0] = (matrix1[1, 0] * matrix2[0, 0] + matrix1[1, 1] * matrix2[1, 0]) % (1 << 30);
            resultMatrix[0, 1] = (matrix1[0, 0] * matrix2[0, 1] + matrix1[0, 1] * matrix2[1, 1]) % (1 << 30);
            resultMatrix[1, 1] = (matrix1[1, 0] * matrix2[0, 1] + matrix1[1, 1] * matrix2[1, 1]) % (1 << 30);
            return resultMatrix;
        }
    }
}