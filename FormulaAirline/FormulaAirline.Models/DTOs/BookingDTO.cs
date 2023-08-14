using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaAirline.Models.DTOs
{
    public class BookingDTO
    {
        public string PassangerName { get; init; }
        public string PassportNumber { get; init; }
        public string From { get; init; }
        public string To { get; init; }
        public int Status { get; init; }
    }
}
