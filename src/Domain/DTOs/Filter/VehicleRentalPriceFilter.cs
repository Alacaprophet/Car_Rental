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
        public VehicleRentalPriceFilter(int vehicleid,DateTime? date=null)
        {
            VehicleId = vehicleid;
            Date = date;
        }

        public int VehicleId { get; set; }

        public DateTime? Date { get; set; }
    }
}
