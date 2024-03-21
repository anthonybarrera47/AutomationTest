using EncoraTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoraTest.Business.Interface
{
    interface ITestRepository
    {
        List<TestCase> ConvertToJson(string jsonString);
        int GetCountAllCases(List<TestCase> testList);
        int GetCountCasesPassed(List<TestCase> testList);
        int GetCountCasesFailed(List<TestCase> testList);
        decimal GetAverageTimeExecution(List<TestCase> testList);
        decimal GetMinimunTimeExecutionFailed(List<TestCase> testList);
        decimal GetMaximunTimeExecutionFailed(List<TestCase> testList);

    }
}
