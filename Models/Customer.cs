using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;



namespace Warehouse.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [AllowNull]
        public string Tel { get; set; }
        [AllowNull]
        public string Doc { get; set; }

    }
}
