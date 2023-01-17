using FuzzyNeuralNet.Numbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace FuzzyNeuralNet
{
    internal class Node
    {
        public TriangularNumber Value;
        public Node[] InNodes;
        public TriangularNumber[] InWeights;

        public Node(int length)
        {
            Value = new TriangularNumber();
            InNodes = new Node[length];
            InWeights = new TriangularNumber[length];
        }

        public Node(Node[] nodes)
        {
            Value = new TriangularNumber();
            InNodes = nodes;
            InWeights = new TriangularNumber[nodes.Length];
        }

        public TriangularNumber UpdateValue()
        {
            Value = new TriangularNumber();

            for(int i = 0; i < InNodes.Length; i++)
            {
                var increment = InNodes[i].Value * InWeights[i];
                Value += increment;
            }

            return Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
