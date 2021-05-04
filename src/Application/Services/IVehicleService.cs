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
    public interface IVehicleService
    {
        List<VehicleDTO> Get(VehicleFilter filter);
        VehicleDTO GetDetails(int id);
        Response Add(Vehicle vehicle);
        Response Delete(int id);
        Vehicle GetById(int id);
        Response Update(Vehicle vehicle);
    }
}
