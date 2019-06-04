using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Debug.WriteLine(string.Format("Calibration set {0}", calibration));
        }

        public float GetWeight(Wiimote board)
        {
            var weight = board.WiimoteState.BalanceBoardState.WeightKg;
            var calibratedWeight = weight - calibration; 
            Debug.WriteLine(string.Format("Weight {0}kg (uncalibrated {1}kg)", calibratedWeight, weight));
            return calibratedWeight;
        }
        
    }
}
