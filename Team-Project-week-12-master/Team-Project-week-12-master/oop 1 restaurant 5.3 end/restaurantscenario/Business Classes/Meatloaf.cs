using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    class Meatloaf:CookedMeal
    {

        /// <summary>
        /// The MeatLoaf Method
        /// </summary>
        public void meatloaf()
        {

        }


        /// <summary>
        /// The Override Void cook Method
        /// </summary>
        public override void Cook()
        {
            Grill();
            base.Cook();
        }

        /// <summary>
        /// The Grill Method
        /// </summary>
        private void Grill()
        {

        }
    }
}
