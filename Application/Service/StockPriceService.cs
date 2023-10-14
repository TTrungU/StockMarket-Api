using Application.Dtos;
using Application.Service.Interface;
using AutoMapper;
using Domain.Exceptions;
using Infrastructure.Repository;
using Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class StockPriceService : IStockPriceService
    {
        private readonly IStockPriceRepository _stockPriceRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        public StockPriceService(IStockPriceRepository stockPriceRepository,
                                 IStockRepository stockRepository,
                                 IMapper mapper )
        {
            _stockRepository = stockRepository; 
            _stockPriceRepository = stockPriceRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<StockPriceDto>> GetStockPriceBySymbolAsync(string symbol)
        {

            if (!_stockRepository.IsExist(s=>s.Symbol == symbol))
                throw new NotFoundException($"Stock with symbol: {symbol} was not found");

            var stock = await _stockPriceRepository.GetStockBySymbol(symbol);

            return _mapper.Map<IEnumerable<StockPriceDto>>(stock);

        }

        public async Task<IEnumerable<StockPriceDto>> GetStockPriceByTimestamp(string symbol, DateTime startDate, DateTime endDate)
        {
            if (!_stockRepository.IsExist(s => s.Symbol == symbol))
                throw new NotFoundException($"Stock with symbol: {symbol} was not found");

            var stock = await _stockPriceRepository.GetStockByTimeStamp(symbol,startDate,endDate);

            return _mapper.Map<IEnumerable<StockPriceDto>>(stock);
        }
    }
}
