using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooScenario
{
    /// <summary>
    /// The class which is used to represent a wallet.
    /// </summary>
    public class Wallet
    {
        /// <summary>
        /// The color of the wallet.
        /// </summary>
        private string color;

        /// <summary>
        /// The amount of money currently contained within the wallet.
        /// </summary>
        private decimal moneyBalance;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="color">The color of the wallet.</param>
        /// <param name="moneyBalance">The initial amount of money in the wallet.</param>
        public Wallet(string color, decimal moneyBalance)
        {
            this.color = color;
            this.moneyBalance = moneyBalance;
        }

        /// <summary>
        /// Gets the color of the wallet.
        /// </summary>
        public string Color
        {
            get
            {
                return this.color;
            }
        }

        /// <summary>
        /// Gets the amount of money currently contained within the wallet.
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                return this.moneyBalance;
            }
        }

        /// <summary>
        /// Adds money to the wallet.
        /// </summary>
        /// <param name="amountToAdd">The amount of money to add.</param>
        public void AddMoney(decimal amountToAdd)
        {
            this.moneyBalance += amountToAdd;
        }

        /// <summary>
        /// Removes a specified amount of money from the wallet.
        /// </summary>
        /// <param name="amountToRemove">The amount of money to remove from the wallet.</param>
        /// <returns>The amount of money that was removed from the wallet.</returns>
        public decimal RemoveMoney(decimal amountToRemove)
        {
            // Define and initialize a result variable.
            decimal result = 0m;

            // If there is enough money in the wallet...
            if (this.MoneyBalance >= amountToRemove)
            {
                // Return the requested amount.
                result = amountToRemove;
            }
            else
            {
                // Return all that is left.
                result = this.MoneyBalance;
            }

            // Subtract the amount of money returned from the wallet.
            this.moneyBalance -= result;

            // Return result.
            return result;
        }
    }
}