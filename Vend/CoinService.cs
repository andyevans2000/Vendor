using System.Linq;

namespace Vend
{
    /// <summary>
    /// A simple implementation of ICoinService
    /// </summary>
    public class CoinService : ICoinService
    {
        private readonly ICoinProvider _coinProvider;

        /// <summary>
        /// create a new instance of the coin service
        /// </summary>
        /// <param name="coinProvider">we need an instance of ICoinProvider so we can get the coin data we need</param>
        public CoinService(ICoinProvider coinProvider)
        {
            _coinProvider = coinProvider;
        }

        /// <summary>
        /// get a specific coin using its size and weight
        /// </summary>
        /// <param name="size">The size of the inserted coin</param>
        /// <param name="weight">The weight of the inserted coin</param>
        /// <returns></returns>
        public Coin GetCoin(double size, double weight)
        {
            return _coinProvider.GetPossibleCoins()
                .FirstOrDefault(coin => coin.Size == size && coin.Weight == weight);
        }
    }
}
