using Application.Infrastructure.Persistence;
using Application.Services.Common;
using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    public class VehicleModelService :BaseService, IVehicleModelService
    {
        public VehicleModelService(ICarRentalDbContext context) : base(context) { }
        public Response Add(VehicleModel vehicleModel)
        {
            Context.VehicleModel.Add(vehicleModel);
            Context.SaveChanges();
            return Response.Succes("Ekleme Başarılı");
        }

        public Response Delete(int id)
        {
            var DeleteToModel = GetById(id);
            Context.VehicleModel.Remove(DeleteToModel);
            Context.SaveChanges();
            return Response.Succes("Başarılı bir şekilde silindi");
        }

        public List<VehicleModel> Get(VehicleModelFilter filter)
        {
            var items = (from m in Context.VehicleModel
                         orderby m.Name
                         select m).ToList();

            return items;
        }

        public VehicleModel GetById(int id)
        {
            return Context.VehicleModel.Where(m => m.Id == id).FirstOrDefault();
        }

        public Response Update(VehicleModel vehicleModel)
        {
            var vehicleModelToUpdate = GetById(vehicleModel.Id);
            vehicleModelToUpdate.Name = vehicleModel.Name;
            vehicleModelToUpdate.VehicleBrand = vehicleModel.VehicleBrand;
            Context.SaveChanges();
            return Response.Succes("Güncelleme Başarılı");
        }
    }
}
