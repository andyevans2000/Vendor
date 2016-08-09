namespace Vend
{
    /// <summary>
    /// the result of the customer inserting a coin object into the machine
    /// </summary>
    public class InsertCoinResult: CustomerActionResult
    {
        /// <summary>
        /// the resulting state of the operation
        /// </summary>
        public CoinInsertedPossibleStates State { get; set; }
        
    }
}
