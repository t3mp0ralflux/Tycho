namespace TRMDataManager.Library.Models
{
    public class ProductModel
    {
        /// <summary>
        /// The unique identifier for a given product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the given product.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// A brief description of the product.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The retail price of the given product.
        /// </summary>
        public decimal RetailPrice { get; set; }

        /// <summary>
        /// How many are left in stock.
        /// </summary>
        public int QuantityInStock { get; set; }
    }
}