using System;

namespace BLL.Models.Models.ShelterModels
{
    public class ShelterListItemDTO
    {
        public Guid ShelterId { get; set; }

        public string Address { get; set; } 

        public DateTime OpeningHour { get; set; }   

        public DateTime ClosingHour { get; set; }

        public byte[] ProfileImage { get; set; }

        public string Description { get; set; }
    }
}
