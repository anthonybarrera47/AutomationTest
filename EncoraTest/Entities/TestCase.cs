using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EncoraTest.Entities
{
    public sealed class TestCase
    {
        [JsonPropertyName("caseId")]
        public int CaseId { get; set; } 
        [JsonPropertyName("passed")]
        public bool Passed { get; set; }
        [JsonPropertyName("executionTime")]
        public decimal ExecutionTime { get; set; }
        public TestCase() { }
    }
}
