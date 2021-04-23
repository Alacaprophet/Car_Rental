using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
     public  class VehicleRentalPriceTable
    {
        public int RentalPriceId { get; set; }
        public string ModelName { get; set; }
        public string TransmissionName { get; set; }
        public string PeriodName { get; set; }
        public string ColorName { get; set; }
        public int ProductYear { get; set; }
        public Decimal Fee { get; set; }
    }
}
