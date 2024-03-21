using EncoraTest.Business.Interface;
using EncoraTest.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EncoraTest.Business
{
    public class TestRepository : ITestRepository
    {
        public List<TestCase> ConvertToJson(string? jsonString)
        {
            return JsonConvert.DeserializeObject<List<TestCase>>(jsonString);
        }

        public int GetCountAllCases(List<TestCase> testList)
        {
            return testList.Count;
        }

        public decimal GetAverageTimeExecution(List<TestCase> testList)
        {
            return testList.Average(x => x.ExecutionTime);
        }

        public int GetCountCasesFailed(List<TestCase> testList)
        {
            return testList.Count(x => !x.Passed);
        }

        public int GetCountCasesPassed(List<TestCase> testList)
        {
            return testList.Count(x => x.Passed);
        }

        public decimal GetMaximunTimeExecutionFailed(List<TestCase> testList)
        {
            return testList.Max(x => x.ExecutionTime);
        }

        public decimal GetMinimunTimeExecutionFailed(List<TestCase> testList)
        {
            return testList.Min(x => x.ExecutionTime);
        }
    }
}
