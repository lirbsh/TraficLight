using TraficLight.Models;

namespace TraficLight.ModelsLogic
{
    internal class Light(Color color,bool isOn = false) : LightModel(color,isOn)
    {
        public override Color Color => IsOn ? color : Colors.White;
    }
}
