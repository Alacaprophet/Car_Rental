﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int VehicleModelId { get; set; }

        [Required]
        public  int TransmissionTypeId { get; set; }

        [Required]
        public int FuelTypeId { get; set; }

        [Required]
        public int TireTypeId { get; set; }

        [Required]
        public int VehicleClassTypeId { get; set; }

        [Required]
        public int ColorTypeId { get; set; }

        [Required]
        public int ProductionYear { get; set; }

        [Required]
        public int EngineDisplacement { get; set; }

        [Required]
        public int Horsepower { get; set; }

        [Required]
        public string Description { get; set; }

        public VehicleModel VehicleModel { get; set; }
        public TransmissionType TransmissionType { get; set; }

        public FuelType Fueltype { get; set; }
        public TireType TireType { get; set; }
        public VehicleClassType VehicleClassType { get; set; }
        public ColorType ColorType { get; set; }
        public ICollection<VehicleImage> VehicleImage { get; set; }
        public ICollection<VehicleRentalPrice> VehicleRentalPrice { get; set; }


    }
}
