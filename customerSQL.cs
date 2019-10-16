using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionCW
{
    public class customerSQL
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string address { get; set; }
        public string PostCode { get; set; }
        public bool ifchanged = false; 

        public customerSQL(int ID, string FirstName, string LastName, string PhoneNumber, string address, string PostCode)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.PhoneNumber = PhoneNumber;
            this.address = address;
            this.PostCode = PostCode;
        }

        public void loadCustomer()
        {




        }

        public customerSQL(string LastName)
        {

            this.LastName = LastName;
        }

    }



    
    
    


}
