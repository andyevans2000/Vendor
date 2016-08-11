using System.Collections.Generic;

namespace Vend
{
    /// <summary>
    /// implement this interface to get coin data
    /// </summary>
    public interface ICoinProvider
    {
        /// <summary>
        /// get possible coins
        /// </summary>
        /// <returns></returns>
        List<Coin> GetPossibleCoins();
    }
}