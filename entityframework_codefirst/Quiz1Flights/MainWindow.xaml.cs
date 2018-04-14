
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

namespace Quiz1Flights
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static FlightsDBContext ctx;
        static ObservableCollection<Flight> flightList;
        public MainWindow()
        {       InitializeComponent();
            try
            {
                ctx = new FlightsDBContext();
                var v = (from p in ctx.Flight select p).ToList();
                flightList = new ObservableCollection<Flight>(v);
                lvFlights.DataContext = flightList;
            }
            catch (System.IO.InvalidDataException ex)
            {
                MessageBox.Show("Error opening database connection: " + ex.Message);
                Environment.Exit(1);
            }
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            DlgAddEdit dlg = new DlgAddEdit(null);
            if (dlg.ShowDialog() == true)
            {
                var v = (from p in ctx.Flight select p).ToList();
                flightList = new ObservableCollection<Flight>(v);
                lvFlights.DataContext = flightList;
            }
        }
        private void lvFlights_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Flight Flight = (Flight)lvFlights.SelectedItem;
            if (Flight == null)
            {
                MessageBox.Show("No item was selected");
                return;
            }
            DlgAddEdit dlg = new DlgAddEdit(Flight);
            if (dlg.ShowDialog() == true)
            {
                var v = (from p in ctx.Flight select p).ToList();
                flightList = new ObservableCollection<Flight>(v);
                lvFlights.DataContext = flightList;
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            btAdd.Focus();
        }


        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            int index = lvFlights.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            var result = MessageBox.Show("Do you want to delete?", "Delete item", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                Flight Flight = (Flight)lvFlights.Items[index];
                try
                {
                    var personDelete = (from r in ctx.Flight
                                        where r.Id == Flight.Id
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
                    flightList = new ObservableCollection<Flight>((from r in ctx.Flight select r).ToList());
                    lvFlights.DataContext = flightList;
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
        }
    }
}
