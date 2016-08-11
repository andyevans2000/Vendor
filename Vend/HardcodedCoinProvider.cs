using System.Collections.Generic;

namespace Vend
{
    /// <summary>
    /// a simple implemenation of ICoinProvider that uses a hardcoded list of coins - in this case standard US coinage
    /// </summary>
    public class HardcodedCoinProvider : ICoinProvider
    {
        /// <summary>
        /// get a list of all possible coins in the system
        /// </summary>
        /// <returns>the list of coins</returns>
        public List<Coin> GetPossibleCoins()
        {
            return new List<Coin>
            {
                new Coin {Size=19.05,Weight=2.5, Value=0.01m }, //1 cent
                new Coin {Size=21.2,Weight=5, Value=0.05m }, //5 cent
                new Coin {Size=17.91,Weight=2.268, Value=0.1m }, // 10 cent
                new Coin {Size=24.26,Weight=5.67, Value=0.25m }, //25 cent
                new Coin {Size=30.61,Weight=11.34, Value=0.5m }, //50 cent
                new Coin {Size=26.5,Weight=8.1, Value=1m } //1 dollar
            };
        }
    }
}
