using EncoraTest.Entities;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoraTest.Utils
{
    public class FileManager
    {
        public string? FileAbsolutePath { get; set; }
        public string[]? Files { get; set; }
        public FileManager()
        {
            rootProject = string.Empty;
            FileAbsolutePath = string.Empty;
        }

        private string rootProject;
        private static readonly string folderName = "ExportedFiles";

        private bool CreateFolder()
        {
            rootProject = AppDomain.CurrentDomain.BaseDirectory;

            string pathFolder = Path.Combine(rootProject, folderName);

            if (!Directory.Exists(pathFolder))
            {
                Directory.CreateDirectory(pathFolder);
                return true;
            }
            else if (Directory.Exists(pathFolder))
                return true;

            return false;
        }
        public string CreateFile(string fileName)
        {
            if (CreateFolder())
            {
                string filePath = Path.Combine(rootProject, folderName, fileName);

                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                    return filePath;
                }
                else if (File.Exists(filePath))
                {
                    return filePath;
                }
                return "";
            }
            return "";
        }
        public void GetAllCsvFilesNames()
        {
            if (FileAbsolutePath == string.Empty)
            {
                rootProject = AppDomain.CurrentDomain.BaseDirectory;
                FileAbsolutePath = Path.Combine(rootProject, folderName);
            }

            if (Directory.Exists(FileAbsolutePath))
            {
                Files = Directory.GetFiles(FileAbsolutePath);

                Console.WriteLine("Files in the directory");
                for (int i = 0; i < Files.Length; i++)
                {
                    string fileName = Path.GetFileName(Files[i]);
                    Console.WriteLine($"{i + 1}. {fileName}");
                }
            }
            else
                Console.WriteLine("No generated file has been found, verify that you have already run the process at least 1 time");
        }
        public void ReadCsvFile()
        {
            GetAllCsvFilesNames();
            if (Files is null || Files.Length <= 0)
            {
                return;
            }

            string pathFile = string.Empty;
            int fileIndex;

            Console.WriteLine("0. Exit");
            do
            {
                Console.WriteLine("Choose a file.");
                _ = int.TryParse(Console.ReadLine(), out fileIndex);

                if (fileIndex == 0)
                    return;

                fileIndex--;
                if (fileIndex > 0 && fileIndex < Files.Length)
                    pathFile = Files[fileIndex];
                else
                    Console.WriteLine("Choose a valid file");

            } while (fileIndex >= 0 );


            if (File.Exists(pathFile))
            {
                using TextFieldParser parser = new(pathFile);
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    Console.WriteLine($"TestCaseId: {fields[0]}");
                    Console.WriteLine($"Status: {fields[1]}");
                    Console.WriteLine($"Execution Time: {fields[2]}");
                    Console.WriteLine("=================================");

                }
            }
            else
            {
                Console.WriteLine("The selected file does not exist");
            }

        }
        public static bool IsArrayJsonValid(string jsonString)
        {
            try
            {
                List<TestCase> result = JsonConvert.DeserializeObject<List<TestCase>>(jsonString);

                if (result is List<TestCase>)
                {
                    return true;
                }
            }
            catch (JsonException)
            {
                return false;
            }

            return false;
        }
    }
}
