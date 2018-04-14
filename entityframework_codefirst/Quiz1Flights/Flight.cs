using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Quiz1Flights
{
    public class Flight
    {
        public Flight()
        {
        }

        public Flight(long id, DateTime onDay, string fromCode, string toCode, TypeFlights typeFlight, int passenger)
        {
            Id = id;
            OnDay = onDay;
            FromCode = fromCode;
            ToCode = toCode;
            TypeFlight = typeFlight;
            Passenger = passenger;
        }

        [Key]
        public long Id { get => _id; set => _id = value; }
        [Required]
        public DateTime OnDay
        {
            get => _onDay; set
            {
                if (DateTime.Compare(value, (DateTime)SqlDateTime.MinValue) < 0)
                {
                    throw new System.IO.InvalidDataException("The date can not be earlier than Jan 1 1753.");
                }
                _onDay = value;
            }
        }
        [Required, MaxLength(5)]
        public string FromCode
        {
            get => _fromCode; set
            {

                if (!new Regex("^[A-Z]{3,5}$").Match(value).Success)
                {
                    throw new System.IO.InvalidDataException("The Passport length must be 3-5 uppercase character");
                }
                _fromCode = value;
            }
        }
        [Required, MaxLength(5)]
        public string ToCode
        {
            get => _toCode; set
            {

                if (!new Regex("^[A-Z]{3,5}$").Match(value).Success)
                {
                    throw new System.IO.InvalidDataException("The Passport length must be 3-5 uppercase character");
                }
                _toCode = value;
            }
        }
        [Required]
        public TypeFlights TypeFlight { get => _typeFlight; set => _typeFlight = value; }
        [Required]
        public int Passenger
        {
            get => _passenger;
            set
            {
                if (value < 0 || value > 200)
                {
                    throw new System.IO.InvalidDataException("The Flights must be between 0 and 200.");
                }
                _passenger = value;
            }
        }
        private long _id;
        private DateTime _onDay;
        private string _fromCode;
        private string _toCode;
        private TypeFlights _typeFlight;
        private int _passenger;
    }
    public enum TypeFlights { Domestic, International, Private };
}
