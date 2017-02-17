using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpAssignment.Model;
using CSharpAssignment.Presenter;

using CSharpAssignment.View;
namespace CSharpAssignment
{
    class Program
    {


        //Entry of the project
        [STAThread]
        static void Main(string[] args)
        {

           
            Console.WriteLine("Configure dataio and mainwindow");

            //when initializing the object of dataio, it uses the constructor to read from the csv file to get the data ready, so the window afterwards can use these data
            DataIO dataIO = new DataIO();

            //initialize the main window view to use dependency injection to inject itself to the presenter, so the view and 
            MainWindow mainwindow = new MainWindow();


            //debug whether the data has been correctly read from the file
           // Console.WriteLine(dataIO.Subjects.Count);
         //   Console.WriteLine(dataIO.Tutorials.Count);
          //  Console.WriteLine(dataIO.Teachers.Count);




            MainWindowPresenter MainwindowPresenter = new MainWindowPresenter(mainwindow, dataIO);
         
            //use the method from presenter to present the view
            MainwindowPresenter.getMainView().ShowDialog();
          
      
         
        }

    }
}
