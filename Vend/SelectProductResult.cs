namespace Vend
{
    /// <summary>
    /// the result of selecting a product in the vending machine
    /// </summary>
    public class SelectProductResult:CustomerActionResult
    {
        public ProductSelectedPossibleStates State { get; set; }
    }
}
