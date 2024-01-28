using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectASP.Models
{
        public class User:IdentityUser<int>
        {
            public string Nume { get; set; }

            public string NrTelefon { get; set; }
            public AdresaLivrare AdreseLivrare { get; set; }
        
            public ICollection<Comanda> Comenzi {  get; set; }
        }

}
