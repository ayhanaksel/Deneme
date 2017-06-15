using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubitetClasses.Models
{
    public class User
    {
        public int ID { get; set; }
        public Faculty Faculty { get; set; }
        public Department Department { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
