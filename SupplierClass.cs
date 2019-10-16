using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionCW
{
    class SupplierClass
    {
        public int SupplierID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }

        public SupplierClass(int SupplierID, string Name, string Address, string Number, string Email)
        {
            this.SupplierID = SupplierID;
            this.Name = Name;
            this.Address = Address;
            this.Number = Number;
            this.Email = Email;

        }

    }
}
