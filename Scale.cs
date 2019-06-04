using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiimoteLib;

namespace WiiBalanceScale
{
    public class Scale
    {
        private float calibration = 0.0f;

        public void Calibrate(Wiimote board)
        {
            calibration = board.WiimoteState.BalanceBoardState.WeightKg;
        }

        public float GetWeight(Wiimote board)
        {
            return board.WiimoteState.BalanceBoardState.WeightKg - calibration;
        }
        
    }
}
