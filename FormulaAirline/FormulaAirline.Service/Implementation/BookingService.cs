using AutoMapper;
using FormulaAirline.Database;
using FormulaAirline.Models.DTOs;
using FormulaAirline.Models.Entities;
using FormulaAirline.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaAirline.Service.Implementation
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly AirlineDbContext _dbContext;

        public BookingService(AirlineDbContext airlineContext, IMapper mapper)
        {
            _dbContext = airlineContext;
            _mapper = mapper;
        }

        public async Task<BookingDTO> Create(BookingDTO model)
        {
            var entity = _mapper.Map<Booking>(model);

            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<BookingDTO>(entity);
        }
    }
}
