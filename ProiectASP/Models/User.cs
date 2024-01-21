using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectASP.Models
{
    public class User
    {
        [Column("id")]
        public int ID { get; set; }
        [Column("UserName")]
        public string UserName { get; set; }
        [Column("Nume")]
        public string Nume { get; set; }

        public string PassHash { get; set; }
        public string Salt {  get; set; }
        public AdresaLivrare AdreseLivrare { get; set; }
    }

}
