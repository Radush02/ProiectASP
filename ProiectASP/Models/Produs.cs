﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ProiectASP.Models
{
    public class Produs
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public decimal Pret { get; set; }

        public string Descriere { get; set; }

        public string Categorie { get; set; }

        public ICollection<Comanda> Comenzi { get; set; }
    }
}
