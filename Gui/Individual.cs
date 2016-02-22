using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetwork;
using DataSet;

namespace Gui
{
    [Serializable()]
    class Individual
    {
        static Random r = new Random();

        public NN nn; //Neural Network

        public int dataType;        //Currently, When individuals are created, they are randomy assigned one of 4 histograms.
                                    //This variable serves as an index to the TrainingSet and ValidationSet lists when passing input
                                    //to this individual.                

        public int totalCycles = 0; //Keep track of how many training cylces nets have undergone. Throw them away if the value gets to o high as they're likely to over fit the training set

        public static int nextID = 0;
        public int ID;

        public bool training = true;    //Used as flags during training, marking for promotion
        public bool goodOne = false;    //

        public double validationScore = 0;
        
        public Individual(int _ins, int _layers, int _perlayer, int histType)
        {
            ID = nextID++;
            dataType = histType;
           
            nn = new NN(_ins, 2, _layers, _perlayer);
        }

        public bool FF(double[] input, bool bp, bool good)//Feed Forward
        {
            double[] answer = nn.FeedForward(input);

            bool correct = false;

            double actual = (good) ? 1 : -1;
            double[] error = { actual - answer[0], -actual - answer[1] };

            if (good)
            {
                if (answer[0] > answer[1])
                    correct = true;
                else
                    correct = false;
            }
            else
            {
                if (answer[0] < answer[1])
                    correct = true;
                else
                    correct = false;
            }
            
            if (bp)
            {
                nn.BackPropagation(error);
            }

            return correct;                
        }

        public string info()
        {
            double percentageScore = validationScore * 100;

            return  "ID: " + ID + 
                    " Hist: " + dataType + 
                    " Layers: " + nn.hiddenLayers.Count + 
                    " Per Layer: " + nn.hiddenLayers[0].Count + 
                    " Cycles: " + totalCycles + 
                    " Score: " + percentageScore.ToString("#.#") + 
                    "%" +
                    "\r\n";
        }
    }
}
