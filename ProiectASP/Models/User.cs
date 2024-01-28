using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectASP.Models
{
        public class User
        {

            public int ID { get; set; }

            public string UserName { get; set; }
            public string Nume { get; set; }

            public string PassHash { get; set; }
            public string Salt {  get; set; }
            public AdresaLivrare AdreseLivrare { get; set; }
        
            public ICollection<Comanda> Comenzi {  get; set; }
        }

}
