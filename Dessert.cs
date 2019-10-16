using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionCW
{
    public class CourseClass
    {
        public int MealID { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public courses Course { get; set; } 

        public CourseClass(int MealID, string Description, decimal Price, courses CourseNo)
        {
            this.MealID = MealID;
            this.Description = Description;
            this.Price = Price;
            this.Course = CourseNo;

        }

    }
}
