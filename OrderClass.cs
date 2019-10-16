using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionCW
{
    class OrderClass
    {
        public int OrderID { get; set; }
        public int CustID { get; set; }
        public DateTime OrderDate;
        public string Date { get { return OrderDate.ToShortDateString(); } }
        public DateTime functionDate;
        public string FunctionDate { get { return functionDate.ToShortDateString(); } }
        public string Venue { get; set; }
        public int NumberofPeople { get; set; }
        public string Starter { get; set; }
        public string Main { get; set; }
        public string Dessert { get; set; }
        public decimal Price { get; set; }
        

        public OrderClass(int OrderID, int CustID, DateTime OrderDate, DateTime functionDate, string Venue, int NumberofPeople, string Starter, string Main, string Dessert, decimal Price)
        {
            this.OrderID = OrderID;
            this.CustID = CustID;
            this.OrderDate = OrderDate;
            this.functionDate = functionDate;
            this.Venue = Venue;
            this.NumberofPeople = NumberofPeople;
            this.Starter = Starter;
            this.Main = Main;
            this.Dessert = Dessert;
            this.Price = Price;
            

        }




    }
}
