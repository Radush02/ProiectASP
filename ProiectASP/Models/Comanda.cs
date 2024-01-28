using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectASP.Models
{
    public class Comanda
    {
        public int ID { get; set; }
        public DateTime DataComenzii { get; set; }
        public int UserID { get; set; }
        public int ProdusID { get; set; }
        public int cantitate { get; set; }
        public User Users { get; set; }
        public Produs Produse { get; set; }
    }
}
