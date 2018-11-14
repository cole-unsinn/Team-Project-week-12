using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooScenario
{
    /// <summary>
    /// The class which is used to represent a zoo.
    /// </summary>
    public class Zoo
    {
        /// <summary>
        /// Contains all of the animals in the zoo.
        /// </summary>
        private List<Animal> animals;

        /// <summary>
        /// The vending machine which allows guests to buy snacks for animals.
        /// </summary>
        private VendingMachine animalSnackMachine;

        /// <summary>
        /// The room for birthing animals.
        /// </summary>
        private BirthingRoom b168;

        /// <summary>
        /// The maximum number of guests the zoo can accommodate at a given time.
        /// </summary>
        private int capacity;

        /// <summary>
        /// Contains all of the employees of the zoo.
        /// </summary>
        private List<Employee> employees;

        /// <summary>
        /// Contains all of the guests currently in the zoo.
        /// </summary>
        private List<Guest> guests;

        /// <summary>
        /// The ladies' restroom.
        /// </summary>
        private Restroom ladiesRoom;

        /// <summary>
        /// The men's restroom.
        /// </summary>
        private Restroom mensRoom;

        /// <summary>
        /// The name of the zoo.
        /// </summary>
        private string name;

        /// <summary>
        /// The ticket booth.
        /// </summary>
        private Booth ticketBooth;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="boothAttendant">The ticket booth's attendant.</param>
        /// <param name="capacity">The number of guests that the zoo can hold at a given time.</param>
        /// <param name="name">The name of the zoo.</param>
        /// <param name="restroomCapacity">The capacity of the zoo's restrooms.</param>
        /// <param name="ticketPrice">The price of an admission ticket for the zoo.</param>
        public Zoo(Employee boothAttendant, int capacity, string name, int restroomCapacity, decimal ticketPrice)
        {
            this.animals = new List<Animal>();
            this.animalSnackMachine = new VendingMachine(0.75m, 0.5m);
            this.b168 = new BirthingRoom();
            this.capacity = capacity;
            this.employees = new List<Employee>();
            this.guests = new List<Guest>();
            this.ladiesRoom = new Restroom(restroomCapacity, "Female");
            this.mensRoom = new Restroom(restroomCapacity, "Male");
            this.name = name;
            this.ticketBooth = new Booth(boothAttendant, ticketPrice);
        }

        /// <summary>
        /// Gets the number of animals in the zoo.
        /// </summary>
        public int AnimalCount
        {
            get
            {
                return this.animals.Count;
            }
        }

        /// <summary>
        /// Gets the vending machine which allows guests to buy snacks for animals.
        /// </summary>
        public VendingMachine AnimalSnackMachine
        {
            get
            {
                return this.animalSnackMachine;
            }
        }

        /// <summary>
        /// Gets the average weight of all animals in the zoo.
        /// </summary>
        public double AverageAnimalWeight
        {
            get
            {
                // Get total animal weight, calculate average, and return it.
                return this.TotalAnimalWeight / this.animals.Count;
            }
        }

        /// <summary>
        /// Gets or sets the temperature of the zoo's room for birthing animals.
        /// </summary>
        public double BirthingRoomTemperature
        {
            get
            {
                return this.b168.Temperature;
            }

            set
            {
                this.b168.Temperature = value;
            }
        }

        /// <summary>
        /// Gets the total weight of all animals in the zoo.
        /// </summary>
        public double TotalAnimalWeight
        {
            get
            {
                // Define and initialize an accumulator variable.
                double result = 0;

                // Loop through the zoo's list of animals.
                foreach (Animal a in this.animals)
                {
                    // Add the current animal's weight to the accumulator variable.
                    result += a.Weight;
                }

                // Return calculated total.
                return result;
            }
        }

        /// <summary>
        /// Adds an animal to the zoo.
        /// </summary>
        /// <param name="animal">The animal to add.</param>
        public void AddAnimal(Animal animal)
        {
            this.animals.Add(animal);
        }

        /// <summary>
        /// Adds an employee to the zoo.
        /// </summary>
        /// <param name="employee">The employee to add.</param>
        public void AddEmployee(Employee employee)
        {
            this.employees.Add(employee);
        }

        /// <summary>
        /// Adds a guest to the zoo.
        /// </summary>
        /// <param name="guest">The guest to add.</param>
        public void AddGuest(Guest guest)
        {
            this.guests.Add(guest);
        }

        /// <summary>
        /// Births all pregnant animals in the zoo.
        /// </summary>
        /// <param name="vet">The vet that is to birth the pregnant animals.</param>
        public void BirthAllPregnantAnimals(Employee vet)
        {
            // Create a temporary copy of the animals list.
            List<Animal> tempList = this.animals.ToList();

            // Loop through all animals in the temporary list.
            foreach (Animal a in tempList)
            {
                // If the current animal is pregnant...
                if (a.IsPregnant)
                {
                    // Have the passed-in vet birth the current animal.
                    this.BirthAnimal(a, vet);
                }
            }
        }

        /// <summary>
        /// Births an animal.
        /// </summary>
        /// <param name="mother">The mother animal.</param>
        /// <param name="vet">The vet that is to birth the animal.</param>
        public void BirthAnimal(Animal mother, Employee vet)
        {
            // Put the vet in the birthing room.
            this.b168.Vet = vet;

            // Birth the animal.
            Animal baby = this.b168.BirthAnimal(mother);

            // Add the animal to the zoo's animal list.
            this.AddAnimal(baby);

            // Remove the vet from the birthing room.
            this.b168.Vet = null;
        }

        /// <summary>
        /// Finds the first animal of the specified type.
        /// </summary>
        /// <param name="type">The type of animal to find.</param>
        /// <returns>The animal that was found.</returns>
        public Animal FindAnimal(string type)
        {
            // Define and initialize a result variable.
            Animal result = null;

            // Loop through all animals in the zoo.
            foreach (Animal a in this.animals)
            {
                // If the desired animal was found...
                if (a.Type == type)
                {
                    // Set the variable to point to the current aniimal.
                    result = a;

                    // Break out of the loop (no need to continue looking).
                    break;
                }
            }

            // Return result.
            return result;
        }

        /// <summary>
        /// Finds the first animal of the specified type and pregnancy status.
        /// </summary>
        /// <param name="type">The type of animal to find.</param>
        /// <param name="isPregnant">The pregnancy status of the animal to find.</param>
        /// <returns>The animal that was found.</returns>
        public Animal FindAnimal(string type, bool isPregnant)
        {
            // Define and initialize a result variable.
            Animal result = null;

            // Loop through all animals in the zoo.
            foreach (Animal a in this.animals)
            {
                // If the desired animal was found...
                if (a.Type == type && a.IsPregnant == isPregnant)
                {
                    // Set the variable to point to the current aniimal.
                    result = a;

                    // Break out of the loop (no need to continue looking).
                    break;
                }
            }

            // Return result.
            return result;
        }

        /// <summary>
        /// Finds the first animal of the specified type and age.
        /// </summary>
        /// <param name="type">The type of animal to find.</param>
        /// <param name="age">The age of the animal to find.</param>
        /// <returns>The animal that was found.</returns>
        public Animal FindAnimal(string type, int age)
        {
            // Define and initialize a result variable.
            Animal result = null;

            // Loop through all animals in the zoo.
            foreach (Animal a in this.animals)
            {
                // If the desired animal was found...
                if (a.Type == type && a.Age == age)
                {
                    // Set the variable to point to the current aniimal.
                    result = a;

                    // Break out of the loop (no need to continue looking).
                    break;
                }
            }

            // Return result.
            return result;
        }

        /// <summary>
        /// Finds an employee from the zoo's employee list.
        /// </summary>
        /// <param name="name">The name of the employee to find.</param>
        /// <returns>The first employee with the specified name.</returns>
        public Employee FindEmployee(string name)
        {
            Employee result = null;

            // Loop through all employees in the zoo.
            foreach (Employee e in this.employees)
            {
                // If the current employee's name matches the desired name...
                if (e.Name == name)
                {
                    // Select current employee.
                    result = e;

                    // Stop looking, since the desired employee was found.
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Finds a guest from the zoo's guest list.
        /// </summary>
        /// <param name="name">The name of the guest to find.</param>
        /// <returns>The first guest whose name matches.</returns>
        public Guest FindGuest(string name)
        {
            // Define and initialize a result variable.
            Guest result = null;

            // Loop through all guests in the zoo.
            foreach (Guest g in this.guests)
            {
                // If the desired guest was found...
                if (g.Name == name)
                {
                    // Set the variable to point to the current guest.
                    result = g;

                    // Break out of the loop (no need to continue looking).
                    break;
                }
            }

            // Return result.
            return result;
        }

        /// <summary>
        /// Removes an animal from the zoo.
        /// </summary>
        /// <param name="animal">The animal to remove.</param>
        public void RemoveAnimal(Animal animal)
        {
            this.animals.Remove(animal);
        }
    }
}