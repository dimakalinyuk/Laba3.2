using System;
using System.IO;

namespace ConsoleCalculator
{
    class Program
    {
        static bool IsNumeric(string NumericText)
        {
            bool isnumber = true;
            foreach (char c in NumericText)
            {
                isnumber = char.IsNumber(c);
                if (!isnumber)
                {
                    if (c != ',')
                        return isnumber;
                }
            }
            return isnumber;
        }
        static double ConvertDouble(string NumericText)
        {
            double digit;
            digit = double.Parse(NumericText);
            digit = Math.Round(digit, 2);
            return digit;
        }
        static void Main(string[] args)
        {
            string pathin = @"C:\Users\Діма\Desktop\Навчання\1 курс 2 семестр\ООП\Laba3\Laba3Task2\input.txt";

            StreamReader f = new StreamReader(pathin);
            string v = f.ReadLine();
            Console.WriteLine(v);

            string path = @"C:\Users\Діма\Desktop\Навчання\1 курс 2 семестр\ООП\Laba3\Laba3Task2\output.txt";

            if (!File.Exists(path))
            {
                string createText = "Hello and Welcome" + Environment.NewLine;
                File.WriteAllText(path, createText);
            }

            string[] arrStr = new string[2];
            string op = "";
            double digit1, digit2, result;

            try
            {
                if (v.Length == 0)
                {
                    throw new Exception(" Нiчого не введено! Введiть правильний вираз.");
                }
                string[] split = v.Split(new Char[] { ' ', '*', '+', '-', '/' });
                int i = 0;
                foreach (string s in split)
                {
                    if (s.Trim() != "")
                    {
                        Console.WriteLine(s);
                        arrStr[i] = s;
                        i++;
                    }
                }
                char[] array0p = new char[4] { '+', '-', '*', '/' };
                foreach (char c in array0p)
                {
                    int indexop = v.IndexOf(c);
                    if (indexop != -1)
                    {
                        op = v[indexop].ToString();
                        break;
                    }
                }
                if (op.Length == 0)
                {
                    throw new Exception("Операцiя не знайдена у виразi");
                }
                if (!IsNumeric(arrStr[0]))
                {
                    throw new Exception("Перший член виразу - не число");
                }
                digit1 = ConvertDouble(arrStr[0]);
                if (!IsNumeric(arrStr[1]))
                {
                    throw new Exception("Перший член виразу - не число");
                }
                digit2 = ConvertDouble(arrStr[1]);
                switch (op)
                {
                    case ("+"):
                        result = digit1 + digit2;
                        break;
                    case ("-"):
                        result = digit1 - digit2;
                        break;
                    case ("/"):
                        result = digit1 / digit2;
                        break;
                    case ("*"):
                        result = digit1 * digit2;
                        break;
                    default:
                        throw new Exception("Невiдома операцiя");
                }
                Console.WriteLine("аргумент1 = {0},операцiя = {1},аргумент2 = {2}", digit1, op, digit2);
                Console.WriteLine("Результат= " + result);

                string text = v;
                string rez = result.ToString();
                try
                {
                    using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                    {
                        sw.WriteLine("{0}\nРезультат = {1}",text, rez);
                    }

                    Console.WriteLine("Запись выполнена");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                string ReadText = File.ReadAllText(path);
                Console.WriteLine(ReadText);
            }
            catch (Exception e)
            {
                Console.WriteLine("Помилка у вхiдних даних" + e.Message);
                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}

