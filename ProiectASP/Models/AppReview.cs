using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectASP.Models
{
    public class AppReview
    {
        [Column("id")]
        public int ID { get; set; }
        [Column("UserID")]
        public int UserID { get; set; }
        [Column("Descriere")]
        public string Descriere { get; set; }
        [Column("DataReview")]
        public DateTime DataReview { get; set; }
    }
}
