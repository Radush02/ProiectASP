using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectASP.Models.DTOs.UserDTOs
{
    public class FullUserDTO
    {
        public string UserName { get; set; }
        public string Nume { get; set; }
        public string Parola { get; set; }
        public string Email { get; set; }
        public string NrTelefon {  get; set; }
        public string Adresa { get; set; }
        public string Oras { get; set; }
    }
}
