using System;
using System.Collections.Generic;
using BLL.Models.Models.PetModels;
using DAL.Models.Models.Filter;

namespace BLL.Contracts
{
    public interface IPetService
    {
        PetDTO GetById(Guid petid);

        List<PetListItemDTO> List(PetFilter filter);

        void Apply(PetDTO petModel);

        void Delete(Guid id);
    }
}
