using System.Collections.Generic;

namespace Vend
{
    /// <summary>
    /// implement this interface to provide a list of valid products
    /// </summary>
    public interface IProductProvider
    {
        List<Product> GetProducts();
    }
}