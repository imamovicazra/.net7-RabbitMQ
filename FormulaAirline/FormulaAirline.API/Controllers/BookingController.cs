using FormulaAirline.Models.DTOs;
using FormulaAirline.Models.Entities;
using FormulaAirline.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormulaAirline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IMessageProducer _messageProducer;
        private readonly IBookingService _bookingService;
        public BookingController(ILogger<BookingController> logger, IMessageProducer messageProducer, IBookingService bookingService)
        {
            _logger = logger;
            _messageProducer = messageProducer;
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(BookingDTO model)
        {
            try
            {
                if (model is null)
                    return BadRequest();

                await _bookingService.Create(model);

                _messageProducer.SendMessage(model);

                _logger.LogInformation("Successful processing");

                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing");
                return BadRequest(ex);
            }
        }
    }
}
