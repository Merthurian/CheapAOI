namespace Gui
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBarGeneral = new System.Windows.Forms.ProgressBar();
            this.backgroundWorkerLoadData = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialogData = new System.Windows.Forms.FolderBrowserDialog();
            this.panelMain = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonLoadNets = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxBad = new System.Windows.Forms.TextBox();
            this.textBoxGood = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownGoodOnes = new System.Windows.Forms.NumericUpDown();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.numericUpDownValidationThreshold = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownMaxCycles = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxSearchSpace = new System.Windows.Forms.GroupBox();
            this.numericUpDownPerLayerMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLayersMin = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLayersMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPerLayerMin = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonTrain = new System.Windows.Forms.Button();
            this.backgroundWorkerTrainer = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGoodOnes)).BeginInit();
            this.groupBoxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValidationThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxCycles)).BeginInit();
            this.groupBoxSearchSpace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPerLayerMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLayersMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLayersMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPerLayerMin)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBarGeneral
            // 
            this.progressBarGeneral.Location = new System.Drawing.Point(12, 408);
            this.progressBarGeneral.Name = "progressBarGeneral";
            this.progressBarGeneral.Size = new System.Drawing.Size(947, 23);
            this.progressBarGeneral.TabIndex = 0;
            // 
            // backgroundWorkerLoadData
            // 
            this.backgroundWorkerLoadData.WorkerReportsProgress = true;
            this.backgroundWorkerLoadData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLoadData_DoWork);
            this.backgroundWorkerLoadData.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerLoadData_ProgressChanged);
            this.backgroundWorkerLoadData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLoadData_RunWorkerCompleted);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.buttonCancel);
            this.panelMain.Controls.Add(this.buttonLoadNets);
            this.panelMain.Controls.Add(this.label8);
            this.panelMain.Controls.Add(this.label7);
            this.panelMain.Controls.Add(this.textBoxBad);
            this.panelMain.Controls.Add(this.textBoxGood);
            this.panelMain.Controls.Add(this.label6);
            this.panelMain.Controls.Add(this.numericUpDownGoodOnes);
            this.panelMain.Controls.Add(this.groupBoxFilter);
            this.panelMain.Controls.Add(this.groupBoxSearchSpace);
            this.panelMain.Controls.Add(this.buttonTrain);
            this.panelMain.Enabled = false;
            this.panelMain.Location = new System.Drawing.Point(12, 12);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(947, 390);
            this.panelMain.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Enabled = false;
            this.buttonCancel.Location = new System.Drawing.Point(91, 221);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 28;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonLoadNets
            // 
            this.buttonLoadNets.Location = new System.Drawing.Point(9, 323);
            this.buttonLoadNets.Name = "buttonLoadNets";
            this.buttonLoadNets.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadNets.TabIndex = 27;
            this.buttonLoadNets.Text = "Load";
            this.buttonLoadNets.UseVisualStyleBackColor = true;
            this.buttonLoadNets.Click += new System.EventHandler(this.buttonLoadNets_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(730, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Bad ones";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(377, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Good ones";
            // 
            // textBoxBad
            // 
            this.textBoxBad.Location = new System.Drawing.Point(587, 53);
            this.textBoxBad.Multiline = true;
            this.textBoxBad.Name = "textBoxBad";
            this.textBoxBad.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxBad.Size = new System.Drawing.Size(349, 260);
            this.textBoxBad.TabIndex = 24;
            // 
            // textBoxGood
            // 
            this.textBoxGood.Location = new System.Drawing.Point(232, 53);
            this.textBoxGood.Multiline = true;
            this.textBoxGood.Name = "textBoxGood";
            this.textBoxGood.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxGood.Size = new System.Drawing.Size(349, 260);
            this.textBoxGood.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Good ones";
            // 
            // numericUpDownGoodOnes
            // 
            this.numericUpDownGoodOnes.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownGoodOnes.Location = new System.Drawing.Point(9, 196);
            this.numericUpDownGoodOnes.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDownGoodOnes.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownGoodOnes.Name = "numericUpDownGoodOnes";
            this.numericUpDownGoodOnes.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownGoodOnes.TabIndex = 21;
            this.numericUpDownGoodOnes.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.numericUpDownValidationThreshold);
            this.groupBoxFilter.Controls.Add(this.label3);
            this.groupBoxFilter.Controls.Add(this.numericUpDownMaxCycles);
            this.groupBoxFilter.Controls.Add(this.label4);
            this.groupBoxFilter.Location = new System.Drawing.Point(3, 91);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(189, 73);
            this.groupBoxFilter.TabIndex = 20;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Filter";
            // 
            // numericUpDownValidationThreshold
            // 
            this.numericUpDownValidationThreshold.DecimalPlaces = 2;
            this.numericUpDownValidationThreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownValidationThreshold.Location = new System.Drawing.Point(6, 19);
            this.numericUpDownValidationThreshold.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownValidationThreshold.Name = "numericUpDownValidationThreshold";
            this.numericUpDownValidationThreshold.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownValidationThreshold.TabIndex = 10;
            this.numericUpDownValidationThreshold.Value = new decimal(new int[] {
            99,
            0,
            0,
            131072});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Validation Threshold";
            // 
            // numericUpDownMaxCycles
            // 
            this.numericUpDownMaxCycles.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownMaxCycles.Location = new System.Drawing.Point(6, 45);
            this.numericUpDownMaxCycles.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownMaxCycles.Name = "numericUpDownMaxCycles";
            this.numericUpDownMaxCycles.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownMaxCycles.TabIndex = 13;
            this.numericUpDownMaxCycles.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Max Cycles";
            // 
            // groupBoxSearchSpace
            // 
            this.groupBoxSearchSpace.Controls.Add(this.numericUpDownPerLayerMax);
            this.groupBoxSearchSpace.Controls.Add(this.numericUpDownLayersMin);
            this.groupBoxSearchSpace.Controls.Add(this.numericUpDownLayersMax);
            this.groupBoxSearchSpace.Controls.Add(this.numericUpDownPerLayerMin);
            this.groupBoxSearchSpace.Controls.Add(this.label1);
            this.groupBoxSearchSpace.Controls.Add(this.label2);
            this.groupBoxSearchSpace.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSearchSpace.Name = "groupBoxSearchSpace";
            this.groupBoxSearchSpace.Size = new System.Drawing.Size(223, 82);
            this.groupBoxSearchSpace.TabIndex = 19;
            this.groupBoxSearchSpace.TabStop = false;
            this.groupBoxSearchSpace.Text = "Search Space";
            // 
            // numericUpDownPerLayerMax
            // 
            this.numericUpDownPerLayerMax.Location = new System.Drawing.Point(142, 50);
            this.numericUpDownPerLayerMax.Name = "numericUpDownPerLayerMax";
            this.numericUpDownPerLayerMax.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownPerLayerMax.TabIndex = 18;
            this.numericUpDownPerLayerMax.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // numericUpDownLayersMin
            // 
            this.numericUpDownLayersMin.Location = new System.Drawing.Point(9, 22);
            this.numericUpDownLayersMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLayersMin.Name = "numericUpDownLayersMin";
            this.numericUpDownLayersMin.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownLayersMin.TabIndex = 0;
            this.numericUpDownLayersMin.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericUpDownLayersMax
            // 
            this.numericUpDownLayersMax.Location = new System.Drawing.Point(142, 22);
            this.numericUpDownLayersMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLayersMax.Name = "numericUpDownLayersMax";
            this.numericUpDownLayersMax.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownLayersMax.TabIndex = 17;
            this.numericUpDownLayersMax.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericUpDownPerLayerMin
            // 
            this.numericUpDownPerLayerMin.Location = new System.Drawing.Point(9, 48);
            this.numericUpDownPerLayerMin.Name = "numericUpDownPerLayerMin";
            this.numericUpDownPerLayerMin.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownPerLayerMin.TabIndex = 1;
            this.numericUpDownPerLayerMin.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Layers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Per Layer";
            // 
            // buttonTrain
            // 
            this.buttonTrain.Location = new System.Drawing.Point(9, 222);
            this.buttonTrain.Name = "buttonTrain";
            this.buttonTrain.Size = new System.Drawing.Size(75, 23);
            this.buttonTrain.TabIndex = 12;
            this.buttonTrain.Text = "Train";
            this.buttonTrain.UseVisualStyleBackColor = true;
            this.buttonTrain.Click += new System.EventHandler(this.buttonTrain_Click);
            // 
            // backgroundWorkerTrainer
            // 
            this.backgroundWorkerTrainer.WorkerReportsProgress = true;
            this.backgroundWorkerTrainer.WorkerSupportsCancellation = true;
            this.backgroundWorkerTrainer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTrainer_DoWork);
            this.backgroundWorkerTrainer.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerTrainer_ProgressChanged);
            this.backgroundWorkerTrainer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerTrainer_RunWorkerCompleted);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 434);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.progressBarGeneral);
            this.Name = "Form1";
            this.Text = "Cheap AOI";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGoodOnes)).EndInit();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValidationThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxCycles)).EndInit();
            this.groupBoxSearchSpace.ResumeLayout(false);
            this.groupBoxSearchSpace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPerLayerMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLayersMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLayersMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPerLayerMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarGeneral;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoadData;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogData;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownPerLayerMin;
        private System.Windows.Forms.NumericUpDown numericUpDownLayersMin;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTrainer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownValidationThreshold;
        private System.Windows.Forms.Button buttonTrain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxCycles;
        private System.Windows.Forms.NumericUpDown numericUpDownLayersMax;
        private System.Windows.Forms.NumericUpDown numericUpDownPerLayerMax;
        private System.Windows.Forms.GroupBox groupBoxSearchSpace;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownGoodOnes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxBad;
        private System.Windows.Forms.TextBox textBoxGood;
        private System.Windows.Forms.Button buttonLoadNets;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonCancel;
    }
}

