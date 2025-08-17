using System.Timers;
using TraficLight.ModelsLogic;

namespace TraficLight.Models
{
    internal abstract class TraficLightModel
    {
        protected bool isAutoChangeLight = false;
        protected System.Timers.Timer timer = new(1000);
        public enum TraficLightState
        {
            Red,
            RedYellow,
            Yellow,
            Green
        }
        protected TraficLightState currentState = TraficLightState.Red;
        protected Light[] lites = [new Light(Colors.Red,true), new Light(Colors.Yellow), new Light(Colors.Green)];
        protected LightImage lightImage = new();
        public enum TraficLight { Red, Yellow, Green }
        public EventHandler<LightChangedEventArgs>? LightChanged;
        public Color RedColor => lites[0].Color;
        public Color YellowColor => lites[1].Color;
        public Color GreenColor => lites[2].Color;
        public abstract string SwitchAutoChangeLightText{ get; }
        public abstract string LightImage{ get; }
        protected abstract void OnTimeElapsed(object? sender, ElapsedEventArgs e);
        public abstract void ChangeLight();
    }
}
