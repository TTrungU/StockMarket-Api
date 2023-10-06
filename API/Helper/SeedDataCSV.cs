using Infrastructure.Data;

namespace API.Helper
{
    public class SeedDataCSV
    {
        private readonly DataContext dataContext;
        public SeedDataCSV(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}
