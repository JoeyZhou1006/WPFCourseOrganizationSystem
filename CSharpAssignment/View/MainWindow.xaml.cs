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
using System.Net.Http;
using CSharpAssignment.Presenter;
namespace CSharpAssignment.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

            Create.Click += OnClick_CreateBtn;


        }

        public void OnClick_CreateBtn(object sender, object e) {
            //NewToturialView newTutorial = new NewToturialView();
            //newTutorial.Show();

        }

        public void load_Tutorials(List<Tutorial> tutorials) {
            //configure the data souce of the tutorial view from a collection of data
         
          



        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
   }
