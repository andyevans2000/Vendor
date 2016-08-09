using System.Collections.Generic;

namespace Vend
{
    public interface ICoinProvider
    {
        List<Coin> GetPossibleCoins();
    }
}