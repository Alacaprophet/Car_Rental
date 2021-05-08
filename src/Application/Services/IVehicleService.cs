using Domain.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IVehicleService
    {
        Response Add(Vehicle vehicle);
        Response Update(Vehicle vehicle);
        Response Delete(int id);
        Vehicle GetById(int id);
        List<VehicleDTO> Get(VehicleFilter filter);
        VehicleDTO GetDetail(int id);
        List<VehicleListItemDTO> GetListItems(VehicleFilter filter);
    }
}
