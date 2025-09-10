using System.ComponentModel.DataAnnotations;



namespace Warehouse.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tel { get; set; }
        public string Doc { get; set; }

    }
}
