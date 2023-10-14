using Application.Dtos;
using Application.Service.Interface;
using AutoMapper;
using Domain.Entity;
using Domain.Exceptions;
using Infrastructure.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;
        public StockService(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<StockDto>> GetAllStockAsync()
        {
            var stock = await _stockRepository.GetAll();
            return _mapper.Map<IEnumerable<StockDto>>(stock);
           
        }

        public async Task<StockDto> GetStockByIdAsync(int id)
        {
            var stock = await _stockRepository.FindByCondition(s=>s.Id == id).FirstOrDefaultAsync();
            if (stock == null)
                throw new NotFoundException($"Stock with id: {id} was not exist");
            return _mapper.Map<StockDto>(stock);
        }
    }
}
