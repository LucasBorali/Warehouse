using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;


namespace Warehouse.Models
{
    public class Dock
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string SelectedTransactionType { get; set; }

        [Required]
       public DateTime Date { get; set; }

        [Required]
       public string Plate { get; set; }


        [Required]
       public string Peso { get; set; }

        [Required]
       public string Ticket { get; set; }

        //Opcionais

        [AllowNull]
       public string Buyer { get; set; }

        [AllowNull]
       public string Impureza { get; set; }

        [AllowNull]
       public string Umidade { get; set; }



    }
}
