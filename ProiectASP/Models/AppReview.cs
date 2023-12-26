namespace TemaASP.Models
{
    public class AppReview
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Descriere { get; set; }
        public DateTime DataReview { get; set; }

        public List<User> Users { get; set; }
    }
}
