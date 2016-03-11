using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataSet;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using Training;

namespace Gui
{
    public partial class Form1 : Form
    {
        public static Random r = new Random();

        Trainer trainer;

        delegate void reportDelegate(Control control, string s);
        
        public Form1()
        {
            InitializeComponent();

            //On startup, point to a training root folder. Must contain two folders called "train" & "validate"
            //Histograms will be created using the contents of these folders

            DialogResult result = folderBrowserDialogData.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            trainer = new Trainer(folderBrowserDialogData.SelectedPath);
            trainer.Report += new Trainer.ReportHandler(HandleReport);
        }

        private void SetText(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                reportDelegate d = new reportDelegate(SetText);

                control.Invoke(d, new object[] { control, text }); 
            }
            else
            {
                control.Text += text;
            }
        }
 
        public void HandleReport(Trainer t, TrainingReport r)
        {
            SetText(this.textBoxGood, r.goodReport);
            SetText(this.textBoxBad, r.badReport);
        }
            
        private void buttonTrain_Click(object sender, EventArgs e)
        {
            trainer.layersMax = (int)numericUpDownLayersMax.Value;
            trainer.layersMin = (int)numericUpDownLayersMin.Value;
            trainer.maxCylces = (int)numericUpDownMaxCycles.Value;
            trainer.perLayerMax = (int)numericUpDownPerLayerMax.Value;
            trainer.perLayerMin = (int)numericUpDownPerLayerMin.Value;
            trainer.SIHeightMax = (int)numericUpDownSIHMax.Value;
            trainer.SIHeightMin = (int)numericUpDownSIHMin.Value;
            trainer.SIWidthMax = (int)numericUpDownSIWMax.Value;
            trainer.SIWidthMin = (int)numericUpDownSIWMin.Value;
            trainer.subImage = radioButtonSI.Checked;

            trainer.validationThresh = (double)numericUpDownValidationThreshold.Value;
            trainer.goodNetListSize = (int)numericUpDownGoodOnes.Value;

            trainer.GoGoGo();

            buttonTrain.Enabled = false;
            buttonCancel.Enabled = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            trainer.Cancel();
        }

        #region numeric up/downs
        private void numericUpDownLayersMin_ValueChanged(object sender, EventArgs e)
        {
            trainer.layersMin = (int)numericUpDownLayersMin.Value;
        }

        private void numericUpDownLayersMax_ValueChanged(object sender, EventArgs e)
        {
            trainer.layersMax = (int)numericUpDownLayersMax.Value;
        }

        private void numericUpDownPerLayerMin_ValueChanged(object sender, EventArgs e)
        {
            trainer.perLayerMin = (int)numericUpDownPerLayerMin.Value;
        }

        private void numericUpDownPerLayerMax_ValueChanged(object sender, EventArgs e)
        {
            trainer.perLayerMax = (int)numericUpDownPerLayerMax.Value;
        }

        private void numericUpDownSIWMin_ValueChanged(object sender, EventArgs e)
        {
            trainer.SIWidthMin = (int)numericUpDownSIWMin.Value;
        }

        private void numericUpDownSIWMax_ValueChanged(object sender, EventArgs e)
        {
            trainer.SIWidthMax = (int)numericUpDownSIWMax.Value;
        }

        private void numericUpDownSIHMin_ValueChanged(object sender, EventArgs e)
        {
            trainer.SIHeightMin = (int)numericUpDownSIHMin.Value;
        }

        private void numericUpDownSIHMax_ValueChanged(object sender, EventArgs e)
        {
            trainer.SIHeightMax = (int)numericUpDownSIHMax.Value;
        }

        private void numericUpDownValidationThreshold_ValueChanged(object sender, EventArgs e)
        {
            trainer.validationThresh = (double)numericUpDownValidationThreshold.Value;
        }

        private void numericUpDownMaxCycles_ValueChanged(object sender, EventArgs e)
        {
            trainer.maxCylces = (int)numericUpDownMaxCycles.Value;
        }

        private void numericUpDownGoodOnes_ValueChanged(object sender, EventArgs e)
        {
            trainer.goodNetListSize = (int)numericUpDownGoodOnes.Value;
        } 
        #endregion   
    }
}
