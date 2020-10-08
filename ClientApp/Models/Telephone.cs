using System;

namespace WebApp.Models.EntityFramework
{
    public class Telephone
    {
        public int TelephoneId { get; set; }

        public string Reference { get; set; }

        public string Marque { get; set; }

        public string Modele { get; set; }

        public int Memoire { get; set; }

        public DateTime DateSortie { get; set; }
    }
}
