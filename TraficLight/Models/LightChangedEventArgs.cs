namespace TraficLight.Models
{
    internal class LightChangedEventArgs(TraficLightModel.TraficLight light) : EventArgs
    {
        public TraficLightModel.TraficLight Light { get; } = light;
    }
}
