using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuralNetwork
{
    [Serializable()]
    public class NN
    {
        static Random r = new Random();
        double learningCoefficient; //Used to tune backpropagation

        int pass;                   //Used when multiple backprop passes are enabled
        int maxPasses;              //

        int totalWeights = 0;       //Or, total numer of connections between all neurons

        public List<Neuron> inputLayer = new List<Neuron>();
        public List<List<Neuron>> hiddenLayers = new List<List<Neuron>>();
        public List<Neuron> outputLayer = new List<Neuron>();

        public NN(int inputs, int outputs, int layers, int perLayer, int _maxPasses)
        {
            maxPasses = _maxPasses;

            #region Network Connection
            for (int i = 0; i < inputs; i++)
            {
                inputLayer.Add(new Neuron());
            }

            inputLayer.Add(new Neuron());   //These two will be used to pass a -1 and 1 constantly to the network
            inputLayer.Add(new Neuron());   //Sometimes called biasing inputs. The XOR problem wouldn't converge
                                            //until I did this.

            
            List<Neuron> previousLayer = inputLayer; //Placeholder for connetion purposes

            for (int x = 0; x < layers; x++)
            {
                hiddenLayers.Add(new List<Neuron>());

                for (int y = 0; y < perLayer; y++)
                {
                    hiddenLayers[x].Add(new Neuron());
                    for (int i = 0; i < previousLayer.Count; i++)
                    {
                        hiddenLayers[x].ElementAt(y).inputWeights.Add((r.NextDouble() * 2) - 1);
                        totalWeights++;
                    }
                }

                previousLayer = hiddenLayers[x];
            }

            for (int j = 0; j < outputs; j++)
            {
                outputLayer.Add(new Neuron());
                for (int i = 0; i < previousLayer.Count; i++)
                {
                    outputLayer[j].inputWeights.Add((r.NextDouble() * 2) - 1);
                    totalWeights++;
                }
            } 
            #endregion

            learningCoefficient = 0.5 / totalWeights;
        }

        public double[] FeedForward(double[] inputValues)
        {
            //Feed the input values to the input neurons. For each neuron,
            //pass on the squashed weighted sum of it's inputs. Then return the values
            //at each output neuron.

            if (inputValues.Length != inputLayer.Count - 2) //The two biasing neurons ..
            {
                return new double[] { -999 };//TODO: Throw exception
            }

            for (int i = 0; i < inputValues.Length; i++)
            {
                inputLayer[i].value = inputValues[i];
            }

            inputLayer[inputLayer.Count - 1].value = 1;     //Bias neurons
            inputLayer[inputLayer.Count - 2].value = -1;    //

            List<Neuron> previousLayer = inputLayer;        //Placeholder

            double sumOfWeightedInputs = 0;

            for (int x = 0; x < hiddenLayers.Count; x++)
            {
                for (int y = 0; y < hiddenLayers[x].Count; y++)
                {
                    sumOfWeightedInputs = 0;

                    for (int i = 0; i < previousLayer.Count; i++)
                    {
                        sumOfWeightedInputs += previousLayer[i].value * hiddenLayers[x].ElementAt(y).inputWeights[i];
                        //Multiply the value of previousLayer[i] by the weight of the connections to it.
                    }

                    hiddenLayers[x].ElementAt(y).value = Sigmoid(sumOfWeightedInputs);
                }

                previousLayer = hiddenLayers[x];//Now do the same all the way through
            }

            for (int i = 0; i < outputLayer.Count; i++)
            {
                sumOfWeightedInputs = 0;
                for (int j = 0; j < previousLayer.Count; j++)
                {
                    sumOfWeightedInputs += previousLayer[j].value * outputLayer[i].inputWeights[j];
                }
                outputLayer[i].value = Sigmoid(sumOfWeightedInputs);
            }

            double[] result = new double[outputLayer.Count];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = outputLayer[i].value;
            }

            CompoundValue();

            return result;
        }

        public void BackProp(double[] errors)
        {
            pass++;//

            for (int i = 0; i < errors.Length; i++)
            {
                outputLayer[i].error += errors[i];
            }

            List<Neuron> previousLayer = outputLayer;

            for (int i = hiddenLayers.Count - 1; i >= 0; i--)
            {
                for (int j = 0; j < hiddenLayers[i].Count; j++)
                {
                    for (int k = 0; k < previousLayer.Count; k++)
                    {
                        hiddenLayers[i].ElementAt(j).error += previousLayer[k].error * previousLayer[k].inputWeights[j];
                    }                    
                }
                previousLayer = hiddenLayers[i];
            }

            for (int i = 0; i < inputLayer.Count; i++)
            {
                for (int j = 0; j < previousLayer.Count; j++)
                {
                    inputLayer[i].error += previousLayer[j].error * previousLayer[j].inputWeights[i];
                }
            }
            
            CompoundError();

            if (pass < maxPasses)
            {
                return;
            }                   

            previousLayer = inputLayer;

            for (int i = 0; i < hiddenLayers.Count; i++)
            {
                for (int j = 0; j < hiddenLayers[i].Count; j++)
                {
                    for (int k = 0; k < previousLayer.Count; k++)
                    {
                        double d = Derivative(hiddenLayers[i].ElementAt(j).compoundValue);
                        double e = hiddenLayers[i].ElementAt(j).compoundError;
                        double a = previousLayer[k].compoundValue;
                        double w = hiddenLayers[i].ElementAt(j).inputWeights[k];

                        hiddenLayers[i].ElementAt(j).inputWeights[k] += learningCoefficient * e * d * a;
                    }
                }
                previousLayer = hiddenLayers[i];
            }

            for (int i = 0; i < outputLayer.Count; i++)
            {
                for (int j = 0; j < previousLayer.Count; j++)
                {
                    double d = Derivative(outputLayer[i].compoundValue);
                    double e = outputLayer[i].compoundError;
                    double a = previousLayer[j].compoundValue;
                    double w = outputLayer[i].inputWeights[j];

                    outputLayer[i].inputWeights[j] += learningCoefficient * e * d * a;
                }
            }

            pass = 0;

            ReZero();
        }

        public void CompoundError()
        {
            for (int i = 0; i < inputLayer.Count; i++)
            {
                inputLayer[i].compoundError = inputLayer[i].error;
                inputLayer[i].error = 0;
            }

            for (int i = 0; i < hiddenLayers.Count; i++)
            {
                for (int j = 0; j < hiddenLayers[i].Count; j++)
                {
                    hiddenLayers[i].ElementAt(j).compoundError = hiddenLayers[i].ElementAt(j).error;
                    hiddenLayers[i].ElementAt(j).error = 0;
                }
            }

            for (int i = 0; i < outputLayer.Count; i++)
            {
                outputLayer[i].compoundError = outputLayer[i].error;
                outputLayer[i].error = 0;
            }
        }
        public void CompoundValue()
        {
            for (int i = 0; i < inputLayer.Count; i++)
            {
                inputLayer[i].compoundValue = inputLayer[i].value;
                inputLayer[i].value = 0;
            }

            for (int i = 0; i < hiddenLayers.Count; i++)
            {
                for (int j = 0; j < hiddenLayers[i].Count; j++)
                {
                    hiddenLayers[i].ElementAt(j).compoundValue = hiddenLayers[i].ElementAt(j).value;
                    hiddenLayers[i].ElementAt(j).value = 0;
                }
            }

            for (int i = 0; i < outputLayer.Count; i++)
            {
                outputLayer[i].compoundValue = outputLayer[i].value;
                outputLayer[i].value = 0;
            }
        }
        public void ReZero()
        {
            for (int i = 0; i < inputLayer.Count; i++)
            {
                inputLayer[i].compoundValue = 0;
                inputLayer[i].compoundError = 0;
            }

            for (int i = 0; i < hiddenLayers.Count; i++)
            {
                for (int j = 0; j < hiddenLayers[i].Count; j++)
                {
                    hiddenLayers[i].ElementAt(j).compoundValue = 0;
                    hiddenLayers[i].ElementAt(j).compoundError = 0;
                }
            }

            for (int i = 0; i < outputLayer.Count; i++)
            {
                outputLayer[i].compoundValue = 0;
                outputLayer[i].compoundError = 0;
            }
        }

        #region Sigmoid & Derivative
        public double Sigmoid(double x)
        {
            return Math.Tanh(x);
        }
        public double Derivative(double x)
        {
            return 1 / (Math.Pow(Math.Cosh(x), 2));
        }
        #endregion
        #region Get/Set Weights (for genetic learning)
        public List<double> GetWeights()
        {
            List<double> weights = new List<Double>();

            for (int x = 0; x < hiddenLayers.Count; x++)
            {
                for (int y = 0; y < hiddenLayers[x].Count; y++)
                {
                    for (int i = 0; i < hiddenLayers[x].ElementAt(y).inputWeights.Count; i++)
                    {
                        weights.Add(hiddenLayers[x].ElementAt(y).inputWeights[i]);
                    }
                }
            }

            for (int i = 0; i < outputLayer.Count; i++)
            {
                for (int j = 0; j < outputLayer[i].inputWeights.Count; j++)
                {
                    weights.Add(outputLayer[i].inputWeights[j]);
                }
            }

            return weights;
        }
        public void SetWeights(double[] weights)
        {
            if (weights.Length != totalWeights)
            {
                //TODO: Throw a shit fit
                return;
            }

            int index = 0;

            for (int x = 0; x < hiddenLayers.Count; x++)
            {
                for (int y = 0; y < hiddenLayers[x].Count; y++)
                {
                    for (int i = 0; i < hiddenLayers[x].ElementAt(y).inputWeights.Count; i++)
                    {
                        hiddenLayers[x].ElementAt(y).inputWeights[i] = weights[index++];
                    }
                }
            }

            for (int i = 0; i < outputLayer.Count; i++)
            {
                for (int j = 0; j < outputLayer[i].inputWeights.Count; j++)
                {
                    outputLayer[i].inputWeights[j] = weights[index++];
                }
            }
        }

        public int weightCount()
        {
            return this.totalWeights;
        }

        #endregion
    }
}
