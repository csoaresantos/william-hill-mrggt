using System;

namespace MRGGT.Models
{
    public class SaveCustomerResponse : BaseResponse
    {
        public Customer Customer { get; private set; }
        public SaveCustomerResponse(bool success, string message, Customer customer) : base(success, message)
        {
            Customer = customer;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public SaveCustomerResponse(Customer customer) : this(true, string.Empty, customer)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveCustomerResponse(string message) : this(false, message, null)
        { }
    }
}
