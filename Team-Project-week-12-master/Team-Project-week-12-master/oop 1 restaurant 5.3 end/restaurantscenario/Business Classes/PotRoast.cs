using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    class PotRoast:CookedMeal
    {

        /// <summary>
        /// The PotRoast Method
        /// </summary>
        public void potRoast()
        {

        }

        /// <summary>
        /// The Cook Method
        /// </summary>
        public override void Cook()
        {
            Bake();
            base.Cook();
        }

        /// <summary>
        /// The Bake Method
        /// </summary>
        private void Bake()
        {

        }
    }
}
