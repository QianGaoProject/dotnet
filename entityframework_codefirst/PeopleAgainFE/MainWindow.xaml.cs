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

namespace PeopleDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PeopleDBContext ctx;
        static ObservableCollection<Person> peopleList;
        public MainWindow()
        {
            InitializeComponent();
            //initial

            try
            {
                ctx = new PeopleDBContext();
                var v = (from p in ctx.People select p).ToList();
                peopleList = new ObservableCollection<Person>(v);
                lvPeople.DataContext = v;

            }
            catch (System.IO.InvalidDataException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            string ageStr = tbAge.Text;
            string heightStr = tbHeight.Text;

            try
            {
                Person person = new Person(name, ageStr, heightStr);
                ctx.People.Add(person);
                ctx.SaveChanges();
                peopleList = new ObservableCollection<Person>((from r in ctx.People select r).ToList());
                lvPeople.DataContext = peopleList;
            }
            catch (System.IO.InvalidDataException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            int index = lvPeople.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("No person was selected. ", "Update person");
                return;
            }
            string name = tbName.Text;
            string ageStr = tbAge.Text;
            string heightStr = tbHeight.Text;
            try
            {
                MessageBoxResult result = MessageBox.Show("Would you like to update data to list?", "add people", MessageBoxButton.OKCancel);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        Person p = peopleList[index];
                        p.Name = name;
                        p.Age = p.ToAgeInt(ageStr);
                        p.Height = p.ToHeightDouble(heightStr);
                        ctx.SaveChanges();
                        peopleList = new ObservableCollection<Person>((from r in ctx.People select r).ToList());
                        lvPeople.DataContext = peopleList;
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                    default:
                        throw new System.IO.InvalidDataException("Error with MessageBox." + result);
                }

            }
            catch (System.IO.InvalidDataException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lvPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lvPeople.SelectedIndex;
            if (index < 0)
            {
                lblIdValue.Content = "...";
                return;
            }
            Person p = peopleList[index];
            lblIdValue.Content = p.Id + "";
            tbName.Text = p.Name;
            tbAge.Text = p.Age + "";
            tbHeight.Text = p.Height + "";
        }
        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = lvPeople.SelectedIndex;
            
            if (index < 0)
            {
                MessageBox.Show("No person was selected. ");
                return;
            }
            int id = peopleList[index].Id;
            try
            {
                MessageBoxResult result = MessageBox.Show("Would you like to update data to list?", "add people", MessageBoxButton.OKCancel);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        var personDelete = (from r in ctx.People
                                      where r.Id == id
                                      select r).ToList();
                        if (personDelete.Count == 0)
                        {
                            MessageBox.Show("No person record. ");
                        }
                        else
                        {
                            ctx.Entry(personDelete[0]).State = System.Data.Entity.EntityState.Deleted;
                            ctx.SaveChanges();
                            //MessageBox.Show("Deletion metod succeeded. ");
                        }
                        peopleList = new ObservableCollection<Person>((from r in ctx.People select r).ToList());
                        lvPeople.DataContext = peopleList;
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                    default:
                        throw new System.IO.InvalidDataException("Error with MessageBox." + result);
                }
            }
            catch (System.IO.InvalidDataException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sHeight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            var slider = sender as Slider;
            if (slider.IsFocused)
            {
                double value = slider.Value;
                string valueStr = string.Format("{0:0.00}", value).ToString();
                tbHeight.Text = valueStr;
            }

        }
    }
}
