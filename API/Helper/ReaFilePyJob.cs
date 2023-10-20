using Domain.Entity;
using Infrastructure.Data;
using Quartz;

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
            var test = new Stock {
                Symbol = "test",
            };


            dataContext.Stocks.Add(test);
            dataContext.SaveChanges();
           
            // Note: This method must always return a value 
            // This is especially important for trigger listers watching job execution 
            return Task.FromResult(true);
        }
    }
}
