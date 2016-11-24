using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class BLStudent
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime Birthday { get; set; }

        public int Age { get { return DateTime.Now.Year - Birthday.Year; } }
    }
}
