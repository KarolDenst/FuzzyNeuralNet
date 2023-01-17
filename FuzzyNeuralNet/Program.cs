using FuzzyNeuralNet;
using FuzzyNeuralNet.Numbers;

var layers = new List<int>
{
    2, 3, 1
};
var neuralNet = new NeuralNet(layers);

// Layer 1
neuralNet.UpdateWeights(1, 0, 0, 0.2, 0.4, 0.7);
neuralNet.UpdateWeights(1, 0, 1, 0.2, 0.3, 0.5);

neuralNet.UpdateWeights(1, 1, 0, 0.5, 0.7, 1);
neuralNet.UpdateWeights(1, 1, 1, 0.2, 0.4, 0.5);

neuralNet.UpdateWeights(1, 2, 0, 0, 0.3, 0.5);
neuralNet.UpdateWeights(1, 2, 1, 0.5, 0.6, 0.7);

//Layer 2
neuralNet.UpdateWeights(2, 0, 0, 0.2, 0.5, 0.6);
neuralNet.UpdateWeights(2, 0, 1, 0.1, 0.5, 0.8);
neuralNet.UpdateWeights(2, 0, 2, 0, 0.1, 0.2);

//Set input
var x1 = new TriangularNumber(0.4, 0.5, 0.6);
var x2 = new TriangularNumber(0.2, 0.5, 0.6);
var inputs = new List<TriangularNumber> { x1, x2 };
neuralNet.SetInput(inputs);

neuralNet.Update();
neuralNet.Print();
