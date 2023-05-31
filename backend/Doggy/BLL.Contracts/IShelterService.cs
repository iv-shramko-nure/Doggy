using BLL.Models.Models.ShelterModels;
using DAL.Models.Models.Filter;
using System;
using System.Collections.Generic;

namespace BLL.Contracts
{
    public interface IShelterService
    {
        ShelterDTO GetShelterById(Guid shelterId);

        List<ShelterListItemDTO> List(ShelterFilter filter);

        Guid Apply(ShelterDTO model);

        void Delete(Guid shelterId);
    }
}
