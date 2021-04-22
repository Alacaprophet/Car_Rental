﻿using Application.Infrastructure.Persistence;
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
    public class RentalPeriodService : BaseService, IRentalPeriodService
    {
        public RentalPeriodService(ICarRentalDbContext context) : base(context) { }
        public Response Add(RentalPeriod rentalPeriod)
        {
            Context.RentalPeriod.Add(rentalPeriod);
            Context.SaveChanges();
            return Response.Succes("Ekleme işlemi başarılı");
        }

        public Response Delete(RentalPeriod rentalPeriod)
        {
            var item = GetById(rentalPeriod.Id);
            Context.RentalPeriod.Remove(item);
            Context.SaveChanges();
            return Response.Succes("Silme İşlemi Başarılı");
        }

        public List<RentalPeriod> Get(RentalPeriodFilter filter)
        {
            var list = (from rp in Context.RentalPeriod
                        orderby rp.Name ascending
                        select rp
                        ).ToList();
            return list;
        }

        public RentalPeriod GetById(int id)
        {
            var item = (from rp in Context.RentalPeriod
                        where rp.Id == id
                        select rp
                        ).FirstOrDefault();
            return item;
        }

        public Response Update(RentalPeriod rentalPeriod)
        {
            var updateTo = GetById(rentalPeriod.Id);
            updateTo.Name = rentalPeriod.Name;
            Context.SaveChanges();
            return Response.Succes("Güncelleme İşlemi Başarılı");
        }
    }
}
