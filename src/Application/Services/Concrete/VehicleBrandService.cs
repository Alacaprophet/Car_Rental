using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Infrastructure.Persistence;
using Domain.DTOs.Filter;

namespace Application.Services.Concrete
{
    public class VehicleBrandService : IVehicleBrandService
    {
        private ICarRentalDbContext Context { get;}

        public VehicleBrandService(ICarRentalDbContext context)
        {
            Context = context;
        }
        public void Add(VehicleBrand vehicleBrand)
        {
            Context.VehicleBrand.Add(vehicleBrand);
            Context.SaveChanges();
        }

        public VehicleBrand GetById(int id)
        {
            return Context.VehicleBrand.Where(v => v.Id == id).SingleOrDefault();
        } 
        public void Update(VehicleBrand vehiclebrand)
        {
            var VehicleBrandToUpdate = GetById(vehiclebrand.Id);
            VehicleBrandToUpdate.Name = vehiclebrand.Name;
            Context.SaveChanges();
        }
        public void Delete(int id)
        {
            var Deleting = GetById(id);
            Context.VehicleBrand.Remove(Deleting);
            Context.SaveChanges();
        }
        public List<VehicleBrand> Get(VehicleBrandFilter filter)
        {
            var items = (from v in Context.VehicleBrand
                where v.Name.StartsWith(filter.Name)
                orderby     v.Name
                select v).ToList();
            return items;
        }
        public string GetName()
        {
            return "Vehicle brand service getname";
        }
    }
}
