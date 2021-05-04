using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class VehicleDTO
    {
        //public int VehicleModelId { get; set; }
       // public int TransmissionTypeId { get; set; }
       // public int FuelTypeId { get; set; }
       // public int TireTypeId { get; set; }
       // public int VehicleClassTypeId { get; set; }
       // public int ColorTypeId { get; set; }
        public int Id { get; set; }
        [Display(Name = "Marka")]
        public string VehicleBrandName { get; set; }
        [Display(Name="Model")]
        public string VehicleModelName { get; set; }
        [Display(Name = "Vites Türü")]
        public string TransmissionTypeName { get; set; }
        [Display(Name = "Yakıt Türü")]
        public string FuelTypeName { get; set; }
        [Display(Name = "Lastik Türü")]
        public string TireTypeName { get; set; }
        [Display(Name = "Araç Sınıfı")]
        public string VehicleClassTypeName { get; set; }
        [Display(Name = "Renk")]
        public string ColorTypeName { get; set; }
        [Display(Name = "Üretim Yılı")]
        public int ProductionYear { get; set; }
        [Display(Name = "Motor Hacmi")]
        public int EngineDisplacement { get; set; }
        [Display(Name = "Beygir Gücü")]
        public int Horsepower { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
    }
}
