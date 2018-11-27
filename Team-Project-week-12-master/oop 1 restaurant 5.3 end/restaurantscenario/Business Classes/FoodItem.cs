using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a food item.
    /// </summary>
    public class FoodItem
    {
        /// <summary>
        /// The type of the food item.
        /// </summary>
        private string type;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="type">The type of food item.</param>
        public FoodItem(string type)
        {
            this.type = type;
        }

        /// <summary>
        /// Gets the type of the food item.
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