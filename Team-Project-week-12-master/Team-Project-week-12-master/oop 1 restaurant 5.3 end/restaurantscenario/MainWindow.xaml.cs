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

namespace RestaurantScenario
{
    /// <summary>
    /// Contains interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Mom's restaurant.
        /// </summary>
        private Restaurant moms;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Calculates the total amount due for the ticket.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void calculateTicketTotalDueButton_Click(object sender, RoutedEventArgs e)
        {
            // Define and initialize an accumlator variable.
            decimal totalDue = 0m;

            // If there is a ticket...
            if (this.moms.TheRegular.MyTicket != null)
            {
                // Loop through the list of menu items in the ticket.
                foreach (MenuItem mi in this.moms.TheRegular.MyTicket.MenuItems)
                {
                    // Add the price of each menu item to the total
                    totalDue += mi.Price;
                }

                // Assign the ticket's total due field to the calculated value.
                this.moms.TheRegular.MyTicket.TotalDue = totalDue;
            }
        }

        /// <summary>
        /// Gives Heidi a $1,000 raise.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void giveHeidi1000RaiseButton_Click(object sender, RoutedEventArgs e)
        {
            // Give Heidi a $1,000 raise.
            this.moms.GiveWaitressRaise(1000m, "Heidi");
        }

        /// <summary>
        /// Requests that Heidi seat "The Regular".
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void heidiSeatPatronButton_Click(object sender, RoutedEventArgs e)
        {
            // Define a temporary variable to hold Heidi.
            Waitress heidi;

            // Find Svanhilde from the list of waitresses.
            heidi = this.moms.FindWaitress("Heidi");

            // If Heidi was found...
            if (heidi != null)
            {
                // Have Heidi seat The Regular at his preferred table.
                this.moms.TheRegular.TableNumber = this.moms.TheRegular.PreferredTableNumber;

                // Increment a counter indicating the number of patrons Heidi has seated.
                heidi.NumberOfPatronsSeated++;
            }
        }

        /// <summary>
        /// Creates a restaurant and related objects.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void newRestaurantButton_Click(object sender, RoutedEventArgs e)
        {
            // Create dinner menu and store in local variable.
            Menu dinnerMenu = new Menu("Black", null, 6, "Dinner");

            // Create daily lunch special (pot roast) and store in local variable.
            MenuItem dailySpecial = new MenuItem(2.52m, 7.99m, "Pot Roast");

            // Create lunch menu and store in local variable.
            Menu lunchMenu = new Menu("Black", dailySpecial, 4, "Lunch");

            // Add menu items to lunch menu.
            lunchMenu.AddMenuItem(0.12m, 1.49m, "Coffee");
            lunchMenu.AddMenuItem(0.23m, 1.99m, "Lemonade");
            lunchMenu.AddMenuItem(2.25m, 7.99m, "Meatloaf");
            lunchMenu.AddMenuItem(2.47m, 6.79m, "Veggie Salad");

            // Create Moms.
            this.moms = new Restaurant(30, 25, "Salvation Army", "Vladimir", 28000, dinnerMenu, lunchMenu, "Mom's", 20, 12, 24);

            // Create The Regular.
            this.moms.TheRegular = new Patron("Lemonade", "Meatloaf", "Frank", 1);

            // Define waitress variable.
            Waitress waitress;

            // Create waitress (Svanhilde).
            waitress = new Waitress("Svanhilde", 18575, 1);

            // Add Svanhilde to the waitress list.
            this.moms.AddWaitress(waitress);

            // Create waitress (Heidi).
            waitress = new Waitress("Heidi", 16550, 2);

            // Add Heidi to the waitress list.
            this.moms.AddWaitress(waitress);
        }

        /// <summary>
        /// Requests that the cook prepare the daily food.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void prepareDailyFoodButton_Click(object sender, RoutedEventArgs e)
        {
            // Get beginning number of breadsticks baked.
            int beginningBreadstickCount = this.moms.Owner.BreadOven.NumberOfBreadsticksBaked;

            // Get beginning amount of soup made.
            double beginningSoupAmount = this.moms.Owner.GasStove.AmountOfSoupMade;

            // Prepare the food for the day.
            this.moms.PrepareDailyFood();

            // Get ending number of breadsticks baked.
            int endingBreadstickCount = this.moms.Owner.BreadOven.NumberOfBreadsticksBaked;

            // Get ending amount of soup made.
            double endingSoupAmount = this.moms.Owner.GasStove.AmountOfSoupMade;
        }

        /// <summary>
        /// Serves lunch to "The Regular".
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void serveLunchToTheRegularButton_Click(object sender, RoutedEventArgs e)
        {
            this.moms.TendToTheRegular("Lunch");
        }

        /// <summary>
        /// Requests that Svanhilde set up a table.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void svanhildeSetUpTableButton_Click(object sender, RoutedEventArgs e)
        {
            this.moms.SetUpTable("Svanhilde");
        }
    }
}