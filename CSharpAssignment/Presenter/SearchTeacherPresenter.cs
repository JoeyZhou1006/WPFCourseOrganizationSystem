using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpAssignment.View;
using CSharpAssignment.Model;
namespace CSharpAssignment.Presenter
{
    class SearchTeacherPresenter
    {
        SearchTeacherView searchView = new SearchTeacherView();
        DataIO dataio;
        public SearchTeacherPresenter(SearchTeacherView searchview, DataIO dataio) {

            this.searchView = searchview;
            this.dataio = dataio;

            initializeTeacherListBox();
            searchView.searchBtn.Click += searchTeacherById;
        }

        public void initializeTeacherListBox() {
            searchView.teacherIDList.ItemsSource = this.dataio.Teachers;
            searchView.teacherIDList.DisplayMemberPath = "fullname";


        }

        public SearchTeacherView getSearchView() {

            return searchView;
        }


        public void searchTeacherById(object sender, object e) {

            int searchid = Convert.ToInt32((searchView.teacherIDList.SelectedItem as Teacher).id);
            int min = 0;
            int n = this.dataio.Teachers.Count;
            int max = n - 1;

            do
            {
                int mid = (min + max) / 2;
                if (searchid > Convert.ToInt32(this.dataio.Teachers[mid].id))
                {
                    min = mid + 1;
                }
                else {
                    max = mid - 1;
                }
                if (Convert.ToInt32(this.dataio.Teachers[mid].id) == searchid) {

                    this.searchView.label.Content = this.dataio.Teachers[mid].firstName;
                    this.searchView.label1.Content = this.dataio.Teachers[mid].lastName;
                   
                }

            } while (min <= max);

           
        }
    }
}
