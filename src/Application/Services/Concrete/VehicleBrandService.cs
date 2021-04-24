using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Infrastructure.Persistence;
using Domain.DTOs.Filter;
using Domain.DTOs;
using Application.Services.Common;

namespace Application.Services.Concrete
{
    public class VehicleBrandService : BaseService, IVehicleBrandService
    {

        public VehicleBrandService(ICarRentalDbContext context):base(context)
        {
        }
        public Response Add(VehicleBrand vehicleBrand)
        {
            var checkadd = CheckToAddOrUpdate(vehicleBrand);
            if (!checkadd.IsSuccess)
            {
                return checkadd;
            }
            Context.VehicleBrand.Add(vehicleBrand);
            Context.SaveChanges();
            return Response.Succes($"{vehicleBrand.Name} markası başarı ile kayıt edildi");
        }
        private Response CheckToAddOrUpdate(VehicleBrand vehicleBrand)
        {
            
            int SameNumberOfRecords = (from b in Context.VehicleBrand
                                       where b.Name== vehicleBrand.Name && b.Id!= vehicleBrand.Id
                                       select b
                                       ).Count();
            if (SameNumberOfRecords > 0)
            {
                return Response.Fail($"{vehicleBrand.Name} markası sistemde zaten kayıtlıdır");
            }
           
            return Response.Succes();
        }
        public VehicleBrand GetById(int id)
        {
            return Context.VehicleBrand.Where(v => v.Id == id).SingleOrDefault();
        } 
        public Response Update(VehicleBrand vehiclebrand)
        {
            var checkupdate = CheckToAddOrUpdate(vehiclebrand);
            if (!checkupdate.IsSuccess)
            {
                return checkupdate;
            }
            var VehicleBrandToUpdate = GetById(vehiclebrand.Id);
            VehicleBrandToUpdate.Name = vehiclebrand.Name;
            Context.SaveChanges();
            return Response.Succes("Marka başarıyla güncellendi");
        }
        public Response Delete(int id)
        {
            var vehicleBrandToDelete = GetById(id);
            var checkResponse = CheckToDelete(vehicleBrandToDelete);
            if (!checkResponse.IsSuccess)
            {
                return checkResponse;
            }
            Context.VehicleBrand.Remove(vehicleBrandToDelete);
            Context.SaveChanges();
            return Response.Succes("Silme işlemi başarı ile geçekleşti");
        }
        private Response CheckToDelete(VehicleBrand vehicleBrand)
        {
            #region chech related models
            int numberOfModels = Context.VehicleModel.Where(m => m.VehicleBrandId == vehicleBrand.Id).Count();
            if (numberOfModels>0)
            {
                return Response.Fail($"{vehicleBrand.Name} markasına ait {numberOfModels} adet model olduğundan bu marka silinemiyor");
            }
            return Response.Succes();
        }
        public List<VehicleBrand> Get(VehicleBrandFilter filter)
        {
            var items = (from v in Context.VehicleBrand
                where v.Name.StartsWith(filter.Name)
                orderby     v.Name
                select v).ToList();
            return items;
        }
        public string GetName()
        {
            return "Vehicle brand service getname";
        }
    }
}
