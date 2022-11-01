using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace DFPS
{
    public static class DeflateCompression
    {
        public static bool Compression(FileInfo file, string dest)
        {
            using FileStream infileStream = File.Open(file.FullName, FileMode.Open);
            string output = Path.Combine(dest, Path.ChangeExtension(file.Name, "dfl"));
            string ext = file.Extension;
            var extByte = Encoding.ASCII.GetBytes(ext);
            int extLength = ext.Length;
            byte[] extLengthByte = BitConverter.GetBytes(extLength);

            try
            {
                using (var outFileStream = new FileStream(output, FileMode.Create))
                {
                    outFileStream.Write(extLengthByte, 0, 4);
                    outFileStream.Write(extByte, 0, extLength);
                    using (var compressor = new DeflateStream(outFileStream, CompressionMode.Compress))
                    {
                        infileStream.CopyTo(compressor);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public static bool Decompression(FileInfo file, string dest)
        {
            using (var inFileStream = new FileStream(file.FullName, FileMode.Open))
            {
                Console.WriteLine("1");
                try
                {
                    //Get extension Length
                    byte[] extLengthByte = new byte[4];
                    inFileStream.Seek(0, SeekOrigin.Begin);
                    inFileStream.Read(extLengthByte, 0, 4);
                    int extLength = BitConverter.ToInt32(extLengthByte);

                    //Get extension
                    var extByte = new byte[extLength];
                    inFileStream.Seek(4, SeekOrigin.Begin);
                    inFileStream.Read(extByte, 0, extLength);
                    string ext = Encoding.ASCII.GetString(extByte);

                    //Get Content length and Content
                    var contentByte = new byte[inFileStream.Length - (extLength + 4)];
                    int contentByteLength = Convert.ToInt32(inFileStream.Length) - (extLength + 4);
                    inFileStream.Seek(4 + extLength, SeekOrigin.Begin);
                    inFileStream.Read(contentByte, 0, contentByteLength);
                    string output = Path.Combine(dest, Path.ChangeExtension(file.Name, ext));
                    using (var memoryStream = new MemoryStream(contentByte))
                    {
                        using (var outFileStream = new FileStream(output, FileMode.Create))
                        {
                            using (var decompressor = new DeflateStream(memoryStream, CompressionMode.Decompress))
                            {
                                decompressor.CopyTo(outFileStream);
                            }
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }
    }
}
