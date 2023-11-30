using Application.Dtos;
using Application.Service;
using Application.Service.Interface;
using Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class StockController: ControllerBase
    {
        private  IStockService _stockService;
        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StockDto>))]
        public async Task<IActionResult> GetAllStock()
        {
            var stock = await _stockService.GetAllStockAsync();
            return Ok(stock);
        }
    }
}
