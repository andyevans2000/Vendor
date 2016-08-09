using System.Linq;

namespace Vend
{
    /// <summary>
    /// A simple implementation of ICoinService
    /// </summary>
    public class CoinService : ICoinService
    {
        private readonly ICoinProvider _coinProvider;

        public CoinService(ICoinProvider coinProvider)
        {
            _coinProvider = coinProvider;
        }

        /// <summary>
        /// get a specific coin using its size and weight
        /// </summary>
        /// <param name="size"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public Coin GetCoin(double size, double weight)
        {
            return _coinProvider.GetPossibleCoins()
                .FirstOrDefault(coin => coin.Size == size && coin.Weight == weight);
        }
    }
}
