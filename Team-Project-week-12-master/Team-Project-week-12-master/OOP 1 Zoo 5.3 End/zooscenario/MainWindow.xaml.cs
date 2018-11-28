using System;
using System.Collections.Generic;
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

namespace ZooScenario
{
    /// <summary>
    /// Contains interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Minnesota's Como Zoo.
        /// </summary>
        private Zoo comoZoo;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Calculates total and average animal weights of all animals in the zoo.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void calculateAnimalWeightsButton_Click(object sender, RoutedEventArgs e)
        {
            // Define and set a variable to hold the sum of all animal weights.
            double totalWeight = this.comoZoo.TotalAnimalWeight;

            // Define and set a variable to hold the average animal weight.
            double averageWeight = this.comoZoo.AverageAnimalWeight;
        }

        /// <summary>
        /// Finds Fred's age.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void findFredAgeButton_Click(object sender, RoutedEventArgs e)
        {
            // Define and initialize a variable to hold Fred.
            Guest fred = this.comoZoo.FindGuest("Fred");

            // If Fred was found...
            if (fred != null)
            {
                // Retrieve Fred's age and store it in a variable.
                int fredsAge = fred.Age;
            }
        }

        /// <summary>
        /// Requests that Flora birth all pregnant animals in the zoo.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void floraBirthAllPregnantAnimalsButton_Click(object sender, RoutedEventArgs e)
        {
            // Get beginning total animal weight.
            double beginningWeight = this.comoZoo.TotalAnimalWeight;

            // Call comoZoo.FindEmployee
            Employee vet = this.comoZoo.FindEmployee("Flora");

            // Call comoZoo.BirthAllPregnantAnimals
            this.comoZoo.BirthAllPregnantAnimals(vet);

            // Get ending total animal weight.
            double endingWeight = this.comoZoo.TotalAnimalWeight;

            // Get vet.AnimalDeliveryCount
            int deliveryCount = vet.AnimalDeliveryCount;
        }

        /// <summary>
        /// Requests that Flora birth a dingo.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void floraBirthDingoButton_Click(object sender, RoutedEventArgs e)
        {
            // Get beginning total animal weight.
            double beginningWeight = this.comoZoo.TotalAnimalWeight;

            // Find the mother dingo.
            Animal mother = this.comoZoo.FindAnimal(typeof(Dingo), true);

            // Find the vet.
            Employee vet = this.comoZoo.FindEmployee("Flora");

            // Birth the dingo.
            this.comoZoo.BirthAnimal(mother, vet);

            // Get ending total animal weight.
            double endingWeight = this.comoZoo.TotalAnimalWeight;
        }

        /// <summary>
        /// Requests that Fred feed a platypus.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void fredFeedPlatypusButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the beginning total animal weight.
            double beginningWeight = this.comoZoo.TotalAnimalWeight;

            // Find Fred.
            Guest fred = this.comoZoo.FindGuest("Fred");

            // Find a platypus.
            Animal platypus = this.comoZoo.FindAnimal(typeof(Platypus));

            // Call guest.FeedAnimal.
            fred.FeedAnimal(platypus, this.comoZoo.AnimalSnackMachine);

            // Get the ending total animal weight.
            double endingWeight = this.comoZoo.TotalAnimalWeight;
        }

        /// <summary>
        /// Creates a zoo and related objects.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void newZooButton_Click(object sender, RoutedEventArgs e)
        {
            // Create Sam.
            Employee employee = new Employee("Sam", 42);

            // Create the Como Zoo.
            this.comoZoo = new Zoo(employee, 1000, "Como Zoo", 4, 15m);

            // Set birthing room temperature.
            this.comoZoo.BirthingRoomTemperature = 77;

            // Add Sam to the Zoo.
            this.comoZoo.AddEmployee(employee);

            // Create Flora
            employee = new Employee("Flora", 98);

            // Add Flora to the Zoo.
            this.comoZoo.AddEmployee(employee);

            // Create Brutus and add him to Como Zoo.
            this.comoZoo.AddAnimal(new Dingo(0, "Brutus", 2.25));

            // Create Coco.
            Animal animal = new Dingo(5, "Coco", 25.8);

            // Make Coco pregnant.
            animal.MakePregnant();

            // Add Coco to the Como Zoo.
            this.comoZoo.AddAnimal(animal);

            // Create Paddy and add him to the Como Zoo.
            this.comoZoo.AddAnimal(new Platypus(3, "Paddy", 15.4));

            // Create Bella.
            animal = new Platypus(6, "Bella", 23.5);

            // Make Bella pregnant.
            animal.MakePregnant();

            // Add Bella to the Como Zoo.
            this.comoZoo.AddAnimal(animal);

            // Create Sally and add her to the Como Zoo.
            this.comoZoo.AddGuest(new Guest(38, 150.35m, "Sally", "Black"));

            // Create Fred and add him to the Como Zoo.
            this.comoZoo.AddGuest(new Guest(11, 15m, "Fred", "Brown"));
        }

        /// <summary>
        /// Releases the first baby (age of 0) dingo from the zoo.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void releaseBabyDingoButton_Click(object sender, RoutedEventArgs e)
        {
            // Get beginning number of animals in list.
            int beginningAnimalCount = this.comoZoo.AnimalCount;

            // Find the first baby animal.
            Animal baby = this.comoZoo.FindAnimal(typeof(Dingo), 0);

            // Remove the baby from zoo's animal list.
            this.comoZoo.RemoveAnimal(baby);

            // Get ending number of animals in list.
            int endingAnimalCount = this.comoZoo.AnimalCount;
        }

        /// <summary>
        /// Requests that Sally feed a dingo.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void sallyFeedDingoButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the beginning total animal weight.
            double beginningWeight = this.comoZoo.TotalAnimalWeight;

            // Find Sally.
            Guest sally = this.comoZoo.FindGuest("Sally");

            // Find a dingo.
            Animal dingo = this.comoZoo.FindAnimal(typeof(Dingo));

            // Call guest.FeedAnimal.
            sally.FeedAnimal(dingo, this.comoZoo.AnimalSnackMachine);

            // Get the ending total animal weight.
            double endingWeight = this.comoZoo.TotalAnimalWeight;
        }

        /// <summary>
        /// Requests that Sally give Fred $5.00.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void sallyGiveFred5Button_Click(object sender, RoutedEventArgs e)
        {
            // Find Sally.
            Guest sally = this.comoZoo.FindGuest("Sally");

            // Find Fred.
            Guest fred = this.comoZoo.FindGuest("Fred");

            // Give $5 from Sally to Fred.
            sally.GiveMoney(5m, fred);
        }
    }
}