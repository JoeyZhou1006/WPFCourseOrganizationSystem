using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CSharpAssignment.Model;
using CSharpAssignment.View;
using System.Windows.Controls;

namespace CSharpAssignment.Presenter
{
    //this class handles the event in create new tutorial form, communicate with model
   public class NewToturialPresenter
    {

        NewToturialView newTutorialView = new NewToturialView();


        //initialize the dataio, so the presenter can use the data from it
        DataIO dataIO = new DataIO();
        

        public NewToturialPresenter(NewToturialView TutorialView, DataIO dataio) {
            this.newTutorialView = TutorialView;
            this.dataIO = dataio;
            //call combo box configureation methods to configure the selections on those combo boxes
            this.configureTeacherCombo();
            this.configureSubjectCombo();
            this.configureSemesterCombo();
            this.configureYearCombo();


            newTutorialView.CreateTutorialBtn.Click += this.createNewTutorial;
            newTutorialView.Cancel_tutorialBtn.Click += this.cancelView;


        }


        //the actual create new tutorial business logic to be used by the new tutorial view 
        public void createNewTutorial(Tutorial newTutorial) {


        }


        public void configureTeacherCombo()
        {

            //dataIO.Teachers;
            // newTutorialView.TeachersComboBox.ItemsSource = dataIO.Teachers;
            // newTutorialView.TeachersComboBox.
            Console.WriteLine("configuring teacher combo box");
            newTutorialView.TeachersComboBox.ItemsSource = dataIO.Teachers;
            newTutorialView.TeachersComboBox.DisplayMemberPath = "firstName";
            //newTutorialView.TeachersComboBox.GetValue();
        }


        public void configureSubjectCombo() {

            Console.WriteLine("configuring subject combo box");
            newTutorialView.SubjectsComboBox.ItemsSource = dataIO.Subjects;
            newTutorialView.SubjectsComboBox.DisplayMemberPath = "subjectName";

        }

        public void configureSemesterCombo() {
            Console.WriteLine("configuring semester combo box");
            string[] semester = {"1","2"};
            newTutorialView.SemestersComboBox.ItemsSource = semester;
        }

        public void configureYearCombo() {
            for (int i =2016;i<2030;i++) {
                ComboBoxItem item = new ComboBoxItem();
                Console.WriteLine(i);
                Console.WriteLine(i.GetType());
                item.Content = Convert.ToString(i);
                Console.WriteLine(item.Content.GetType());
                newTutorialView.yearComboBox.Items.Add(item);
            }
        }



        public void createNewTutorial(object sender, object e) {

            string teacherID = null;
            string subjectID = null;
            string year;
            string semester;
            try
            {
                teacherID = (newTutorialView.TeachersComboBox.SelectedItem as Teacher).id;
            }
            catch(NullReferenceException){
                Console.WriteLine("teacher box is null");
        }

            try
            {
                subjectID = (newTutorialView.SubjectsComboBox.SelectedItem as Subject).subjectID;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("subject box is null");
            }


               

            //check for both year and semester combobox and see whether they are null
            if (newTutorialView.yearComboBox.SelectedItem == null)
            {
                Console.WriteLine("year box is null");
            }
            if (newTutorialView.SemestersComboBox.SelectedItem == null)
            {

                Console.WriteLine("semester box is null");
            }


            if (newTutorialView.yearComboBox.SelectedItem != null && newTutorialView.SemestersComboBox.SelectedItem != null && newTutorialView.SubjectsComboBox.SelectedItem != null && newTutorialView.TeachersComboBox.SelectedItem !=null) {
                Console.WriteLine("All the boxes are not null, you can append the new tutorial now");
                //year = newTutorialView.yearComboBox.SelectedItem as string;
                year = newTutorialView.yearComboBox.Text;
                Console.WriteLine(" the yeaeeeeeeeeeeeeeeeear issssssssssssss");
                //Console.WriteLine(year == null);
                semester = newTutorialView.SemestersComboBox.SelectedItem as string;
                

                Tutorial newTutorial = new Tutorial(teacherID, subjectID,year, semester);
                this.dataIO.Tutorials.Add(newTutorial);

                dataIO.addNewTutorialToFile(newTutorial);
            }
           



        }


        public NewToturialView getTutorialView() {

            return this.newTutorialView;
        }

        public void cancelView(object sender, object e) {
            this.newTutorialView.Close();
        }






    }
}
