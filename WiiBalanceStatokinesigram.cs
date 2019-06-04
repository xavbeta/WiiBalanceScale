/*********************************************************************************
WiiBalanceStatokinesigram

MIT License

Copyright (c) 2019 Saverio Delpriori

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
**********************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using WiimoteLib;


[assembly: System.Reflection.AssemblyTitle("WiiBalanceStatokinesigram")]
[assembly: System.Reflection.AssemblyProduct("WiiBalanceStatokinesigram")]
[assembly: System.Reflection.AssemblyVersion("1.0.0.0")]
[assembly: System.Reflection.AssemblyFileVersion("1.0.0.0")]
[assembly: System.Runtime.InteropServices.ComVisible(false)]

namespace WiiBalanceScale
{
    internal class WiiBalanceStatokinesigram
    {

        private WiiBalanceScaleForm f = null;
        private Wiimote bb = null;
        private ConnectionManager cm = null;
        private Timer BoardTimer = null;
        public const int LONG_MEASUREMENT_DURATION = 30;
        public const int SHORT_MEASUREMENT_DURATION = 15;
        private int measurementDuration = LONG_MEASUREMENT_DURATION;
        private int TickNumber = 0;
        private DataWriter writer;
        private IList<Record> data;
        private Scale scale = new Scale();

        [STAThread]
        static void Main(string[] args)
        {
            WiiBalanceStatokinesigram stabilo = new WiiBalanceStatokinesigram();
        }

        public WiiBalanceStatokinesigram()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
                      
            f = new WiiBalanceScaleForm();

            f.boxType.TextChanged += new System.EventHandler(UpdateUI);
            f.boxType.TextChanged += new System.EventHandler(SetExperimentType);
            f.txtName.TextChanged += new System.EventHandler(UpdateUI);
            f.txtHeight.TextChanged += new System.EventHandler(UpdateUI);
            f.txtWeight.TextChanged += new System.EventHandler(UpdateUI);
            f.txtNotes.TextChanged += new System.EventHandler(UpdateUI);
            f.boxSex.TextChanged += new System.EventHandler(UpdateUI);
            f.txtPath.TextChanged += new System.EventHandler(UpdateUI);

            f.txtPath.Text = Environment.ExpandEnvironmentVariables("%userprofile%"); //default path

            f.btnReset.Click += new System.EventHandler(Reset_click);

            f.btnStart.Enabled = false;
            f.btnStart.Click += new System.EventHandler(StartTimer_click);

            ConnectBalanceBoard(false);

            if (f == null)
            {
                //connecting required application restart, end this process here
                Shutdown();
                return;
            }

            f.btnZero.Click += BtnZero_Click;
            f.btnScale.Click += BtnWeight_Click;

            Application.Run(f);
            Shutdown();
        }

        private void SetExperimentType(object sender, EventArgs e)
        {
            var box = (ComboBox)sender;
            if (string.IsNullOrWhiteSpace(box.Text)) {
                return;
            }

            measurementDuration = box.Text.Contains("ONE LEG") ? SHORT_MEASUREMENT_DURATION : LONG_MEASUREMENT_DURATION;
            f.countdown.Text = measurementDuration.ToString();
        }

        private void BtnWeight_Click(object sender, EventArgs e)
        {
            if (bb != null)
            {
                f.txtWeight.Text = ((int) scale.GetWeight(bb)).ToString();
            }
        }

        private void BtnZero_Click(object sender, EventArgs e)
        {
            if(bb != null) {
                scale.Calibrate(bb);
            }
        }

        private void Reset_click(object sender, EventArgs e)
        {
            if (BoardTimer != null)
            {
                StopMeasuring();
            }

            f.txtName.Text = "";
            f.boxSex.SelectedIndex = 0;
            f.boxType.SelectedIndex = 0;
            f.txtHeight.Text = "0";
            f.txtWeight.Text = "0";
            f.txtNotes.Text = "";
            f.btnStart.Enabled = false;
        }

        private void StartTimer_click(object sender, EventArgs e)
        {

            if (BoardTimer == null)
            {
                StarMeasuring();

            } else {
                StopMeasuring();
                Debug.WriteLine("Measurement interrupted!");
            }

        }

        private bool validateSubjectData()
        {
            return (!string.IsNullOrWhiteSpace(f.txtName.Text)
                && !string.IsNullOrWhiteSpace(f.txtHeight.Text)
                && !string.IsNullOrWhiteSpace(f.txtWeight.Text)
                && !string.IsNullOrWhiteSpace(f.boxSex.Text)
                && !string.IsNullOrWhiteSpace(f.txtPath.Text));
        }

        private Subject getSubjectData()
        {
            if (validateSubjectData())
            {
                return new Subject
                {
                    Name = f.txtName.Text,
                    Height = f.txtHeight.Text,
                    Weight = f.txtWeight.Text,
                    Notes = f.txtNotes.Text,
                    Sex = f.boxSex.Text,
                    ExperimentType = f.boxType.Text                   
                };
            }

            return null;
        }


        void StarMeasuring()
        {

            writer = new DataWriter(getSubjectData(),f.txtPath.Text);

            f.progressbar.Value = 0;
            f.countdown.Text = LONG_MEASUREMENT_DURATION.ToString();
            TickNumber = 0;

            BoardTimer = new System.Windows.Forms.Timer();
            BoardTimer.Interval = 10;
            BoardTimer.Tick += new System.EventHandler(BoardTimer_Tick);
            BoardTimer.Start();

            f.btnStart.Text = "STOP";
        }

        void StopMeasuring()
        {
            if (writer != null && data != null) {
                writer.Log(data);
            }

            f.progressbar.Value = 0;
            f.countdown.Text = LONG_MEASUREMENT_DURATION.ToString();
            TickNumber = 0;

            BoardTimer.Stop();
            BoardTimer.Dispose();
            BoardTimer = null;
            f.btnStart.Text = "START";
        }

        void Shutdown()
        {
            if (BoardTimer != null) { BoardTimer.Stop(); BoardTimer = null; }
            if (cm != null) { cm.Cancel(); cm = null; }
            if (f != null) { if (f.Visible) f.Close(); f = null; }
            Application.Exit();
        }

        void ConnectBalanceBoard(bool WasJustConnected)
        {
            bool Connected = true; try { bb = new Wiimote(); bb.Connect(); bb.SetLEDs(1); bb.GetStatus(); } catch { Connected = false; }

            if (!Connected || bb.WiimoteState.ExtensionType != ExtensionType.BalanceBoard)
            {
                if (ConnectionManager.ElevateProcessNeedRestart()) { Shutdown(); return; }
                if (cm == null) cm = new ConnectionManager();
                cm.ConnectNextWiiMote();
                return;
            }
            if (cm != null) { cm.Cancel(); cm = null; }

            f.Refresh();
        }

        void BoardTimer_Tick(object sender, System.EventArgs e)
        {
            if (cm != null)
            {
                if (cm.IsRunning())
                {
                    return;
                }
                if (cm.HadError())
                {
                    BoardTimer.Stop();
                    System.Windows.Forms.MessageBox.Show(f, "No compatible bluetooth adapter found - Quitting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Shutdown();
                    return;
                }
                ConnectBalanceBoard(true);
                return;
            }

            if (TickNumber * BoardTimer.Interval < measurementDuration * 1000)
            {
                if(data == null)
                {
                    data = new List<Record>();
                }

                TickNumber++;
                UpdateCountdownUI();
                var centerOfGravity = bb.WiimoteState.BalanceBoardState.CenterOfGravity;
                Debug.WriteLine(string.Format("X: {0}  Y: {1} ", centerOfGravity.X, centerOfGravity.Y));
                data.Add(new Record {
                        Ticks = DateTime.Now.Ticks,
                        //Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                        GravX = centerOfGravity.X.ToString(new CultureInfo("en-US")),
                        GravY = centerOfGravity.Y.ToString(new CultureInfo("en-US"))
                });

            } else
            {
                StopMeasuring();
                Debug.WriteLine("Measurement finished!");
            }

        }

        private void UpdateCountdownUI()
        {
            var elapsedSecs = ((TickNumber * BoardTimer.Interval) / 1000);
            f.countdown.Text = (measurementDuration - (int)elapsedSecs).ToString();

            var progress = elapsedSecs * 100 / measurementDuration;
            f.progressbar.Value = progress;

        }

        void UpdateUI(object sender, System.EventArgs e)
        {
            f.btnStart.Enabled = validateSubjectData();
        }
    }
}
