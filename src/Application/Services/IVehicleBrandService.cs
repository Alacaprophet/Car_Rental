using Domain.DTOs;
using Domain.DTOs.Filter;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IVehicleBrandService
    {
        Response Add(VehicleBrand vehicleBrand);
        Response Update(VehicleBrand vehicleBrand);
        Response Delete(int id);
        VehicleBrand GetById(int id);
        List<VehicleBrand> Get(VehicleBrandFilter filter);

        string GetName();
    }
}
