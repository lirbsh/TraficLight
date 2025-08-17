using System.Timers;
using TraficLight.Models;

namespace TraficLight.ModelsLogic
{
    internal class TraficLight : TraficLightModel
    {
        public override string SwitchAutoChangeLightText => isAutoChangeLight ? Strings.StopAutoChange : Strings.StartAutoChange;
        public TraficLight()
        {
            timer.Elapsed += OnTimeElapsed;
        }
        protected override void OnTimeElapsed(object? sender, ElapsedEventArgs e)
        {
            ChangeLight();
        }

        public override void ChangeLight()
        {
            if(currentState == TraficLightState.Red)
            {
                currentState = TraficLightState.RedYellow;
                lites[(int)TraficLightModel.TraficLight.Yellow].IsOn = true;
                LightChanged?.Invoke(this, new LightChangedEventArgs(TraficLightModel.TraficLight.Yellow));
            }
            else if (currentState == TraficLightState.RedYellow)
            {
                currentState = TraficLightState.Green;
                lites[(int)TraficLightModel.TraficLight.Red].IsOn = false;
                lites[(int)TraficLightModel.TraficLight.Yellow].IsOn = false;
                lites[(int)TraficLightModel.TraficLight.Green].IsOn = true;
                for (int i = 0; i < 3; i++)
                    LightChanged?.Invoke(this, new LightChangedEventArgs((TraficLightModel.TraficLight)i));
            }
            else if (currentState == TraficLightState.Green)
            {
                currentState = TraficLightState.Yellow;
                lites[(int)TraficLightModel.TraficLight.Red].IsOn = false;
                lites[(int)TraficLightModel.TraficLight.Yellow].IsOn = true;
                lites[(int)TraficLightModel.TraficLight.Green].IsOn = false;
                for (int i = 0; i < 3; i++)
                    LightChanged?.Invoke(this, new LightChangedEventArgs((TraficLightModel.TraficLight)i));
            }  
            else if (currentState == TraficLightState.Yellow)
            {
                currentState = TraficLightState.Red;
                lites[(int)TraficLightModel.TraficLight.Red].IsOn = true;
                lites[(int)TraficLightModel.TraficLight.Yellow].IsOn = false;
                for (int i = 0; i < 2; i++)
                    LightChanged?.Invoke(this, new LightChangedEventArgs((TraficLightModel.TraficLight)i));
            }
        }
        internal void SwitchAutoChangeLight()
        {
            if (isAutoChangeLight)
                timer.Stop();
            else
                timer.Start();
            isAutoChangeLight = !isAutoChangeLight;
        }
    }
}
