using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantScenario
{
    /// <summary>
    /// The class which is used to represent a cook.
    /// </summary>
    public class Cook
    {
        /// <summary>
        /// The cook's breadbasket.
        /// </summary>
        private Basket breadbasket;

        /// <summary>
        /// The cook's bread oven.
        /// </summary>
        private Oven breadOven;

        /// <summary>
        /// The charity which is to receive the cook's leftover food.
        /// </summary>
        private Charity charity;

        /// <summary>
        /// The cook's gas stove.
        /// </summary>
        private Stove gasStove;

        /// <summary>
        /// The cook's name.
        /// </summary>
        private string name;

        /// <summary>
        /// The total number of menu items the cook has cooked.
        /// </summary>
        private int numberOfMenuItemsCooked;

        /// <summary>
        /// The cook's salary.
        /// </summary>
        private decimal salary;

        /// <summary>
        /// The cook's soup vat.
        /// </summary>
        private Vat soupVat;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="basketBreadstickCapacity">The number of breadsticks the basket can hold.</param>
        /// <param name="charityName">The name of the cook's favorite charity.</param>
        /// <param name="name">The cook's name.</param>
        /// <param name="ovenBreadstickBatchSize">The number of breadsticks that can be made in the oven at one time.</param>
        /// <param name="salary">The cook's salary.</param>
        /// <param name="stoveSoupBatchSize">The amount of soup that can be made on the gas stove at one time.</param>
        /// <param name="vatCapacity">The amount of liquid the vat can hold.</param>
        public Cook(int basketBreadstickCapacity, string charityName, string name, int ovenBreadstickBatchSize, decimal salary, double stoveSoupBatchSize, double vatCapacity)
        {
            this.breadbasket = new Basket(basketBreadstickCapacity);
            this.breadOven = new Oven(ovenBreadstickBatchSize);
            this.charity = new Charity(charityName);
            this.gasStove = new Stove(stoveSoupBatchSize);
            this.name = name;
            this.salary = salary;
            this.soupVat = new Vat(vatCapacity, "Soup");
        }

        /// <summary>
        /// Gets the cook's bread oven.
        /// </summary>
        public Oven BreadOven
        {
            get
            {
                return this.breadOven;
            }
        }

        /// <summary>
        /// Gets the cook's gas stove.
        /// </summary>
        public Stove GasStove
        {
            get
            {
                return this.gasStove;
            }
        }

        /// <summary>
        /// Gets or sets the cook's salary.
        /// </summary>
        public decimal Salary
        {
            get
            {
                return this.salary;
            }
            set
            {
                this.salary = value;
            }
        }

        /// <summary>
        /// Makes breadsticks and soup.
        /// </summary>
        public void MakeBreadsticksAndSoup()
        {
            // If the bread oven is not in use.
            if (this.BreadOven.IsInUse == false)
            {
                // Make the daily beadsticks.
                this.MakeDailyBreadsticks();
            }

            if (this.GasStove.IsInUse == false)
            {
                // Make the daily soup.
                this.MakeDailySoup();
            }
        }

        /// <summary>
        /// Makes a meal.
        /// </summary>
        /// <param name="menuItem">The menu item to make.</param>
        /// <returns>The prepared food item.</returns>
        public FoodItem MakeMeal(MenuItem menuItem)
        {
            FoodItem result;

            // Create a new foodItem.
            result = new FoodItem();

            // Increment the cook's number of items cooked.
            this.numberOfMenuItemsCooked++;

            return result;
        }

        /// <summary>
        /// Makes a batch of breadsticks.
        /// </summary>
        /// <returns>The number of leftover breadsticks.</returns>
        private int MakeBreadsticks()
        {
            // Turn on the bread oven.
            this.breadOven.TurnOn();

            // Mix breadstick dough.
            this.MixBreadstickDough();

            // Roll the breadsticks.
            this.RollBreadsticks();

            // Bake the breadsticks.
            int numberOfBreadsticksMade = this.BreadOven.BakeBreadsticks();

            // Add the breadsticks to the breadbasket.
            int numberOfExtraBreadsticks = this.breadbasket.AddBreadsticks(numberOfBreadsticksMade);

            // Turn off the bread oven.
            this.breadOven.TurnOff();

            // Return the number of breadsticks that didn't fit in the breadbasket.
            return numberOfExtraBreadsticks;
        }

        /// <summary>
        /// Makes enough breadsticks for the day.
        /// </summary>
        private void MakeDailyBreadsticks()
        {
            int numberOfLeftoverBreadsticks = 0;

            // While there is free space in the basket...
            while (this.breadbasket.FreeBreadstickCapacity > 0)
            {
                // Make a batch of breadsticks.
                numberOfLeftoverBreadsticks = this.MakeBreadsticks();
            }

            // If there are any leftover breadsticks...
            if (numberOfLeftoverBreadsticks > 0)
            {
                // Give any extra breadsticks to charity.
                this.charity.TakeLeftoverBreadsticks(numberOfLeftoverBreadsticks);
            }
        }

        /// <summary>
        /// Makes enough soup for the day.
        /// </summary>
        private void MakeDailySoup()
        {
            double leftoverSoup = 0;

            // While there is free space in the vat...
            while (this.soupVat.FreeCapacity > 0)
            {
                // Make a batch of soup.
                leftoverSoup = this.MakeSoup();
            }

            // If there is any leftover soup...
            if (leftoverSoup > 0)
            {
                // Give any leftover soup to charity.
                this.charity.TakeLeftoverSoup(leftoverSoup);
            }
        }

        /// <summary>
        /// Makes a batch of soup.
        /// </summary>
        /// <returns>The amount of leftover soup.</returns>
        private double MakeSoup()
        {
            // Turn on the gas stove.
            this.gasStove.TurnOn();

            // Cook the soup.
            double amountOfSoupMade = this.GasStove.CookSoup();

            // Add the soup to the vat.
            double amountOfExtraSoup = this.soupVat.FillSoup(amountOfSoupMade);

            // Turn off the gas stove.
            this.gasStove.TurnOff();

            // Return the amount of soup that didn't fit in the vat.
            return amountOfExtraSoup;
        }

        /// <summary>
        /// Mixes breadstick dough.
        /// </summary>
        private void MixBreadstickDough()
        {
            // Mix breadstick dough.
        }

        /// <summary>
        /// Rolls breadstick dough into breadsticks.
        /// </summary>
        private void RollBreadsticks()
        {
            // Roll breadstick dough into breadsticks.
        }
    }
}