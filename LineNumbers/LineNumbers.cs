﻿using System.IO;
using System.Linq;
using System.Text;

namespace LineNumbers
{
    using System;
    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder sb = new StringBuilder();

            string[] lines = File.ReadAllLines(inputFilePath);

            for (int i = 0; i < lines.Length; i++)
            {
                string word = lines[i];
                int countOfLetters = word.Count(x => char.IsLetter(x));
                int countOfChars = word.Count(x => char.IsPunctuation(x));
                sb.AppendLine($"Line {i + 1}: {word} ({countOfLetters})({countOfChars})");
            }
            File.WriteAllText(outputFilePath, sb.ToString().TrimEnd());
        }
    }
}
