using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace ML.CoreReports.Tests
{
    public class ReporterExecutionTest
    {
        [Fact]
        public void Should_Generate_String()
        {

            var path = GetPath("templates\\template-1.html");

            var htmlString = File.ReadAllText(path);

            var reporterExecution = new ReporterExecution();
            var inputData = new
            {
                Name = "Ronaldo Nogueira"
            };
            var result = reporterExecution.GenerateReport(htmlString, inputData);


            Assert.True(!string.IsNullOrEmpty(result));
        }
        [Fact]
        public void Should_Do_ForEach()
        {

            var path = GetPath("templates\\template-2.html");

            var htmlString = File.ReadAllText(path);

            var reporterExecution = new ReporterExecution();
            var inputData = new
            {
                Ronaldos = new[] { new { Name = "Ronaldo 1" }, new { Name = "Ronaldo 2" } }
            };

            var result = reporterExecution.GenerateReport(htmlString, inputData);


            Assert.True(!string.IsNullOrEmpty(result));
        }
        public string GetPath(string relativePath)
        {
            var codeBaseUrl = new Uri(Assembly.GetExecutingAssembly().CodeBase);
            var codeBasePath = Uri.UnescapeDataString(codeBaseUrl.AbsolutePath);
            var dirPath = Path.GetDirectoryName(codeBasePath);
            return Path.Combine(dirPath, relativePath);
        }
    }
}
