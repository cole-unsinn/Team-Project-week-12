using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a charity.
    /// </summary>
    public class Charity
    {
        /// <summary>
        /// The name of the charity.
        /// </summary>
        private string name;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="name">The name of the charity.</param>
        public Charity(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Gets the name of the charity.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Takes leftover breadsticks.
        /// </summary>
        /// <param name="numberToAccept">The number of breadsticks to accept.</param>
        public void TakeLeftoverBreadsticks(int numberToAccept)
        {
        }

        /// <summary>
        /// Takes leftover soup.
        /// </summary>
        /// <param name="amountToAccept">The amount of soup (in quarts) to accept.</param>
        public void TakeLeftoverSoup(double amountToAccept)
        {
        }
    }
}