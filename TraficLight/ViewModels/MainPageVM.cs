using System.Windows.Input;
using TraficLight.Models;

namespace TraficLight.ViewModels
{
    internal class MainPageVM: ObservableObject
    {
        private readonly ModelsLogic.TraficLight traficLight = new();
        public ICommand ChangeLightCommand => new Command(ChangeLight);
        public ICommand AutoChangeCommand => new Command(AutoChangeLight);

        private void AutoChangeLight()
        {
            traficLight.SwitchAutoChangeLight();
            OnPropertyChanged(nameof(SwitchAutoChangeLightText));
        }

        public void ChangeLight()
        {
            traficLight.ChangeLight(); 
        }

        public Color RedColor => traficLight.RedColor;
  
        public Color YellowColor => traficLight.YellowColor;
      
        public Color GreenColor => traficLight.GreenColor;
        public string SwitchAutoChangeLightText => traficLight.SwitchAutoChangeLightText;
        public string LightImage => traficLight.LightImage;
        public MainPageVM()
        {
            traficLight.LightChanged += OnTraficLightChanged;
        }

        private void OnTraficLightChanged(object? sender, LightChangedEventArgs e)
        {
            ColorChanged(e.Light);
        }

        private void ColorChanged(TraficLightModel.TraficLight light)
        {
            switch (light)
            {
                case TraficLightModel.TraficLight.Red:
                    OnPropertyChanged(nameof(RedColor));
                    break;
                case TraficLightModel.TraficLight.Yellow:
                    OnPropertyChanged(nameof(YellowColor));
                    break;
                case TraficLightModel.TraficLight.Green:
                    OnPropertyChanged(nameof(GreenColor));
                    break;
            } 
            OnPropertyChanged(nameof(LightImage));
        }
    }
}
