using ISP.Services;
using ISP.Entities;
using System.Diagnostics;

namespace ISP;

public partial class CurrencyConverterPage : ContentPage
{
    private IRateService rateServise;

    public CurrencyConverterPage(IRateService rate)
    {
        rateServise = rate;
        InitializeComponent();
        DatePick.MaximumDate = DateTime.Now;
    }

    private async void OnDateSelected(object sender, EventArgs e)
    {
        var buff = rateServise.GetRates(DatePick.Date);
        IEnumerable<Rate> buff_ = await buff;
        var allRates = buff_.ToList();
        List<Rate> rates = new();
        foreach (var rate in allRates)
        {
            rates.Add(rate);
            Debug.WriteLine(rate.Cur_Name);
        }

        CurrencyPicker.ItemsSource = rates;
    }

    private void OnCurrencySelected(object sender, EventArgs e)
    {
        var selectedCurrency = CurrencyPicker.SelectedItem as Rate;
        if (selectedCurrency != null)
        {
            ForCurrencyLabel.Text = selectedCurrency.Cur_OfficialRate.ToString();
            BelCurrencyLabel.Text = (1 / float.Parse(ForCurrencyLabel.Text)).ToString();
        }
    }
}