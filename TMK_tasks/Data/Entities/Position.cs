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
        public int SteelTypeId { get; set; }

        [Column("diameter")]
        public int Diameter { get; set; }

        [Column("side_width")]
        public int SideWidth { get; set; }

        [Column("volume")]
        public int Volume { get; set; }

        [Column("unit")]
        public string Unit { get; set; }

        [Column("state_id")]
        public int StateId { get; set; }

        [Column("order_id")]
        public int OrderId { get; set; }

        public SteelType SteelType { get; set; }

        public State State { get; set; }

        public Order Order { get; set; }
    }
}