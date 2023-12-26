using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectASP.Models
{
    public class Produs
    {
        [Column("ID")]
        public int ID { get; set; }
        [Column("Nume")]
        public string Nume { get; set; }
        [Column("Pret")]
        public decimal Pret { get; set; }
        [Column("Descriere")]
        public string Descriere { get; set; }
    }
}
