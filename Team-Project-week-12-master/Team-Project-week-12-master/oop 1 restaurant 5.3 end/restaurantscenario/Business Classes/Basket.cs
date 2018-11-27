using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a basket.
    /// </summary>
    public class Basket
    {
        /// <summary>
        /// The number of breadsticks that the basket can hold.
        /// </summary>
        private int breadstickCapacity;

        /// <summary>
        /// The number of breadsticks currently in the basket.
        /// </summary>
        private int breadstickCount;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="breadstickCapacity">The breadstick capacity of the basket.</param>
        public Basket(int breadstickCapacity)
        {
            this.breadstickCapacity = breadstickCapacity;
        }

        /// <summary>
        /// Gets the number of breadsticks currently in the basket.
        /// </summary>
        public int BreadstickCount
        {
            get
            {
                return this.breadstickCount;
            }
        }

        /// <summary>
        /// Gets the number of breadsticks that the basket can still hold.
        /// </summary>
        public int FreeBreadstickCapacity
        {
            get
            {
                return this.breadstickCapacity - this.BreadstickCount;
            }
        }

        /// <summary>
        /// Adds the specified number of breadsticks to the basket.
        /// </summary>
        /// <param name="numberToAdd">The number of breadsticks to add to the basket.</param>
        /// <returns>The number of leftover breadsticks.</returns>
        public int AddBreadsticks(int numberToAdd)
        {
            // Determine the number of breadsticks needed to fill the basket.
            int numberNeeded = this.FreeBreadstickCapacity;

            // If more breadsticks are needed than are available to add.
            if (numberNeeded > numberToAdd)
            {
                // Take all the breadsticks that are available to be added.
                numberNeeded = numberToAdd;
            }

            // Add the number of needed breadsticks to the basket.
            this.breadstickCount += numberNeeded;

            // Return any leftover breadsticks.
            return numberToAdd -= numberNeeded;
        }
    }
}