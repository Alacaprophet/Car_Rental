using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Filter
{
    public class VehicleRentalPriceFilter
    {
        public int VehicleId { get; set; }

       
        public int RentalPeriodId { get; set; }
      
        public decimal Price { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        public Vehicle Vehicle { get; set; }
        public RentalPeriod RentalPeriod { get; set; }
    }
}
