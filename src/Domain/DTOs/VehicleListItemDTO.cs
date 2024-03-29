﻿namespace Domain.DTOs
{
    public class VehicleListItemDTO
    {
        public int Id { get; set; }
        public string VehicleBrandName { get; set; }
        public string VehicleModelName { get; set; }
        public string TransmissionTypeName { get; set; }
        public string FuelTypeName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
