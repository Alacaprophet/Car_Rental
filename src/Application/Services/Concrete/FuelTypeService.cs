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
    public class FuelTypeService : BaseService, IFuelTypeService
    {

        public FuelTypeService(CarRentalDbContext context) : base(context)
        {
        }

        public Response Add(FuelType fuelType)
        {
            Response checkadd = CheckToAddOrUpdate(fuelType);
            if (!checkadd.IsSuccess)
            {
                return checkadd;
            }
            Context.FuelType.Add(fuelType);
            Context.SaveChanges();
            return Response.Succes("Yakıt Tipi Ekleme Başarılı");
        }
        private Response CheckToAddOrUpdate(FuelType fuelType)
        {
            int SameNumberOfRecords = (from b in Context.FuelType
                                       where b.Name == fuelType.Name && b.Id != fuelType.Id
                                       select b
                                       ).Count();
            if (SameNumberOfRecords > 0)
            {
                return Response.Fail($"{fuelType.Name} yakıt tipi sistemde zaten kayıtlıdır");
            }
            return Response.Succes();
        }
        public Response Delete(int id)
        {
            var deleteTo = GetById(id);
            Context.FuelType.Remove(deleteTo);
            Context.SaveChanges();
            return Response.Succes("Silme işlemi Başarılı");
        }

        public List<FuelType> Get(FuelTypeFilter filter)
        {
            List<FuelType> list = (from l in Context.FuelType
                                   where l.Name.StartsWith(filter.Name)
                                   orderby l.Name ascending
                                    select l
                                    ).ToList();
            return list;
        }

        public FuelType GetById(int id)
        {
            var item = (from ft in Context.FuelType
                        where ft.Id == id
                        select ft
                        ).FirstOrDefault();
            return item;
        }

        public Response Update(FuelType fuelType)
        {
            Response checkupdate = CheckToAddOrUpdate(fuelType);
            if (!checkupdate.IsSuccess)
            {
                return checkupdate;
            }
            var updateTo = GetById(fuelType.Id);
            updateTo.Name = fuelType.Name;
            Context.SaveChanges();
            return Response.Succes("Güncelleme İşlemi Başarılı");
        }
    }
}
