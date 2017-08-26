using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTest.entities
{
    class Address
    {
        private string _city;
        private string _street;
        private int _house;

        public Address(string city, string street, int house)
        {
            this.City = city;
            this.Street = street;
            this.House = house;
        }
        public Address() { }

        public string City
        {
            get
            {
                return _city;
            }

            set
            {
                
               _city = value;
             

            }
        }

        public string Street
        {
            get
            {
                return _street;
            }

            set
            {
               _street = value;

            }
        }

        public int House
        {
            get
            {
                return _house;
            }
            set
            {
                if (value > 0) _house = value;
                else
                    throw new System.ArgumentException("the value is less than 1");
            }
        }

        public override string ToString()
        {
            return _city + ", " + _street + ", " + _house + " ";
        }

    }
}
