using System;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;
using UrhoCharts.Forms.Example.Models;


namespace UrhoCharts.Forms.Example.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private SurfaceChart _sampleChart;
        public SurfaceChart SampleChart
        {
            get => _sampleChart;
            set => SetProperty(ref _sampleChart, value);
        }

        public ICommand ReloadCommand { get; private set; }

        private readonly ChartSamples _samples = new ChartSamples();

        public MainPageViewModel()
        {
            //SampleChart = _samples.Sample1;

            ReloadCommand = new Command(Reload);
        }

        private void Reload()
        {
            if (SampleChart?.Equals(_samples.Sample1) == true)
            {
                SampleChart = _samples.Sample2;
            }
            else
            {
                SampleChart = _samples.Sample1;
            }
        }
    }
}
