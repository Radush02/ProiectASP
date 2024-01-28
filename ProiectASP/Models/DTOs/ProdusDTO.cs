using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectASP.Models.DTOs
{
    public class ProdusDTO
    {
        public string Nume { get; set; }
        public decimal Pret { get; set; }
        public string Descriere { get; set; }

        public string Categorie { get; set; }
    }
}
