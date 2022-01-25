

namespace EvenLines
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using System;

    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StreamReader stremaReader = new StreamReader(inputFilePath);
            StringBuilder sb = new StringBuilder();
            char[] symbols = { '-', ',', '.', '!', '?' };
            int counter = 0;
            while (true)
            {
                string result = stremaReader.ReadLine();
                if (result == null)
                {
                    break;
                }

                if (counter % 2 == 0)
                {
                    foreach (var symbol in symbols)
                    {
                        result = result.Replace(symbol, '@');
                    }

                    result = string.Join(" ", result.Split().Reverse());

                    sb.AppendLine(result);
                }

                counter++;
            }

            return sb.ToString().TrimEnd();
        }
    }

   
}



