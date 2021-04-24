using Application.Infrastructure.Persistence;
using Application.Services.Common;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
            var checkadd = CheckToAddOrUpdate(vehicleModel);
            if (!checkadd.IsSuccess)
            {
                return checkadd;
            }
            Context.VehicleModel.Add(vehicleModel);
            Context.SaveChanges();
            return Response.Succes("Ekleme Başarılı");
        }
        private Response CheckToAddOrUpdate(VehicleModel vehicleModel)
        {
            int SameNumberOfRecords = (from b in Context.VehicleModel
                                       where b.Name == vehicleModel.Name && 
                                       b.VehicleBrandId==vehicleModel.VehicleBrandId&&
                                       b.Id != vehicleModel.Id
                                       select b
                                       ).Count();
            if (SameNumberOfRecords > 0)
            {
                return Response.Fail($"{vehicleModel.Name} modeli sistemde zaten kayıtlıdır");
            }
            return Response.Succes();
        }
        public Response Update(VehicleModel vehicleModel)
        {
            var checkupdate = CheckToAddOrUpdate(vehicleModel);
            if (!checkupdate.IsSuccess)
            {
                return checkupdate;
            }
            var vehicleModelToUpdate = GetById(vehicleModel.Id);
            vehicleModelToUpdate.Name = vehicleModel.Name;
            vehicleModelToUpdate.VehicleBrand = vehicleModel.VehicleBrand;
            Context.SaveChanges();
            return Response.Succes("Güncelleme Başarılı");
        }
        public Response Delete(int id)
        {
            var DeleteToModel = GetById(id);
            Context.VehicleModel.Remove(DeleteToModel);
            Context.SaveChanges();
            return Response.Succes("Başarılı bir şekilde silindi");
        }

        public List<VehicleModelDTO> Get(VehicleModelFilter filter)
        {
            var items = (from m in Context.VehicleModel
                         join b in Context.VehicleBrand on m.VehicleBrandId equals b.Id
                         orderby m.Name
                         select new VehicleModelDTO 
                                 {
                                    Id=m.Id,
                                    Name=m.Name,
                                    VehicleBranId=b.Id,
                                    VehicleBrandName=b.Name
                                 }
                         ).ToList();
            return items;
        }

        public VehicleModel GetById(int id)
        {
            return Context.VehicleModel.Where(m => m.Id == id).FirstOrDefault();
        }
        public VehicleModelDTO GetDetail(int id)
        {
            var item = (from m in Context.VehicleModel.Include(m=>m.VehicleBrand)
                        where m.Id == id
                        select new VehicleModelDTO
                        {
                            Id = m.Id,
                            Name = m.Name,
                            VehicleBranId=m.VehicleBrandId,
                            VehicleBrandName=m.VehicleBrand.Name
                        }).SingleOrDefault();
            return item;
        }
        
    }
}
