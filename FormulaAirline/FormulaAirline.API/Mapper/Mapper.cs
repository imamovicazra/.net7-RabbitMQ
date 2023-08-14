using AutoMapper;
using FormulaAirline.Models.DTOs;
using FormulaAirline.Models.Entities;

namespace FormulaAirline.API.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Booking, BookingDTO>().ReverseMap();
        }
    }
}
