using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDB
{
    class Person : System.ComponentModel.INotifyPropertyChanged
    {
        public Person() { }
        public Person(int id, string name, string ageStr, string heightStr)
        {
            Id = id;
            Name = name;
            Age = ToAgeInt(ageStr);
            Height = ToHeightDouble(heightStr);
        }

        public Person(string name, string ageStr, string heightStr)
        {
            Name = name;
            Age = ToAgeInt(ageStr);
            Height = ToHeightDouble(heightStr);
        }
        public Person(int id, string name, int age, double height)
        {
            Id = id;
            Name = name;
            Age = age;
            Height = height;
        }
        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, Age: {2}, Height: {3:0.00}",
               Id, Name, Age, Height);
        }
        public int ToAgeInt(string ageStr)
        {
            int age = -1;
            if (!Int32.TryParse(ageStr, out age))
            {
                throw new System.IO.InvalidDataException("Age must be an integer.");
            }
            return age;
        }
        public double ToHeightDouble(string heihgtStr)
        {
            double heihgt = -0.1;
            if (!double.TryParse(heihgtStr, out heihgt))
            {
                throw new System.IO.InvalidDataException("Height must be an double.");
            }
            return heihgt;
        }
        [MaxLength(50), Required]
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length < 2 || value.Length > 50)
                {
                    throw new System.IO.InvalidDataException("The length of name  must be between 2 and 50 character.");
                }
                _name = value;
                OnNotifyPropertyChanged();
            }
        }
        [Required]
        public int Age
        {
            get => _age;
            set
            {
                if (value < 1 || value > 150)
                {
                    throw new System.IO.InvalidDataException("The age must be between 1 and 150.");
                }
                _age = value;
                OnNotifyPropertyChanged();
            }
        }
        [Required]
        public double Height
        {
            get => _height;
            set
            {
                if (value < 30 || value > 300)
                {
                    throw new System.IO.InvalidDataException("The height must be between 30 and 300.");
                }
                _height = value;
                OnNotifyPropertyChanged();
            }
        }

        [Key]
        public int Id { get => _id; set => _id = value; }

        protected virtual void OnNotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public event PropertyChangedEventHandler PropertyChanged;


        private int _id;
        private string _name;
        private int _age;
        private double _height;
    }
}
