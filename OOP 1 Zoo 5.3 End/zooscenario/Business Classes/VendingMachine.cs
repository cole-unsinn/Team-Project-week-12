using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooScenario
{
    /// <summary>
    /// The class which is used to represent a vending machine.
    /// </summary>
    public class VendingMachine
    {
        /// <summary>
        /// The weight of a single portion of dingo food.
        /// </summary>
        private readonly double dingoFoodPortionWeight = 0.1;

        /// <summary>
        /// The initial amount of money to put into the vending machine.
        /// </summary>
        private readonly decimal initialMoneyBalance = 100m;

        /// <summary>
        /// The weight of a single portion of platypus food.
        /// </summary>
        private readonly double platypusFoodPortionWeight = 0.05;

        /// <summary>
        /// A pre-packaged packet of dingo food which is displayed
        /// to guests, and which will be the next one sold.
        /// </summary>
        private Food dingoFood;

        /// <summary>
        /// The maximum capacity of dingo food (in pounds).
        /// </summary>
        private double dingoFoodMaxStock;

        /// <summary>
        /// The price of a single portion of dingo food.
        /// </summary>
        private decimal dingoFoodPrice;

        /// <summary>
        /// The amount of dingo food currently in stock (in pounds).
        /// </summary>
        private double dingoFoodStock;

        /// <summary>
        /// The amount of money currently in the vending machine.
        /// </summary>
        private decimal moneyBalance;

        /// <summary>
        /// A pre-packaged packet of platypus food which is displayed
        /// to guests, and which will be the next one sold.
        /// </summary>
        private Food platypusFood;

        /// <summary>
        /// The maximum capacity of platypus food (in pounds).
        /// </summary>
        private double platypusFoodMaxStock;

        /// <summary>
        /// The price of a single portion of platypus food.
        /// </summary>
        private decimal platypusFoodPrice;

        /// <summary>
        /// The amount of platypus food currently in stock (in pounds).
        /// </summary>
        private double platypusFoodStock;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="dingoFoodPrice">The price of a dingo food packet.</param>
        /// <param name="platypusFoodPrice">The price of a platypus food packet.</param>
        public VendingMachine(decimal dingoFoodPrice, decimal platypusFoodPrice)
        {
            this.dingoFood = new Food("Bone", this.dingoFoodPortionWeight);
            this.dingoFoodMaxStock = 20;
            this.dingoFoodPrice = dingoFoodPrice;
            this.dingoFoodStock = this.dingoFoodMaxStock;
            this.moneyBalance = this.initialMoneyBalance;
            this.platypusFood = new Food("Earthworms", this.platypusFoodPortionWeight);
            this.platypusFoodMaxStock = 17;
            this.platypusFoodPrice = platypusFoodPrice;
            this.platypusFoodStock = this.platypusFoodMaxStock;
        }

        /// <summary>
        /// Gets the price of a single portion of dingo food.
        /// </summary>
        public decimal DingoFoodPrice
        {
            get
            {
                return this.dingoFoodPrice;
            }
        }

        /// <summary>
        /// Gets the amount of money currently in the vending machine.
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                return this.moneyBalance;
            }
        }

        /// <summary>
        /// Gets the price of a single portion of platypus food.
        /// </summary>
        public decimal PlatypusFoodPrice
        {
            get
            {
                return this.platypusFoodPrice;
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not dingo food is available.
        /// </summary>
        private bool IsDingoFoodAvailable
        {
            get
            {
                // Define and intialize result variable.
                bool result = false;

                if (this.dingoFoodStock >= this.dingoFoodPortionWeight)
                {
                    result = true;
                }

                // Return result.
                return result;
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not platypus food is available.
        /// </summary>
        private bool IsPlatypusFoodAvailable
        {
            get
            {
                // Define and intialize result variable.
                bool result = false;

                if (this.platypusFoodStock >= this.platypusFoodPortionWeight)
                {
                    result = true;
                }

                // Return result.
                return result;
            }
        }

        /// <summary>
        /// Buys a portion of food (bone) for a dingo.
        /// </summary>
        /// <param name="payment">The payment for the dingo food.</param>
        /// <returns>A portion of dingo food.</returns>
        public Food BuyDingoFood(decimal payment)
        {
            // Define and intialize result variable.
            Food result = null;

            // Get the pre-built dingo food packet.
            result = this.dingoFood;

            // Empty food holder.
            this.dingoFood = null;

            // Add money to the money box.
            this.AddMoney(payment);

            // Build the next packet of dingo food.
            this.dingoFood = this.BuildDingoFoodPacket();

            // Return the pre-built packet.
            return result;
        }

        /// <summary>
        /// Buys a portion of food (earthworms) for a platypus.
        /// </summary>
        /// <param name="payment">The payment for the platypus food.</param>
        /// <returns>A portion of platypus food.</returns>
        public Food BuyPlatypusFood(decimal payment)
        {
            // Define and intialize result variable.
            Food result = null;

            // Get the pre-built platypus food packet.
            result = this.platypusFood;

            // Empty food holder.
            this.platypusFood = null;

            // Add money to the money box.
            this.AddMoney(payment);

            // Build the next packet of platypus food.
            this.platypusFood = this.BuildPlatypusFoodPacket();

            // Return the pre-built packet.
            return result;
        }

        /// <summary>
        /// Gets the price of a portion of food for the specified animal type.
        /// </summary>
        /// <param name="animalType">The type of animal for which to return the food price.</param>
        /// <returns>The price of food for the specified animal type.</returns>
        public decimal LookupFoodPrice(string animalType)
        {
            // Define and intialize result variable.
            decimal result = 0;

            if (animalType == "Dingo")
            {
                result = this.DingoFoodPrice;
            }
            else if (animalType == "Platypus")
            {
                result = this.PlatypusFoodPrice;
            }
            else
            {
                // TODO: Handle unsupported animal type.
                result = 0;
            }

            // Return result.
            return result;
        }

        /// <summary>
        /// Adds money to the vending machine's money box.
        /// </summary>
        /// <param name="amountToAdd">The amount of money to add.</param>
        private void AddMoney(decimal amountToAdd)
        {
            // Add the passed-in amount of money to the money balance.
            this.moneyBalance += amountToAdd;
        }

        /// <summary>
        /// Builds the next dingo food packet for sale.
        /// </summary>
        /// <returns>The next dingo food packet for sale.</returns>
        private Food BuildDingoFoodPacket()
        {
            // Define and intialize result variable.
            Food result = null;

            // Check if there is food available.
            bool isFoodAvailable = this.IsDingoFoodAvailable;

            // If food is available...
            if (isFoodAvailable)
            {
                // Create an instance of the Food class.
                result = new Food("Bone", this.dingoFoodPortionWeight);

                // Remove food from stock.
                this.dingoFoodStock -= result.Weight;
            }

            // Return the newly-built packet.
            return result;
        }

        /// <summary>
        /// Builds the next platypus food packet for sale.
        /// </summary>
        /// <returns>The next platypus food packet for sale.</returns>
        private Food BuildPlatypusFoodPacket()
        {
            // Define and intialize result variable.
            Food result = null;

            // Check if there is food available.
            bool isFoodAvailable = this.IsPlatypusFoodAvailable;

            // If food is available...
            if (isFoodAvailable)
            {
                // Create an instance of the Food class.
                result = new Food("Earthworms", this.platypusFoodPortionWeight);

                // Remove food from stock.
                this.platypusFoodStock -= result.Weight;
            }

            // Return the newly-built packet.
            return result;
        }
    }
}