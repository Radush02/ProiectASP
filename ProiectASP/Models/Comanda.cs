using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectASP.Models
{
    public class Comanda
    {
        [Column("id")]
        public int ID { get; set; }
        [Column("order_date")]
        public DateTime DataComenzii { get; set; }
        [Column("idUser")]
        public int UserID { get; set; }
        [Column("idProdus")]
        public int ProdusID { get; set; }
        [Column("Cantitate")]
        public int cantitate { get; set; }
        public User Users { get; set; }
        public Produs Produse { get; set; }
    }
}
