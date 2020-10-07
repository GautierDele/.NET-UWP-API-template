using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.EntityFramework
{
    [Table("T_E_MYENTITY_MYE")]
    public class MyEntity
    {
        [Key]
        [Column("MYE_ID")]
        public int MyEntityId { get; set; }
    }
}
