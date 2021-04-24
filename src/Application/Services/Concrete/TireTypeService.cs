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
            Response checkadd = CheckToAddOrUpdate(tire);
            if (!checkadd.IsSuccess)
            {
                return checkadd;
            }
            Context.TireType.Add(tire);
            Context.SaveChanges();
            return Response.Succes("Ekleme İşlemi Başarılı");
        }
        private Response CheckToAddOrUpdate(TireType tire)
        {
            int SameNumberOfRecords = (from b in Context.TireType
                                       where b.Name == tire.Name && b.Id != tire.Id
                                       select b
                                       ).Count();
            if (SameNumberOfRecords > 0)
            {
                return Response.Fail($"{tire.Name} Lastik tipi sistemde zaten kayıtlıdır");
            }
            return Response.Succes();
        }
        public Response Delete(TireType tire)
        {
            Context.TireType.Remove(tire);
            Context.SaveChanges();
            return Response.Succes("Silme İşlemi Başarılı");
        }

        public List<TireType> Get(TireTypeFilter filter)
        {
            List<TireType> list = (from tt in Context.TireType
                                   where tt.Name.StartsWith(filter.Name)
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
            Response checkupdate = CheckToAddOrUpdate(tire);
            if (!checkupdate.IsSuccess)
            {
                return checkupdate;
            }
            TireType UpdateToTire = GetById(tire.Id);
            UpdateToTire.Name = tire.Name;
            Context.SaveChanges();
            return Response.Succes("Güncelleme İşlemi Başarılı");
        }
    }
}
