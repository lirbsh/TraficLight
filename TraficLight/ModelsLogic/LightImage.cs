using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraficLight.Models;

namespace TraficLight.ModelsLogic
{
    class LightImage : LightImageModel
    {
        public override string GetImage(TraficLightModel.TraficLightState state)
        {
            return images[(int)state];
        }
    }
}
