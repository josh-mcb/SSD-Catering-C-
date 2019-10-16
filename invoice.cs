using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionCW
{
    class invoice
    {
        public int InvoiceID { get; set; } 
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string Address { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public int Qty { get; set; }
        public string Starter { get; set; }
        public string Main { get; set; }
        public string Dessert { get; set; }
        public decimal Total { get; set; }

        public invoice(int InvoiceID, int OrderID, int CustomerID, string Address, DateTime Date, int Qty, string Starter, string Main, string Dessert, decimal Total)
        {
            this.InvoiceID = InvoiceID;
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.Address = Address;
            this.Date = Date;
            this.Qty = Qty;
            this.Starter = Starter;
            this.Main = Main;
            this.Dessert = Dessert;
            this.Total = Total;

        }


    }
}
