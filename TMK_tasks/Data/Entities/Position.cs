using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TMK_tasks.Data.Entities
{
    [Table("positions")]
    public class Position
    {
        [Key]
        public int Id { get; set; }

        [Column("steel_type_id")]
        [Required(ErrorMessage = "Необходимо указать марку стали")]
        public int? SteelTypeId { get; set; }

        [Column("diameter")]
        [Required(ErrorMessage = "Необходимо указать диаметр")]
        public int? Diameter { get; set; }

        [Column("side_width")]
        [Required(ErrorMessage = "Необходимо указать стенку")]
        public int? SideWidth { get; set; }

        [Column("volume")]
        [Required(ErrorMessage = "Необходимо указать объем")]
        public int? Volume { get; set; }

        [Column("unit")]
        [Required(ErrorMessage = "Необходимо указать единицы измерения")]
        public string? Unit { get; set; }

        [Column("state_id")]
        [Required(ErrorMessage = "Необходимо указать статус позиции")]
        public int? StateId { get; set; }

        [Column("order_id")]
        [Required(ErrorMessage = "Необходимо указать связанный заказ")]
        public int OrderId { get; set; }

        public SteelType SteelType { get; set; }

        public State State { get; set; }

        public Order Order { get; set; }
    }
}