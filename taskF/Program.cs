using System;

namespace taskF
{
    class Program
    {
        static void Main(string[] args)
        {
            int wordsNumber;
            int shift;
            // Если входные данные неверные, то выводим "wrong" и завершаем программу.
            if (!int.TryParse(Console.ReadLine(), out wordsNumber) || (wordsNumber < 0) || !int.TryParse(Console.ReadLine(), out shift))
            {
                Console.WriteLine("wrong");
                return;
            }
            string encrypString;
            string inputString;
            // Считываем и обрабатываем входящие значения.
            for (int i = 0; i < wordsNumber; i++)
            {
                inputString = Console.ReadLine();
                // Если строка содержит что-то кроме латинских букв нижнего регистра, то выводим "wrong" и завершаем программу.
                if (!CheckString(inputString))
                {
                    Console.WriteLine("wrong");
                    return;
                }
                // Шифруем строку.
                Caesar(inputString, shift, out encrypString);
                Console.WriteLine(encrypString);
            }
        }

        /// <summary>
        /// Метод проверяет правильность строки (она должна содержать только строчные буквы латинского алфавита).
        /// </summary>
        /// <param name="str">строка</param>
        /// <returns>true, если строка введена правильно, false, если нет</returns>
        private static bool CheckString(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!((str[i] >= Convert.ToInt32('a')) && (str[i] <= Convert.ToInt32('z'))))
                    return false;
            }
            return true;
        }
        
        /// <summary>
        /// Метод шифрует строку с помощью шифра Цезаря.
        /// </summary>
        /// <param name="word">слово, которое надо зашифровать</param>
        /// <param name="shift">нужный сдвиг</param>
        /// <param name="ciphertext">выходная строка</param>
        private static void Caesar(string word, int shift, out string ciphertext)
        {
            ciphertext = "";
            shift = shift % 26;
            if (shift < 0)
                shift = 26 + shift;
            for (int i = 0; i < word.Length; i++)
                ciphertext += Convert.ToChar(((Convert.ToInt16(word[i]) - Convert.ToInt32('a') + shift) % 26) + Convert.ToInt32('a'));
        }
    }
}