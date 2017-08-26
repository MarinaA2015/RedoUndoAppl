using ForTest.entities;
using System;
using System.Collections.Generic;


namespace ForTest.model
{
    class PersonCreation
    {
        LinkedList<Person> PersonList = new LinkedList<Person>();
        LinkedListNode<Person> CurrentNode;

        public PersonCreation()
        {   
            CurrentNode = PersonList.First;
        }

        public void Start()
        {
            ConsoleKeyInfo keyInfo;
            
            Boolean flag = true;
            Person person = EnterPerson();
            PersonList.AddFirst(person);
            CurrentNode = PersonList.First;
            while (flag)
            {
                CurrentNode.Value.Display();
                Console.Write("Press key to continue ('r' - Redo, 'u' - Undo, 'c' - Change, 'x' - exit): ");
                keyInfo = Console.ReadKey();
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.R:
                            RedoPerson();
                            break;
                        case ConsoleKey.U:
                            UndoPerson();
                            break;
                        case ConsoleKey.C:
                            ChangePerson();
                            break;
                        case ConsoleKey.X:
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("Illegal operation. Press any key to continue");
                            Console.ReadKey();
                        break;

                    }
            }
               
        }

        private void UndoPerson()
        {
            if (CurrentNode.Equals(PersonList.First))
            {
                Console.WriteLine();
                Console.WriteLine("It is the first modification. Press any key to continue");
                Console.ReadKey();
            }
            else CurrentNode = CurrentNode.Previous;
        }

        private void RedoPerson()
        {
            if (CurrentNode.Equals(PersonList.Last))
            {
                Console.WriteLine();
                Console.WriteLine("It is the last modification. Press any key to continue");
                Console.ReadKey();
            }
            else CurrentNode = CurrentNode.Next;
        }

        public void ChangePerson()
        {
            Person person = EnterPerson();
            Console.Write("Person: ");
            person.Display();
            PersonList.AddAfter(CurrentNode,person);
            CurrentNode = CurrentNode.Next;
            if(!CurrentNode.Equals(PersonList.Last)) CleanTail(CurrentNode);
            
        }

        private void CleanTail(LinkedListNode<Person> currentNode)
        {
            LinkedListNode<Person> node = PersonList.Last;
            while (!node.Equals(currentNode))
            {
                node = node.Previous;
                PersonList.RemoveLast();
            }

        }

        private Person EnterPerson()
        {
            Person person = new entities.Person();
            Boolean flag = true;
            string str;
            Console.WriteLine("\n");
            Console.WriteLine("------- Enter person information -------");
            while (flag)
            {
                try
                {
                    Console.Write("Name: ");
                    str = Console.ReadLine();
                    person.Name = str;
                    flag = false;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Error. The name has to be entered.");
                }
            }
            flag = true;
            while (flag)
            {
                try
                {
                    Console.Write("Age: ");
                    str = Console.ReadLine();
                    person.Age = Int32.Parse(str);
                    flag = false;
                }
                catch 
                {
                    Console.WriteLine("The age has to be a number in the range from 0 to 150");
                }
            }
            Address address = EnterAddress();
            person.Address = address;
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();

            return person;
            
        }

        private Address EnterAddress()
        {
            Address address = new Address();
            bool flag = true;
            Console.WriteLine();
            Console.Write("City: ");
            address.City = Console.ReadLine();
            Console.Write("Street: ");
            address.Street = Console.ReadLine();
            while (flag)
            {
                try
                {
                    Console.Write("House number: ");
                    address.House = Int32.Parse(Console.ReadLine());
                    flag = false;
                }
                catch
                {
                    Console.WriteLine("The house number has to be a number and > 0");
                }
                
            }
                    
            return address;


        }
    }
}
