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
        [Required(ErrorMessage = "Необходимо указать цех-производитель")]
        public int? ManufacturerId { get; set; }

        [Column("date_start")]
        [Required(ErrorMessage = "Необходимо указать дату начала заказа")]
        public DateTime? DateStart { get; set; }

        [Column("date_end")]
        [Required(ErrorMessage = "Необходимо указать дату окончания заказа")]
        public DateTime? DateEnd { get; set; }

        [Column("state_id")]
        [Required(ErrorMessage = "Необходимо указать статус заказа")]
        public int? StateId { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public State State { get; set; }

        public List<Position> Positions { get; set; }
    }
}