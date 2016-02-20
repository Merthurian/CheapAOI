using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetwork
{
    [Serializable()]
    public class Neuron
    {
        public List<double> inputWeights = new List<double>();
        public double value;
        public double error;
        public double compoundError;
        public double compoundValue;
    }
}
