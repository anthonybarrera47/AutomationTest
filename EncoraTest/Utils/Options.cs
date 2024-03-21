using EncoraTest.Business;
using EncoraTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoraTest.Utils
{
    public class Options
    {
        readonly FileManager fileManager = new();
        public void WriteOptions()
        {
            Console.Clear();
            Console.WriteLine("Choose an Option:");
            Console.WriteLine("1. Enter Json with the cases");
            Console.WriteLine("2. See an example of the json format");
            Console.WriteLine("3. Show all created files");
            Console.WriteLine("4. Open file Csv");
            Console.WriteLine("5. Exit");
            ReadOptions();

        }
        private void ReadOptions() { var option = Console.ReadLine(); ExcuteOptions(option); }
        private void ExcuteOptions(string? option)
        {
            if (int.TryParse(option, out int result))
            {
                switch (result)
                {
                    case 1:
                        string filename = ReadFileName();

                        if (string.IsNullOrEmpty(filename))
                        {
                            Util.PressKey();
                            WriteOptions();
                        }

                        WriteImportanInformation();
                        string jsonData = ReadJsonData();

                        ProcessJson(filename, jsonData);
                        break;
                    case 2:
                        Util.WriteJsonExample();
                        break;
                    case 3:
                        fileManager.GetAllCsvFilesNames();

                        break;
                    case 4:
                        fileManager.ReadCsvFile();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("ALERT: Choose a valid option");
                        break;
                }
            }
            Util.PressKey();
            WriteOptions();
        }
        private static string ReadFileName()
        {
            Console.WriteLine("Enter a name for the CSV file");

            StringBuilder fileName = new(Console.ReadLine());

            if (string.IsNullOrEmpty(fileName.ToString()))
            {
                Console.WriteLine("Write a correct name");
                return string.Empty;
            }

            if (!Util.HaveCsvExtension(fileName.ToString()))
                fileName.Append(".csv");

            return fileName.ToString();
        }
        private string ReadJsonData()
        {
            Console.WriteLine("Enter the json information");
            string json = Util.ReadMultiplesLines();
            string result = string.Empty;

            if (FileManager.IsArrayJsonValid(json))
            {
                result = json;
            }
            else
            {
                Console.WriteLine("The JSON format entered is incorrect, check the example for the correct format");
                Util.PressKey();
                WriteOptions();
            }

            return result;
        }
        private void ProcessJson(string filename, string jsonData)
        {
            TestRepository testRepository = new();

            var result = testRepository.ConvertToJson(jsonData);
            var total = testRepository.GetCountAllCases(result);
            var casesPassed = testRepository.GetCountCasesPassed(result);
            var casesFailed = testRepository.GetCountCasesFailed(result);
            var maximunExecutionTime = testRepository.GetMaximunTimeExecutionFailed(result);
            var minimunExecutionTime = testRepository.GetMinimunTimeExecutionFailed(result);
            PrintResults(total, casesPassed, casesFailed, maximunExecutionTime, minimunExecutionTime);
            CreateCsvFile(filename, result);
            WriteOptions();
        }
        private static void PrintResults(int total, int casesPassed, int casesFailed, decimal maximunExecutionTime, decimal minimunExecutionTime)
        {
            Console.WriteLine("All Cases:" + total);
            Console.WriteLine("Cases Passed:" + casesPassed);
            Console.WriteLine("Cases Failed:" + casesFailed);
            Console.WriteLine("Maximun Execution Time:" + maximunExecutionTime);
            Console.WriteLine("Minimun Execution Time:" + minimunExecutionTime);

        }

        private void CreateCsvFile(string fileName, List<TestCase> testCases)
        {

            var rootFile = fileManager.CreateFile(fileName);

            if (File.Exists(rootFile))
            {
                Util.ExportToCsv(testCases, rootFile);
                Console.WriteLine($"The path in which the file was created is: {rootFile}");
            }
            else
            {
                Console.WriteLine("An error occurred during file creation, please contact support");
            }
            Util.PressKey();
        }
        private static void WriteImportanInformation()
        {
            Console.WriteLine("Important, to implement reading multiple lines in the console it is necessary to do a double-enter");
        }
    }
}
