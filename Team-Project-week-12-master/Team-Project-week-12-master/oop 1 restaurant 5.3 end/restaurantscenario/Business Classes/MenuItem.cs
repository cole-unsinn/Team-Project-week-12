using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a menu item.
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// The cost of the menu item.
        /// </summary>
        private decimal cost;

        /// <summary>
        /// The price of the menu item.
        /// </summary>
        private decimal price;

        /// <summary>
        /// The type of the menu item.
        /// </summary>
        private string type;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="cost">The cost of the menu item.</param>
        /// <param name="price">The price of the menu item.</param>
        /// <param name="type">The type of menu item.</param>
        public MenuItem(decimal cost, decimal price, string type)
        {
            this.cost = cost;
            this.price = price;
            this.type = type;
        }

        /// <summary>
        /// Gets or sets the cost of the menu item.
        /// </summary>
        public decimal Cost
        {
            get
            {
                return this.cost;
            }
            set
            {
                this.cost = value;
            }
        }

        /// <summary>
        /// Gets or sets the price of the menu item.
        /// </summary>
        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        /// <summary>
        /// Gets the type of the menu item.
        /// </summary>
        public string Type
        {
            get
            {
                return this.type;
            }
        }
    }
}