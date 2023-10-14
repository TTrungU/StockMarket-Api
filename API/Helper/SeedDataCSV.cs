using Application.Model;
using CsvHelper;
using Domain.Entity;
using Infrastructure.Data;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace API.Helper
{
    public class SeedDataCSV
    {
        private readonly DataContext dataContext;
        public SeedDataCSV(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public  void SeedDataContext() 
        {
           
            string resourceName = "D:\\KLTN\\WebAPI\\StockMarket\\Infrastructure\\SeedDataCSV\\STB_Historical_Data.csv";

            using (var reader = new StreamReader(resourceName))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {               
                while (csv.Read())
                {
                    var record = csv.GetRecord<StockPriceSeedData>();
                    var stockPrice = new StockPrice()
                    {
                        Open = record.Open,
                        Price = record.Price,
                        Low = record.Low,
                        TimeStamp = record.TimeStamp,
                        StockId = 1
                    };

                    dataContext.StockPrices.Add(stockPrice);
                }
            }            
            dataContext.SaveChanges();
        }
    }
}
