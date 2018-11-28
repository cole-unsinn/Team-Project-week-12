using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a waitress.
    /// </summary>
    public class Waitress
    {
        /// <summary>
        /// The waitress' name.
        /// </summary>
        private string name;

        /// <summary>
        /// The number of condiment bottles the waitress has filled.
        /// </summary>
        private int numberOfCondimentsFilled;

        /// <summary>
        /// The number of patrons the waitress has seated.
        /// </summary>
        private int numberOfPatronsSeated;

        /// <summary>
        /// The number of tables the waitress has set.
        /// </summary>
        private int numberOfTablesSet;

        /// <summary>
        /// The waitress' salary.
        /// </summary>
        private decimal salary;

        /// <summary>
        /// The number of the waitress' assigned table.
        /// </summary>
        private int tableNumber;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="name">The name of the waitress.</param>
        /// <param name="salary">The salary of the waitress.</param>
        /// <param name="tableNumber">The table number of the waitress.</param>
        public Waitress(string name, decimal salary, int tableNumber)
        {
            this.name = name;
            this.salary = salary;
            this.tableNumber = tableNumber;
        }

        /// <summary>
        /// Gets the waitress' name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets or sets number of patrons the waitress has seated.
        /// </summary>
        public int NumberOfPatronsSeated
        {
            get
            {
                return this.numberOfPatronsSeated;
            }
            set
            {
                this.numberOfPatronsSeated = value;
            }
        }

        /// <summary>
        /// Gets or sets the waitress' salary.
        /// </summary>
        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                this.salary = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of the waitress' assigned table.
        /// </summary>
        public int TableNumber
        {
            get
            {
                return this.tableNumber;
            }
            set
            {
                this.tableNumber++;
            }
        }

        /// <summary>
        /// Fills all of the condiments.
        /// </summary>
        public void FillCondiments()
        {
            this.FillKetchup();

            this.FillMustard();

            this.FillSalt();

            this.FillPepper();
        }

        /// <summary>
        /// Sets a table.
        /// </summary>
        public void SetTable()
        {
            // Increment the waitress's number of tables set.
            this.numberOfTablesSet++;
        }

        /// <summary>
        /// Waits on a table.
        /// </summary>
        /// <param name="cook">The cook to make the meal.</param>
        /// <param name="menu">The menu from which the patron will order.</param>
        /// <param name="patron">The patron to be served.</param>
        public void WaitTable(Cook cook, Menu menu, Patron patron)
        {
            // Create a new ticket for this patron.
            Ticket ticket = new Ticket();

            // Define a variable to hold a menu item.
            MenuItem menuItem;

            // Get the patron's drink order.
            menuItem = patron.PlaceDrinkOrder(menu);

            // If an item was ordered...
            if (menuItem != null)
            {
                // Add the drink to the ticket.
                ticket.AddMenuItem(menuItem);

                // Add the price of the drink to the ticket's total amount due.
                ticket.TotalDue += menuItem.Price;
            }

            // Get the patron's meal order.
            menuItem = patron.PlaceMealOrder(menu);

            // If an item was ordered...
            if (menuItem != null)
            {
                // Add the meal to the ticket.
                ticket.AddMenuItem(menuItem);

                // Add the price of the meal to the ticket's total amount due.
                ticket.TotalDue += menuItem.Price;
            }

            // For each menu item in the ticket.
            foreach (MenuItem mi in ticket.MenuItems)
            {
                // Define a variable to hold a food item.
                FoodItem foodItem;

                // Have the cook make a food item, given the current menu item.
                foodItem = cook.MakeMeal(mi);

                // Add the food item to the ticket.
                ticket.AddFoodItem(foodItem);
            }

            

            // Give the patron the ticket (which includes the ordered food items.)
            patron.TakeTicketAndMeal(ticket);

            // Clear the waitress' ticket (giving sole ownership of it to the patron.)
            ticket = null;
        }

        /// <summary>
        /// Fills one bottle of ketchup.
        /// </summary>
        private void FillKetchup()
        {
            // Increment the number of condiments filled.
            this.numberOfCondimentsFilled++;
        }

        /// <summary>
        /// Fills one bottle of mustard.
        /// </summary>
        private void FillMustard()
        {
            // Increment the number of condiments filled.
            this.numberOfCondimentsFilled++;
        }

        /// <summary>
        /// Fills one pepper shaker.
        /// </summary>
        private void FillPepper()
        {
            // Increment the number of condiments filled.
            this.numberOfCondimentsFilled++;
        }

        /// <summary>
        /// Fills one salt shaker.
        /// </summary>
        private void FillSalt()
        {
            // Increment the number of condiments filled.
            this.numberOfCondimentsFilled++;
        }
    }
}