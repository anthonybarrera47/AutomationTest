using EncoraTest.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace EncoraTest.Utils
{
    public static class Util
    {
        public static void ExportToCsv(List<TestCase> testCases, string csvFilePath)
        {
            try
            {
                using var writer = new StreamWriter(csvFilePath);
                // Write the header row
                writer.WriteLine("CaseId,Passed,ExecutionTime");

                // Write data rows
                foreach (var testCase in testCases)
                {
                    writer.WriteLine($"{testCase.CaseId},{testCase.Passed},{testCase.ExecutionTime}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error exporting to CSV: " + ex.Message);
            }
        }
        public static bool HaveCsvExtension(string fileName)
        {
            return Regex.IsMatch(fileName, @"\.csv$", RegexOptions.IgnoreCase);
        }
        public static void PressKey()
        {
            Console.WriteLine("Press a key to continue....");
            Console.ReadKey();
        }
        public static string ReadMultiplesLines()
        {
            string line;
            StringBuilder allText = new();

            while (true)
            {
                line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    break; // Sale del bucle si la línea está en blanco
                }
                allText.AppendLine(line); // Agrega la línea al texto completo
            }

            return allText.ToString().Trim(); // Eliminar el espacio adicional al final
        }

        public static void WriteJsonExample()
        {
            string jsonString = @"[
                    {""caseId"":1,""passed"":true,""executionTime"":1},
                    {""caseId"":2,""passed"":true,""executionTime"":2},
                    {""caseId"":3,""passed"":false,""executionTime"":3}
                ]";

            // Deserializa el string JSON y lo formatea con sangría para imprimirlo de manera legible
            dynamic json = JsonConvert.DeserializeObject(jsonString);
            string prettyJson = JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine();
            Console.WriteLine(prettyJson);
        }
    }
}
