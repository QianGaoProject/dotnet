using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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

namespace Quiz1Flights
{
    /// <summary>
    /// Interaction logic for DlgAddEdit.xaml
    /// </summary>
    public partial class DlgAddEdit : Window
    {
        private Flight currentItem;

        public DlgAddEdit(Flight item)
        {
            currentItem = item;
            InitializeComponent();
            List<Flightsinfo> FlightsinfoList = new List<Flightsinfo>();

            FlightsinfoList.Add(new Flightsinfo() { Name = "Domestic" });
            FlightsinfoList.Add(new Flightsinfo() { Name = "International" });
            FlightsinfoList.Add(new Flightsinfo() { Name = "Private" });

            infoFlights.ItemsSource = FlightsinfoList;

            if (currentItem == null)
            {
                btSave.Content = "Add";
            }
            else
            {
                try
                {
                    lblIdValue.Content = item.Id + "";
                    tbDate.Text = item.OnDay.ToString(@"dd-MM-yyyy");
                    tbFromCode.Text = item.FromCode;
                    tbToCode.Text = item.ToCode;

                    tbPassenger.Text = item.Passenger + "";
                    infoFlights.Text = item.TypeFlight.ToString();
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Error Message");
                }
            }
        }
        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Flight flight = (currentItem == null ? new Flight() : currentItem);
                string onDayStr = tbDate.Text;
                DateTime newDate;
                if (!DateTime.TryParse(onDayStr, out newDate))
                {
                    throw new System.IO.InvalidDataException("Can't make OnDay!");
                }
                flight.OnDay = newDate;
                flight.FromCode = tbFromCode.Text;
                flight.ToCode = tbToCode.Text;

                var value = infoFlights.SelectedItem ?? throw new System.IO.InvalidDataException("The info was not selected!");
                // Try to convert the string to an enum:
                TypeFlights typeFlight = (TypeFlights)Enum.Parse(typeof(TypeFlights), value.ToString());
                flight.TypeFlight = typeFlight;


                string passengerStr = tbPassenger.Text;
                int passengerInt = 0;
                if (!Int32.TryParse(passengerStr, out passengerInt))
                {
                    throw new System.IO.InvalidDataException("Can't convert string to int with passenger!");
                }
                flight.Passenger = passengerInt;
                // add and edit - insert
                FlightsDBContext ctx = MainWindow.ctx;
                if (currentItem == null)
                {
                    ctx.Flight.Add(flight);
                }
                ctx.SaveChanges();
                DialogResult = true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error: Database add/update error!" + ex.Message, "Error Message");
            }
            catch (System.IO.InvalidDataException ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Error Message");
            }
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            tbDate.Focus();
        }



        private void sPassenger_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            if (slider.IsFocused)
            {
                double value = slider.Value;
                string valueStr = string.Format("{0:0}", value).ToString();
                tbPassenger.Text = valueStr;
            }

        }
    }
    public class Flightsinfo
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

}
