using System.Collections.Generic;

namespace Vend
{
    /// <summary>
    /// implement this interface to provide a list of valid products
    /// </summary>
    public interface IProductProvider
    {
        /// <summary>
        /// get possible products
        /// </summary>
        /// <returns></returns>
        List<Product> GetProducts();
    }
}