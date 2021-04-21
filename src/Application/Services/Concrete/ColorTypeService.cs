using Domain.DTOs;
using Domain.DTOs.Filter;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Infrastructure.Persistence;
namespace Application.Services.Concrete
{
    public class ColorTypeService : IColorTypeService
    {
        public static CarRentalDbContext Context { get; set; }
        public ColorTypeService(CarRentalDbContext context)
        {
            Context = context;
        }
        public Response Add(ColorType color)
        {
            Context.ColorType.Add(color);
            Context.SaveChanges();
            return Response.Succes("Renk Ekleme Başarılı");
        }

        public Response Delete(int id)
        {
            var DeleteTo = GetById(id);
            Context.ColorType.Remove(DeleteTo);
            Context.SaveChanges();
            return Response.Succes("Renk Silme Başarılı");
        }

        public List<ColorType> Get(ColorTypeFilter filter)
        {
            List<ColorType> list = (from a in Context.ColorType
                                    orderby a.Name ascending
                                    select a
                                   ).ToList();
            return list;
        }

        public ColorType GetById(int id)
        {
            var item = (from m in Context.ColorType
                        where m.Id == id
                        select m
                      ).FirstOrDefault();
            return item;
        }

        public Response Update(ColorType colorType)
        {
            var item = GetById(colorType.Id);
            item.Name = colorType.Name;
            Context.SaveChanges();
            return Response.Succes("Güncelleme Başarılı");
        }
    }
}
