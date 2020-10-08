using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.EntityFramework
{
    [Table("T_E_TELEPHONE_TEL")]
    public class Telephone
    {
        [Key]
        [Column("TEL_ID")]
        public int TelephoneId { get; set; }

        [Column("TEL_REFERENCE", TypeName = "char(5)")]
        public string Reference { get; set; }

        [Column("TEL_MARQUE")]
        public string Marque { get; set; }

        [Column("TEL_MODELE")]
        public string Modele { get; set; }

        [Column("TEL_MEMOIRE")]
        [DefaultValue(64)]
        public int Memoire { get; set; }

        [Column("TEL_DATESORTIE", TypeName = "date")]
        public DateTime DateSortie { get; set; }
    }
}
