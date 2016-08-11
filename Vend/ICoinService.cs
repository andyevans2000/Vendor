namespace Vend
{
    /// <summary>
    /// implement this interface to provide coin info
    /// </summary>
    public interface ICoinService
    {
        /// <summary>
        /// get a coin object for an inserted object of a given size and weight
        /// </summary>
        /// <param name="size">the size of the object</param>
        /// <param name="weight">the weight of the object</param>
        /// <returns>The matched coin (if it does match)</returns>
        Coin GetCoin(double size, double weight);
    }
}