using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Transaction
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } 
        public DateTime date { get; set; }
        public double price { get; set; }
        public int SoldQuantity { get; set; }
        public int BeforeQuantity { get; set; }
        public string CashierName { get; set; } = string.Empty;
    }
}
