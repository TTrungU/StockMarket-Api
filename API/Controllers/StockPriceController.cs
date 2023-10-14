using Application.Dtos;
using Application.Service;
using Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockPriceController: ControllerBase
    {
        private IStockPriceService _stockPriceService;
        public StockPriceController(IStockPriceService stockPriceService)
        {
            _stockPriceService = stockPriceService;
        }

        [HttpGet("symbol")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StockPriceDto>))]
        public async Task<IActionResult> GetStockPriceBySymbol(string symbol)
        {
            var stock = await _stockPriceService.GetStockPriceBySymbolAsync(symbol);
            return Ok(stock);
        }

        [HttpGet("GetByTimeStamp")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StockPriceDto>))]
        public async Task<IActionResult> GetStockPriceByTimestamp(string symbol,DateTime startDate,DateTime endDate)
        {
            var stock = await _stockPriceService.GetStockPriceByTimestamp(symbol,startDate,endDate);
            return Ok(stock);
        }
    }
}
