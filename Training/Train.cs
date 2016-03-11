using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataSet;
using System.IO;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Management;

namespace Training
{
    public class TrainingReport : EventArgs
    {
        public string goodReport = "";
        public string badReport = "";
    }
    
    public class Trainer
    {
        public static Random r = new Random();

        public Thread worker;
        
        public delegate void ReportHandler(Trainer t, TrainingReport e);
        public event ReportHandler Report;

        string[] validationImages;  //File names
        string[] trainImages;       //

        string goodReportBuffer = "";
        string badReportBuffer = "";

        List<pictureData>[] TrainingSet = new List<pictureData>[4];
        List<pictureData>[] ValidationSet = new List<pictureData>[4];

        List<Individual> TrainingPool = new List<Individual>();     //Training pool
        List<Individual> GoodNets = new List<Individual>();         //Good ones found during training
        List<Individual> PickledBrains = new List<Individual>();    //From file - TODO: Stuff

        public Trainer(string folder)
        {
            trainImages = Directory.GetFiles(folder + "/train");
            validationImages = Directory.GetFiles(folder + "/validate");
            
            getPics();
        }       

        #region fileIO
        private void getPics()
        {
            List<pictureData> trainingR = new List<pictureData>();
            List<pictureData> trainingG = new List<pictureData>();
            List<pictureData> trainingB = new List<pictureData>();
            List<pictureData> trainingHS = new List<pictureData>();

            List<pictureData> validationR = new List<pictureData>();
            List<pictureData> validationG = new List<pictureData>();
            List<pictureData> validationB = new List<pictureData>();
            List<pictureData> validationHS = new List<pictureData>();

            int todo = trainImages.Count() + validationImages.Count();  //For progress bar
            int doneIndex = 0;                                          //

            foreach (var file in trainImages)
            {
                if (file.Contains(".jpg"))
                {
                    pictureData r = new pictureData();
                    pictureData g = new pictureData();
                    pictureData b = new pictureData();
                    pictureData hs = new pictureData();

                    bool isgood = true;

                    if (file.Contains("bad"))//This is naughty .. make sure the path doesn't contain this word or there'll be chaos
                        isgood = false;

                    Bitmap bitmap = new Bitmap(file);

                    r.hist = ImageData.GetData(bitmap, (int)ImageData.Types.R);
                    r.good = isgood;
                    r.bitmap = bitmap; //Chucking this here for the time being.
                    g.hist = ImageData.GetData(bitmap, (int)ImageData.Types.G);
                    g.good = isgood;
                    b.hist = ImageData.GetData(bitmap, (int)ImageData.Types.B);
                    b.good = isgood;
                    hs.hist = ImageData.GetData(bitmap, (int)ImageData.Types.HS);
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
            }

            foreach (var file in validationImages)
            {
                if (file.Contains(".jpg"))
                {
                    pictureData r = new pictureData();
                    pictureData g = new pictureData();
                    pictureData b = new pictureData();
                    pictureData hs = new pictureData();

                    bool isgood = true;

                    if (file.Contains("bad"))
                        isgood = false;

                    Bitmap bitmap = new Bitmap(file);

                    r.hist = ImageData.GetData(new Bitmap(file), (int)ImageData.Types.R);
                    r.good = isgood;
                    r.bitmap = bitmap; //Chucking this here for the time being.
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
        public void saveGoodNets(string filename)
        {
            try
            {
                using (Stream stream = File.Open(filename, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, GoodNets);
                }
            }
            catch (IOException)
            {
            }
        }
        public void LoadNets(string filename)
        {
            try
            {
                using (Stream stream = File.Open(filename, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    PickledBrains = (List<Individual>)bin.Deserialize(stream);
                }
            }
            catch (IOException)
            {
            }
        }
        #endregion

        #region Validation & Training
        private int Validate(Individual individual)
        {
            //Exposes the Individual to the validation folder.
            //Learning will not take place at this stage.
            //This is to count the number of validation images
            //an Individual net can correctly classify.
            //It also stores a ratio of correct/total

            int h = individual.dataType;

            int correct = 0;

            if (h != (int)DataSet.ImageData.Types.SI)
            {
                foreach (var v in ValidationSet[h])
                {
                    if (individual.FF(v.hist, false, v.good))
                        correct++;
                }
            }
            else
            {
                foreach (var v in ValidationSet[0])
                {
                    double[] rgbArray = new double[individual.nn.inputLayer.Count - 2];

                    int index = 0;

                    for (int x = 0; x < individual.rectangle.w; x++)
                    {
                        for (int y = 0; y < individual.rectangle.h; y++)
                        {
                            Color c = v.bitmap.GetPixel(individual.rectangle.x + x, individual.rectangle.y + y);
                            rgbArray[index++] = (double)c.R / 255;
                            rgbArray[index++] = (double)c.G / 255;
                            rgbArray[index++] = (double)c.B / 255;
                        }
                    }

                    if (individual.FF(rgbArray, false, v.good))
                        correct++;
                }
            }

            double d = ((double)correct / (double)ValidationSet[0].Count);

            if (d > validationThresh)
                individual.training = false;//flag for promotion 

            individual.validationScore = d;
            return correct;
        }
        public bool ValidateGoodNets()
        {
            int imagesPassed = 0;

            List<int> imagesFailed = new List<int>();//Keep track of these to see if the nets are tripping over the same images consistantly

            for (int v = 0; v < ValidationSet[0].Count; v++)                            //For each image
            {
                int correct = 0;                                                              //Count the number of nets in the list that get the correct answer
                foreach (var net in GoodNets)
                {


                    if (subImage)
                    {
                        double[] rgbArray = new double[net.nn.inputLayer.Count - 2];

                        int index = 0;

                        for (int x = 0; x < net.rectangle.w; x++)
                        {
                            for (int y = 0; y < net.rectangle.h; y++)
                            {
                                Color c = ValidationSet[0].ElementAt(v).bitmap.GetPixel(net.rectangle.x + x, net.rectangle.y + y);
                                rgbArray[index++] = (double)c.R / 255;
                                rgbArray[index++] = (double)c.G / 255;
                                rgbArray[index++] = (double)c.B / 255;
                            }
                        }

                        if (net.FF(rgbArray, false, ValidationSet[0].ElementAt(v).good))
                            correct++;

                    }
                    else
                    {
                        if (net.FF(ValidationSet[net.dataType].ElementAt(v).hist,      //FF returns a bool determined by whether it classifies the image correctly
                                                                        false,                                                  //Don't do back prop
                                                                        ValidationSet[net.dataType].ElementAt(v).good))    //The correct answer
                            correct++;
                    }
                }

                if (correct <= GoodNets.Count / 2)                                     //if theres ! a majority of correct answers
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

        public void GoGoGo()
        {
            //Populates the TrainingPool list. One per core. The topology (layers*perlayer) is randomly chosen
            //for each Individual between the limits set in the gui. Then each Individual will be trained in parallel.

            TrainingPool.Clear();

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                if (subImage)
                    TrainingPool.Add(subImageIndividual());
                else
                    TrainingPool.Add(histIndividual());
            }

            worker = new Thread(DoWork);
            worker.Start();
            //worker.Join();
            //DoWork();
        }
        private void trainThread(Individual individual)
        {
            int h = individual.dataType;

            int count = 0;
            int maxCycles = 1000;

            if (h == (int)DataSet.ImageData.Types.SI)
            {
                while (count < maxCycles)
                {
                    double[] rgbArray = new double[individual.nn.inputLayer.Count - 2];

                    int index = 0;

                    int randomImage = r.Next(TrainingSet[0].Count);

                    for (int x = 0; x < individual.rectangle.w; x++)
                    {
                        for (int y = 0; y < individual.rectangle.h; y++)
                        {
                            Color c = TrainingSet[0].ElementAt(randomImage).bitmap.GetPixel(individual.rectangle.x + x, individual.rectangle.y + y);
                            rgbArray[index++] = (double)c.R / 255;
                            rgbArray[index++] = (double)c.G / 255;
                            rgbArray[index++] = (double)c.B / 255;
                        }
                    }

                    individual.FF(rgbArray, true, TrainingSet[0].ElementAt(randomImage).good);

                    count++;
                }
            }
            else
            {
                while (count < maxCycles)
                {
                    var histogram = TrainingSet[h].ElementAt(r.Next(TrainingSet[h].Count));
                    individual.FF(histogram.hist, true, histogram.good);

                    count++;
                }
            }

            individual.totalCycles += maxCycles;
        }
        private void DoWork()
        {
            bool done = false;
            while (!done)
            {
                int rNewLayers = r.Next(layersMin, layersMax + 1);
                int rNewPerLayer = r.Next(perLayerMin, perLayerMax + 1);
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

                        goodReportBuffer += good.info();

                        int hType = r.Next(TrainingSet.Length);

                        if (subImage)
                            TrainingPool[i] = subImageIndividual();
                        else
                            TrainingPool[i] = histIndividual();
                    }

                    if (TrainingPool[i].totalCycles >= maxCylces)
                    {
                        int hType = r.Next(TrainingSet.Length);

                        Individual old = TrainingPool[i];

                        if (subImage)
                            TrainingPool[i] = subImageIndividual();
                        else
                            TrainingPool[i] = histIndividual();

                        badReportBuffer += old.info();
                    }

                    Validate(TrainingPool[i]);
                }

                if (GoodNets.Count >= goodNetListSize)
                {
                    done = ValidateGoodNets();
                    if (!done)
                        GoodNets.RemoveAt(0); //FIFO
                }

                if (goodReportBuffer != "" || badReportBuffer != "")
                {
                    TrainingReport tr = new TrainingReport();
                    tr.goodReport = goodReportBuffer;
                    tr.badReport = badReportBuffer;

                    Report(this, tr);
                }
                goodReportBuffer = "";
                badReportBuffer = "";
            }
            //Save them
        }

        /*
        public void Report()
        {
            //Use these buffers to report what's going on

            //textBoxGood.Text += goodReportBuffer;
            goodReportBuffer = "";

            //textBoxGood.SelectionStart = textBoxGood.Text.Length;
            //textBoxGood.ScrollToCaret();

            //textBoxBad.Text += badReportBuffer;
            badReportBuffer = "";

            //textBoxBad.SelectionStart = textBoxBad.Text.Length;
            //textBoxBad.ScrollToCaret();            
        } 
        */
        public void Cancel()
        {
            return;
        }
        #endregion

        #region Individual Types
        public Individual histIndividual()
        {
            int hType = r.Next(4);

            int layers = r.Next(layersMin, layersMax + 1);
            int perLayer = r.Next(perLayerMin, perLayerMax + 1);

            return new Individual(TrainingSet[hType].ElementAt(0).hist.Length, layers, perLayer, hType, new Rect());
        }
        public Individual subImageIndividual()
        {
            int layers = r.Next(layersMin, layersMax + 1);
            int perLayer = r.Next(perLayerMin, perLayerMax + 1);

            int width = r.Next(SIWidthMin, SIWidthMax);
            int height = r.Next(SIHeightMin, SIHeightMax);

            Rect rect = new Rect();
            rect.w = width;
            rect.h = height;

            int imageWidth = TrainingSet[0].ElementAt(0).bitmap.Width;
            int imageHeight = TrainingSet[0].ElementAt(0).bitmap.Height;

            rect.x = r.Next(0, imageWidth - width);
            rect.y = r.Next(0, imageHeight - height);

            return new Individual(width * height * 3, layers, perLayer, (int)DataSet.ImageData.Types.SI, rect);
        } 
        #endregion               
        
        #region properties
        public bool subImage { get; set; }
        public double validationThresh { get; set; }
        public int layersMin { get; set; }
        public int layersMax { get; set; }
        public int perLayerMin { get; set; }
        public int perLayerMax { get; set; }
        public int maxCylces { get; set; }
        public int goodNetListSize { get; set; }
        public int SIWidthMin { get; set; }
        public int SIWidthMax { get; set; }
        public int SIHeightMin { get; set; }
        public int SIHeightMax { get; set; }    
        #endregion     
    }
}
