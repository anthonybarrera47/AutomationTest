using EncoraTest.Business;
using EncoraTest.Entities;
using Xunit;

namespace EncoraUnitTest
{
    public class TestCaseTest
    {
        [Fact]
        public void ConvertToJson_ValidJsonString_ReturnsListOfTestCase()
        {
            // Arrange
            var jsonString = "[{\"caseId\":1,\"Passed\":true,\"ExecutionTime\":1}," +
                             "{\"caseId\":2,\"Passed\":true,\"ExecutionTime\":2}]";

            var repository = new TestRepository();

            // Act
            var result = repository.ConvertToJson(jsonString);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetCountAllCases_ListOfTestCases_ReturnsCount()
        {
            var repository = new TestRepository();
            // Arrange
            var testList = new List<EncoraTest.Entities.TestCase>
        {
            new EncoraTest.Entities.TestCase { CaseId = 1, Passed = true, ExecutionTime = 1 },
            new EncoraTest.Entities.TestCase { CaseId = 2, Passed = false, ExecutionTime = 2 },
            new EncoraTest.Entities.TestCase { CaseId = 3, Passed = true, ExecutionTime = 3 }
        };

            // Act
            var result = repository.GetCountAllCases(testList);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void GetAverageTimeExecution_ListOfTestCases_ReturnsAverage()
        {
            var repository = new TestRepository();
            // Arrange
            var testList = new List<EncoraTest.Entities.TestCase>
        {
            new EncoraTest.Entities.TestCase { CaseId = 1, Passed = true, ExecutionTime = 1 },
            new EncoraTest.Entities.TestCase { CaseId = 2, Passed = true, ExecutionTime = 2 },
            new EncoraTest.Entities.TestCase { CaseId = 3, Passed = true, ExecutionTime = 3 }
        };

            // Act
            var result = repository.GetAverageTimeExecution(testList);
            _ = decimal.TryParse("2", out decimal value);
            // Assert
            Assert.Equal(value, result);
        }

        [Fact]
        public void GetCountCasesFailed_ListOfTestCases_ReturnsCount()
        {
            var repository = new TestRepository();
            // Arrange
            var testList = new List<EncoraTest.Entities.TestCase>
        {
            new EncoraTest.Entities.TestCase { CaseId = 1, Passed = true, ExecutionTime = 1 },
            new EncoraTest.Entities.TestCase { CaseId = 2, Passed = false, ExecutionTime = 2 },
            new EncoraTest.Entities.TestCase { CaseId = 3, Passed = false, ExecutionTime = 3 }
        };

            // Act
            var result = repository.GetCountCasesFailed(testList);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void GetCountCasesPassed_ListOfTestCases_ReturnsCount()
        {
            var repository = new TestRepository();
            // Arrange
            var testList = new List<EncoraTest.Entities.TestCase>
        {
            new EncoraTest.Entities.TestCase { CaseId = 1, Passed = true, ExecutionTime = 1 },
            new EncoraTest.Entities.TestCase { CaseId = 2, Passed = false, ExecutionTime = 2 },
            new EncoraTest.Entities.TestCase { CaseId = 3, Passed = true, ExecutionTime = 3 }
        };

            // Act
            var result = repository.GetCountCasesPassed(testList);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void GetMaximunTimeExecutionFailed_ListOfTestCases_ReturnsMaximum()
        {
            var repository = new TestRepository();
            // Arrange
            var testList = new List<EncoraTest.Entities.TestCase>
        {
            new EncoraTest.Entities.TestCase { CaseId = 1, Passed = true, ExecutionTime = 1 },
            new EncoraTest.Entities.TestCase { CaseId = 2, Passed = false, ExecutionTime = 2 },
            new EncoraTest.Entities.TestCase { CaseId = 3, Passed = false, ExecutionTime = 3 }
        };

            // Act
            var result = repository.GetMaximunTimeExecutionFailed(testList);

            // Assert
            _ = decimal.TryParse("3", out decimal value);

            Assert.Equal(value, result);
        }

        [Fact]
        public void GetMinimunTimeExecutionFailed_ListOfTestCases_ReturnsMinimum()
        {
            var repository = new TestRepository();
            // Arrange
            var testList = new List<EncoraTest.Entities.TestCase>
        {
            new EncoraTest.Entities.TestCase { CaseId = 1, Passed = true, ExecutionTime = 1 },
            new EncoraTest.Entities.TestCase { CaseId = 2, Passed = false, ExecutionTime = 2 },
            new EncoraTest.Entities.TestCase { CaseId = 3, Passed = false, ExecutionTime = 3 }
        };

            // Act
            var result = repository.GetMinimunTimeExecutionFailed(testList);
            _ = decimal.TryParse("1", out decimal value);
            // Assert
            Assert.Equal(value, result);
        }

    }
}