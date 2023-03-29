using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TMK_tasks.Data.Entities
{
    [Table("steel_types")]
    public class SteelType
    {
        [Key]
        public int Id { get; set; }

        [Column("title")]
        [Required(ErrorMessage = "Название обязательно для заполнения")]
        public string? Title { get; set; }

        public List<Position> Positions { get; set; }
    }
}
