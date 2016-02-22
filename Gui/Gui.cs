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

namespace Gui
{
    public partial class Form1 : Form
    {
        public static Random r = new Random();

        string[] validationImages;  //File names
        string[] trainImages;       //
        
        string goodTextBoxBuffer = "";
        string badTextBoxBuffer = "";
        
        List<HistData>[] TrainingSet = new List<HistData>[4];
        List<HistData>[] ValidationSet = new List<HistData>[4];

        List<Individual> TrainingPool = new List<Individual>();     //Training pool
        List<Individual> GoodNets = new List<Individual>();         //Good ones found during training
        List<Individual> PickledBrains = new List<Individual>();    //From file - TODO: Stuff

        public Form1()
        {
            InitializeComponent();

            //On startup, point to a training root folder. Must contain two folders called "train" & "validate"
            //Histograms will be created using the contents of these folders

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

            int todo = trainImages.Count() + validationImages.Count();  //For progress bar
            int doneIndex = 0;                                          //

            foreach (var file in trainImages)
            {
                if (file.Contains(".jpg"))
                {
                    HistData r = new HistData();
                    HistData g = new HistData();
                    HistData b = new HistData();
                    HistData hs = new HistData();

                    bool isgood = true;

                    if (file.Contains("bad"))//This is naughty .. make sure the path doesn't contain this word or there'll be chaos
                        isgood = false;

                    r.hist = ImageData.GetData(new Bitmap(file), (int)ImageData.Types.R);
                    r.good = isgood;
                    g.hist = ImageData.GetData(new Bitmap(file), (int)ImageData.Types.G);
                    g.good = isgood;
                    b.hist = ImageData.GetData(new Bitmap(file), (int)ImageData.Types.B);
                    b.good = isgood;
                    hs.hist = ImageData.GetData(new Bitmap(file), (int)ImageData.Types.HS);
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

                    r.hist = ImageData.GetData(new Bitmap(file), (int)ImageData.Types.R);
                    r.good = isgood;
                    g.hist = ImageData.GetData(new Bitmap(file), (int)ImageData.Types.G);
                    g.good = isgood;
                    b.hist = ImageData.GetData(new Bitmap(file), (int)ImageData.Types.B);
                    b.good = isgood;
                    hs.hist = ImageData.GetData(new Bitmap(file), (int)ImageData.Types.HS);
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

        public void saveCouncilOfElrond()
        {
            var result = saveFileDialog1.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    using (Stream stream = File.Open(saveFileDialog1.FileName, FileMode.Create))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, GoodNets);
                    }
                }
                catch (IOException)
                {
                }
            }
        }

        #region Training & Validation
        private int Validate(Individual individual)
        {
            //Exposes the Individual to the validation folder.
            //Learning will not take place at this stage.
            //This is to count the number of validation images
            //an Individual net can correctly classify.
            //It also stores a ratio of correct/total

            int h = individual.dataType;

            int correct = 0;

            foreach (var v in ValidationSet[h])
            {
                if (individual.FF(v.hist, false, v.good))
                    correct++;
            }

            double d = ((double)correct / (double)ValidationSet[h].Count);

            if (d > (double)numericUpDownValidationThreshold.Value)
                individual.training = false;//flag for promotion 

            individual.validationScore = d;
            return correct;
        }

        private bool ValidateCouncilOfElrond()
        {
            int imagesPassed = 0;

            List<int> imagesFailed = new List<int>();//Keep track of these to see if the nets are tripping over the same images consistantly

            for (int v = 0; v < ValidationSet[0].Count; v++)                            //For each image
            {
                int c = 0;                                                              //Count the number of nets in the list that get the correct answer
                foreach (var net in GoodNets)
                {                    
                    if (net.FF(ValidationSet[net.dataType].ElementAt(v).hist,      //FF returns a bool determined by whether it classifies the image correctly
                                false,                                                  //Don't do back prop
                                ValidationSet[net.dataType].ElementAt(v).good))    //The correct answer
                        c++;
                }

                if (c <= GoodNets.Count / 2)                                     //if theres ! a majority of correct answers
                    imagesFailed.Add(v);                                                //Add this image to the list
                else
                    imagesPassed++;                                                     //increment this
            }

            double d = ((double)imagesPassed / (double)ValidationSet[0].Count);

            if (imagesPassed == ValidationSet[0].Count) //If we got a correct majority on the validation
                return true;
            else
                return false;
        }     

