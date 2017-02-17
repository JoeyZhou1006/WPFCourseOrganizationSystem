using CSharpAssignment.Model;
using CSharpAssignment.View;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace CSharpAssignment.Presenter
{
    class MainWindowPresenter
    {

        MainWindow MainView = new MainWindow();

        DataIO dataio;

        public MainWindowPresenter(MainWindow MainView, DataIO dataio) {


            //configure the coloumns in the datagrid view, and assign a name to the binding element to be later used to assosiate data in the tutorial object
            DataGridTextColumn c1 = new DataGridTextColumn();
            c1.Header = "TeacherID";
            c1.Binding = new Binding("TeacherID");
            c1.Width = 110;
            MainView.tutorialGrid.Columns.Add(c1);
            DataGridTextColumn c2 = new DataGridTextColumn();
            c2.Header = "SubjectID";
            c2.Width = 110;
            c2.Binding = new Binding("SubjectID");
            MainView.tutorialGrid.Columns.Add(c2);
            DataGridTextColumn c3 = new DataGridTextColumn();
            c3.Header = "semester";
            c3.Width = 110;
            c3.Binding = new Binding("semester");
            MainView.tutorialGrid.Columns.Add(c3);


            DataGridTextColumn c4 = new DataGridTextColumn();
            c4.Header = "year";
            c4.Width = 110;
            c4.Binding = new Binding("year");
            MainView.tutorialGrid.Columns.Add(c4);


            //dependency injection
            this.MainView = MainView;
            this.dataio = dataio;

            this.LoadTutorials();
            this.MainView.Create.Click += this.createNewTutorialView;
            this.MainView.CountBtn.Click += this.countTutorialNum;
            this.MainView.SearchBtn.Click += this.searchNewTutorialView;
            //add an event handler to tutorial list when new tutorial is added to the list
            dataio.Tutorials.CollectionChanged += new NotifyCollectionChangedEventHandler(changed);
            findTeacherById();

        }

        public void changed(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs args) {

            MainView.tutorialGrid.Items.Clear();
        
            this.LoadTutorials();

        }

   


        //a method to return the mainview window 
        public Window getMainView() {

            return MainView;

        }

        public void LoadTutorials() {

            //link between view and model, insert every tutorial in the tutorials list inside of the model(dataio) into the listview in view
            for (int i = 0; i < dataio.Tutorials.Count; i++)
            {
               MainView.tutorialGrid.Items.Add(dataio.Tutorials[i]);
            }
               
        }

        public void createNewTutorialView(object sender, object e) {
            NewToturialView newTutorial = new NewToturialView();
            NewToturialPresenter tutorialPresenter = new NewToturialPresenter(newTutorial,this.dataio);
            tutorialPresenter.getTutorialView().ShowDialog();

        }


        public void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //This will get called when the collection is changed
            Console.WriteLine("the tutorials collection is changed");
        }

        public void countTutorialNum(object sender, object e) {
            Tutorial testtype = new Tutorial("0","0","1993","2");
            int a = dataio.Tutorials.Count(n => n.GetType().Equals(testtype.GetType()));

            MessageBox.Show(a.ToString(), "Count of tutorials", MessageBoxButton.OK);

        }


        public void findTeacherById() {

            for (int i = 0;i<dataio.Teachers.Count;i++) {
                Console.WriteLine(dataio.Teachers[i].id);
            }
        }

        public void searchNewTutorialView(object sender, object e)
        {
           
            Thread newWindowThread = new Thread(new ThreadStart(searchNewTutoViewNewThread));
            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = true;
            newWindowThread.Start();

        }

        public void searchNewTutoViewNewThread() {
            SearchTeacherView searchTeacher = new SearchTeacherView();
            SearchTeacherPresenter searchTeachPresneter = new SearchTeacherPresenter(searchTeacher, this.dataio);
            searchTeachPresneter.getSearchView().ShowDialog();
          //  System.Windows.Threading.Dispatcher.Run();

        }
    }
}
