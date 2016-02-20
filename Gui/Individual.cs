using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetwork;
using Histograms;

namespace Gui
{
    [Serializable()]
    class Individual
    {
        static Random r = new Random();

        public NN nn; //Neural Network

        public int histogramType;   //Currently, When individuals are created, they are randomy assigned one of 4 histograms.
                                    //This variable serves as an index to the TrainingSet and ValidationSet lists when passing input
                                    //to this individual.                

        public int totalCycles = 0;

        public static int nextID = 0;
        public int ID;

        public bool training = true;
        public bool goodOne = false;

        public double validationScore = 0;
        
        public Individual(int _ins, int _layers, int _perlayer, int histType)
        {
            ID = nextID++;
            histogramType = histType;
           
            nn = new NN(_ins, 2, _layers, _perlayer);
        }

        public bool FF(double[] input, bool bp, bool good)
        {
            double[] answer = nn.FeedForward(input);

            bool ret = false;

            double actual = (good) ? 1 : -1;
            double[] error = { actual - answer[0], -actual - answer[1] };

            if (good)
            {
                if (answer[0] > answer[1])
                    ret = true;
                else
                    ret = false;
            }
            else
            {
                if (answer[0] < answer[1])
                    ret = true;
                else
                    ret = false;
            }

            /*
            if (Math.Abs(error[0]) + Math.Abs(error[1]) < errorThreshold)
                ret = true;
            */

            if (bp)
            {
                nn.BackProp(error);
            }

            return ret;                
        }

        public string info()
        {
            return "ID:" + ID + " Hist:" + histogramType + " Layers:" + nn.hiddenLayers.Count + " Per Layer:" + nn.hiddenLayers[0].Count + " Cycles:" + totalCycles + " Score:" + validationScore.ToString("#.##") + "\r\n";
        }
    }
}
