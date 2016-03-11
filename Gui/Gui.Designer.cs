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
            this.folderBrowserDialogData = new System.Windows.Forms.FolderBrowserDialog();
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBoxSubImageSearch = new System.Windows.Forms.GroupBox();
            this.numericUpDownSIWMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSIHMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSIWMin = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSIHMin = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBoxHistOrPic = new System.Windows.Forms.GroupBox();
            this.radioButtonSI = new System.Windows.Forms.RadioButton();
            this.radioButtonHist = new System.Windows.Forms.RadioButton();
            this.buttonCancel = new System.Windows.Forms.Button();
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
            this.groupBoxNetSearch = new System.Windows.Forms.GroupBox();
            this.numericUpDownPerLayerMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLayersMin = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLayersMax = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPerLayerMin = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonTrain = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panelMain.SuspendLayout();
            this.groupBoxSubImageSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSIWMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSIHMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSIWMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSIHMin)).BeginInit();
            this.groupBoxHistOrPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGoodOnes)).BeginInit();
            this.groupBoxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValidationThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxCycles)).BeginInit();
            this.groupBoxNetSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPerLayerMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLayersMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLayersMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPerLayerMin)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.textBox1);
            this.panelMain.Controls.Add(this.groupBoxSubImageSearch);
            this.panelMain.Controls.Add(this.groupBoxHistOrPic);
            this.panelMain.Controls.Add(this.buttonCancel);
            this.panelMain.Controls.Add(this.label8);
            this.panelMain.Controls.Add(this.label7);
            this.panelMain.Controls.Add(this.textBoxBad);
            this.panelMain.Controls.Add(this.textBoxGood);
            this.panelMain.Controls.Add(this.label6);
            this.panelMain.Controls.Add(this.numericUpDownGoodOnes);
            this.panelMain.Controls.Add(this.groupBoxFilter);
            this.panelMain.Controls.Add(this.groupBoxNetSearch);
            this.panelMain.Controls.Add(this.buttonTrain);
            this.panelMain.Location = new System.Drawing.Point(12, 12);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(947, 395);
            this.panelMain.TabIndex = 1;
            // 
            // groupBoxSubImageSearch
            // 
            this.groupBoxSubImageSearch.Controls.Add(this.numericUpDownSIWMax);
            this.groupBoxSubImageSearch.Controls.Add(this.numericUpDownSIHMax);
            this.groupBoxSubImageSearch.Controls.Add(this.numericUpDownSIWMin);
            this.groupBoxSubImageSearch.Controls.Add(this.numericUpDownSIHMin);
            this.groupBoxSubImageSearch.Controls.Add(this.label5);
            this.groupBoxSubImageSearch.Controls.Add(this.label9);
            this.groupBoxSubImageSearch.Location = new System.Drawing.Point(3, 91);
            this.groupBoxSubImageSearch.Name = "groupBoxSubImageSearch";
            this.groupBoxSubImageSearch.Size = new System.Drawing.Size(223, 82);
            this.groupBoxSubImageSearch.TabIndex = 32;
            this.groupBoxSubImageSearch.TabStop = false;
            this.groupBoxSubImageSearch.Text = "Sub Image Search";
            // 
            // numericUpDownSIWMax
            // 
            this.numericUpDownSIWMax.Location = new System.Drawing.Point(142, 22);
            this.numericUpDownSIWMax.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownSIWMax.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownSIWMax.Name = "numericUpDownSIWMax";
            this.numericUpDownSIWMax.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownSIWMax.TabIndex = 4;
            this.numericUpDownSIWMax.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownSIWMax.ValueChanged += new System.EventHandler(this.numericUpDownSIWMax_ValueChanged);
            // 
            // numericUpDownSIHMax
            // 
            this.numericUpDownSIHMax.Location = new System.Drawing.Point(142, 48);
            this.numericUpDownSIHMax.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownSIHMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSIHMax.Name = "numericUpDownSIHMax";
            this.numericUpDownSIHMax.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownSIHMax.TabIndex = 5;
            this.numericUpDownSIHMax.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownSIHMax.ValueChanged += new System.EventHandler(this.numericUpDownSIHMax_ValueChanged);
            // 
            // numericUpDownSIWMin
            // 
            this.numericUpDownSIWMin.Location = new System.Drawing.Point(9, 22);
            this.numericUpDownSIWMin.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownSIWMin.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownSIWMin.Name = "numericUpDownSIWMin";
            this.numericUpDownSIWMin.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownSIWMin.TabIndex = 0;
            this.numericUpDownSIWMin.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownSIWMin.ValueChanged += new System.EventHandler(this.numericUpDownSIWMin_ValueChanged);
            // 
            // numericUpDownSIHMin
            // 
            this.numericUpDownSIHMin.Location = new System.Drawing.Point(9, 48);
            this.numericUpDownSIHMin.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownSIHMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSIHMin.Name = "numericUpDownSIHMin";
            this.numericUpDownSIHMin.Size = new System.Drawing.Size(69, 20);
            this.numericUpDownSIHMin.TabIndex = 1;
            this.numericUpDownSIHMin.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownSIHMin.ValueChanged += new System.EventHandler(this.numericUpDownSIHMin_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Width";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(84, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Height";
            // 
            // groupBoxHistOrPic
            // 
            this.groupBoxHistOrPic.Controls.Add(this.radioButtonSI);
            this.groupBoxHistOrPic.Controls.Add(this.radioButtonHist);
            this.groupBoxHistOrPic.Location = new System.Drawing.Point(14, 251);
            this.groupBoxHistOrPic.Name = "groupBoxHistOrPic";
            this.groupBoxHistOrPic.Size = new System.Drawing.Size(173, 49);
            this.groupBoxHistOrPic.TabIndex = 31;
            this.groupBoxHistOrPic.TabStop = false;
            // 
            // radioButtonSI
            // 
            this.radioButtonSI.AutoSize = true;
            this.radioButtonSI.Location = new System.Drawing.Point(84, 19);
            this.radioButtonSI.Name = "radioButtonSI";
            this.radioButtonSI.Size = new System.Drawing.Size(76, 17);
            this.radioButtonSI.TabIndex = 30;
            this.radioButtonSI.Text = "Sub Image";
            this.radioButtonSI.UseVisualStyleBackColor = true;
            // 
            // radioButtonHist
            // 
            this.radioButtonHist.AutoSize = true;
            this.radioButtonHist.Checked = true;
            this.radioButtonHist.Location = new System.Drawing.Point(6, 18);
            this.radioButtonHist.Name = "radioButtonHist";
            this.radioButtonHist.Size = new System.Drawing.Size(72, 17);
            this.radioButtonHist.TabIndex = 29;
            this.radioButtonHist.TabStop = true;
            this.radioButtonHist.Text = "Histogram";
            this.radioButtonHist.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Enabled = false;
            this.buttonCancel.Location = new System.Drawing.Point(102, 361);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 28;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
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
            this.label6.Location = new System.Drawing.Point(95, 338);
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
            this.numericUpDownGoodOnes.Location = new System.Drawing.Point(20, 336);
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
            this.numericUpDownGoodOnes.ValueChanged += new System.EventHandler(this.numericUpDownGoodOnes_ValueChanged);
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Controls.Add(this.numericUpDownValidationThreshold);
            this.groupBoxFilter.Controls.Add(this.label3);
            this.groupBoxFilter.Controls.Add(this.numericUpDownMaxCycles);
            this.groupBoxFilter.Controls.Add(this.label4);
            this.groupBoxFilter.Location = new System.Drawing.Point(3, 179);
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
            this.numericUpDownValidationThreshold.ValueChanged += new System.EventHandler(this.numericUpDownValidationThreshold_ValueChanged);
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
            this.numericUpDownMaxCycles.ValueChanged += new System.EventHandler(this.numericUpDownMaxCycles_ValueChanged);
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
            // groupBoxNetSearch
            // 
            this.groupBoxNetSearch.Controls.Add(this.numericUpDownPerLayerMax);
            this.groupBoxNetSearch.Controls.Add(this.numericUpDownLayersMin);
            this.groupBoxNetSearch.Controls.Add(this.numericUpDownLayersMax);
            this.groupBoxNetSearch.Controls.Add(this.numericUpDownPerLayerMin);
            this.groupBoxNetSearch.Controls.Add(this.label1);
            this.groupBoxNetSearch.Controls.Add(this.label2);
            this.groupBoxNetSearch.Location = new System.Drawing.Point(3, 3);
            this.groupBoxNetSearch.Name = "groupBoxNetSearch";
            this.groupBoxNetSearch.Size = new System.Drawing.Size(223, 82);
            this.groupBoxNetSearch.TabIndex = 19;
            this.groupBoxNetSearch.TabStop = false;
            this.groupBoxNetSearch.Text = "Net Search";
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
            this.numericUpDownPerLayerMax.ValueChanged += new System.EventHandler(this.numericUpDownPerLayerMax_ValueChanged);
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
            this.numericUpDownLayersMin.ValueChanged += new System.EventHandler(this.numericUpDownLayersMin_ValueChanged);
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
            this.numericUpDownLayersMax.ValueChanged += new System.EventHandler(this.numericUpDownLayersMax_ValueChanged);
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
            this.numericUpDownPerLayerMin.ValueChanged += new System.EventHandler(this.numericUpDownPerLayerMin_ValueChanged);
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
            this.buttonTrain.Location = new System.Drawing.Point(20, 362);
            this.buttonTrain.Name = "buttonTrain";
            this.buttonTrain.Size = new System.Drawing.Size(75, 23);
            this.buttonTrain.TabIndex = 12;
            this.buttonTrain.Text = "Train";
            this.buttonTrain.UseVisualStyleBackColor = true;
            this.buttonTrain.Click += new System.EventHandler(this.buttonTrain_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(396, 335);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 33;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 413);
            this.Controls.Add(this.panelMain);
            this.Name = "Form1";
            this.Text = "Cheap AOI";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.groupBoxSubImageSearch.ResumeLayout(false);
            this.groupBoxSubImageSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSIWMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSIHMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSIWMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSIHMin)).EndInit();
            this.groupBoxHistOrPic.ResumeLayout(false);
            this.groupBoxHistOrPic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGoodOnes)).EndInit();
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownValidationThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxCycles)).EndInit();
            this.groupBoxNetSearch.ResumeLayout(false);
            this.groupBoxNetSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPerLayerMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLayersMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLayersMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPerLayerMin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogData;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownPerLayerMin;
        private System.Windows.Forms.NumericUpDown numericUpDownLayersMin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownValidationThreshold;
        private System.Windows.Forms.Button buttonTrain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxCycles;
        private System.Windows.Forms.NumericUpDown numericUpDownLayersMax;
        private System.Windows.Forms.NumericUpDown numericUpDownPerLayerMax;
        private System.Windows.Forms.GroupBox groupBoxNetSearch;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownGoodOnes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxBad;
        private System.Windows.Forms.TextBox textBoxGood;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBoxHistOrPic;
        private System.Windows.Forms.RadioButton radioButtonSI;
        private System.Windows.Forms.RadioButton radioButtonHist;
        private System.Windows.Forms.GroupBox groupBoxSubImageSearch;
        private System.Windows.Forms.NumericUpDown numericUpDownSIWMax;
        private System.Windows.Forms.NumericUpDown numericUpDownSIHMax;
        private System.Windows.Forms.NumericUpDown numericUpDownSIWMin;
        private System.Windows.Forms.NumericUpDown numericUpDownSIHMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
    }
}

