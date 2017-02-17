using CSharpAssignment.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CSharpAssignment.Model;

namespace CSharpAssignment.View
{
    /// <summary>
    /// Interaction logic for NewToturialView.xaml
    /// </summary>
    public partial class NewToturialView : Window
    {

      
      
      
    
    public NewToturialView()
        {
            InitializeComponent();
           
            //use dependency injection to connect the view to its presenter
       
            this.configureTeacherComboBox();

            //assign the action for creating new tutorial button 
            CreateTutorialBtn.Click += OnClick_CreateTutorialBtn;
        }



        public void OnClick_CreateTutorialBtn(object sender, object e)
        {


            //create thew new tutorial object based on the user selection
             // TutorialPresenter.createNewTutorial(new Tutorial());
          

        }


        //configure teacher combobox
        public void configureTeacherComboBox() {
            //Access the methods in presenter to return a list of teachers


        }

        private void CreateTutorialBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
