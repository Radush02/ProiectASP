using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectASP.Models
{
    public class AppReview
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Descriere { get; set; }
        public DateTime DataReview { get; set; }
    }
}
