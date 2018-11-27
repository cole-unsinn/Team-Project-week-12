using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooScenario
{
    /// <summary>
    /// The class which is used to represent a guest.
    /// </summary>
    public class Guest
    {
        /// <summary>
        /// The age of the guest.
        /// </summary>
        private int age;

        /// <summary>
        /// The name of the guest.
        /// </summary>
        private string name;

        /// <summary>
        /// The guest's wallet.
        /// </summary>
        private Wallet wallet;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="age">The guest's age.</param>
        /// <param name="moneyBalance">The initial amount of money in the guest's wallet.</param>
        /// <param name="name">The guest's name.</param>
        /// <param name="walletColor">The color of the guest's wallet.</param>
        public Guest(int age, decimal moneyBalance, string name, string walletColor)
        {
            this.age = age;
            this.name = name;
            this.wallet = new Wallet(walletColor, moneyBalance);
        }

        /// <summary>
        /// Gets the age of the guest.
        /// </summary>
        public int Age
        {
            get
            {
                return this.age;
            }
        }

        /// <summary>
        /// Gets the name of the guest.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets the guest's wallet.
        /// </summary>
        public Wallet Wallet
        {
            get
            {
                return this.wallet;
            }
        }

        /// <summary>
        /// Feeds the specified animal.
        /// </summary>
        /// <param name="animal">The animal to feed.</param>
        /// <param name="animalSnackMachine">The vending machine from which to buy animal food.</param>
        public void FeedAnimal(Animal animal, VendingMachine animalSnackMachine)
        {
            // Define a variable to store the food price.
            decimal foodPrice;

            // Set food price.
            foodPrice = animalSnackMachine.LookupFoodPrice(GetType());

            // Define a variable to store the payment.
            decimal cashInHand;

            // Set cash in hand.
            cashInHand = this.Wallet.RemoveMoney(foodPrice);

            if (foodPrice == cashInHand)
            {
                // Define variable to store the food.
                Food food = null;
                
                // TODO: Below here is the changes that I made and text to Cole about.
                if (animal.GetType() == GetType())
                {
                    // Buy dingo food.
                    food = animalSnackMachine.BuyDingoFood(cashInHand);
                }

                if (animal.GetType() == GetType())
                {
                    // Buy platypus food.
                    food = animalSnackMachine.BuyPlatypusFood(cashInHand);
                }

                // Feed the animal.
                animal.Eat(food);
            }
        }

        /// <summary>
        /// Gives a specified amount of money to another guest.
        /// </summary>
        /// <param name="amount">The amount of money to give to the specified guest.</param>
        /// <param name="receiver">The guest that will be receiving the money.</param>
        public void GiveMoney(decimal amount, Guest receiver)
        {
            // If the receiver is not null...
            if (receiver != null)
            {
                // Take money from this guest.
                decimal amountRemoved = this.Wallet.RemoveMoney(amount);

                // Give money to receiver.
                receiver.Wallet.AddMoney(amountRemoved);
            }
        }
    }
}