using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionCW
{
    public class StockClass
    {
        public int IDStock { get; set; }
        public string Description { get; set; }
        public string StorageType { get; set; }
        public int StockQty { get; set; }
        public int StockMinQty { get; set; }
        public Boolean Fresh { get; set; }
        
        


        public StockClass(int IDStock, string Description, string StorageType, int StockQty, int StockMinQty, Boolean Fresh)
        {
            this.IDStock = IDStock;
            this.Description = Description;
            this.StorageType = StorageType;
            this.StockQty = StockQty;
            this.StockMinQty = StockMinQty;
            this.Fresh = Fresh;
            
            

        }

    }
}
