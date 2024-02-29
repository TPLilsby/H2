using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAroundApp
{
    public abstract class Bird
    {
        public abstract void SetLocation(double longitude, double latitude);
        public abstract void Draw();
    }
}
