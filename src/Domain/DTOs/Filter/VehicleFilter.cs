using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class VehicleFilter
    {
        [Required]
        [Display(Name = "Model")]
        public int VehicleModelId { get; set; }
        [Required]
        [Display(Name = "Şanzıman")]
        public int TransmissionTypeIds { get; set; }
        [Required]
        [Display(Name = "Yakıt tipi")]
        public int FuelTypeIds { get; set; }
        [Required]
        [Display(Name = "Lastik Türü")]
        public int TireTypeId { get; set; }
        [Required]
        [Display(Name = "Araç Sınıfı")]
        public int VehicleClassTypeIds { get; set; }
        [Required]
        [Display(Name = "Renk")]
        public int ColorTypeIds { get; set; }
        [Required]
        [Display(Name = "Üretim Yılı")]
        public RangeValue<int?> ProductionYearRange { get; set; } = new RangeValue<int?>();
        [Required]
        [Display(Name = "Motor Hacmi")] 
        public RangeValue<int?> EngineDisplacementRange { get; set; } = new RangeValue<int?>();
        [Required]
        [Display(Name = "Motor Gücü")]
        public RangeValue<int?> HorsepowerRange { get; set; } = new RangeValue<int?>();
    }
}
