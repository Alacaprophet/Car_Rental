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
    public class TireTypeService : BaseService, ITireTypeService
    {
        public TireTypeService(ICarRentalDbContext context) : base(context) { }
        public Response Add(TireType tire)
        {
            Context.TireType.Add(tire);
            Context.SaveChanges();
            return Response.Succes("Ekleme İşlemi Başarılı");
        }

        public Response Delete(TireType tire)
        {
            TireType DeleteToTire = GetById(tire.Id);
            Context.TireType.Remove(DeleteToTire);
            Context.SaveChanges();
            return Response.Succes("Silme İşlemi Başarılı");
        }

        public List<TireType> Get(TireTypeFilter filter)
        {
            List<TireType> list = (from tt in Context.TireType
                                   orderby tt.Name ascending
                                   select tt
                                   ).ToList();
            return list;
        }

        public TireType GetById(int id)
        {
            TireType item = (from tt in Context.TireType
                             where tt.Id == id
                             select tt
                           ).FirstOrDefault();
            return item;
        }

        public Response Update(TireType tire)
        {
            TireType UpdateToTire = GetById(tire.Id);
            UpdateToTire.Name = tire.Name;
            Context.SaveChanges();
            return Response.Succes("Güncelleme İşlemi Başarılı");
        }
    }
}
