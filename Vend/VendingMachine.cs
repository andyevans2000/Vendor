using log4net;
using System.Linq;

namespace Vend
{
    /// <summary>
    /// represents the vending machine - this is designed to be created as a single, shared instance so it will alwyas be in the correct state
    /// </summary>
    public class VendingMachine : IVendingMachine
    {  
        private readonly ICoinService _coinService;
        private readonly IProductProvider _productProvider;
        private readonly ILog _log;

        /// <summary>
        /// create a new instance of the vending machine
        /// </summary>
        /// <param name="coinService">we a need a instance of ICoinService to give us valid coin info</param>
        /// <param name="productProvider">we need an instance of IProductProvider to give us our product info</param>
        /// <param name="log">we need an instance of ILog to be able to log stuff</param>
        public VendingMachine(ICoinService coinService, IProductProvider productProvider,ILog log)
        {
            _coinService = coinService;
            _productProvider = productProvider;
            _log = log;
            CurrentState = State.Ready;
        }

        /// <summary>
        /// the current state of the machine
        /// </summary>
        public State CurrentState { get; private set; }

        /// <summary>
        /// the currently selected product
        /// </summary>
        public Product CurrentProduct { get; private set; }

        /// <summary>
        /// the money available  (to either make or purchase or get back as change) in the machine
        /// </summary>
        public decimal CurrentMoneyAvailable { get; private set; }

        /// <summary>
        /// choose a product, using a product type
        /// </summary>
        /// <param name="productType">e.g. cola or chips</param>
        /// <returns></returns>
        public SelectProductResult SelectProduct(ProductType productType)
        {
            _log.InfoFormat($"product {productType} selected");
            //do nowt if the machine is in the fault state
            if (CurrentState == State.Fault)
                return new SelectProductResult { State = ProductSelectedPossibleStates.Fault };

            //choose the product based on what was selected
            CurrentProduct = _productProvider.GetProducts()
                .FirstOrDefault(p=>p.ProductType==productType);
            if (CurrentProduct == null)
                return new SelectProductResult {State = ProductSelectedPossibleStates.Fault};
            //if there is enough money in the machine we can dispense the product and return the change
            if (CurrentMoneyAvailable >= CurrentProduct.Cost)
            {
                CurrentMoneyAvailable = CurrentMoneyAvailable - CurrentProduct.Cost;
               
                var change=ReturnChangeInternal();
                _log.InfoFormat($"product {CurrentProduct} purchase made");
                return new SelectProductResult { State = ProductSelectedPossibleStates.PurchaseMade, Change = change };
            }

            //if we are here we need to insert more money
            return new SelectProductResult { State = ProductSelectedPossibleStates.NeedMoreMoney };
        }

        /// <summary>
        /// call this if a fault is fixed, e.g. by a repair guy
        /// </summary>
        public void SetReadyToVend()
        {
            _log.InfoFormat("Ready to vend");
            CurrentState = State.Ready;
            CurrentProduct = null;
        }

        /// <summary>
        /// call this for if the customer hits the return change button
        /// </summary>
        /// <returns></returns>
        public decimal ReturnChange()
        {
            return CurrentState == State.Fault ? 0 : ReturnChangeInternal();
        }

        private decimal ReturnChangeInternal()
        {
            //current product is not set
            CurrentProduct = null;
            //save the money to return temporarily, as  we need to set the main property to 0
            var moneyToReturn = CurrentMoneyAvailable;
            _log.InfoFormat($"{moneyToReturn} Change given");
            CurrentMoneyAvailable = 0;
            return moneyToReturn;
        }

        /// <summary>
        /// call this if a fault is detected - e.g. a jam
        /// </summary>
        public void SetFault()
        {
            _log.ErrorFormat("Machine is at fault");
            CurrentState = State.Fault;
        }

        /// <summary>
        /// insert an object into the coin slot - it may not be a valid coin but it does have a size and a weight
        /// </summary>
        /// <param name="size">The size of the object being inserted</param>
        /// <param name="weight">The weight of the object being inserted</param>
        /// <returns></returns>
        public InsertCoinResult InsertCoinObject(double size, double weight)
        {
            //if the machine is currently in the valut state we probably want to just return the object or tell the customer
            if (CurrentState == State.Fault)
                return new InsertCoinResult { State = CoinInsertedPossibleStates.Fault };

            //we could get odd values, its not a valid coin anyway
            if( size<=0 || weight <= 0)
            {
                _log.WarnFormat($"Strange object inserted with weight {weight} and size {size}");
                return new InsertCoinResult { State = CoinInsertedPossibleStates.NotAValidCoin };
            }

            //use our injected coin service to work out what coin it is (if any)
            var coin=_coinService.GetCoin(size, weight);

            //its not a valid coin, so return the correct result
            if (coin == null)
            {
                _log.WarnFormat($"Unknow coin inserted with weight {weight} and size {size}");
                return new InsertCoinResult { State = CoinInsertedPossibleStates.NotAValidCoin };
            }

            _log.InfoFormat($"{coin} Coin inserted");
            //increment the available money amount
            CurrentMoneyAvailable = CurrentMoneyAvailable + coin.Value;

            //there is no product selected, that is fine because the customer may not have chosen a product yet
            if (CurrentProduct==null)
                return new InsertCoinResult { State = CoinInsertedPossibleStates.NoProductSelected };

            //if we have enough money for the selected product, set the remaining money (change), return the change and dispense the product
            if(CurrentMoneyAvailable>= CurrentProduct.Cost)
            {
                CurrentMoneyAvailable = CurrentMoneyAvailable - CurrentProduct.Cost;
                _log.InfoFormat($"product {CurrentProduct} purchase made");
                var change=ReturnChangeInternal();
                return new InsertCoinResult { State = CoinInsertedPossibleStates.PurchaseMade, Change = change };
            }
            
            //if we are here we need more money to purchase the product
            return new InsertCoinResult { State = CoinInsertedPossibleStates.NeedMoreMoney };
        }
    }
}
