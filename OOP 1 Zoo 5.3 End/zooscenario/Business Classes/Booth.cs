using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooScenario
{
    /// <summary>
    /// The class which is used to represent a ticket booth.
    /// </summary>
    public class Booth
    {
        /// <summary>
        /// The starting money balance of the booth.
        /// </summary>
        private readonly decimal initialMoneyBalance = 100m;

        /// <summary>
        /// The booth attendant.
        /// </summary>
        private Employee attendant;

        /// <summary>
        /// The amount of money currently in the ticket booth.
        /// </summary>
        private decimal moneyBalance;

        /// <summary>
        /// The number of tickets sold.
        /// </summary>
        private int ticketCountSold;

        /// <summary>
        /// The price of a ticket.
        /// </summary>
        private decimal ticketPrice;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="attendant">The booth's attendant.</param>
        /// <param name="ticketPrice">The price of a ticket.</param>
        public Booth(Employee attendant, decimal ticketPrice)
        {
            this.attendant = attendant;
            this.moneyBalance = this.initialMoneyBalance;
            this.ticketCountSold = 0;
            this.ticketPrice = ticketPrice;
        }

        /// <summary>
        /// Gets the number of tickets sold
        /// </summary>
        public int TicketCountSold
        {
            get
            {
                return this.ticketCountSold;
            }
        }
    }
}