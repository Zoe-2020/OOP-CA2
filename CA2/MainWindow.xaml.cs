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
        //create full Time Employees , part Time Employees and employees list
        List<Employee> employees = new List <Employee>();
        List<FullTimeEmployee> fullTimeEmployees = new List<FullTimeEmployee>();
        List<PartTimeEmployee> partTimeEmployees = new List<PartTimeEmployee>();




        private void EmployeeLB_Loaded(object sender, RoutedEventArgs e)
        {
            // creating employess
            PartTimeEmployee e1 = new PartTimeEmployee("Jane", "Jones", "Part Time", 5, 88);
            FullTimeEmployee e2 = new FullTimeEmployee("Joe", "Murphy","Full Time", 5000);
            PartTimeEmployee e3 = new PartTimeEmployee("John", "Smith", "Part Time",8,9);
            FullTimeEmployee e4 = new FullTimeEmployee("Jess", "Walsh", "Full Time", 99050);
            // creating 2 FullTimeEmployee and 2 PartTimeEmployee objects 
            PartTimeEmployee e5 = new PartTimeEmployee("Max", "Cooper", "Part Time", 100, 9);
            FullTimeEmployee e6 = new FullTimeEmployee("Toby", "Ross", "Full Time", 88000);
            PartTimeEmployee e7 = new PartTimeEmployee("Rex", "Brown", "Part Time", 20, 10);
            FullTimeEmployee e8 = new FullTimeEmployee("Steven", "Thomson", "Full Time", 40040);

            //adding all employees to employess list
            employees.Add(e1);
            employees.Add(e2);
            employees.Add(e3);
            employees.Add(e4);
            employees.Add(e5);
            employees.Add(e6);
            employees.Add(e7);
            employees.Add(e8);

            //adding partTime Employees partTime Employees list 
            partTimeEmployees.Add(e1);
            partTimeEmployees.Add(e3);
            partTimeEmployees.Add(e5);
            partTimeEmployees.Add(e7);
            //adding fullTime Employees to fullTime Employees list 
            fullTimeEmployees.Add(e2);
            fullTimeEmployees.Add(e4);
            fullTimeEmployees.Add(e6);
            fullTimeEmployees.Add(e8);

        }


        // press add button to add new Employee
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            //first name and surname are are in both lists 
            string NewFirstName = FirstNameTBox.Text;
            string NewLastName = SurnameTBox.Text;

            if (FtRBtn.IsChecked != false)
            {
              //if fulltime ratio is clicked they will will be in fullime class
                string NewShift = "Full Time"; //declaring full time 
                decimal NewSalary = decimal.Parse(SalaryTBox.Text); //takes in salary
                FullTimeEmployee fullTimeEmployee = new FullTimeEmployee(NewFirstName, NewLastName, NewShift, NewSalary);//take into full time employee
                fullTimeEmployees.Add(fullTimeEmployee); // add to fullTimeEmployees list
                employees.Add(fullTimeEmployee);// add to employees list 

            }
            else if (PtRBtn.IsChecked != false)
            {
                //if parttime ratio is clicked they will will be in partime class
                string NewShift = "Part Time"; //declaring part time 
                decimal NewHourlyRate = decimal.Parse(HourlyRateTBox.Text); //takes in hour rate
                decimal NewHourlyWorked = decimal.Parse(HoursWorkedTBox.Text);//takes in hour work
                PartTimeEmployee partTimeEmployee = new PartTimeEmployee(NewFirstName, NewLastName, NewShift,NewHourlyRate,NewHourlyWorked); //take into part time emplyee
                partTimeEmployees.Add(partTimeEmployee);  // add to partTimeEmployees list
                employees.Add(partTimeEmployee); // add to employees list 

            }

            //reloads the listBox to that new inputs will appear automatic
            EmployeeLB.ItemsSource = null;
            EmployeeLB.ItemsSource = employees;

        




        }

        //seleted employee will display their information right
        private void EmployeeLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //take list to display from employee , full time and part time to be slected
            Employee selecetedEmployee = EmployeeLB.SelectedItem as Employee;
            PartTimeEmployee selecetedPartTime= EmployeeLB.SelectedItem as PartTimeEmployee;
            FullTimeEmployee selecetedFullTime = EmployeeLB.SelectedItem as FullTimeEmployee;

            //if a employee is selected
            if (selecetedEmployee != null)
            {
                //takes in first & last names
                FirstNameTBox.Text = selecetedEmployee.FirstName;
                SurnameTBox.Text = selecetedEmployee.LastName;

                if (selecetedEmployee.Shift == "Full Time")
                {
                    // if full time needs to dispaly salary 
                    //clear hours worked and hour rate to not display anything
                    HoursWorkedTBox.Clear();
                    HourlyRateTBox.Clear();

                    //dispaly salary in salaryTBox 
                    SalaryTBox.Text = selecetedFullTime.Salary.ToString();

                }
                else
                {
                    // else they will be part time 
                    //dont need salary so clear 
                    SalaryTBox.Clear();
                    HoursWorkedTBox.Text = selecetedPartTime.HourlyRate.ToString(); //display hours worked
                    HourlyRateTBox.Text = selecetedPartTime.HoursWorked.ToString(); //display hours rate
                }

                // display Monthly Pay in textblock rounded up 
                monthlyPayTxtBlock.Text = Decimal.Round(selecetedEmployee.CalculateMonthlyPay()).ToString();
                    

            }

        }

  
        private void FullTimeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //puts employees in alphabetically order of Surname in listbox
            EmployeeLB.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("LastName", System.ComponentModel.ListSortDirection.Ascending));


            if (FullTimeCheckBox.IsChecked != false) 
            {
                //if fulltime is checked will display fulltime employee
                EmployeeLB.ItemsSource = fullTimeEmployees;

                if (PartTimeCheckBox.IsChecked != false)
                {
                    //if both parttime and fulltime is checked will display all employees
                    EmployeeLB.ItemsSource = employees;
                   
                }
            }
            

        }

        private void PartTimeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //if part employee is checked will display parttime employees
            if (PartTimeCheckBox.IsChecked != false) 
            {
                EmployeeLB.ItemsSource = partTimeEmployees;

                if (FullTimeCheckBox.IsChecked != false)
                {
                   //if fulltime is also checked will display all employee
                    EmployeeLB.ItemsSource = employees;
                    
                }

            }
             
            
        }

        private void FullTimeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            //if partime and fulltime are both unchecked will display nothing
            if ((PartTimeCheckBox.IsChecked == false) && (FullTimeCheckBox.IsChecked == false))
            {
                EmployeeLB.ItemsSource = "";
            }
            else if (FullTimeCheckBox.IsChecked == false)
            {
                //if fulltime is not checked will display part time
                EmployeeLB.ItemsSource = partTimeEmployees;
            }


        }

        private void PartTimeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            //if partime and fulltime are both unchecked will display nothing
            if ((PartTimeCheckBox.IsChecked == false) && (FullTimeCheckBox.IsChecked == false))
            {
                EmployeeLB.ItemsSource = "";
            }
            else if (PartTimeCheckBox.IsChecked == false)
            {
                //if part time is not checked will display full time
                EmployeeLB.ItemsSource = fullTimeEmployees;
            }

        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            //will clear all info if clear button is pressed
            FirstNameTBox.Clear();
            SurnameTBox.Clear();
            SalaryTBox.Clear();
            HoursWorkedTBox.Clear();
            HourlyRateTBox.Clear();
            monthlyPayTxtBlock.Text = String.Empty; 
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {

            //changing employee info 
            //select from list
            FullTimeEmployee changeFullTimeEmp = EmployeeLB.SelectedItem as FullTimeEmployee;
            PartTimeEmployee changePartTimeEmp = EmployeeLB.SelectedItem as PartTimeEmployee;

            //looping through all fulltime employees
                for (int x = 0; x < fullTimeEmployees.Count; x++)
            {
                //if employee selected to change is in fulltime employee list
                if (changeFullTimeEmp == fullTimeEmployees[x])
                {
                    //takes in first name , surname and salary 
                    string changedFullTime = FirstNameTBox.Text;
                    string changedPartTime = SurnameTBox.Text;
                    decimal changedSalary = decimal.Parse(SalaryTBox.Text);

                    //sets the new figures to the slected full employee
                    fullTimeEmployees[x].FirstName = changedFullTime;
                    fullTimeEmployees[x].LastName = changedPartTime;
                    fullTimeEmployees[x].Salary = changedSalary;

                    //refresh listbox
                    EmployeeLB.ItemsSource = null;
                    EmployeeLB.ItemsSource = fullTimeEmployees;
                }
            }
                //loops through part employee
            for (int z = 0; z < partTimeEmployees.Count; z++)
            {
                //if selected employee is part time
                if (changePartTimeEmp == partTimeEmployees[z])
                {
                    //takes in new first name , surname, hours rate , hours worked
                    string changedFullTime = FirstNameTBox.Text;
                    string changedPartTime = SurnameTBox.Text;
                    decimal changedHourlyRate = decimal.Parse(HourlyRateTBox.Text);
                    decimal changedHoursWorked = decimal.Parse(HoursWorkedTBox.Text);

                    //sets new details 
                    partTimeEmployees[z].FirstName = changedFullTime;
                    partTimeEmployees[z].LastName = changedPartTime;
                    partTimeEmployees[z].HourlyRate = changedHourlyRate;
                    partTimeEmployees[z].HoursWorked = changedHoursWorked;

                    //refresh list box
                    EmployeeLB.ItemsSource = null;
                    EmployeeLB.ItemsSource = partTimeEmployees;
                }

            }

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            //select from list 
            Employee delSelecetEmpl = EmployeeLB.SelectedItem as Employee;
            FullTimeEmployee delSelecetFullTimeEmpl = EmployeeLB.SelectedItem as FullTimeEmployee;
            PartTimeEmployee delSelecetPartTimeEmpl = EmployeeLB.SelectedItem as PartTimeEmployee;


            //loops through full time employee
            for (int z = 0; z < fullTimeEmployees.Count; z++)
            {
                //if selected employee is fulltime
                if (delSelecetFullTimeEmpl == fullTimeEmployees[z])
                {
                    //delete it 
                    fullTimeEmployees.RemoveAt(z);
                    
                }
                //refresh list
                    EmployeeLB.ItemsSource = null;
                    EmployeeLB.ItemsSource = fullTimeEmployees;

                
            }
            //loop thorugh parttime employees
            for (int x = 0; x < partTimeEmployees.Count; x++)
            {
                // selected employee 
                if (delSelecetPartTimeEmpl == partTimeEmployees[x])
                {
                    //delete it 
                    partTimeEmployees.RemoveAt(x);

                    //refresh listbox
                    EmployeeLB.ItemsSource = null;
                    EmployeeLB.ItemsSource = partTimeEmployees;

                }
              

            }
            //loop through employee
            for (int Q = 0; Q < employees.Count; Q++)
            {
                if (delSelecetEmpl == employees[Q])
                {
                    //delete employee
                    employees.RemoveAt(Q);
                    //refresh page 
                    EmployeeLB.ItemsSource = null;
                    EmployeeLB.ItemsSource = employees;
                }

            }
        }

       
    }
}
