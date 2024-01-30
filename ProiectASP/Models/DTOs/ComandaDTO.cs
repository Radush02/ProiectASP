using ProiectASP.Models.DTOs.ProdusDTOs;
using ProiectASP.Models.DTOs.UserDTOs;

namespace ProiectASP.Models.DTOs
{
    public class ComandaDTO
    {
        public UserInfoDTO user { get; set; }
        public ProdusDTO produs { get; set; }
        public DateTime DataComenzii { get; set; }
        public int cantitate { get; set; }

    }
}
