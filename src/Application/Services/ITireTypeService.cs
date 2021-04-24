using Domain.DTOs;
using Domain.DTOs.Filter;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ITireTypeService
    {
        Response Add(TireType tire);
        Response Delete(TireType tire);
        Response Update(TireType tire);

        TireType GetById(int id);
        List<TireType> Get(TireTypeFilter filter);

    }
}
