using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a menu.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// The color of the menu.
        /// </summary>
        private string color;

        /// <summary>
        /// The menu's daily special.
        /// </summary>
        private MenuItem dailySpecial;

        /// <summary>
        /// The list of items on the menu.
        /// </summary>
        private List<MenuItem> items;

        /// <summary>
        /// The number of pages in the menu.
        /// </summary>
        private int numberOfPages;

        /// <summary>
        /// The type of the menu.
        /// </summary>
        private string type;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="color">The color of the menu.</param>
        /// <param name="dailySpecial">The menu's daily special.</param>
        /// <param name="numberOfPages">The number of pages in the menu.</param>
        /// <param name="type">The type of menu.</param>
        public Menu(string color, MenuItem dailySpecial, int numberOfPages, string type)
        {
            this.color = color;
            this.dailySpecial = dailySpecial;
            this.items = new List<MenuItem>();
            this.numberOfPages = numberOfPages;
            this.type = type;
        }

        /// <summary>
        /// Gets or sets the menu's daily special.
        /// </summary>
        public MenuItem DailySpecial
        {
            get
            {
                return this.dailySpecial;
            }
            set
            {
                this.dailySpecial = value;
            }
        }

        /// <summary>
        /// Gets the type of the menu.
        /// </summary>
        public string Type
        {
            get
            {
                return this.type;
            }
        }

        /// <summary>
        /// Adds a menu item.
        /// </summary>
        /// <param name="cost">The cost of the menu item.</param>
        /// <param name="price">The price of the menu item.</param>
        /// <param name="type">The type of the menu item.</param>
        public void AddMenuItem(decimal cost, decimal price, string type)
        {
            this.items.Add(new MenuItem(cost, price, type));
        }

        /// <summary>
        /// Finds the specified item in the menu.
        /// </summary>
        /// <param name="type">The type of the item to find.</param>
        /// <returns>The first menu item matching the specified type.</returns>
        public MenuItem FindMenuItem(string type)
        {
            MenuItem result = null;

            // Loop through the items on the menu.
            foreach (MenuItem mi in this.items)
            {
                // If the desired menu item was found...
                if (mi.Type == type)
                {
                    // Set the temporary variable to to the current item.
                    result = mi;

                    // Break out of the loop.
                    break;
                }
            }

            return result;
        }
    }
}