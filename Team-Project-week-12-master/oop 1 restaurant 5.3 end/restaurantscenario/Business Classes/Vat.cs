using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a vat.
    /// </summary>
    public class Vat
    {
        /// <summary>
        /// The maximum amount of soup that fits in the vat (in quarts).
        /// </summary>
        private double capacity;

        /// <summary>
        /// The amount of soup currently contained within the vat (in quarts).
        /// </summary>
        private double level;

        /// <summary>
        /// The vat's type.
        /// </summary>
        private string type;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="capacity">The maximum amount of soup (in quarts) that fit in the vat.</param>
        /// <param name="type">The type of food .</param>
        public Vat(double capacity, string type)
        {
            this.capacity = capacity;
            this.type = type;
        }

        /// <summary>
        /// Gets the amount of space remaining for soup (in quarts).
        /// </summary>
        public double FreeCapacity
        {
            get
            {
                return this.capacity - this.Level;
            }
        }

        /// <summary>
        /// Gets the amount of soup currently contained within the vat (in quarts).
        /// </summary>
        public double Level
        {
            get
            {
                return this.level;
            }
        }

        /// <summary>
        /// Adds the specified amount of soup to the vat.
        /// </summary>
        /// <param name="amountToAdd">The amount of soup (in quarts) to add.</param>
        /// <returns>The amount of leftover soup (in quarts).</returns>
        public double FillSoup(double amountToAdd)
        {
            // Determine the amount of soup needed to fill the vat.
            double amountNeeded = this.FreeCapacity;

            // If the amount of soup needed is greater than the amount available.
            if (amountNeeded > amountToAdd)
            {
                // Take all available soup.
                amountNeeded = amountToAdd;
            }

            // Add the amount of soup needed to the vat.
            this.level += amountNeeded;

            // Return any leftover soup.
            return amountToAdd -= amountNeeded;
        }
    }
}