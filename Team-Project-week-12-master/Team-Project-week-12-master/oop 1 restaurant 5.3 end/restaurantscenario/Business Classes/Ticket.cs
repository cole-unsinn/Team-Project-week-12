using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a meal ticket.
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// The list of the ticket's food items.
        /// </summary>
        private List<FoodItem> foodItems;

        /// <summary>
        /// The list of the ticket's menu items.
        /// </summary>
        private List<MenuItem> menuItems;

        /// <summary>
        /// The ticket's total amount due.
        /// </summary>
        private decimal totalDue;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public Ticket()
        {
            this.foodItems = new List<FoodItem>();
            this.menuItems = new List<MenuItem>();
        }

        /// <summary>
        /// Gets the list of the ticket's food items.
        /// </summary>
        public List<FoodItem> FoodItems
        {
            get
            {
                return this.foodItems;
            }
        }

        /// <summary>
        /// Gets the list of the ticket's menu items.
        /// </summary>
        public List<MenuItem> MenuItems
        {
            get
            {
                return this.menuItems;
            }
        }

        /// <summary>
        /// Gets or sets the ticket's total amount due.
        /// </summary>
        public decimal TotalDue
        {
            get
            {
                return this.totalDue;
            }
            set
            {
                this.totalDue = value;
            }
        }

        /// <summary>
        /// Adds a food item to the ticket's list of food items.
        /// </summary>
        /// <param name="item">The food item to add.</param>
        public void AddFoodItem(FoodItem item)
        {
            this.foodItems.Add(item);
        }

        /// <summary>
        /// Adds a menu item to the ticket's list of menu items.
        /// </summary>
        /// <param name="item">The menu item to add.</param>
        public void AddMenuItem(MenuItem item)
        {
            this.menuItems.Add(item);
        }
    }
}