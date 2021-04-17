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
        void Add(VehicleBrand vehicleBrand);
        void Update(VehicleBrand vehicleBrand);
        VehicleBrand GetById(int id);
        void Delete(int id);
        List<VehicleBrand> Get(VehicleBrandFilter filter);
        string GetName();
    }
}
