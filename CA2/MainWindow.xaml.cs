using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CA2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List <Employee> employees = new List <Employee>();
        List<FullTimeEmployee> fullTimeEmployees = new List<FullTimeEmployee>();
        List<PartTimeEmployee> partTimeEmployees = new List<PartTimeEmployee>();



        private void EmployeeLB_Loaded(object sender, RoutedEventArgs e)
        {


            // string[] LastName = { "Jones", "Murphy", "Smith", "Walsh" };
            /* Employee e1 = new Employee("Jane", "Jones");
             Employee e2 = new Employee("Joe", "Murphy");
             Employee e3 = new Employee("John", "Smith");
             Employee e4 = new Employee("Jess", "Walsh"); */

            PartTimeEmployee e1 = new PartTimeEmployee("Jane", "Jones", "Part Time", 5, 88);
            FullTimeEmployee e2 = new FullTimeEmployee("Joe", "Murphy","Full Time", 5000);
            PartTimeEmployee e3 = new PartTimeEmployee("John", "Smith", "Part Time",8,9);
            FullTimeEmployee e4 = new FullTimeEmployee("Jess", "Walsh", "Full Time", 99050);

            employees.Add(e1);
            employees.Add(e2);
            employees.Add(e3);
            employees.Add(e4);

            partTimeEmployees.Add(e1);
            partTimeEmployees.Add(e3);
            fullTimeEmployees.Add(e2);
            fullTimeEmployees.Add(e4);





            employees.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
            partTimeEmployees.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
            fullTimeEmployees.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);






        }

        private void FirstNameTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            FirstNameTBox.Clear();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

            string NewFirstName = FirstNameTBox.Text;
            string NewLastName = SurnameTBox.Text;

            if (FtRBtn.IsChecked != false)
            {
              
                string NewShift = "Full Time";
                decimal NewSalary = decimal.Parse(SalaryTBox.Text);
                FullTimeEmployee fullTimeEmployee = new FullTimeEmployee(NewFirstName, NewLastName, NewShift, NewSalary);
                fullTimeEmployees.Add(fullTimeEmployee);
                employees.Add(fullTimeEmployee);

            }
            else if (PtRBtn.IsChecked != false)
            {
               
                string NewShift = "Part Time";
                decimal NewHourlyRate = decimal.Parse(HourlyRateTBox.Text);
                decimal NewHourlyWorked = decimal.Parse(HoursWorkedTBox.Text);
                PartTimeEmployee partTimeEmployee = new PartTimeEmployee(NewFirstName, NewLastName, NewShift,NewHourlyRate,NewHourlyWorked);
                partTimeEmployees.Add(partTimeEmployee);
                employees.Add(partTimeEmployee);

            }

            EmployeeLB.ItemsSource = null;
            EmployeeLB.ItemsSource = employees;


            


        }

        private void EmployeeLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee selecetedEmployee = EmployeeLB.SelectedItem as Employee;
            PartTimeEmployee selecetedPartTime= EmployeeLB.SelectedItem as PartTimeEmployee;
            FullTimeEmployee selecetedFullTime = EmployeeLB.SelectedItem as FullTimeEmployee;

            if (selecetedEmployee != null)
            {
                FirstNameTBox.Text = selecetedEmployee.FirstName;
                SurnameTBox.Text = selecetedEmployee.LastName;

                if (selecetedEmployee.Shift == "Full Time")
                {
                    HoursWorkedTBox.Clear();
                    HourlyRateTBox.Clear();

                    SalaryTBox.Text = selecetedFullTime.Salary.ToString();

                }
                else
                {
                    SalaryTBox.Clear();
                    HoursWorkedTBox.Text = selecetedPartTime.HourlyRate.ToString();
                    HourlyRateTBox.Text = selecetedPartTime.HoursWorked.ToString();
                }

                monthlyPayTxtBlock.Text = Decimal.Round(selecetedEmployee.CalculateMonthlyPay()).ToString();
                    

            }

        }

       

        private void SurnameTBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SurnameTBox.Clear();
        }

        private void FullTimeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
          


         /*   if ((PartTimeCheckBox.IsChecked != false) && (FullTimeCheckBox.IsChecked == false))
            {
                EmployeeLB.ItemsSource = partTimeEmployees;
                
            } */
           
            
           

            if (FullTimeCheckBox.IsChecked != false) 
            {
                EmployeeLB.ItemsSource = fullTimeEmployees;

                if (PartTimeCheckBox.IsChecked != false)
                {
                    EmployeeLB.ItemsSource = employees;
                }
            }
            

        }

        private void PartTimeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
           

            if (PartTimeCheckBox.IsChecked != false) 
            {
                EmployeeLB.ItemsSource = partTimeEmployees;

                if (FullTimeCheckBox.IsChecked != false)
                {
                    EmployeeLB.ItemsSource = employees;
                }

            }
             
            
        }

        private void FullTimeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if ((PartTimeCheckBox.IsChecked == false) && (FullTimeCheckBox.IsChecked == false))
            {
                EmployeeLB.ItemsSource = "";
            }
            else if (FullTimeCheckBox.IsChecked == false)
            {
                EmployeeLB.ItemsSource = partTimeEmployees;
            }


        }

        private void PartTimeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if ((PartTimeCheckBox.IsChecked == false) && (FullTimeCheckBox.IsChecked == false))
            {
                EmployeeLB.ItemsSource = "";
            }
            else if (PartTimeCheckBox.IsChecked == false)
            {
                EmployeeLB.ItemsSource = fullTimeEmployees;
            }

        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            FirstNameTBox.Clear();
            SurnameTBox.Clear();
            SalaryTBox.Clear();
            HoursWorkedTBox.Clear();
            HourlyRateTBox.Clear();
            monthlyPayTxtBlock.Text = String.Empty; 


        }
    }
}
