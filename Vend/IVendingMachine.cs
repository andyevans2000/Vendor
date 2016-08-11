namespace Vend
{
    /// <summary>
    /// implement this interface to provide a vending machine
    /// </summary>
    public interface IVendingMachine
    {
        /// <summary>
        /// the current money available to the customer
        /// </summary>
        decimal CurrentMoneyAvailable { get; }

        /// <summary>
        /// the current selected product
        /// </summary>
        Product CurrentProduct { get; }

        /// <summary>
        /// the current state of the machine
        /// </summary>
        State CurrentState { get; }

        /// <summary>
        /// the customer inserts a coin object
        /// </summary>
        /// <param name="size">the size of the coin object</param>
        /// <param name="weight">the weight of the coin object</param>
        /// <returns>A result containing an indication of the result and any resulting change</returns>
        InsertCoinResult InsertCoinObject(double size, double weight);

        /// <summary>
        /// the customer chooses to return available change
        /// </summary>
        /// <returns>the amout of change returned</returns>
        decimal ReturnChange();

        /// <summary>
        /// the customer chooses a product
        /// </summary>
        /// <param name="productType">the type of product selected</param>
        /// <returns>A result that also contains any resulting change</returns>
        SelectProductResult SelectProduct(ProductType productType);

        /// <summary>
        /// set the fault state in the machine e.g. after a jam
        /// </summary>
        void SetFault();

        /// <summary>
        /// set the ready state in the machine e.g. after a jam is fioxed
        /// </summary>
        void SetReadyToVend();
    }
}