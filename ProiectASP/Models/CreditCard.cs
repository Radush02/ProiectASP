namespace ProiectASP.Models
{
    public class CreditCard
    {
        public int ID {  get; set; }
        public int userID { get; set; }
        public string NumarCard { get; set; }
        public int CVV { get; set; }
        public string Data_Expirare { get; set; }
        public User Users { get; set; }
    }
}
