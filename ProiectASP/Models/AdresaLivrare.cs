using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectASP.Models
{
    public class AdresaLivrare
    {
        public int ID { get; set; }
        public string Adresa { get; set; }
        public string Oras { get; set; }
    }
}