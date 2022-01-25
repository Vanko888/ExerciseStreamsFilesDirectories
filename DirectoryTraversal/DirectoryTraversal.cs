using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DirectoryTraversal
{
    using System;
    public class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath, "*");
            Dictionary<string, Dictionary<string, double>> fileInfo = new Dictionary<string, Dictionary<string, double>>();
            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);
                string fileExtension = Path.GetExtension(file);
                double fileSize = new FileInfo(file).Length / 1024.0;
                if (!fileInfo.ContainsKey(fileExtension))
                {
                    fileInfo[fileExtension] = new Dictionary<string, double>();
                }

                fileInfo[fileExtension].Add(fileName, fileSize);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var item in fileInfo.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                sb.AppendLine(item.Key);
                foreach (var currFile in item.Value.OrderBy(x => x.Value))
                {
                    sb.AppendLine($"--{currFile.Key} - {currFile.Value:F3}kb");
                }
            }
            return sb.ToString().TrimEnd();




        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";
            File.WriteAllText(path, textContent);
        }

    }
}
