using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Models;

namespace WpfApp2.Utils
{
    public static class ImageByState
    {
        public static String GetImage(State state)
        {
            String result = "";

            switch (state)
            {
                case State.SHIP:
                    result = "BB61_USS_Iowa_BB61_broadside_USN.jpg";
                    break;
                case State.WATER:
                    result = "water.jpg";
                    break;
                case State.FIRED_SHIP:
                    result = "battleship_003.jpg";
                    break;
                case State.FIRED_WATER:
                    result = "stopSign.png";
                    break;
                case State.RETRY:
                    result = "";
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
