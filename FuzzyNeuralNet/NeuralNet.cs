using FuzzyNeuralNet.Numbers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyNeuralNet
{
    internal class NeuralNet
    {
        public List<Node[]> Nodes;
        public List<int> Layers;

        public NeuralNet(List<int> layers)
        {
            Layers = layers;
            Nodes = new List<Node[]>();

            for (int i = 0; i < layers.Count; i++)
            {
                Nodes.Add(new Node[layers[i]]);

                if (i != 0)
                {
                    for (int j = 0; j < layers[i]; j++)
                    {
                        Nodes[i][j] = new Node(Nodes[i - 1]);
                    }
                }
                else
                {
                    for (int j = 0; j < layers[i]; j++)
                    {
                        Nodes[i][j] = new Node(0);
                    }
                }
            }
        }

        public void SetInput(List<TriangularNumber> numbers)
        {
            for(int i = 0; i < Nodes[0].Length; i++)
            {
                Nodes[0][i].Value = numbers[i];
            }
        }

        public List<TriangularNumber> GetOutput()
        {
            var numbers = new List<TriangularNumber>();
            foreach (var node in Nodes[Layers.Count - 1])
            {
                numbers.Add(node.Value);
            }

            return numbers;
        }

        public void Update()
        {
            for(int i = 1; i < Nodes.Count; i++)
            {
                for (int j = 0; j < Nodes[i].Length; j++)
                {
                    Nodes[i][j].UpdateValue();
                }
            }
        }

        public void UpdateWeights(int x, int y, int z, TriangularNumber number)
        {
            Nodes[x][y].InWeights[z] = number;
        }

        public void UpdateWeights(int x, int y, int z, double a, double b, double c)
        {
            var number = new TriangularNumber(a, b, c);
            UpdateWeights(x, y, z, number);
        }

        public void Print()
        {
            int lineLength = 40;
            foreach (var layer in Nodes)
            {
                int interval = lineLength / (layer.Length + 1);
                StringBuilder sb = new StringBuilder();

                foreach (var node in layer)
                {
                    string s = node.ToString();
                    int spaces = interval - (s.Length / 2);
                    
                    for (int i = 0; i < spaces; i++)
                    {
                        sb.Append(' ');
                    }

                    sb.Append(s);
                }

                Console.WriteLine(sb.ToString());
                Console.WriteLine();
            }
        }
    }
}
