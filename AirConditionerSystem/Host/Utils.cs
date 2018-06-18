using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Host
{
    class Utils
    {
        public static Image getRuningImage(ServiceMode mode, ESpeed speed)
        {
            if (mode == ServiceMode.HOT)
            {
                switch (speed)
                {
                    case ESpeed.NoWind:
                        return Properties.Resources.H0;
                    case ESpeed.Small:
                        return Properties.Resources.H1;
                    case ESpeed.Mid:
                        return Properties.Resources.H2;
                    case ESpeed.Large:
                        return Properties.Resources.H3;
                    default:
                        return Properties.Resources.C3;

                }
            }
            else
            {
                switch (speed)
                {
                    case ESpeed.NoWind:
                        return Properties.Resources.C0;
                    case ESpeed.Small:
                        return Properties.Resources.C1;
                    case ESpeed.Mid:
                        return Properties.Resources.C2;
                    case ESpeed.Large:
                        return Properties.Resources.C3;
                    default:
                        return Properties.Resources.C3;
                }
            }
        }
    }
}
