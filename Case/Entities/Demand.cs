using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Case.Entity.Base;

namespace Case.Entity
{
    public class Demand : BaseEntity
    {
        [Required]
        [Column("complaint", TypeName = "nvarchar(4000)")]
        public string Complaint { get; set; }
        [Required]
        [Column("name", TypeName = "nvarchar(254)")]
        public string Name { get; set; }
    }
}
