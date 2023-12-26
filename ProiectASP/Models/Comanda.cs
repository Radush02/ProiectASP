namespace ProiectASP.Models
{
    public class Comanda
    {
        public int ID { get; set; }
        public DateTime DataComenzii { get; set; }
        public int UserID { get; set; }
        public int ProdusID { get; set; }
        public int pret { get; set; }
        public User Users { get; set; }
        public List<Produs> Produse { get; set; }
    }
}
