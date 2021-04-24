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
    public class TransmissionTypeService : BaseService, ITransmissionTypeService
    {
        public TransmissionTypeService(ICarRentalDbContext context) : base(context) { }
        public Response Add(TransmissionType transmissionType)
        {
            var checkadd = CheckToAddOrUpdate(transmissionType);
            if (!checkadd.IsSuccess)
            {
                return checkadd;
            }
            Context.TransmissionType.Add(transmissionType);
            Context.SaveChanges();
            return Response.Succes($"{transmissionType.Name} Vites tipi başarı ile kayıt edildi");
        }
        private Response CheckToAddOrUpdate(TransmissionType transmissionType)
        {
            int SameNumberOfRecords = (from b in Context.TransmissionType
                                       where b.Name == transmissionType.Name && b.Id != transmissionType.Id
                                       select b
                                       ).Count();
            if (SameNumberOfRecords > 0)
            {
                return Response.Fail($"{transmissionType.Name} Vites tipi sistemde zaten kayıtlıdır");
            }
            return Response.Succes();
        }
        public Response Delete(TransmissionType transmissionType)
        {
            Context.TransmissionType.Remove(transmissionType);
            Context.SaveChanges();
            return Response.Succes("Silme işlemi başarı ile geçekleşti");
        }

        public List<TransmissionType> Get(TransmissionTypeFilter filter)
        {
            var items = (from v in Context.TransmissionType
                         where v.Name.StartsWith(filter.Name)
                         orderby v.Name
                         select v).ToList();
            return items;
        }

        public TransmissionType GetById(int id)
        {
            return Context.TransmissionType.Where(v => v.Id == id).SingleOrDefault();
        }

        public Response Update(TransmissionType transmissionType)
        {
            var checkupdate = CheckToAddOrUpdate(transmissionType);
            if (!checkupdate.IsSuccess)
            {
                return checkupdate;
            }
            var VehicleBrandToUpdate = GetById(transmissionType.Id);
            VehicleBrandToUpdate.Name = transmissionType.Name;
            Context.SaveChanges();
            return Response.Succes("Vites tipi başarıyla güncellendi");
        }
    }
}
