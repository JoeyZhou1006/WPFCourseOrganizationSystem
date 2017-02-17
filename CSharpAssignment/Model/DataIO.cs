using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAssignment.Model
{
    public class DataIO
    {

       private  List<Subject> subjects = new List<Subject>();
       private  List<Teacher> teachers = new List<Teacher>();
        private ObservableCollection<Tutorial> tutorials = new ObservableCollection<Tutorial>();




        public DataIO() {
            Console.WriteLine("before faking data");

            //configure the list of teaqchers and subjects to be used by views
          
            Console.WriteLine("afater faking data");
            this.readFromTeacherFile();
            this.readFromSubjectFile();
            this.readFromTutorialFile();

        }


      




        //get and set methods for the two lists
        public List<Subject> Subjects
        {
            get {
                    return this.subjects;
            }
        }


        public List<Teacher> Teachers
        {
                get {

                return this.teachers;
            }
        }


        public ObservableCollection<Tutorial> Tutorials
        {
            get
            {

                return this.tutorials;
            }
        }




        public void readFromTeacherFile() {
            try
            {
                using (TextFieldParser parser = new TextFieldParser(@"C:\Users\joeyz\Documents\CSharpAssignment\Teacher.csv"))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    parser.ReadFields();
                    while (!parser.EndOfData)
                    {

                        //processing the row
                        string[] fields = parser.ReadFields();

                        //encapsulate each line of data read from excel file to a teacher object
                        Teacher temp = new Teacher(fields[0], fields[1], fields[2]);
                        Console.Write(fields[0]);
                        Console.Write(fields[1]);
                        Console.WriteLine(fields[2]);
                        //add it to the collection
                        Teachers.Add(temp);

                    }
                }
            }
            catch (IOException e) {
                
            }

        }

        //read from csv file and save read objects to the collection to be used later
        public void readFromSubjectFile() {

            using (TextFieldParser parser = new TextFieldParser(@"C:\Users\joeyz\Documents\CSharpAssignment\Subject.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                parser.ReadFields();
                while (!parser.EndOfData)
                {

                    //processing the row
                    string[] fields = parser.ReadFields();

                    //encapsulate each line of data read from excel file to a subject object
                    Subject temp = new Subject(fields[0], fields[1]);
                    Console.Write(fields[0]);
                    Console.Write(fields[1]);
                 
                    //add it to the collection
                    Subjects.Add(temp);

                }
            }

        }



        public void readFromTutorialFile() {
            using (TextFieldParser parser = new TextFieldParser(@"C:\Users\joeyz\Documents\CSharpAssignment\Tutorial.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
               
                parser.ReadFields();
                while (!parser.EndOfData)
                {

                    //processing the row
                    string[] fields = parser.ReadFields();

                    //encapsulate each line of data read from excel file to a subject object
                    Tutorial temp = new Tutorial(fields[0], fields[1], fields[2], fields[3]);
                    Console.Write(fields[0]);
                    Console.Write(fields[1]);
                    Console.WriteLine(fields[2]);
                    //add it to the collection
                    tutorials.Add(temp);

                }
            }


        }

        public void addNewTutorialToFile(Tutorial newTutorial) {
            using (StreamWriter sw = new StreamWriter(@"C: \Users\joeyz\Documents\CSharpAssignment\Tutorial.csv", true))
            {
                Console.WriteLine("write to fileeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
                string csv = string.Format("{0},{1},{2},{3}",newTutorial.TeacherID,newTutorial.SubjectID, newTutorial.year, newTutorial.semester);
                sw.WriteLine(csv);
                //sw.Write(csv);

                sw.Close();


            }
        }
    }
}
