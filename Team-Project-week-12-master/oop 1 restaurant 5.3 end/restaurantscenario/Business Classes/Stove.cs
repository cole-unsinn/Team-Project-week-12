using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a stove.
    /// </summary>
    public class Stove
    {
        /// <summary>
        /// The total amount of soup made by the stove (in quarts).
        /// </summary>
        private double amountOfSoupMade;

        /// <summary>
        /// A value indicating whether or not the stove is currently in use.
        /// </summary>
        private bool isInUse;

        /// <summary>
        /// The amount of soup that can be made in a single batch (in quarts).
        /// </summary>
        private double soupBatchSize;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="soupBatchSize">The amount of soup (in quarts) that can be made in a single batch.</param>
        public Stove(double soupBatchSize)
        {
            this.soupBatchSize = soupBatchSize;
        }

        /// <summary>
        /// Gets or sets the total amount of soup made by the stove (in quarts).
        /// </summary>
        public double AmountOfSoupMade
        {
            get
            {
                return this.amountOfSoupMade;
            }
            set
            {
                this.amountOfSoupMade = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not the stove is currently in use.
        /// </summary>
        public bool IsInUse
        {
            get
            {
                return this.isInUse;
            }
        }

        /// <summary>
        /// Cooks a batch of soup.
        /// </summary>
        /// <returns>The amount of soup (in quarts) that was made.</returns>
        public double CookSoup()
        {
            // Add to the total amount of soup made.
            this.AmountOfSoupMade += this.soupBatchSize;

            // Return the amount of soup made in this batch.
            return this.soupBatchSize;
        }

        /// <summary>
        /// Turns the stove on.
        /// </summary>
        public void TurnOn()
        {
            this.isInUse = true;
        }

        /// <summary>
        /// Turns the stove off.
        /// </summary>
        public void TurnOff()
        {
            this.isInUse = false;
        }
    }
}