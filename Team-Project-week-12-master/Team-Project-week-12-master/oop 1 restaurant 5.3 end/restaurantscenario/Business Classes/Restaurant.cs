using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a restaurant.
    /// </summary>
    public class Restaurant
    {
        /// <summary>
        /// The number of patrons that can be seated in the restaurant at one time.
        /// </summary>
        private int capacity;

        /// <summary>
        /// The dinner menu.
        /// </summary>
        private Menu dinnerMenu;

        /// <summary>
        /// The lunch menu.
        /// </summary>
        private Menu lunchMenu;

        /// <summary>
        /// The name of the restaurant.
        /// </summary>
        private string name;

        /// <summary>
        /// The owner of the restaurant.
        /// </summary>
        private Cook owner;

        /// <summary>
        /// The restaurant's "regular" patron.
        /// </summary>
        private Patron theRegular;

        /// <summary>
        /// The restaurant's list of waitresses.
        /// </summary>
        private List<Waitress> waitresses;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="basketBreadstickCapacity">The number of breadsticks the basket can hold.</param>
        /// <param name="capacity">The capacity of the restaurant.</param>
        /// <param name="charityName">The name of the cook's charity.</param>
        /// <param name="cookName">The name of the restaurant's cook.</param>
        /// <param name="cookSalary">The salary of the restaurant's cook.</param>
        /// <param name="dinnerMenu">The restaurant's dinner menu.</param>
        /// <param name="lunchMenu">The restaurant's lunch menu.</param>
        /// <param name="name">The name of the restaurant.</param>
        /// <param name="ovenBreadstickBatchSize">The number of breadsticks that can be made in the oven at one time.</param>
        /// <param name="stoveSoupBatchSize">The amount of soup that can be made on the gas stove at one time.</param>
        /// <param name="vatCapacity">The amount of soup that the vat can hold.</param>
        public Restaurant(
            int basketBreadstickCapacity,
            int capacity,
            string charityName,
            string cookName,
            decimal cookSalary,
            Menu dinnerMenu,
            Menu lunchMenu,
            string name,
            int ovenBreadstickBatchSize,
            double stoveSoupBatchSize,
            double vatCapacity)
        {
            this.capacity = capacity;
            this.dinnerMenu = dinnerMenu;
            this.lunchMenu = lunchMenu;
            this.name = name;
            this.owner = new Cook(basketBreadstickCapacity, charityName, cookName, ovenBreadstickBatchSize, cookSalary, stoveSoupBatchSize, vatCapacity);
            this.waitresses = new List<Waitress>();
        }

        /// <summary>
        /// Gets the owner of the restaurant.
        /// </summary>
        public Cook Owner
        {
            get
            {
                return this.owner;
            }
        }

        /// <summary>
        /// Gets or sets the restaurant's "regular" patron.
        /// </summary>
        public Patron TheRegular
        {
            get
            {
                return this.theRegular;
            }
            set
            {
                this.theRegular = value;
            }
        }

        /// <summary>
        /// Adds a waitress to the restaurant's list of waitresses.
        /// </summary>
        /// <param name="waitress">The waitress to add to the list.</param>
        public void AddWaitress(Waitress waitress)
        {
            this.waitresses.Add(waitress);
        }

        /// <summary>
        /// Finds the first waitress in the waitress list that has the specified name.
        /// </summary>
        /// <param name="name">The waitress's name.</param>
        /// <returns>The waitress with the passed in name.</returns>
        public Waitress FindWaitress(string name)
        {
            // Define a result variable.
            Waitress result = null;

            foreach (Waitress w in this.waitresses)
            {
                if (w.Name == name)
                {
                    // Set the temporary variable to the current waitress.
                    result = w;

                    // Break out of the loop.
                    break;
                }
            }

            // Return the result.
            return result;
        }

        /// <summary>
        /// Gives a waitress an increase in (annual) salary by the amount specified.
        /// </summary>
        /// <param name="amount">The amount by which to increase the waitress' (annual) salary.</param>
        /// <param name="waitressName">The name of the waitress of which to give a raise.</param>
        public void GiveWaitressRaise(decimal amount, string waitressName)
        {
            // Find a waitress of the specified name.
            Waitress waitress = this.FindWaitress(waitressName);

            // If a waitress was found...
            if (waitress != null)
            {
                // Increase the waitress' salary by the specified amount.
                waitress.Salary += amount;
            }
        }

        /// <summary>
        /// Requests that the cook prepare the food needed for the day (breadsticks and soup).
        /// </summary>
        public void PrepareDailyFood()
        {
            // Make breadsticks and soup.
            this.Owner.MakeBreadsticksAndSoup();
        }

        /// <summary>
        /// Sets up a table in preparation for a patron.
        /// </summary>
        /// <param name="waitressName">The name of the waitress that is to set up the table.</param>
        public void SetUpTable(string waitressName)
        {
            // Find the waitress.
            Waitress waitress = this.FindWaitress(waitressName);

            // Set the table.
            waitress.SetTable();

            // Fill the condiments.
            waitress.FillCondiments();
        }

        /// <summary>
        /// Tend to the regular.
        /// </summary>
        /// <param name="menuType">The type of menu to give to the regular.</param>
        public void TendToTheRegular(string menuType)
        {
            // Find a waitress for "The Regular".
            Waitress waitress = this.FindWaitress(this.TheRegular);

            // Find a menu.
            Menu menu = this.FindMenu(menuType);

            Cook owner = this.Owner;

            Patron theregular = this.TheRegular;

            // Wait on "The Regular's" table.
            waitress.WaitTable(this.Owner, menu, this.TheRegular);
        }

        /// <summary>
        /// Finds a menu of the specified type.
        /// </summary>
        /// <param name="type">The type of menu to find.</param>
        /// <returns>The first menu of the specified type.</returns>
        private Menu FindMenu(string type)
        {
            Menu result = null;

            // If the requested type is Lunch...
            if (type == this.lunchMenu.Type)
            {
                // Return the lunch menu.
                result = this.lunchMenu;
            }
            else if (type == this.dinnerMenu.Type)
            {
                // Return the Dinner menu.
                result = this.dinnerMenu;
            }
            else
            {
                // TODO: Handle invalid menu type.
                result = null;
            }

            // Return the menu.
            return result;
        }

        /// <summary>
        /// Finds the first waitress in the waitress list whose table number matches the specified patron's table number.
        /// </summary>
        /// <param name="patron">The patron whose table to find a waitress for.</param>
        /// <returns>The first waitress whose table number matches that of the patron.</returns>
        private Waitress FindWaitress(Patron patron)
        {
            Waitress result = null;

            // Loop through the restaruant's list of waitresses.
            foreach (Waitress w in this.waitresses)
            {
                // If the waitress' table number matches the patron's table number.
                if (w.TableNumber == patron.TableNumber)
                {
                    // Set the temporary variable to the current waitress.
                    result = w;

                    // Break out of the loop.
                    break;
                }
            }

            // Return the result.
            return result;
        }
    }
}