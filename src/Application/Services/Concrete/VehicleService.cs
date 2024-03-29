using Application.Infrastructure.Persistence;
using Application.Services.Common;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Concrete
{
    public class VehicleService : BaseService, IVehicleService
    {
        public VehicleService(ICarRentalDbContext context) : base(context)
        {

        }

        public Response Add(Vehicle vehicle)
        {
            Context.Vehicle.Add(vehicle);
            Context.SaveChanges();

            return Response.Succes("Araç başarıyla kaydedildi");
        }

        public Response Update(Vehicle vehicle)
        {
            var vehicleToUpdate = GetById(vehicle.Id);
            vehicleToUpdate.VehicleModelId = vehicle.VehicleModelId;
            vehicleToUpdate.TransmissionTypeId = vehicle.TransmissionTypeId;
            vehicleToUpdate.FuelTypeId = vehicle.FuelTypeId;
            vehicleToUpdate.TireTypeId = vehicle.TireTypeId;
            vehicleToUpdate.VehicleClassTypeId = vehicle.VehicleClassTypeId;
            vehicleToUpdate.ColorTypeId = vehicle.ColorTypeId;
            vehicleToUpdate.ProductionYear = vehicle.ProductionYear;
            vehicleToUpdate.EngineDisplacement = vehicle.EngineDisplacement;
            vehicleToUpdate.Horsepower = vehicle.Horsepower;
            vehicleToUpdate.Description = vehicle.Description;
            Context.SaveChanges();

            return Response.Succes("Araç başarıyla güncellendi");
        }

        public Response Delete(int id)
        {
            var vehicleToDelete = GetById(id);
            Context.Vehicle.Remove(vehicleToDelete);
            Context.SaveChanges();

            return Response.Succes("Araç başarıyla silindi");
        }

        public List<VehicleDTO> Get(VehicleFilter filter)
        {
            var items = (from v in Context.Vehicle.Include(x => x.ColorType)
                                                  .Include(x => x.Fueltype)
                                                  .Include(x => x.VehicleClassType)
                                                  .Include(x => x.TireType)
                                                  .Include(x => x.TransmissionType)
                                                  .Include(x => x.VehicleModel.VehicleBrand)
                         where 1 == 1
                            && (filter.VehicleModelId > 0 ? v.VehicleModelId == filter.VehicleModelId : true)
                            && (filter.TransmissionTypeIds > 0 ? v.TransmissionTypeId == filter.TransmissionTypeIds : true)
                            && (filter.FuelTypeIds > 0 ? v.FuelTypeId == filter.FuelTypeIds : true)
                            && (filter.VehicleClassTypeIds > 0 ? v.VehicleClassTypeId == filter.VehicleClassTypeIds : true)
                            && (filter.ColorTypeIds > 0 ? v.ColorTypeId == filter.ColorTypeIds : true)
                            && (filter.TireTypeId > 0 ? v.TireTypeId == filter.TireTypeId : true)
                            &&
                            (
                                (filter.ProductionYearRange.Start.HasValue ? v.ProductionYear >= filter.ProductionYearRange.Start.Value : true)
                                &&
                                (filter.ProductionYearRange.End.HasValue ? v.ProductionYear <= filter.ProductionYearRange.End.Value : true)
                            )
                            &&
                            (
                                (filter.EngineDisplacementRange.Start.HasValue ? v.EngineDisplacement >= filter.EngineDisplacementRange.Start.Value : true)
                                &&
                                (filter.EngineDisplacementRange.End.HasValue ? v.EngineDisplacement <= filter.EngineDisplacementRange.End.Value : true)
                            )
                            &&
                            (
                                (filter.HorsepowerRange.Start.HasValue ? v.Horsepower >= filter.HorsepowerRange.Start.Value : true)
                                &&
                                (filter.HorsepowerRange.End.HasValue ? v.Horsepower <= filter.HorsepowerRange.End.Value : true)
                            )
                         select new VehicleDTO
                         {
                             ColorTypeId = v.ColorTypeId,
                             ColorTypeName = v.ColorType.Name,
                             Description = v.Description,
                             EngineDisplacement = v.EngineDisplacement,
                             FuelTypeId = v.FuelTypeId,
                             FuelTypeName = v.Fueltype.Name,
                             Horsepower = v.Horsepower,
                             Id = v.Id,
                             ProductionYear = v.ProductionYear,
                             TireTypeId = v.TireTypeId,
                             TireTypeName = v.TireType.Name,
                             TransmissionTypeId = v.TransmissionTypeId,
                             TransmissionTypeName = v.TransmissionType.Name,
                             VehicleBrandId = v.VehicleModel.VehicleBrandId,
                             VehicleBrandName = v.VehicleModel.VehicleBrand.Name,
                             VehicleClassTypeId = v.VehicleClassTypeId,
                             VehicleClassTypeName = v.VehicleClassType.Name,
                             VehicleModelId = v.VehicleModelId,
                             VehicleModelName = v.VehicleModel.Name
                         }).ToList();
            return items;
        }

        public Vehicle GetById(int id)
        {
            return Context.Vehicle.Where(m => m.Id == id).SingleOrDefault();
        }

        public VehicleDTO GetDetail(int id)
        {
            var item = (from v in Context.Vehicle.Include(x => x.ColorType)
                                                 .Include(x => x.Fueltype)
                                                 .Include(x => x.VehicleClassType)
                                                 .Include(x => x.TireType)
                                                 .Include(x => x.TransmissionType)
                                                 .Include(x => x.VehicleModel.VehicleBrand)
                        where v.Id == id
                        select new VehicleDTO
                        {
                            ColorTypeId = v.ColorTypeId,
                            ColorTypeName = v.ColorType.Name,
                            Description = v.Description,
                            EngineDisplacement = v.EngineDisplacement,
                            FuelTypeId = v.FuelTypeId,
                            FuelTypeName = v.Fueltype.Name,
                            Horsepower = v.Horsepower,
                            Id = v.Id,
                            ProductionYear = v.ProductionYear,
                            TireTypeId = v.TireTypeId,
                            TireTypeName = v.TireType.Name,
                            TransmissionTypeId = v.TransmissionTypeId,
                            TransmissionTypeName = v.TransmissionType.Name,
                            VehicleBrandId = v.VehicleModel.VehicleBrandId,
                            VehicleBrandName = v.VehicleModel.VehicleBrand.Name,
                            VehicleClassTypeId = v.VehicleClassTypeId,
                            VehicleClassTypeName = v.VehicleClassType.Name,
                            VehicleModelId = v.VehicleModelId,
                            VehicleModelName = v.VehicleModel.Name
                        }).SingleOrDefault();
            return item;
        }

        public List<VehicleListItemDTO> GetListItems(VehicleFilter filter)
        {
            var items = (from v in Context.Vehicle.Include(x => x.Fueltype)
                                                  .Include(x => x.TransmissionType)
                                                  .Include(x => x.VehicleModel.VehicleBrand)
                                                  .Include(x => x.VehicleImage)
                                                  .Include(x => x.VehicleRentalPrice)
                         where 1 == 1
                            && v.VehicleRentalPrice.Count(p => p.StartDate <= DateTime.Today && p.EndDate >= DateTime.Today) > 0
                            && (filter.VehicleModelId > 0 ? v.VehicleModelId == filter.VehicleModelId : true)
                            && (filter.TransmissionTypeIds > 0 ? v.TransmissionTypeId == filter.TransmissionTypeIds : true)
                            && (filter.FuelTypeIds > 0 ? v.FuelTypeId == filter.FuelTypeIds : true)
                            && (filter.VehicleClassTypeIds > 0 ? v.VehicleClassTypeId == filter.VehicleClassTypeIds : true)
                            && (filter.ColorTypeIds > 0 ? v.ColorTypeId == filter.ColorTypeIds : true)
                            && (filter.TireTypeId > 0 ? v.TireTypeId == filter.TireTypeId : true)
                            &&
                            (
                                (filter.ProductionYearRange.Start.HasValue ? v.ProductionYear >= filter.ProductionYearRange.Start.Value : true)
                                &&
                                (filter.ProductionYearRange.End.HasValue ? v.ProductionYear <= filter.ProductionYearRange.End.Value : true)
                            )
                            &&
                            (
                                (filter.EngineDisplacementRange.Start.HasValue ? v.EngineDisplacement >= filter.EngineDisplacementRange.Start.Value : true)
                                &&
                                (filter.EngineDisplacementRange.End.HasValue ? v.EngineDisplacement <= filter.EngineDisplacementRange.End.Value : true)
                            )
                            &&
                            (
                                (filter.HorsepowerRange.Start.HasValue ? v.Horsepower >= filter.HorsepowerRange.Start.Value : true)
                                &&
                                (filter.HorsepowerRange.End.HasValue ? v.Horsepower <= filter.HorsepowerRange.End.Value : true)
                            )
                         select new VehicleListItemDTO
                         {
                             FuelTypeName = v.Fueltype.Name,
                             Id = v.Id,
                             TransmissionTypeName = v.TransmissionType.Name,
                             VehicleBrandName = v.VehicleModel.VehicleBrand.Name,
                             VehicleModelName = v.VehicleModel.Name,
                             ImageUrl = v.VehicleImage.Count() > 0 ? v.VehicleImage.FirstOrDefault().ImageUrl : "",
                             Price = v.VehicleRentalPrice.Where(p => p.StartDate <= DateTime.Today && p.EndDate >= DateTime.Today)
                                                         .OrderBy(p => p.Price).FirstOrDefault().Price
                         }).ToList();
            return items;
        }
    }
}
