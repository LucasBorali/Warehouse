using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Warehouse.Models
{
    public class Output
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Plate { get; set; }

        [Required]
        public string Peso { get; set; }

        [Required]
        public string Ticket { get; set; }

        [AllowNull]
        public string Buyer { get; set; }

    }
}
