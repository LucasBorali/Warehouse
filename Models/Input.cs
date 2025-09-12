using System.ComponentModel.DataAnnotations;



namespace Warehouse.Models
{
    public class Input
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


        [Required]
       public string Impureza { get; set; }

        [Required]
       public string Umidade { get; set; }



    }
}
