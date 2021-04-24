using Application.Infrastructure.Persistence;
using Application.Services.Common;
using Domain.DTOs;
using Domain.DTOs.Filter;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    public class VehicleClassTypeService : BaseService, IVehicleClassTypeService
    {
        public VehicleClassTypeService(ICarRentalDbContext context) : base(context) { }
        public Response Add(VehicleClassType vehicleClassType)
        {
            Response checkadd = CheckToAddOrUpdate(vehicleClassType);
            if (!checkadd.IsSuccess)
            {
                return checkadd;
            }
            Context.VehicleClassType.Add(vehicleClassType);
            Context.SaveChanges();
            return Response.Succes("Ekleme İşlemi Başarılı");
        }
        private Response CheckToAddOrUpdate(VehicleClassType vehicleClassType)
        {
            int SameNumberOfRecords = (from b in Context.VehicleClassType
                                       where b.Name == vehicleClassType.Name && b.Id != vehicleClassType.Id
                                       select b
                                       ).Count();
            if (SameNumberOfRecords > 0)
            {
                return Response.Fail($"{vehicleClassType.Name} Vites tipi sistemde zaten kayıtlıdır");
            }
            return Response.Succes();
        }
        public Response Delete(VehicleClassType vehicleClassType)
        {
            Context.VehicleClassType.Remove(vehicleClassType);
            Context.SaveChanges();
            return Response.Succes("Silme işlemi başarılı");
        }

        public List<VehicleClassType> Get(VehicleClassTypeFilter filter)
        {
            List<VehicleClassType> list = (from vct in Context.VehicleClassType
                                           where vct.Name.StartsWith(filter.Name)
                                           orderby vct.Name ascending
                                           select vct
                                           ).ToList();
            return list;
        }

        public VehicleClassType GetById(int id)
        {
            VehicleClassType vehicle = (from v in Context.VehicleClassType
                                        where v.Id == id
                                        select v
                                        ).FirstOrDefault();
            return vehicle;
        }

        public Response Update(VehicleClassType vehicleClassType)
        {
            Response checkupdate = CheckToAddOrUpdate(vehicleClassType);
            if (!checkupdate.IsSuccess)
            {
                return checkupdate;
            }
            VehicleClassType updateToVehicle = GetById(vehicleClassType.Id);
            updateToVehicle.Name = vehicleClassType.Name;
            updateToVehicle.Description = vehicleClassType.Description;
            Context.SaveChanges();
            return Response.Succes("Güncelleme İşlemi başarılı");
        }
    }
}
