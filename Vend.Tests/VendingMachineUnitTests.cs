using log4net;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace Vend.Tests
{
    /// <summary>
    /// unit test the vending machine
    /// </summary>
    [TestFixture]
    public class VendingMachineUnitTests
    {
        /// <summary>
        /// test that when set the machine to the Fault state the correct things happen, 
        /// like you can't get products out
        /// </summary>
        [Test]
        public void TestSetFault()
        {
            var vendingMachine = new VendingMachine(GetTestCoinService(), Substitute.For<IProductProvider>(), Substitute.For<ILog>());
            //put some money in
            var res = vendingMachine.InsertCoinObject(1, 2);

            //set the fault state
            vendingMachine.SetFault();
            
            //the machine should be in fault
            Assert.AreEqual(State.Fault, vendingMachine.CurrentState);

            //try to insert another coin, should not allow it
            var insertResult=vendingMachine.InsertCoinObject(1, 2);
            Assert.AreEqual(CoinInsertedPossibleStates.Fault, insertResult.State);
            Assert.AreEqual(1, vendingMachine.CurrentMoneyAvailable); //still has the original coin but not the new one

            //try to select a product and test the result
            var selectProductResult = vendingMachine.SelectProduct(ProductType.Candy);
            Assert.AreEqual(ProductSelectedPossibleStates.Fault, selectProductResult.State);

            //try to return change
            var returnedMoney=vendingMachine.ReturnChange();

            //if the machine is in fault we shouldn't get any change
            Assert.AreEqual(0, returnedMoney);

            //reset the state e.g. by a repair man
            vendingMachine.SetReadyToVend();

            //check the state is corerct
            Assert.AreEqual(State.Ready, vendingMachine.CurrentState);
        }
        
        private static IProductProvider GetTestProductProvider()
        {
            //use NSubstitute to mock our injected types 
            var productProvider = Substitute.For<IProductProvider>();
            productProvider.GetProducts()
                .Returns(new List<Product> {
                new Product
                {
                    Cost = 1, ProductType = ProductType.Candy
                },
                new Product
                {
                    Cost = 2,
                    ProductType = ProductType.Chips
                }
            });

            return productProvider;
        }

        /// <summary>
        /// helper method to get a mocked coin service instance
        /// </summary>
        /// <returns></returns>
        private static ICoinService GetTestCoinService()
        {
            var coinService = Substitute.For<ICoinService>();
            coinService.GetCoin(1, 2) //mock the returned value
                .Returns(new Coin { Value = 1 });

            return coinService;
        }

        /// <summary>
        /// tests the scenario where a person selects a product first then adds coins
        /// </summary>
        [Test]
        public void TestSelectProductFirstAndPurchase()
        {
            var vendingMachine = new VendingMachine(GetTestCoinService(), GetTestProductProvider(), Substitute.For<ILog>());
            //set the product
            vendingMachine.SelectProduct(ProductType.Chips);

            //test the select product is correct
            Assert.AreEqual(vendingMachine.CurrentProduct.Cost, 2);
            Assert.AreEqual(vendingMachine.CurrentProduct.ProductType, ProductType.Chips);

            //add some money, but not enough
            var res=vendingMachine.InsertCoinObject(1, 2);
            Assert.AreEqual(1, vendingMachine.CurrentMoneyAvailable);
            Assert.AreEqual(CoinInsertedPossibleStates.NeedMoreMoney, res.State);
            Assert.IsFalse(res.Change.HasValue);

            //add more money, should now be purchased
            res = vendingMachine.InsertCoinObject(1, 2);
            Assert.AreEqual(0, vendingMachine.CurrentMoneyAvailable);
            Assert.AreEqual(CoinInsertedPossibleStates.PurchaseMade, res.State);
            Assert.AreEqual(0, res.Change);
            //and we have no selected product
            Assert.IsNull(vendingMachine.CurrentProduct);
        }

        /// <summary>
        /// tests the scenario where a user puts in money then selects product
        /// </summary>
        [Test]
        public void TestSelectAddMoneyFirstAndPurchase()
        {
            var vendingMachine = new VendingMachine(GetTestCoinService(), GetTestProductProvider(), Substitute.For<ILog>());
            //add money
            var res = vendingMachine.InsertCoinObject(1, 2);
            //check the states
            Assert.AreEqual(1, vendingMachine.CurrentMoneyAvailable);
            Assert.AreEqual(CoinInsertedPossibleStates.NoProductSelected, res.State);
            Assert.IsFalse(res.Change.HasValue);
            res = vendingMachine.InsertCoinObject(1, 2);
            Assert.AreEqual(2, vendingMachine.CurrentMoneyAvailable);
            Assert.AreEqual(CoinInsertedPossibleStates.NoProductSelected, res.State);

            //choose the product and check the state
            var selectProductResult= vendingMachine.SelectProduct(ProductType.Chips);

            Assert.AreEqual(ProductSelectedPossibleStates.PurchaseMade,selectProductResult.State);
            Assert.AreEqual(0, selectProductResult.Change);

            //should now be purchased and we have no money left

            Assert.AreEqual(0, vendingMachine.CurrentMoneyAvailable);
            
            //and we have no selected product
            Assert.IsNull(vendingMachine.CurrentProduct);
        }

        /// <summary>
        /// tests scenario where customer hits the get change button
        /// </summary>
        [Test]
        public void TestGetChange()
        {
            var vendingMachine = new VendingMachine(GetTestCoinService(), GetTestProductProvider(), Substitute.For<ILog>());
            //add 2 coins
            vendingMachine.InsertCoinObject(1, 2);
            vendingMachine.InsertCoinObject(1, 2);

            //check the money is available
            Assert.AreEqual(2, vendingMachine.CurrentMoneyAvailable);
            //return change
            var res=vendingMachine.ReturnChange();
            //check the change
            Assert.AreEqual(2, res);
            //should be no money available
            Assert.AreEqual(0, vendingMachine.CurrentMoneyAvailable);
        }

        /// <summary>
        /// tests adding a non recognised coin
        /// </summary>
        [Test]
        public void TestAddInvalidCoin()
        {
            var vendingMachine = new VendingMachine(GetTestCoinService(), GetTestProductProvider(), Substitute.For<ILog>());
            var res=vendingMachine.InsertCoinObject(3232, 2);
            //check the result
            Assert.AreEqual(CoinInsertedPossibleStates.NotAValidCoin, res.State);
            //should be no money available
            Assert.AreEqual(0, vendingMachine.CurrentMoneyAvailable);
        }

        /// <summary>
        /// tests the scenario where coins weired values (e.g. negative) are used
        /// </summary>
        [Test]
        public void TestAddInvalidCoinBadValues()
        {
            var vendingMachine = new VendingMachine(GetTestCoinService(), GetTestProductProvider(), Substitute.For<ILog>());
            var res = vendingMachine.InsertCoinObject(-3232, 2);
            Assert.AreEqual(CoinInsertedPossibleStates.NotAValidCoin, res.State);
            Assert.AreEqual(0, vendingMachine.CurrentMoneyAvailable);
        }

        /// <summary>
        /// tests the scenario for change being correctly returned after a purchase
        /// </summary>
        [Test]
        public void TestChangeIsGivenAfterPurchase()
        {
            var productProvider = Substitute.For<IProductProvider>();
            productProvider.GetProducts()
                .Returns(new List<Product> {
                new Product
                {
                    Cost = 1.5m, ProductType = ProductType.Candy
                }
            });

            var vendingMachine = new VendingMachine(GetTestCoinService(), productProvider, Substitute.For<ILog>());
            //add money (2)
            vendingMachine.InsertCoinObject(1, 2);
            vendingMachine.InsertCoinObject(1, 2);

            //choose the product and check the state
            var selectProductResult = vendingMachine.SelectProduct(ProductType.Candy);

            Assert.AreEqual(ProductSelectedPossibleStates.PurchaseMade,selectProductResult.State);

            //Product cost 1.5, so we should get 0.5 back
            Assert.AreEqual(0.5m, selectProductResult.Change);
        }
    }
}
