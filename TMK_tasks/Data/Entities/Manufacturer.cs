using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TMK_tasks.Data.Entities
{
    [Table("manufacturers")]
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        [Column("title")]
        public string? Title { get; set; }

        public List<Order> Orders { get; set; }
    }
}
