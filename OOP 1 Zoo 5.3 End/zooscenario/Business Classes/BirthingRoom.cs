using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooScenario
{
    /// <summary>
    /// The class which is used to represent a birthing room.
    /// </summary>
    public class BirthingRoom
    {
        /// <summary>
        /// The current temperature of the birthing room.
        /// </summary>
        private double temperature;

        /// <summary>
        /// The employee currently assigned to be the vet of the birthing room.
        /// </summary>
        private Employee vet;

        /// <summary>
        /// Gets or sets the current temperature of the birthing room.
        /// </summary>
        public double Temperature
        {
            get
            {
                return this.temperature;
            }

            set
            {
                this.temperature = value;
            }
        }

        /// <summary>
        /// Gets or sets the employee currently assigned to be the vet of the birthing room.
        /// </summary>
        public Employee Vet
        {
            get
            {
                return this.vet;
            }

            set
            {
                this.vet = value;
            }
        }

        /// <summary>
        /// Births an animal.
        /// </summary>
        /// <param name="mother">The mother animal.</param>
        /// <returns>The baby animal.</returns>
        public Animal BirthAnimal(Animal mother)
        {
            // Define and initialize a result variable.
            Animal result = null;

            // Deliver the animal.
            result = this.Vet.DeliverAnimal(mother);

            // Return result.
            return result;
        }
    }
}