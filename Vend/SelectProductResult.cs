namespace Vend
{
    /// <summary>
    /// the result of selecting a product in the vending machine
    /// </summary>
    public class SelectProductResult:CustomerActionResult
    {
        /// <summary>
        /// the state e.g. 'Purchased'
        /// </summary>
        public ProductSelectedPossibleStates State { get; set; }
    }
}
