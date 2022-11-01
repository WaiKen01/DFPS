using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DFPS
{
    class HuffmanCoding
    {
        private Node rootHuffmanNode;
        private List<Node> valueHuffmanNodes;

        private List<Node> BuildHuffmanTree(string value) 
        {
            List<Node> huffmanNodes = GetInitialNodeList();

            value.ToList().ForEach(c => huffmanNodes[c].Frequency++);

            huffmanNodes = huffmanNodes.Where(c => (c.Frequency > 0))
                .OrderBy(c => (c.Frequency))
                .ThenBy(c => (c.charValue))
                .ToList();

            huffmanNodes = UpdateNodeParents(huffmanNodes);
            rootHuffmanNode = huffmanNodes[0];
            huffmanNodes.Clear();

            SortNodes(rootHuffmanNode, huffmanNodes);
            return huffmanNodes;
        }

        public void Compression(FileInfo file, string dest)
        {
            string fileContent = "";

            //Read file content into string
            using (StreamReader strReader = new StreamReader(File.OpenRead(file.FullName)))
            {
                fileContent = strReader.ReadToEnd();
            }

            List<Node> huffmanNodes = BuildHuffmanTree(fileContent);

            valueHuffmanNodes = huffmanNodes.Where(c => (c.charValue.HasValue == true))
                .OrderBy(c => (c.BinaryWord))
                .ToList();

            Dictionary<char, string> charToBinaryDictionary = new Dictionary<char, string> ();

            foreach(Node huffmanNode in valueHuffmanNodes)
            {
                charToBinaryDictionary.Add(huffmanNode.charValue.Value, huffmanNode.BinaryWord);
            }

            //Compress according to Huffman Coding and turn into list of bytes
            StringBuilder strBuilder = new StringBuilder();
            List<byte> byteList = new List<byte>();
            for(int i=0; i <fileContent.Length; i++)
            {
                string binaryString = "";

                strBuilder.Append(charToBinaryDictionary[fileContent[i]]);

                while(strBuilder.Length >= 8)
                {
                    binaryString = strBuilder.ToString().Substring(0, 8);
                    strBuilder.Remove(0, binaryString.Length);
                }

                if(String.IsNullOrEmpty(binaryString) == false)
                {
                    byteList.Add(Convert.ToByte(binaryString, 2));
                }
            }

            //retrieve any value left in buffer
            if (strBuilder.Length > 0)
            {
                string binString = strBuilder.ToString();

                if (String.IsNullOrEmpty(binString) == false)
                {
                    byteList.Add(Convert.ToByte(binString, 2));
                }
            }

            //Output compressed file
            string output = Path.Combine(dest,Path.ChangeExtension(file.Name,"comp"));

            using (FileStream fileStream = File.OpenWrite(output))
            {
                fileStream.Write(byteList.ToArray(), 0, byteList.Count);
            }
        }

        public void Decompression(FileInfo file, string dest)
        {
            byte[] buffer = null;

            using(FileStream fileStream = File.OpenRead(file.FullName))
            {
                buffer = new byte[fileStream.Length];
                fileStream.Read(buffer, 0, buffer.Length);
            }

            Node zeroNode = rootHuffmanNode;
            while (zeroNode.leftNode != null)
            {
                zeroNode = zeroNode.leftNode;
            }

            Node currentNode = null;
            StringBuilder strBuilder = new StringBuilder();

            for(int i = 0; i < buffer.Length; i++)
            {
                string binaryString = "";
                byte singleByte = buffer[i];

                if(singleByte == 0)
                {
                    binaryString = zeroNode.BinaryWord;
                }
                else
                {
                    binaryString = Convert.ToString(singleByte, 2);
                }

                if ((binaryString.Length < 8) && (i < (buffer.Length - 1)))
                {
                    StringBuilder binaryStrBuilder = new StringBuilder(binaryString);
                    while (binaryStrBuilder.Length < 8)
                    {
                        binaryStrBuilder.Insert(0, "0");
                    }
                    binaryString = binaryStrBuilder.ToString();
                }

                for(int j = 0; j < binaryString.Length; j++)
                {
                    char character = binaryString[j];

                    if(currentNode == null)
                    {
                        currentNode = rootHuffmanNode;
                    }

                    if(character == '0')
                    {
                        currentNode = currentNode.leftNode;
                    }
                    else
                    {
                        currentNode = currentNode.rightNode;
                    }

                    if ((currentNode.leftNode == null) && (currentNode.rightNode == null))
                    {
                        strBuilder.Append(currentNode.charValue.Value);
                        currentNode = null;
                    }   
                }
            }
            string output = Path.Combine(dest, Path.ChangeExtension(file.Name, "decomp"));

            using (StreamWriter strWriter = new StreamWriter(File.OpenWrite(output)))
            {
                strWriter.Write(strBuilder.ToString());
            }
        }

        private static List<Node> GetInitialNodeList()
        {
            List<Node> getNodeList = new List<Node>();

            for (int i = Char.MinValue; i < Char.MaxValue; i++)
            {
                getNodeList.Add(new Node((char)(i)));
            }

            return getNodeList;
        }

        private static void SortNodes(Node node, List<Node> nodes)
        {
            if (nodes.Contains(node) == false)
            {
                nodes.Add(node);
            }
            if(node.leftNode != null)
            {
                SortNodes(node.leftNode, nodes);
            }
            if (node.rightNode != null)
            {
                SortNodes(node.rightNode, nodes);
            }
        }

        private static List <Node> UpdateNodeParents(List<Node> nodes)
        {
            while(nodes.Count > 1)
            {
                int operations = (nodes.Count / 2);
                for (int operation = 0, i = 0, j = 1; operation < operations; operation++, i += 2, j += 2)
                {
                    if(j < nodes.Count)
                    {
                        Node parentNode = new Node(nodes[i], nodes[j]);
                        nodes.Add(parentNode);

                        nodes[i] = null;
                        nodes[j] = null;
                    }
                }

                nodes = nodes.Where(c => (c != null))
                    .OrderBy(c => (c.Frequency))
                    .ToList();
            }
            return nodes;
        }
    }
}
