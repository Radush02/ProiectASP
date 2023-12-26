using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemaASP.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Nume { get; set; }
        public List<AdresaLivrare> AdreseLivrare { get; set; }
    }

}
