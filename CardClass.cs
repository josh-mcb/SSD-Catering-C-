using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionCW
{
    class CardClass
    {
        public int CustID { get; set; }
        public int cardNumber { get; set; }
        public int CVC { get; set; }
        public DateTime date { get; set; }


        public CardClass(int CustID, int cardNumber, int CVC, DateTime date)
        {

            this.CustID = CustID;
            this.cardNumber = cardNumber;
            this.CVC = CVC;
            this.date = date;
            
        }



    }
}
