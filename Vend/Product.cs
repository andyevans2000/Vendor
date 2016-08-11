namespace Vend
{
    /// <summary>
    /// represents a product e.g. cola
    /// </summary>
    public class Product
    {
        /// <summary>
        /// monetry cost of the product
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// what is the product type
        /// </summary>
        public ProductType ProductType { get; set; }

        public override string ToString()
        {
            return $"Product {ProductType} Cost {Cost}";
        }
    }

    
}
