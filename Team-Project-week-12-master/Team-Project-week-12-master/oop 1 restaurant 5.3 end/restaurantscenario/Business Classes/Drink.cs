using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    class Drink:FoodItem
    {

        /// <summary>
        /// The Drink Method
        /// </summary>
        public void drink()
        {

        }

        /// <summary>
        /// The Over ride prepare method
        /// </summary>
        public override void Prepare()
        {
            Pour();
            base.Prepare();
        }

        /// <summary>
        /// The Pour Method
        /// </summary>
        private void Pour()
        {

        }
    }
}
