using Application.Model;
using Application.Service;
using Application.Service.Interface;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WatchListController : ControllerBase
    {
        private IWatchListService _watchListService;
        public WatchListController(IWatchListService watchListService)
        {
            _watchListService = watchListService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWatchList([FromBody] WatchListDto watchList)
        {
            await _watchListService.CreateWathListAsync(watchList);
            return Ok();
        }
        [HttpGet("userId")]
        public async Task<IActionResult> GetWatchListByUserId(int userId)
        {
            var watchList = await _watchListService.GetWatchListByUserIdAsync(userId);
            return Ok(watchList);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteWatchList(int userId, int StockId)
        { 
            await _watchListService.DeleteWatchListAsync(userId, StockId);
            return NoContent();
        }
    }
}
