using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTest.entities
{
    class Person
    {
        private string _name;
        private int _age;
        private Address _address;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != null && value != "")
                    _name = value;
                else throw new System.ArgumentException("the value is epty or not defined");
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value >= 0 && value <= 150)
                    _age = value;
                else throw new System.ArgumentException("the value is less than 0 or more than 150");
            }
        }

        public Address Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }

        public Person()
        { }

        
        public Person(string name, int age, Address address)
        {
            this.Name = name;
            this.Age = age;
            this.Address = address;
        }


        public override string ToString()
        {
            return "Name: " + Name + " Age: " + Age + " Address: " + Address;
        }

        public void Display()
        {
            Console.WriteLine();
            Console.WriteLine("---- Person Details ----");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Address: " + Address);
            Console.WriteLine("-------------------------");
            Console.WriteLine();
        }
    }
}
