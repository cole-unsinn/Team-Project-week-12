using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent an oven.
    /// </summary>
    public class Oven
    {
        /// <summary>
        /// The maximum number of breadsticks that can be baked in the oven at one time.
        /// </summary>
        private int breadstickBatchSize;

        /// <summary>
        /// A value indicating whether or not the oven is in use.
        /// </summary>
        private bool isInUse;

        /// <summary>
        /// The total number of breadsticks that have been baked in the oven.
        /// </summary>
        private int numberOfBreadsticksBaked;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="breadstickBatchSize">The number of breadsticks that can be baked in the oven at one time.</param>
        public Oven(int breadstickBatchSize)
        {
            this.breadstickBatchSize = breadstickBatchSize;
        }

        /// <summary>
        /// Gets a value indicating whether or not the oven is in use.
        /// </summary>
        public bool IsInUse
        {
            get
            {
                return this.isInUse;
            }
        }

        /// <summary>
        /// Gets or sets the total number of breadsticks that have been baked in the oven.
        /// </summary>
        public int NumberOfBreadsticksBaked
        {
            get
            {
                return this.numberOfBreadsticksBaked;
            }
            set
            {
                this.numberOfBreadsticksBaked = value;
            }
        }

        /// <summary>
        /// Bakes a batch of breadsticks.
        /// </summary>
        /// <returns>The number of breadsticks baked.</returns>
        public int BakeBreadsticks()
        {
            int result = 0;

            // Increase the oven's total number of breadsticks baked by the oven's capacity.
            this.NumberOfBreadsticksBaked += this.breadstickBatchSize;

            // Set result to the number of breadsticks baked in the batch.
            result = this.breadstickBatchSize;

            return result;
        }

        /// <summary>
        /// Turns the oven on.
        /// </summary>
        public void TurnOn()
        {
            this.isInUse = true;
        }

        /// <summary>
        /// Turns the oven off.
        /// </summary>
        public void TurnOff()
        {
            this.isInUse = false;
        }
    }
}