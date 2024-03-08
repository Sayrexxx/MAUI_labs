using AngouriMath;
using AngouriMath.Core.Exceptions;

namespace ISP;

public partial class CalculatorPage : ContentPage
{
    public CalculatorPage()
    {
        InitializeComponent();
    }
    private void OnDigitButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string digit = button.Text;

        if (Label.Text == "0" || Label.Text == "-0")
        {
            Label.Text = digit;
        }
        else
        {
            Label.Text += digit;
        }

        buttonClear.Text = "C";
    }

    private void OnClearButtonClicked(object sender, EventArgs e)
    {
        Label.Text = "0";
        buttonClear.Text = "AC";
    }

    private void OnComaButtonClicked(object sender, EventArgs e)
    {
        if (!Label.Text.Contains('.'))
        {
            Label.Text += '.';
        }
    }

    private void OnSignButtonClicked(object sender, EventArgs e)
    {
        if (Label.Text.Length > 0 && Label.Text[0] == '-')
        {
            Label.Text = Label.Text.Remove(0, 1);
        }
        else
        {
            Label.Text = Label.Text.Insert(0, "-");
        }
    }

    private void OnOperatorButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string digit = button.Text;
        Label.Text += digit;
    }

    private void OnTenPowButtonClicked(object sender, EventArgs e)
    {
        double number = double.Parse(Label.Text);
        Label.Text = Math.Pow(10, number).ToString();
    }

    private void OnEqualButtonClicked(object sender, EventArgs e)
    {
        try
        {
            Label.Text = Label.Text.Replace('\u00f7', '/');
            Entity expr = Label.Text.Replace('x', '*');
            double test = (double)expr.EvalNumerical();
            Label.Text = test.ToString();
        }
        catch (NumberCastException)
        {
            Label.Text = "error";
        }
    }

    private void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        if (Label.Text.Length != 0 && Label.Text.Length != 1)
        {
            Label.Text = Label.Text.Remove(Label.Text.Length - 1, 1);
        }
        else
        {
            Label.Text = "0";
        }
    }

    private void OnRationalFunctionButtonClicked(object sender, EventArgs e)
    {
        double number = double.Parse(Label.Text);
        Label.Text = (1 / number).ToString();
    }

    private void OnSquareButtonClicked(object sender, EventArgs e)
    {
        double number = double.Parse(Label.Text);
        Label.Text = (number * number).ToString();
    }

    private void OnSquareRootButtonClicked(object sender, EventArgs e)
    {
        double number = double.Parse(Label.Text);
        Label.Text = (Math.Sqrt(number)).ToString();
    }
}