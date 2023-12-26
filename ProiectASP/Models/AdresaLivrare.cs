using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectASP.Models
{
    public class AdresaLivrare
    {
        [Column("id")]
        public int ID { get; set; }
        [Column("Adresa")]
        public string Adresa { get; set; }
        [Column("oras")]
        public string Oras { get; set; }
    }
}