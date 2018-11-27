using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    class Meal:FoodItem
    {

        /// <summary>
        /// The Meat Method
        /// </summary>
        public void Meat()
        {

        }

        /// <summary>
        /// The Prepare Over ride Method
        /// </summary>
        public override void Prepare()
        {
            Plate();
            base.Prepare();
        }
        
        /// <summary>
        /// The Plate Method
        /// </summary>
        private void Plate()
        {

        }
    }
}
