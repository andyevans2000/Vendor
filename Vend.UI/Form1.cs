using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Vend.UI
{
    /// <summary>
    /// THIS IS A SAMPLE / TEST CLIENT FOR THE VENDING MACHINE
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly IVendingMachine _vendingMachine;
        public Form1(IVendingMachine vendingMachine)
        {
            _vendingMachine = vendingMachine;
            InitializeComponent();
            SetProductButtons(null);
        }

        //CHOOSE COLA
        private void button1_Click(object sender, EventArgs e)
        {
            SetProductButtons(colaButton);
            HandleProductSelected(_vendingMachine.SelectProduct(ProductType.Cola));
        }
        
        private void oneCentButton_Click(object sender, EventArgs e)
        {
            HandleMoneyInserted(_vendingMachine.InsertCoinObject(19.05, 2.5));
        }

        private void UpdateMoney()
        {
            currentMoneyLabel.Text =$"${_vendingMachine.CurrentMoneyAvailable.ToString()}";
        }

        private void HandleMoneyInserted(InsertCoinResult result)
        {
            if (result.State == CoinInsertedPossibleStates.PurchaseMade)
                PurchaseMade();
            else if (result.State == CoinInsertedPossibleStates.NeedMoreMoney)
            {
                infoLabel.Text = $"PRICE - ${_vendingMachine.CurrentProduct.Cost}";
            }
            UpdateMoney();
        }

        private void HandleProductSelected(SelectProductResult result)
        {
            if (result.State == ProductSelectedPossibleStates.PurchaseMade)
                PurchaseMade();
            else if (result.State == ProductSelectedPossibleStates.NeedMoreMoney)
            {
                infoLabel.Text = $"PRICE - ${_vendingMachine.CurrentProduct.Cost}";
                UpdateMoney();
            }
        }

        private void PurchaseMade()
        {
            infoLabel.Text = "THANK YOU - change given";
            infoLabel.Update();
            infoLabel.Refresh();
            
            //normally we don't do this but freeze the app for 5 seconds to simulate dispensing the product and then reset
            Thread.Sleep(5000);
            _vendingMachine.ReturnChange();
            _vendingMachine.SetReadyToVend();
            UpdateMoney();
            infoLabel.Text = "Insert Coin";
            SetProductButtons(null);
        }
        private void fiveCentButton_Click(object sender, EventArgs e)
        {
            HandleMoneyInserted(_vendingMachine.InsertCoinObject(21.2, 5));
        }

        private void tenCentButton_Click(object sender, EventArgs e)
        {
            HandleMoneyInserted(_vendingMachine.InsertCoinObject(17.91, 2.268));
        }

        private void twentyFiveCentButton_Click(object sender, EventArgs e)
        {
            HandleMoneyInserted(_vendingMachine.InsertCoinObject(24.26, 5.67));
        }

        private void fiftyCentButton_Click(object sender, EventArgs e)
        {
            HandleMoneyInserted(_vendingMachine.InsertCoinObject(30.61, 11.34));
        }

        private void oneDollarButton_Click(object sender, EventArgs e)
        {
            HandleMoneyInserted(_vendingMachine.InsertCoinObject(26.5, 8.1));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HandleProductSelected(_vendingMachine.SelectProduct(ProductType.Chips));
            SetProductButtons(chipsButton);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HandleProductSelected(_vendingMachine.SelectProduct(ProductType.Candy));
            SetProductButtons(candyButton);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            infoLabel.Text = $"${ _vendingMachine.ReturnChange()} returned";
            UpdateMoney();
        }

        private void SetProductButtons(Button button)
        {
            candyButton.BackColor = colaButton.BackColor = chipsButton.BackColor = Color.Gray;
            if (button != null)
                button.BackColor = Color.Red;
        }
        
    }
}
