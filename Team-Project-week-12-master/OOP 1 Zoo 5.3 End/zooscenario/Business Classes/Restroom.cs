using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooScenario
{
    /// <summary>
    /// The class which is used to represent a restroom.
    /// </summary>
    public class Restroom
    {
        /// <summary>
        /// The maximum number of people allowed in the restroom at a given time.
        /// </summary>
        private int capacity;

        /// <summary>
        /// The gender of the restroom.
        /// </summary>
        private string gender;

        /// <summary>
        /// A value indicating whether or not the restroom is currently occupied.
        /// </summary>
        private bool isOccupied;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="capacity">The number of people that can be in the restroom at a given time.</param>
        /// <param name="gender">The gender of the restroom.</param>
        public Restroom(int capacity, string gender)
        {
            this.capacity = capacity;
            this.gender = gender;
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the restroom is currently occupied.
        /// </summary>
        public bool IsOccupied
        {
            get
            {
                return this.isOccupied;
            }

            set
            {
                this.isOccupied = value;
            }
        }
    }
}