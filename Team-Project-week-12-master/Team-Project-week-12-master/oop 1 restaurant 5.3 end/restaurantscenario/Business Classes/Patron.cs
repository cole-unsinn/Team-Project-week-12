using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a patron.
    /// </summary>
    public class Patron
    {
        /// <summary>
        /// The patron's favorite drink.
        /// </summary>
        private string favoriteDrinkName;

        /// <summary>
        /// The patron's favorite meal.
        /// </summary>
        private string favoriteMealName;

        /// <summary>
        /// The patron's ticket.
        /// </summary>
        private Ticket myTicket;

        /// <summary>
        /// The name of the patron.
        /// </summary>
        private string name;

        /// <summary>
        /// The number of the patron's preferred table.
        /// </summary>
        private int preferredTableNumber;

        /// <summary>
        /// The number of the table the patron is currently seated at.
        /// </summary>
        private int tableNumber;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="favoriteDrinkName">The name of the patron's favorite drink.</param>
        /// <param name="favoriteMealName">The name of the patron's favorite meal.</param>
        /// <param name="name">The name of the patron.</param>
        /// <param name="preferredTableNumber">The patron's preferred table number.</param>
        public Patron(string favoriteDrinkName, string favoriteMealName, string name, int preferredTableNumber)
        {
            this.favoriteDrinkName = favoriteDrinkName;
            this.favoriteMealName = favoriteMealName;
            this.name = name;
            this.preferredTableNumber = preferredTableNumber;
        }

        /// <summary>
        /// Gets or sets the patron's ticket.
        /// </summary>
        public Ticket MyTicket
        {
            get
            {
                return this.myTicket;
            }
            set
            {
                this.myTicket = value;
            }
        }

        /// <summary>
        /// Gets the number of the patron's preferred table.
        /// </summary>
        public int PreferredTableNumber
        {
            get
            {
                return this.preferredTableNumber;
            }
        }

        /// <summary>
        /// Gets or sets the number of the table the patron is currently seated at.
        /// </summary>
        public int TableNumber
        {
            get
            {
                return this.tableNumber;
            }
            set
            {
                this.tableNumber = value;
            }
        }

        /// <summary>
        /// Consumes a food item.
        /// </summary>
        /// <param name="food">The food item to consume.</param>
        public void Consume(FoodItem food)
        {
        }

        /// <summary>
        /// Places an order for a drink.
        /// </summary>
        /// <param name="menu">The menu from which to order the drink.</param>
        /// <returns>The drink menu item.</returns>
        public MenuItem PlaceDrinkOrder(Menu menu)
        {
            MenuItem result = null;

            // Select the drink from the menu
            result = this.SelectDrink(menu);

            return result;
        }

        /// <summary>
        /// Places an order for a meal.
        /// </summary>
        /// <param name="menu">The menu from which to order the meal.</param>
        /// <returns>The meal menu item.</returns>
        public MenuItem PlaceMealOrder(Menu menu)
        {
            // Select the meal from the menu.
            MenuItem result = this.SelectMeal(menu);

            return result;
        }

        /// <summary>
        /// Accepts the ticket.
        /// </summary>
        /// <param name="ticket">The ticket to accept.</param>
        public void TakeTicketAndMeal(Ticket ticket)
        {
            // For each food item on the ticket.
            foreach (FoodItem fi in ticket.FoodItems)
            {
                // Eat the food item.
                this.Consume(fi);
            }

            this.MyTicket = ticket;
        }

        /// <summary>
        /// Selects a drink from a menu.
        /// </summary>
        /// <param name="menu">The menu from which to select the meal.</param>
        /// <returns>The drink menu item.</returns>
        private MenuItem SelectDrink(Menu menu)
        {
            MenuItem result = null;

            // Find the menu item.
            result = menu.FindMenuItem(this.favoriteDrinkName);

            return result;
        }

        /// <summary>
        /// Selects a meal from a menu.
        /// </summary>
        /// <param name="menu">The menu from which to select the drink.</param>
        /// <returns>The meal menu item.</returns>
        private MenuItem SelectMeal(Menu menu)
        {
            MenuItem result = null;

            // Find the meal.
            result = menu.FindMenuItem(this.favoriteMealName);

            // If the desired meal is not found...
            if (result == null)
            {
                // Select the daily special instead.
                result = menu.DailySpecial;
            }

            return result;
        }
    }
}