using Math = System.Math;

namespace ISP;

public partial class IntegralPage : ContentPage
{
    public IntegralPage()
    {
        InitializeComponent();
    }

    private CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

    private async void OnStartButtonClicked(object sender, EventArgs e)
    {
        progressBar.Progress = 0;
        //StartButton.IsEnabled = false;
        cancelTokenSource?.Cancel();
        cancelTokenSource = new CancellationTokenSource();
        CancellationToken token = cancelTokenSource.Token;
        progressBar.IsEnabled = true;
        Label.Text = "Вычисление";

        try
        {
            double result = await Task.Run(() => CalculateIntegral(token), token);
            Label.Text = result.ToString();
            //StartButton.IsEnabled = true;
        }
        catch (TaskCanceledException)
        {
            Label.Text = "Задание отменено";
        }
    }

    private void OnCancelButtonClicked(object sender, EventArgs e)
    {
        progressBar.Progress = 0;
        Label.Text = "Welcome to .NET MAUI!";
        cancelTokenSource?.Cancel();
        //StartButton.IsEnabled = true;
    }

    private double CalculateIntegral(CancellationToken token)
    {
        int progress = 0;
        int lastProgress = 0;
        double result = 0;
        const double step = 0.00000001;

        for (double i = 0; i < 1.0; i += step)
        {
            if (token.IsCancellationRequested)
            {
                Console.WriteLine($"Поток № {Thread.CurrentThread.ManagedThreadId} прерван");
                throw new TaskCanceledException();
            }

            result += Math.Sin(i) * step;

            progress = Convert.ToInt32(i / 1.0 * 100);
            if (progress != lastProgress)
            {
                lastProgress = progress;
                ShowProgress(this, progress);
            }
        }

        Console.WriteLine(result);
        return result;
    }

    private void ShowProgress(object sender, int percent)
    {
        double value = percent;
        value /= 100;
        Device.BeginInvokeOnMainThread(() =>
        {
            if (progressBar.Progress < 1)
            {
                progressBar.Progress = value;
            }

            Label.Text = $"{(percent).ToString()} %";
        });
    }
}