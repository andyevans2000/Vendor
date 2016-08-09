namespace Vend
{
    public interface IVendingMachine
    {
        decimal CurrentMoneyAvailable { get; }
        Product CurrentProduct { get; }
        State CurrentState { get; }

        InsertCoinResult InsertCoinObject(double size, double weight);
        decimal ReturnChange();
        SelectProductResult SelectProduct(ProductType productType);
        void SetFault();
        void SetReadyToVend();
    }
}