using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    class CookedMeal:Meal
    {
        /// <summary>
        /// The CookMeal Method
        /// </summary>
        public void cookedMeal()
        {

        }


        /// <summary>
        /// The Override Prepare Method
        /// </summary>
        public override void Prepare()
        {
            Cook();
            base.Prepare();
        }


        /// <summary>
        /// The Virtual Cook Method
        /// </summary>
        public virtual void Cook()
        {

        }
    }
}
