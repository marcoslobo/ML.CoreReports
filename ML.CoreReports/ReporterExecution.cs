using RazorEngine;
using System;
using RazorEngine.Templating;


namespace ML.CoreReports
{
    public class ReporterExecution
    {
        public string GenerateReport(string template, object inputData)
        {
            var guid = Guid.NewGuid().ToString();

           var result = Engine.Razor
                .RunCompile(template,
                    guid,
                    null, inputData
                   );

            return result;
        }
    }
}
