namespace TemaASP.Models
{
    public class Produs
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public decimal Pret { get; set; }
        public string Descriere { get; set; }

        public List<Comanda> Comenzi { get; set; }
    }
}
