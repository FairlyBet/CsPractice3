using System;
using System.Windows.Forms;

namespace CsPractice3
{
    public partial class FractionPresentation : Form
    {
        CommonFraction fraction1 = new CommonFraction();
        CommonFraction fraction2 = new CommonFraction();
        CommonFraction fraction3 = new CommonFraction();

        CommonFraction result = new CommonFraction();

        String taskLine;

        public FractionPresentation()
        {
            InitializeComponent();
        }

        private void CountButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!fraction1.SetValues(Int32.Parse(Num1Box.Text), Int32.Parse(Denom1Box.Text)) ||
                    !fraction2.SetValues(Int32.Parse(Num2Box.Text), Int32.Parse(Denom2Box.Text)) ||
                    !fraction3.SetValues(Int32.Parse(Num3Box.Text), Int32.Parse(Denom3Box.Text)))
                {
                    MessageBox.Show("Denominator mustn't be equaled to 0");
                }
                else
                {
                    fraction1.ReduceFraction();
                    fraction2.ReduceFraction();
                    fraction3.ReduceFraction();

                    result = (fraction1 + fraction2) * (fraction1 - fraction3);

                    taskLine = $"R = (a1/b1 + a2/b2) * (a1/b1 - a3/b3)\nR = ({fraction1} + {fraction2}) * ({fraction1} - {fraction3}) = {result}";

                    taskLine = taskLine.Replace("+ -", "- ");

                    taskLine = taskLine.Replace("- -", "+ ");

                    result.ReverseFraction();

                    taskLine += $"\n1/R = {result}";

                    TaskLabel.Text = taskLine;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}