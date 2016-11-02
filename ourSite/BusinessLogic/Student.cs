using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public Int32 Id { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public DateTime Birthday { get; set; }
    }
}