        private void trainThread(Individual individual)
        {
            int h = individual.dataType;

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
                if (backgroundWorkerTrainer.CancellationPending)
                    return;

                int rNewLayers = r.Next((int)numericUpDownLayersMin.Value, (int)numericUpDownLayersMax.Value + 1);
                int rNewPerLayer = r.Next((int)numericUpDownPerLayerMin.Value, (int)numericUpDownPerLayerMax.Value + 1);
                //These are used in case a new Individual needs to be created. We can change these settings in the gui
                //while this thread is running and alter this in real time

                Thread[] threads = new Thread[TrainingPool.Count];   //Each Individual will now be given a thread and will be 
                //trained for 1000 iterations.

                for (int i = 0; i < TrainingPool.Count; i++)
                {
                    threads[i] = new Thread(() => trainThread(TrainingPool[i]));
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

                for (int i = 0; i < TrainingPool.Count; i++)
                {

                    if (TrainingPool[i].goodOne)
                    {
                        continue;
                    }
                    if (!TrainingPool[i].training)//which means that it passed validation and is now being called to join the CouncilOfElrond
                    {
                        Individual good = TrainingPool[i];
                        GoodNets.Add(good);

                        goodTextBoxBuffer += good.info();

                        int hType = r.Next(TrainingSet.Length);

                        TrainingPool[i] = new Individual(TrainingSet[hType].ElementAt(0).hist.Length, rNewLayers, rNewPerLayer, hType);
                    }

                    if (TrainingPool[i].totalCycles >= (int)numericUpDownMaxCycles.Value)
                    {
                        int hType = r.Next(TrainingSet.Length);

                        Individual old = TrainingPool[i];

                        TrainingPool[i] = new Individual(TrainingSet[hType].ElementAt(0).hist.Length, rNewLayers, rNewPerLayer, hType);

                        badTextBoxBuffer += old.info();
                    }

                    Validate(TrainingPool[i]);
                }

                if (GoodNets.Count >= (int)numericUpDownGoodOnes.Value)
                {
                    done = ValidateCouncilOfElrond();
                    if (!done)
                        GoodNets.RemoveAt(0); //FIFO
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
            if(!e.Cancelled)
                saveCouncilOfElrond();
            buttonCancel.Enabled = false;
            buttonTrain.Enabled = true;
        } 
        #endregion

        private void buttonTrain_Click(object sender, EventArgs e)
        {
            //Populates the TrainingPool list. One per core. The topology (layers*perlayer) is randomly chosen
            //for each Individual between the limits set in the gui. Then, backgroundWorkerTrainer is started
            //which will train each Individual in parallel.

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                int hType = r.Next(4);

                int layers = r.Next((int)numericUpDownLayersMin.Value, (int)numericUpDownLayersMax.Value + 1);
                int perLayer = r.Next((int)numericUpDownPerLayerMin.Value, (int)numericUpDownPerLayerMax.Value + 1);

                Individual individual = new Individual(TrainingSet[hType].ElementAt(0).hist.Length, layers, perLayer, hType);
                TrainingPool.Add(individual);
            }
            backgroundWorkerTrainer.RunWorkerAsync();
            buttonTrain.Enabled = false;
            buttonCancel.Enabled = true;
        }
        
        private void buttonLoadNets_Click(object sender, EventArgs e)
        {
            DialogResult = openFileDialog1.ShowDialog();

            try
            {
                using (Stream stream = File.Open(openFileDialog1.FileName, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    PickledBrains = (List<Individual>)bin.Deserialize(stream);
                }
            }
            catch (IOException)
            {
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            backgroundWorkerTrainer.CancelAsync();
            buttonCancel.Enabled = false;
        }      
    }
}
