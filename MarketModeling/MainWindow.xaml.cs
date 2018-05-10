using System;
using System.Windows;

namespace MarketModeling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonCalculate_OnClick(object sender, RoutedEventArgs e)
        {
            var sharePrice = double.Parse(TextBoxSharePrice.Text);

            var quantity = int.Parse(TextBoxQuantity.Text);

            var investeded = (sharePrice * quantity);

            var tradeCost = double.Parse(TextBoxTradeCost.Text);

            TextBoxInvested.Text = Math.Round(investeded, 2, MidpointRounding.AwayFromZero).ToString();

            var stamp = investeded * .005;

            TextBoxStamp.Text = Math.Round(stamp, 2, MidpointRounding.AwayFromZero).ToString();

            var totalBuyingTradeCost = investeded + tradeCost + stamp;

            TextBoxTotal.Text = Math.Round(totalBuyingTradeCost, 2, MidpointRounding.AwayFromZero).ToString();

            var divPerShare = double.Parse(TextBoxDiv.Text);

            var totalDiv = divPerShare * quantity;

            TextBoxDivTotal.Text = totalDiv.ToString();

            var sellPrice = double.Parse(TextBoxSellPrice.Text);

            var profitLoss = sellPrice * quantity;

            TextBoxTradeSaleOfShares.ToolTip = sellPrice +  " * " + quantity + " (sell price * no. of shares)";
            TextBoxTradeSaleOfShares.Text = Math.Round(profitLoss, 2, MidpointRounding.AwayFromZero).ToString(); ;

            var tradeCostSell = double.Parse(TextBoxTradeCostSale.Text);
           
            var totalCapitalProfitLoss = profitLoss - investeded;

            TextBoxTotalCapitalProfLoss.ToolTip = profitLoss + " - " + investeded + " (Profit/Loss - Invested)";
            TextBoxTotalCapitalProfLoss.Text = Math.Round(totalCapitalProfitLoss, 2, MidpointRounding.AwayFromZero).ToString();

            TextBoxProfLoss.ToolTip = totalCapitalProfitLoss + "+" + totalDiv + " ((Profit/Loss - Invested) + Div)";
            TextBoxProfLoss.Text = Math.Round((totalCapitalProfitLoss + totalDiv), 2, MidpointRounding.AwayFromZero).ToString();

            var totalCost = tradeCost + tradeCostSell + stamp;

            TextBoxTotalSaleCost .Text = Math.Round(totalCost, 2, MidpointRounding.AwayFromZero).ToString();

            var minusAllExpenses = (profitLoss - totalCost);

            TextBoxTotalAfterSaleAndCharges.Text = Math.Round(minusAllExpenses, 2, MidpointRounding.AwayFromZero).ToString();


            var totalProfitLoss = minusAllExpenses - investeded + totalDiv;

            TextBoxTotalProfitLoss.Text = Math.Round(totalProfitLoss, 2, MidpointRounding.AwayFromZero).ToString();


            var totalBuyingSellingTradeCost = totalBuyingTradeCost + 8;

            TextBoxTotalBuyingSellingCosts.Text = Math.Round(totalBuyingSellingTradeCost, 2, MidpointRounding.AwayFromZero).ToString();

            var sharePriceBreakEven = (totalBuyingSellingTradeCost - totalDiv) / quantity;

            TextBoxSharePriceBreakEven.Text = Math.Round(sharePriceBreakEven, 6, MidpointRounding.AwayFromZero).ToString();

            TextBoxTotalBuyingSellingCostByShare.Text = Math.Round(totalBuyingSellingTradeCost / quantity, 6, MidpointRounding.AwayFromZero).ToString();

            var taxRate = .075;

            var divTax = (totalDiv - totalCost) * taxRate;

            LabelTaxPayableOnDiv.Content = "Tax Payable On Div (" + (taxRate * 100) + "%)";

            TextBoxShareTaxPayableOnDiv.Text = Math.Round(divTax, 2, MidpointRounding.AwayFromZero).ToString();

            var sharePriceBreakEvenWithTax = ((totalBuyingSellingTradeCost + divTax) - totalDiv) / quantity;

            TextBoxSharePriceBreakEvenWithTax.Text = Math.Round(sharePriceBreakEvenWithTax, 5, MidpointRounding.AwayFromZero).ToString();


            LabelDivPerShare.Content = "Div Per Share (" + Math.Round(divPerShare / sharePrice * 100, 2, MidpointRounding.AwayFromZero) + "%)";

            var lossAllowedInPence = sharePrice - sharePriceBreakEvenWithTax;

            var sharePriceBreakevenTaxPercentage = (sharePrice - sharePriceBreakEvenWithTax) / sharePrice;

            LabelSharePriceBreakdownIncTax.Content = "SP Breakeven Inc Tax (" + Math.Round(sharePriceBreakevenTaxPercentage * 100, 2, MidpointRounding.AwayFromZero) 
                                                    + "% " + " - £" + Math.Round(lossAllowedInPence, 4, MidpointRounding.AwayFromZero) + " )";

            TextBoxTotalTaxProfitLoss.Text = Math.Round(0 - divTax + totalProfitLoss, 2, MidpointRounding.AwayFromZero).ToString();
        }

    }

}
