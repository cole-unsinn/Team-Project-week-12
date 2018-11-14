using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooScenario
{
    /// <summary>
    /// The class which is used to represent an employee.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// The number of animals the employee has delivered.
        /// </summary>
        private int animalDeliveryCount;

        /// <summary>
        /// The name of the employee.
        /// </summary>
        private string name;

        /// <summary>
        /// The employee's identification number.
        /// </summary>
        private int number;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="name">The employee's name.</param>
        /// <param name="number">The employee's number.</param>
        public Employee(string name, int number)
        {
            this.name = name;
            this.number = number;
        }

        /// <summary>
        /// Gets the number of animals the employee has delivered.
        /// </summary>
        public int AnimalDeliveryCount
        {
            get
            {
                return this.animalDeliveryCount;
            }
        }

        /// <summary>
        /// Gets the name of the employee.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets the employee's identification number.
        /// </summary>
        public int Number
        {
            get
            {
                return this.number;
            }
        }

        /// <summary>
        /// Aids the specified mother animal in delivering her baby.
        /// </summary>
        /// <param name="mother">The mother animal.</param>
        /// <returns>The new baby animal.</returns>
        public Animal DeliverAnimal(Animal mother)
        {
            // Define and initialize a result variable.
            Animal result = null;

            // Sterilize birthing area before delivering animal.
            this.SterilizeBirthingArea();

            // Aid the mother animal in reproducing.
            result = mother.Reproduce();

            // Wash up birthing area after delivering animal.
            this.WashUpBirthingArea();

            // Increment delivery count.
            this.animalDeliveryCount++;

            // Return result.
            return result;
        }

        /// <summary>
        /// Sterilizes the birthing area in preparation for delivering a baby animal.
        /// </summary>
        private void SterilizeBirthingArea()
        {
            // Sterilize the birthing area.
        }

        /// <summary>
        /// Washes up the birthing area after having delivered a baby animal.
        /// </summary>
        private void WashUpBirthingArea()
        {
            // Wash up the birthing area.
        }
    }
}