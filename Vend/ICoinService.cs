namespace Vend
{
    /// <summary>
    /// implement this interface to provide coin info
    /// </summary>
    public interface ICoinService
    {
        Coin GetCoin(double size, double weight);
    }
}