using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Histograms;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gui
{
    public partial class Form1 : Form
    {
        public static Random r = new Random();

        string[] validationImages;  //File names
        string[] trainImages;       //

        List<HistData>[] TrainingSet = new List<HistData>[4];
        List<HistData>[] ValidationSet = new List<HistData>[4];

        List<Individual> Individuals = new List<Individual>();
        List<Individual> CouncilOfElrond = new List<Individual>();

        public Form1()
        {
            InitializeComponent();

            DialogResult result = folderBrowserDialogData.ShowDialog();
            if (result == DialogResult.OK)
            {
                trainImages = Directory.GetFiles(folderBrowserDialogData.SelectedPath + "/train");
                validationImages = Directory.GetFiles(folderBrowserDialogData.SelectedPath + "/validate");
            }
            else
                return;

            backgroundWorkerLoadData.RunWorkerAsync();
        }

        private void getPics()
        {
            List<HistData> trainingR = new List<HistData>();
            List<HistData> trainingG = new List<HistData>();
            List<HistData> trainingB = new List<HistData>();
            List<HistData> trainingHS = new List<HistData>();

            List<HistData> validationR = new List<HistData>();
            List<HistData> validationG = new List<HistData>();
            List<HistData> validationB = new List<HistData>();
            List<HistData> validationHS = new List<HistData>();

            int todo = trainImages.Count() + validationImages.Count();

            int doneIndex = 0;

            foreach (var file in trainImages)
            {
                if (file.Contains(".jpg"))
                {
                    HistData r = new HistData();
                    HistData g = new HistData();
                    HistData b = new HistData();
                    HistData hs = new HistData();

                    bool isgood = true;

                    if (file.Contains("bad"))
                        isgood = false;

                    r.hist = Histogram.DoHistogram(new Bitmap(file), (int)Histogram.Types.R);
                    r.name = "R";
                    r.good = isgood;
                    g.hist = Histogram.DoHistogram(new Bitmap(file), (int)Histogram.Types.G);
                    g.name = "G";
                    g.good = isgood;
                    b.hist = Histogram.DoHistogram(new Bitmap(file), (int)Histogram.Types.B);
                    b.name = "B";
                    b.good = isgood;
                    hs.hist = Histogram.DoHistogram(new Bitmap(file), (int)Histogram.Types.HS);
                    hs.name = "HS";
                    hs.good = isgood;

                    r.filename = file;
                    g.filename = file;
                    b.filename = file;
                    hs.filename = file;
                    

                    trainingR.Add(r);
                    trainingG.Add(g);
                    trainingB.Add(b);
                    trainingHS.Add(hs);
                }
                doneIndex++;

                int progress = (int)(100 * ((double)doneIndex / todo));

                backgroundWorkerLoadData.ReportProgress(progress);
            }

            foreach (var file in validationImages)
            {
                if (file.Contains(".jpg"))
                {
                    HistData r = new HistData();
                    HistData g = new HistData();
                    HistData b = new HistData();
                    HistData hs = new HistData();

                    bool isgood = true;

                    if (file.Contains("bad"))
                        isgood = false;

                    r.hist = Histogram.DoHistogram(new Bitmap(file), (int)Histogram.Types.R);
                    r.name = "R";
                    r.good = isgood;
                    g.hist = Histogram.DoHistogram(new Bitmap(file), (int)Histogram.Types.G);
                    g.name = "G";
                    g.good = isgood;
                    b.hist = Histogram.DoHistogram(new Bitmap(file), (int)Histogram.Types.B);
                    b.name = "B";
                    b.good = isgood;
                    hs.hist = Histogram.DoHistogram(new Bitmap(file), (int)Histogram.Types.HS);
                    hs.name = "HS";
                    hs.good = isgood;

                    r.filename = file;
                    g.filename = file;
                    b.filename = file;
                    hs.filename = file;

                    validationR.Add(r);
                    validationG.Add(g);
                    validationB.Add(b);
                    validationHS.Add(hs);
                }
                doneIndex++;

                int progress = (int)(100 * ((double)doneIndex / todo));

                backgroundWorkerLoadData.ReportProgress(progress);
            }
            TrainingSet[0] = trainingR;
            TrainingSet[1] = trainingG;
            TrainingSet[2] = trainingB;
            TrainingSet[3] = trainingHS;

            ValidationSet[0] = validationR;
            ValidationSet[1] = validationG;
            ValidationSet[2] = validationB;
            ValidationSet[3] = validationHS;
        }

        string goodTextBoxBuffer = "";
        string badTextBoxBuffer = "";

        #region backgroundWorkerLoadData
        private void backgroundWorkerLoadData_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarGeneral.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            getPics();
        }

        private void backgroundWorkerLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarGeneral.Value = 0;
            panelMain.Enabled = true;
        }
        #endregion
       
        private int Validate(Individual individual)
        {
            int h = individual.histogramType;

            int correct = 0;

            foreach (var v in ValidationSet[h])
            {
                if (individual.FF(v.hist, false, v.good))
                    correct++;
            }

            double d = ((double)correct / (double)ValidationSet[h].Count);

            if (d > (double)numericUpDownValidationThreshold.Value)
                individual.training = false;

            individual.validationScore = d;
            return correct;
        }

        private bool ValidateGoodOnes()
        {
            int imagesPassed = 0;

            List<int> imagesFailed = new List<int>();

            for (int v = 0; v < ValidationSet[0].Count; v++)
            {
                int c = 0;
                foreach (var i in CouncilOfElrond)
                {                    
                    if (i.FF(ValidationSet[i.histogramType].ElementAt(v).hist, false, ValidationSet[i.histogramType].ElementAt(v).good))
                        c++;
                }
                if (c <= CouncilOfElrond.Count / 2)
                    imagesFailed.Add(v);
                else
                    imagesPassed++;
            }

            double d = ((double)imagesPassed / (double)ValidationSet[0].Count);

            if (imagesPassed == ValidationSet[0].Count)
                return true;
            else
                return false;
        }

        private void trainThread(Individual individual)
        {
            int h = individual.histogramType;

            int count = 0;
            int maxCycles = 1000;

            while (count < maxCycles)
            {
                var histogram = TrainingSet[h].ElementAt(r.Next(TrainingSet[h].Count));
                individual.FF(histogram.hist, true, histogram.good);

                count++;
            }

            individual.totalCycles += maxCycles;
        }

        private void backgroundWorkerTrainer_DoWork(object sender, DoWorkEventArgs e)
        {
            bool done = false;
            while (!done)
            {
                int rNewLayers = r.Next((int)numericUpDownLayersMin.Value, (int)numericUpDownLayersMax.Value + 1);
                int rNewPerLayer = r.Next((int)numericUpDownPerLayerMin.Value, (int)numericUpDownPerLayerMax.Value + 1);
                //These are used in case a new Individual needs to be created.

                Thread[] threads = new Thread[Individuals.Count];   //Each Individual will now be given a thread and will be 
                                                                    //trained for 1000 iterations.

                for (int i = 0; i < Individuals.Count; i++)
                {
                    threads[i] = new Thread(() => trainThread(Individuals[i]));
                    threads[i].Start();
                    threads[i].Join();
                }

                bool threadsDone = false;

                while (!threadsDone)
                {
                    threadsDone = true;

                    for (int t = 0; t < threads.Length; t++)
                    {
                        if (threads[t].ThreadState != ThreadState.Stopped)
                        {
                            threadsDone = false;
                            Thread.Sleep(25);
                        }
                    }
                }

                for (int i = 0; i < Individuals.Count; i++)
                {
                    
                    if (Individuals[i].goodOne)
                    {
                        continue;
                    }
                    if (!Individuals[i].training)
                    {
                        Individual good = Individuals[i];
                        CouncilOfElrond.Add(good);

                        goodTextBoxBuffer += good.info();

                        int hType = r.Next(4);

                        Individuals[i] = new Individual(TrainingSet[hType].ElementAt(0).hist.Length, rNewLayers, rNewPerLayer, hType);
                    }

                    if (Individuals[i].totalCycles >= (int)numericUpDownMaxCycles.Value)
                    {
                        int hType = r.Next(4);

                        Individual old = Individuals[i];

                        Individuals[i] = new Individual(TrainingSet[hType].ElementAt(0).hist.Length, rNewLayers, rNewPerLayer, hType);

                        badTextBoxBuffer += old.info();
                    }

                    Validate(Individuals[i]);
                }

                if (CouncilOfElrond.Count >= (int)numericUpDownGoodOnes.Value)
                {
                    done = ValidateGoodOnes();
                    if (!done)
                        CouncilOfElrond.RemoveAt(0);
                        //CouncilOfElrond.Clear();
                }
                backgroundWorkerTrainer.ReportProgress(0);
            }            
        }

        private void backgroundWorkerTrainer_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            textBoxGood.Text += goodTextBoxBuffer;
            goodTextBoxBuffer = "";

            textBoxGood.SelectionStart = textBoxGood.Text.Length;
            textBoxGood.ScrollToCaret();

            textBoxBad.Text += badTextBoxBuffer;
            badTextBoxBuffer = "";

            textBoxBad.SelectionStart = textBoxBad.Text.Length;
            textBoxBad.ScrollToCaret();    
        }

        private void backgroundWorkerTrainer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                using (Stream stream = File.Open("good.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, CouncilOfElrond);
                }
            }
            catch (IOException)
            {
            }
        }

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            //Populates the Individuals list. One per core. The topology (layers*perlayer) is randomly chosen
            //for each Individual between the limits set in the gui. Then, backgroundWorkerTrainer is started
            //which will train each Individual in parallel.

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                int hType = r.Next(4);

                int layers = r.Next((int)numericUpDownLayersMin.Value, (int)numericUpDownLayersMax.Value + 1);
                int perLayer = r.Next((int)numericUpDownPerLayerMin.Value, (int)numericUpDownPerLayerMax.Value + 1);

                Individual individual = new Individual(TrainingSet[hType].ElementAt(0).hist.Length, layers, perLayer, hType);
                Individuals.Add(individual);
            }
            backgroundWorkerTrainer.RunWorkerAsync();
        }
    }
}
