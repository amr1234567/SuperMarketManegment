using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        [Required,DataType(DataType.Date)]
        public DateTime date { get; set; }
        [Required]
        public double price { get; set; }
        [Required]
        public int SoldQuantity { get; set; }
        [Required]
        public int BeforeQuantity { get; set; }
        [Required]
        public string CashierName { get; set; } = string.Empty;

        public Product Product { get; set; }
    }
}
