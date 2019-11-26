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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] countriesList = { "Canada", "Usa", "Chile", "Egypt" };
       

        public MainWindow()
        {
            InitializeComponent();
            LoadCountries();
            cmbCountry.ItemsSource = countriesList;
         //   cmbCountry.SelectedIndex = 0;
        }

        // reading countries from the file
        private void LoadCountries()
        {
            try
            {
                string fileName = "../../Countries.txt";
                if (File.Exists(fileName))
                    countriesList = File.ReadAllLines(fileName);
                else
                    MessageBox.Show("Loading default country list");

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtName.Text) || txtName.Text.Trim() =="")
            //    MessageBox.Show($"Hello {txtName.Text}");
            //else
            //    MessageBox.Show("Name is provided", "Error", MessageBoxButton.OK, MessageBoxImage.Error);




            /*   StringBuilder msg = new StringBuilder();
               msg.AppendLine(txtName.Text);
               msg.AppendLine(txtMajor.Text);
               msg.AppendLine(cmbCountry.SelectedItem.ToString());

               if (rbtnTeacher.IsChecked.Value)
                   msg.AppendLine("Teacher");
               else if (rbtnStudent.IsChecked.Value)
                   msg.AppendLine("Student");
               else
                   msg.AppendLine("Professional");

               //checkbox
                if (chkbSpeaker.IsChecked.Value)
                   msg.AppendLine("Guest Speaker");

               msg.AppendLine(dpCheckIn.SelectedDate.Value.ToString());

               MessageBox.Show(msg.ToString()); */

            if (CheckAllInput())
            {
                Visitor visitor = GetVisitorInfo();
                
                MessageBox.Show(visitor.ToString(),"Form Completed",MessageBoxButton.OK,MessageBoxImage.Information);
                // add to list Box
                visitorList.Items.Add(visitor);
                visitorList.Items.Refresh();
            }
            

        }

        private Visitor GetVisitorInfo()
        {
            return new Visitor()
            {
                Name = txtName.Text,
                Major = txtMajor.Text,
                Country = cmbCountry.SelectedValue.ToString(),
                IsSpeaker = chkbSpeaker.IsChecked.Value,
                //VisitorStatus = (Status)(rbtnTeacher.IsChecked.Value ? 0 :
                //rbtnStudent.IsChecked.Value ? 1 : 2)
              VisitorStatus = rbtnTeacher.IsChecked.Value ? Status.Teacher :
                              rbtnStudent.IsChecked.Value ? Status.Student : Status.Professional

            };
        }

        private bool CheckAllInput()
        {
            bool result = true;
            StringBuilder msg = new StringBuilder();
            // name
            if (string.IsNullOrEmpty(txtName.Text))
                msg.AppendLine("Name is a required field");
            // major
            if (string.IsNullOrEmpty(txtMajor.Text))
                msg.AppendLine("major is a required field");
            // the country
            if (cmbCountry.SelectedValue == null)
                msg.AppendLine("No Country Selected");

            //status
            if (!(rbtnTeacher.IsChecked.Value || rbtnStudent.IsChecked.Value || rbtnProf.IsChecked.Value))
                msg.AppendLine("Status is not chosen");
            //check in date
            if (!dpCheckIn.SelectedDate.HasValue)
                msg.AppendLine("Date is not selected");

            if (!string.IsNullOrEmpty(msg.ToString()))
            {
                MessageBox.Show(msg.ToString(), "Form Mising Data", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
                return true;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
        
        }
    }
}
