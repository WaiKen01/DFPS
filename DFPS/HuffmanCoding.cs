using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace DFPS
{
    static class HuffmanCoding
    {
        public static bool Compression(FileInfo file, string dest)
        {
            HuffmanTree huffmanTree = new HuffmanTree();
            var fileBytes = File.ReadAllBytes(file.FullName);
            string fileString = Encoding.ASCII.GetString(fileBytes);

            try
            {
                huffmanTree.Build(fileString);
                BitArray encoded = huffmanTree.Encode(fileString);

                byte[] encodedBytes = new byte[encoded.Length / 8 + (encoded.Length % 8 == 0 ? 0 : 1)];
                encoded.CopyTo(encodedBytes, 0);

                string output = Path.Combine(dest, Path.ChangeExtension(file.Name, ".bin"));
                File.WriteAllBytes(output, encodedBytes);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static bool Decompression(FileInfo file, string dest)
        {
            try
            {
                HuffmanTree huffmanTree = new HuffmanTree();
                var encodedBytes = File.ReadAllBytes(file.FullName);
                var encodedBit = new BitArray(encodedBytes);
                string decoded = huffmanTree.Decode(encodedBit);

                var decodedBytes = Encoding.ASCII.GetBytes(decoded);

                string output = Path.Combine(dest, Path.ChangeExtension(file.Name,".txt"));
                File.WriteAllBytes(output, decodedBytes);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
