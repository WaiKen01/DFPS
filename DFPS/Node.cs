using System;
using System.Collections.Generic;
using System.Text;

namespace DFPS
{
    class Node
    {
        private string binaryString;
        private bool isLeftNode;
        private bool isRightNode;
        private Node left;
        private Node parent;
        private Node right;
        private char? character;
        private int frequency;
        
        //constructors
        public Node()
        {

        }
        public Node(char value)
        {
            this.character = value;
        }
        public Node(Node left, Node right)
        {
            this.left = left;
            this.left.parent = this;
            this.left.isLeftNode = true;

            this.right = right;
            this.right.parent = this;
            this.right.isRightNode = true;

            this.frequency = (left.frequency + right.frequency);
        }

        public string BinaryWord
        {
            get
            {
                string binStr = "";

                if (String.IsNullOrEmpty(binaryString) == true)
                {
                    StringBuilder strBuilder = new StringBuilder();

                    Node node = this;

                    while (node != null)
                    {
                        if (node.isLeftNode == true)
                        {
                            strBuilder.Insert(0, "0");
                        }

                        if (node.isRightNode == true)
                        {
                            strBuilder.Insert(0, "1");
                        }

                        node = node.parent;
                    }

                    binStr = strBuilder.ToString();
                    binaryString = binStr;
                }
                else
                {
                    binStr = binaryString;
                }
                return binStr;
            }
        }

        public Node leftNode
        {
            get
            {
                return left;
            }
        }

        public Node rightNode
        {
            get
            {
                return right;
            }
        }

        public Node parentNode
        {
            get
            {
                return parent;
            }
        }

        public char? charValue
        {
            get
            {
                return character;
            }
        }

        public int Frequency
        {
            get
            {
                return frequency;
            }
            set
            {
                frequency = value;
            }
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();

            if (character.HasValue == true)
            {
                strBuilder.AppendFormat("'{0}' ({1}) - {2} ({3})", character.Value, frequency, BinaryWord, BinaryStringToInt32(BinaryWord));
            }
            else
            {
                if ((left != null) && (right != null))
                {
                    if ((left.charValue.HasValue == true) && (right.charValue.HasValue == true))
                    {
                        strBuilder.AppendFormat("{0} + {1} ({2})", left.charValue, right.charValue, frequency);
                    }
                    else
                    {
                        strBuilder.AppendFormat("{0}, {1} - ({2})", left, right, frequency);
                    }
                }
                else
                {
                    strBuilder.Append(frequency);
                }
            }

            return strBuilder.ToString();
        }

        public int BinaryStringToInt32(string charValue)
        {
            int iBinaryStringToInt32 = 0;

            for (int i = (charValue.Length - 1), j = 0; i >= 0; i--, j++)
            {
                iBinaryStringToInt32 += ((charValue[j] == '0' ? 0 : 1) * (int)(Math.Pow(2, i)));
            }

            return iBinaryStringToInt32;
        }

    }
}
