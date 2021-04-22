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
    public interface ITransmissionTypeService
    {
        Response Add(TransmissionType transmissionType);
        Response Update(TransmissionType transmissionType);
        Response Delete(TransmissionType transmissionType);
        TransmissionType GetById(int id);
        List<TransmissionType> Get(TransmissionTypeFilter filter);
    }
}
