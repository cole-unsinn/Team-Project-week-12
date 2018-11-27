using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooScenario
{
    /// <summary>
    /// The class which is used to represent food.
    /// </summary>
    public class Food
    {
        /// <summary>
        /// The day of the week by which the food should be eaten.
        /// </summary>
        private string bestIfEatenBy;

        /// <summary>
        /// The type of food.
        /// </summary>
        private string type;

        /// <summary>
        /// The weight of the food (in pounds).
        /// </summary>
        private double weight;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="type">The type of food.</param>
        /// <param name="weight">The weight of the food.</param>
        public Food(string type, double weight)
        {
            this.type = type;
            this.weight = weight;

            if (type == "Bone")
            {
                this.bestIfEatenBy = "Friday";
            }
            else if (type == "Earthworms")
            {
                this.bestIfEatenBy = "Tuesday";
            }
            else
            {
                // TODO : Invalid food type
            }
        }

        /// <summary>
        /// Gets the day of the week by which the food should be eaten.
        /// </summary>
        public string BestIfEatenBy
        {
            get
            {
                return this.bestIfEatenBy;
            }
        }

        /// <summary>
        /// Gets the type of food.
        /// </summary>
        public string Type
        {
            get
            {
                return this.type;
            }
        }

        /// <summary>
        /// Gets the weight of the food (in pounds).
        /// </summary>
        public double Weight
        {
            get
            {
                return this.weight;
            }
        }
    }
}