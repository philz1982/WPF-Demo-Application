using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Novacode;

namespace Demo_Application
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

        private void CalculatePrice(object sender, RoutedEventArgs e)
        {
            CalcPrice();

        }

        private void CreateProposal(object sender, RoutedEventArgs e)
        {
            // Create a docx object. Use this object to open template file. Find, specific strings in the
            // template file and replace these strings with objects from the application. Then, the docx
            // object will save the file as a new file.

            CalcPrice();

            string fileNameTemplate = @"C:\DemoApplication\FinalDocs\Demo-Proposal-{0}-{1}.docx";
            string compName = this.compName.Text;
            string outputFileName = string.Format(fileNameTemplate, compName, DateTime.Now.ToString("dd-MMM-yyyy"));
            DocX letter = DocX.Load(@"C:\DemoApplication\TemplateDoc\SampleProposal.docx");
            //Date
            DateTime dt = new DateTime();
            dt.AddDays(90);
            letter.ReplaceText("[date]", dt.ToString("dd-MMM-yyyy"));
            //Replace Financial Data
            letter.ReplaceText("[widCount]", this.widCount.Text);
            letter.ReplaceText("[sell]", this.totalSell.Text);
            letter.ReplaceText("[margin]", this.totalMargin.Text);


            //Replace Customer Data
            letter.ReplaceText("[compName]", this.compName.Text);
            letter.ReplaceText("[projSiteName]", this.projSiteName.Text);
            letter.ReplaceText("[custFName]", this.custFName.Text);
            letter.ReplaceText("[custLName]", this.custLName.Text);
            letter.ReplaceText("[compAdd1]", this.custCity.Text);
            letter.ReplaceText("[custCity]", this.custState.Text);
            letter.ReplaceText("[custState]", this.custState.Text);

            letter.SaveAs(outputFileName);
        }

        private void CalcPrice()
        {
            // Instatiting Objects for Function
            decimal widgetCount = Convert.ToDecimal(this.widCount.Text);
            decimal marginPercentage = Convert.ToDecimal(this.marginPct.Text);
            decimal salesTaxRate = Convert.ToDecimal(this.salesTax.Text);
            double widgetCost = .20;

            //Instatiting Calc Values
            decimal cost = 0;

            // Instatiating Final Objects
            decimal totalSellPrice = 0;
            decimal totalMarginVolume = 0;

            // Widget Count > 100 Widgets = 0.10. Widget <=100 Widget = 0.20

            if (widgetCount > 100)
            {
                widgetCost = .10;
            }

            cost = widgetCount * Convert.ToDecimal(widgetCost);
            totalSellPrice = (cost * (1 + (salesTaxRate * Convert.ToDecimal(.01)))
                / (1 - (marginPercentage * Convert.ToDecimal(.01))));
            totalMarginVolume = totalSellPrice - cost;

            string sellPrice = totalSellPrice.ToString("C");
            string marginPrice = totalMarginVolume.ToString("C");

            totalSell.Text = sellPrice;
            totalMargin.Text = marginPrice;
        }
    }

}
