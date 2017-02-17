using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssignment
{
    public class Subject
    {
        public string subjectID { get; set; }
        public string subjectName { get; set; }


        public Subject(string subjectID, string subjectName) {
            this.subjectID = subjectID;
            this.subjectName = subjectName;
        }
    }
}
