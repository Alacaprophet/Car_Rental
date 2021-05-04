using Application.Infrastructure.Persistence;
using Application.Services.Common;
using Domain.DTOs;
using Domain.DTOs.Filter;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    public class VehicleService:BaseService,IVehicleService
    {
        public VehicleService(ICarRentalDbContext context) : base(context) { }

        public Response Add(Vehicle vehicle)
        {
            Context.Vehicle.Add(vehicle);
            Context.SaveChanges();
            return Response.Succes("Ekleme İşlemi başarılı");
        }

        public Response Delete(int id)
        {
            var deleteToVehicle = GetById(id);
            Context.Vehicle.Remove(deleteToVehicle);
            Context.SaveChanges();
            return Response.Succes("Silme İşlemi Başarılı");
        }

        public List<VehicleDTO> Get(VehicleFilter filter)
        {
            //var item=(from v in Context.Vehicle.Include(v=>v.VehicleModel).Include(z => z.TransmissionType).Include(v => v.Fueltype).Include(v => v.TireType).Include(v => v.VehicleClassType).Include(v => v.ColorType)
            List<VehicleDTO> item = (from mode in Context.Vehicle
                                        join vm in Context.VehicleModel on mode.VehicleModelId equals vm.Id
                                        join trt in Context.TransmissionType on mode.TransmissionTypeId equals trt.Id
                                        join ft in Context.FuelType on mode.FuelTypeId equals ft.Id
                                        join tit in Context.TireType on mode.TireTypeId equals tit.Id
                                        join vct in Context.VehicleClassType on mode.VehicleClassTypeId equals vct.Id
                                        join ct in Context.ColorType on mode.ColorTypeId equals ct.Id
                                        join vb in Context.VehicleBrand on vm.VehicleBrandId equals vb.Id
                                     where true
                                  && (filter.VehicleModelId > 0 ? mode.VehicleModelId == filter.VehicleModelId : true)
                                  && (filter.TransmissionTypeIds > 0 ? mode.TransmissionTypeId == filter.TransmissionTypeIds : true)
                                  && (filter.FuelTypeIds > 0 ? mode.FuelTypeId == filter.FuelTypeIds : true)
                                  && (filter.VehicleClassTypeIds > 0 ? mode.VehicleClassTypeId == filter.VehicleClassTypeIds : true)
                                  && (filter.ColorTypeIds > 0 ? mode.ColorTypeId == filter.VehicleClassTypeIds : true)
                                  && (filter.TireTypeId > 0 ? mode.TireTypeId == filter.TireTypeId : true)
                                  &&
                                  (
                                        (filter.EngineDisplacementRange.Start.HasValue ? mode.EngineDisplacement>=filter.EngineDisplacementRange.Start.Value:true) 
                                        &&
                                        (filter.EngineDisplacementRange.End.HasValue ? mode.EngineDisplacement <= filter.EngineDisplacementRange.End.Value : true)
                                  )
                                  &&
                                  (
                                        (filter.ProductionYearRange.Start.HasValue ? mode.ProductionYear >= filter.ProductionYearRange.Start.Value : true)
                                        &&
                                        (filter.ProductionYearRange.End.HasValue ? mode.ProductionYear <= filter.ProductionYearRange.End.Value : true)
                                  )
                                  &&
                                  (
                                        (filter.HorsepowerRange.Start.HasValue ? mode.Horsepower>= filter.HorsepowerRange.Start.Value : true)
                                        &&
                                        (filter.HorsepowerRange.End.HasValue ? mode.Horsepower<= filter.HorsepowerRange.End.Value : true)
                                  )
                                     select new VehicleDTO
                                        {
                                            Id = mode.Id,
                                            VehicleBrandName=vb.Name,
                                            VehicleModelName = vm.Name,
                                            TransmissionTypeName = trt.Name,
                                            FuelTypeName = ft.Name,
                                            TireTypeName = tit.Name,
                                            VehicleClassTypeName = vct.Name,
                                            ColorTypeName = ct.Name,
                                            ProductionYear = mode.ProductionYear,
                                            EngineDisplacement = mode.EngineDisplacement,
                                            Horsepower = mode.Horsepower,
                                            Description = mode.Description
                                        }
                                        ).ToList();
            return item;
        }

        public Vehicle GetById(int id)
        {
            Vehicle vehicle = (from v in Context.Vehicle
                               where v.Id == id
                               select v
                             ).SingleOrDefault();
            return vehicle;
        }

        public VehicleDTO GetDetails(int id)
        {
            VehicleDTO item = (from mode in Context.Vehicle
                                     join vm in Context.VehicleModel on mode.VehicleModelId equals vm.Id
                                     join trt in Context.TransmissionType on mode.TransmissionTypeId equals trt.Id
                                     join ft in Context.FuelType on mode.FuelTypeId equals ft.Id
                                     join tit in Context.TireType on mode.TireTypeId equals tit.Id
                                     join vct in Context.VehicleClassType on mode.VehicleClassTypeId equals vct.Id
                                     join ct in Context.ColorType on mode.ColorTypeId equals ct.Id
                                     join vb in Context.VehicleBrand on vm.VehicleBrandId equals vb.Id
                               where mode.Id==id
                                     select new VehicleDTO
                                     {
                                         Id = mode.Id,
                                         VehicleBrandName = vb.Name,
                                         VehicleModelName = vm.Name,
                                         TransmissionTypeName = trt.Name,
                                         FuelTypeName = ft.Name,
                                         TireTypeName = tit.Name,
                                         VehicleClassTypeName = vct.Name,
                                         ColorTypeName = ct.Name,
                                         ProductionYear = mode.ProductionYear,
                                         EngineDisplacement = mode.EngineDisplacement,
                                         Horsepower = mode.Horsepower,
                                         Description = mode.Description
                                     }
                                        ).FirstOrDefault();
            return item;
        }

        public Response Update(Vehicle vehicle)
        {
            var UpdateToVehicle = GetById(vehicle.Id);
            UpdateToVehicle.VehicleModelId = vehicle.VehicleModelId;
            UpdateToVehicle.TransmissionTypeId = vehicle.TransmissionTypeId;
            UpdateToVehicle.FuelTypeId = vehicle.FuelTypeId;
            UpdateToVehicle.TireTypeId = vehicle.TireTypeId;
            UpdateToVehicle.VehicleClassTypeId = vehicle.VehicleClassTypeId;
            UpdateToVehicle.ColorTypeId = vehicle.ColorTypeId;
            UpdateToVehicle.ProductionYear = vehicle.ProductionYear;
            UpdateToVehicle.EngineDisplacement = vehicle.EngineDisplacement;
            UpdateToVehicle.Horsepower = vehicle.Horsepower;
            UpdateToVehicle.Description = vehicle.Description;
            Context.SaveChanges();
            return Response.Succes("Araç Güncelleme İşlemi Başarılı");
        }
    }
}
