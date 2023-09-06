using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employeeprogram
{
    internal class Employee
    {
        ////private
        //int id;


        ////Property
        //public int Id { 
        //    get { return id; } 
        //    set { id = value; } 
        //}

        // instead of above method we can use below methods

        public int Id { get; set; }
        public string Name { get; set; }
        public float Age { get; set; }
        public string Phone { get; set; }
        public double Salary { get; set; }
    }
}
