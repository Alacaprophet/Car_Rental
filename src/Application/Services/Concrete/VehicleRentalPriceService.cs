using Application.Infrastructure.Persistence;
using Application.Services.Common;
using Domain.DTOs;
using Domain.DTOs.Filter;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    public class VehicleRentalPriceService : BaseService, IVehicleRentalPriceService
    {
        public VehicleRentalPriceService(ICarRentalDbContext context) : base(context) { }
        
        public Response Add(VehicleRentalPrice vehicleRentalPrice)
        {
            Context.VehicleRentalPrice.Add(vehicleRentalPrice);
            Context.SaveChanges();
            return Response.Succes("Ekleme İşlemi Başarılı");
        }
        private Response CheckToAddOrUpdate(VehicleRentalPrice vehicleRentalPrice)
        {
            int SameNumberOfRecords = (from b in Context.VehicleRentalPrice
                                       where b.Price == vehicleRentalPrice.Price &&b.RentalPeriod==vehicleRentalPrice.RentalPeriod && b.StartDate==vehicleRentalPrice.StartDate && b.Id != vehicleRentalPrice.Id
                                       select b
                                       ).Count();
            if (SameNumberOfRecords > 0)
            {
                return Response.Fail($"Araç kiralama işlemleri sistemde zaten kayıtlıdır");
            }
            return Response.Succes();
        }
        public Response Delete(VehicleRentalPrice vehicleRentalPrice)
        {
            throw new NotImplementedException();
        }
        //var item = (from mode
        //                  in (from vrp in Context.VehicleRentalPrice
        //                      join v in Context.Vehicle
        //                      on vrp.VehicleId equals v.Id
        //                      select new { v.VehicleModelId, v.TransmissionTypeId, v.ColorTypeId, v.ProductionYear, vrp.RentalPeriodId }
        //                      )
        //            join rp in Context.RentalPeriod
        //                on mode.RentalPeriodId equals rp.Id
        //            join vm in Context.VehicleModel
        //                on mode.VehicleModelId equals vm.Id
        //            join tt in Context.TransmissionType
        //                on mode.TransmissionTypeId equals tt.Id
        //            join ct in Context.ColorType
        //                on mode.ColorTypeId equals ct.Id

        //            select new { ModelName = vm.Name, TransmissionName = tt.Name, RentalPeriod = rp.Name, ColorName = ct.Name, ProductYear = mode.ProductionYear }
        //               ).ToList();
        public List<VehicleRentalPriceTable> Get(VehicleRentalPriceFilter filter)
        {
            var item = (from mode
                              in (from vrp in Context.VehicleRentalPrice
                                  join v in Context.Vehicle
                                  on vrp.VehicleId equals v.Id
                                  select new { v.VehicleModelId, v.TransmissionTypeId, v.ColorTypeId, v.ProductionYear, vrp.RentalPeriodId,vrp.Price ,vrp.Id}
                                  )
                        join rp in Context.RentalPeriod
                            on mode.RentalPeriodId equals rp.Id
                        join vm in Context.VehicleModel
                            on mode.VehicleModelId equals vm.Id
                        join tt in Context.TransmissionType
                            on mode.TransmissionTypeId equals tt.Id
                        join ct in Context.ColorType
                            on mode.ColorTypeId equals ct.Id

                        
                        select new VehicleRentalPriceTable { ModelName = vm.Name, TransmissionName = tt.Name, PeriodName = rp.Name, ColorName = ct.Name, ProductYear = mode.ProductionYear, Fee = mode.Price , RentalPriceId =mode.Id}
                             ).ToList();

            return item;
        }

        public VehicleModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Response Update(VehicleRentalPrice vehicleRentalPrice)
        {
            throw new NotImplementedException();
        }
    }
}
