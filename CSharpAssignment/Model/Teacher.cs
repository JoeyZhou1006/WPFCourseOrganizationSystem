using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssignment
{
    public class Teacher
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullname { get; set; }


        public Teacher(string id, string firstname, string lastname) {
            this.id = id;
            this.firstName = firstname;
            this.lastName = lastname;
            this.fullname = firstName +" "+ lastname;
        }
  


    }
}
