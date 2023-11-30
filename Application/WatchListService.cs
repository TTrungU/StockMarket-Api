using Application.Service.Interface;
using AutoMapper;
using Domain.Dtos;
using Domain.Entity;
using Domain.Exceptions;
using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class WatchListService : IWatchListService
    {
        private readonly IMapper _mapper;
        private readonly IWatchListRepository _watchListRepository;
        private readonly IUserRepository _userRepository;
        private readonly IStockRepository _stockRepository;
        public WatchListService(IWatchListRepository watchListRepository, IUserRepository userRepository, IStockRepository stockRepository,IMapper mapper)
        {
            _mapper = mapper;
            _watchListRepository = watchListRepository;
            _userRepository = userRepository;
            _stockRepository = stockRepository;
        }
        public async Task CreateWathListAsync(WatchListDto watchListDto)
        {
            if (!_userRepository.IsUserExist(watchListDto.UserId))
                throw new NotFoundException($"User with id {watchListDto.UserId} was not found");

            if (!_stockRepository.IsExist(stock => stock.Id == watchListDto.StockId))
                throw new NotFoundException($"Stock with id {watchListDto.StockId} was not found");

            var watchList = _mapper.Map<WatchList>(watchListDto);
            _watchListRepository.Create(watchList);
            await _watchListRepository.SaveAsync();

        }

        public async Task DeleteWatchListAsync(int userId, int stockId)
        {

            var watchList = await _watchListRepository.GetWatchListById(userId,stockId);
            if (watchList == null)
                throw new NotFoundException($"Watch list was not found");
             _watchListRepository.Delete(watchList);
            await _watchListRepository.SaveAsync();
        }

        public async Task<IEnumerable<WatchListDto>> GetWatchListByUserIdAsync(int userId)
        {
            if (!_userRepository.IsUserExist(userId))
                throw new UserNotFoundException(userId);
            var watchList = await _watchListRepository.FindByCondition(w=>w.UserId == userId).ToListAsync();

            var watchListDto = _mapper.Map<IEnumerable<WatchListDto>>(watchList);
            return watchListDto;
            
        }
    }
}
