using System.Collections.Generic;

namespace Vend
{
    /// <summary>
    /// a simple implemenation of IProductProvider that uses a hardcoded list of products
    /// </summary>
    public class HardcodedProductProvider : IProductProvider
    {
        /// <summary>
        /// Get the list of possible products
        /// </summary>
        /// <returns>the list of products</returns>
        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product {Cost=1m,ProductType=ProductType.Cola },
                new Product {Cost=0.5m,ProductType=ProductType.Chips },
                new Product {Cost=0.65m,ProductType=ProductType.Candy},
            };
        }
    }
}
