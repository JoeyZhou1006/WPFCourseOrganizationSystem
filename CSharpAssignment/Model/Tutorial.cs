using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssignment
{
    public class Tutorial
    {
        public string TeacherID { get; set; }
        public string SubjectID { get; set; }
        public  string year { get; set; }
        public string semester { get; set; }

        public Tutorial(string TeacherID, string SubjectID, string year, string semester) {
            this.TeacherID = TeacherID;
            this.SubjectID = SubjectID;
            this.year = year;
            this.semester = semester;

        }
    }
}
