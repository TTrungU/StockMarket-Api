using Domain.Entity;
using Infrastructure.Data;
using Quartz;
using System.Diagnostics;

namespace API.Helper
{
    public class ReaFilePyJob:IJob
    {
        private readonly DataContext dataContext;

        public ReaFilePyJob(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public Task Execute(IJobExecutionContext context)
        {
            string pythonPath = "python";  // Use "python" or specify the full path to the Python executable.
            string scriptPath = @"D:\KLTN\WebAPI\StockMarket\API\Helper\ML\hello.py";

            // Create a new process start info
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = pythonPath,
                Arguments = scriptPath,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // Start the process
            using (Process process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();

                // Read the output of the Python script (optional)
        

                process.WaitForExit();
            }

            // Note: This method must always return a value 
            // This is especially important for trigger listers watching job execution 
            return Task.FromResult(true);
        }
    }
}
