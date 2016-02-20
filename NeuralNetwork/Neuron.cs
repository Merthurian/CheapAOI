using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetwork
{
    [Serializable()]
    public class Neuron
    {
        //The neuron is a node with an unlimited number input and output connections
        //It takes the weighted sum of all the inputs. Squashes this to between
        //-1 and 1, then passes this resulting value on to each output. That's it.

        public List<double> inputWeights = new List<double>();
        public double value;            //Weighted sum of all inputs

        public double error;            //Used in back propagation                 
    }
}
