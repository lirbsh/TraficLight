using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraficLight.Models
{
    abstract class LightImageModel
    {
        protected string[] images = ["thinksmile2.jpg", "thinksmile.jpg","crysmiley.jpg","happeysmile.jpg"];
        public abstract string GetImage(TraficLightModel.TraficLightState state);
    }
}
