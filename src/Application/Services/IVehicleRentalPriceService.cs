using Domain.DTOs;
using Domain.DTOs.Filter;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
namespace Application.Services
{
    public interface IVehicleRentalPriceService
    {
        Response Add(VehicleRentalPrice vehicleRentalPrice);
        Response Update(VehicleRentalPrice vehicleRentalPrice);
        Response Delete(int id);
        VehicleRentalPrice GetById(int id);
        VehicleRentalPriceDTO GetDetail(int id);
        List<VehicleRentalPriceDTO> Get(VehicleRentalPriceFilter filter);
    }
}
