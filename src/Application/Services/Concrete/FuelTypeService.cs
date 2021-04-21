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
            Context.FuelType.Add(fuelType);
            Context.SaveChanges();
            return Response.Succes("Yakıt Tipi Ekleme Başarılı");
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
            var updateTo = GetById(fuelType.Id);
            updateTo.Name = fuelType.Name;
            Context.SaveChanges();
            return Response.Succes("Güncelleme İşlemi Başarılı");
        }
    }
}
