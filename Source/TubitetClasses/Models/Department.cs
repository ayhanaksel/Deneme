using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubitetClasses.Models
{
    public class Department
    {
        public int ID { get; set; }
        public Faculty Faculty { get; set; }
        public string DepartmentName { get; set; }
        public Boolean IsDeleted { get; set; }

    }
}
