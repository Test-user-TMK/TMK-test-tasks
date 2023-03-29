using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMK_tasks.Data.Entities
{
    [Table("orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Column("manufacturer_id")]
        public int? ManufacturerId { get; set; }

        [Column("date_start")]
        public DateTime DateStart { get; set; }

        [Column("date_end")]
        public DateTime DateEnd { get; set; }

        [Column("state_id")]
        public int StateId { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public State State { get; set; }

        public List<Position> Positions { get; set; }
    }
}