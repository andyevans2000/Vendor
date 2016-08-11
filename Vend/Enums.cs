namespace Vend
{
    /// <summary>
    /// possible results when a coin is inserted into the vending machine
    /// </summary>
    public enum CoinInsertedPossibleStates
    {
        NotAValidCoin,
        PurchaseMade,
        NoProductSelected,
        Fault,
        NeedMoreMoney
    }

    /// <summary>
    /// possible results when a product is selected
    /// </summary>
    public enum ProductSelectedPossibleStates
    {
        Fault,
        PurchaseMade,
        NeedMoreMoney
    }

    /// <summary>
    /// possible states of the vending machine
    /// </summary>
    public enum State
    {
        Ready,
        Fault
    }

    /// <summary>
    /// possible product types
    /// </summary>
    public enum ProductType
    {
        Cola, Chips, Candy
    }
}
