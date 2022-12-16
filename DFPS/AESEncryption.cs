using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace DFPS
{
    public static class AESEncryption
    {
        public static string Encrypt(string pass, FileInfo file, string destinationPath)
        {
            Aes aes = Aes.Create();
            //generate salt for hashing
            var salt = generateBytes();
            //hash the key
            var hashedKey = SHA256Hash.Hash(pass, salt);
            //file extension hashing
            var hashedExt = SHA256Hash.Hash(file.Extension, salt);

            //Salt
            int saltLength = salt.Length;
            byte[] saltLengthByte = BitConverter.GetBytes(saltLength);
            //IV
            int ivLength = aes.IV.Length;
            byte[] ivLengthByte = BitConverter.GetBytes(ivLength);
            //Extension
            int extLength = hashedExt.Length;
            byte[] extLengthByte = BitConverter.GetBytes(extLength);

            try
            {
                //assign the hashed key to AES
                aes.Key = hashedKey;
                ICryptoTransform transform = aes.CreateEncryptor();

                //destination file path + file name
                string outputFile = Path.Combine(destinationPath, Path.ChangeExtension(file.Name, ".enc"));

                //Output File Stream
                using (var outFileStream = new FileStream(outputFile, FileMode.Create))
                {
                    //Write salt length + IV length + ExtLength + Salt + IV + HashedExt + Encrypted Content
                    outFileStream.Write(saltLengthByte, 0, 4);
                    outFileStream.Write(ivLengthByte, 0, 4);
                    outFileStream.Write(extLengthByte, 0, 4);
                    outFileStream.Write(salt, 0, saltLength);
                    outFileStream.Write(aes.IV, 0, ivLength);
                    outFileStream.Write(hashedExt, 0, extLength);

                    //initialize crypto stream for encrypting the content
                    using (var outCryptoStream = new CryptoStream(outFileStream, transform, CryptoStreamMode.Write))
                    {
                        int count = 0;
                        int offset = 0;

                        int blockSizeBytes = aes.BlockSize / 8;
                        byte[] data = new byte[blockSizeBytes];
                        int bytesRead = 0;

                        //Input File Stream to read content
                        using (var inFileStream = new FileStream(file.FullName, FileMode.Open))
                        {
                            //Loop until reading all the bytes
                            do
                            {
                                //Read bytes and store into data
                                count = inFileStream.Read(data, 0, blockSizeBytes);
                                offset += count;
                                //Write encrypted bytes into output file
                                outCryptoStream.Write(data, 0, count);
                                bytesRead += blockSizeBytes;
                            } while (count > 0);
                        }
                        //clear the buffer
                        outCryptoStream.FlushFinalBlock();
                    }
                }
                return outputFile;
            }
            catch (Exception ex)
            {
                return null;
            } 
        }

        public static string Decrypt(string pass, FileInfo file, string destinationPath)
        {
            Aes aes = Aes.Create();

            byte[] saltLengthByte = new byte[4];
            byte[] ivLengthByte = new byte[4];
            byte[] extLengthByte = new byte[4];

            try
            {
                //initialize the input file stream and read the file
                using (var inFileStream = new FileStream(file.FullName, FileMode.Open))
                {
                    //Set position of the stream
                    inFileStream.Seek(0, SeekOrigin.Begin);
                    inFileStream.Read(saltLengthByte, 0, 3);

                    inFileStream.Seek(4, SeekOrigin.Begin);
                    inFileStream.Read(ivLengthByte, 0, 3);

                    inFileStream.Seek(8, SeekOrigin.Begin);
                    inFileStream.Read(extLengthByte, 0, 3);

                    int saltLength = BitConverter.ToInt32(saltLengthByte, 0);
                    int ivLength = BitConverter.ToInt32(ivLengthByte, 0);
                    int extLength = BitConverter.ToInt32(extLengthByte, 0);

                    //define start of cipher text 
                    int startOfCipher = saltLength + ivLength + extLength + 12;
                    //determine length of content
                    int lengthOfContent = (int)inFileStream.Length - startOfCipher;
                    
                    byte[] salt = new byte[saltLength];
                    byte[] iv = new byte[ivLength];
                    byte[] hashedExt = new byte[extLength];

                    inFileStream.Seek(12, SeekOrigin.Begin);
                    inFileStream.Read(salt, 0, saltLength);

                    inFileStream.Seek(12 + saltLength, SeekOrigin.Begin);
                    inFileStream.Read(iv, 0, ivLength);

                    inFileStream.Seek(12 + saltLength + ivLength, SeekOrigin.Begin);
                    inFileStream.Read(hashedExt, 0, extLength);

                    var hashedkey = SHA256Hash.Hash(pass, salt);
                    string ext = "";

                    if (SHA256Hash.compareHash(".pdf", salt, hashedExt))
                    {
                        ext = ".pdf";
                    }
                    else if (SHA256Hash.compareHash(".jpg", salt, hashedExt))
                    {
                        ext = ".jpg";
                    }
                    else if (SHA256Hash.compareHash(".csv", salt, hashedExt))
                    {
                        ext = ".csv";
                    }
                    else if (SHA256Hash.compareHash(".txt", salt, hashedExt))
                    {
                        ext = ".txt";
                    }
                    else if (SHA256Hash.compareHash(".doc", salt, hashedExt))
                    {
                        ext = ".doc";
                    }
                    else if (SHA256Hash.compareHash(".docx", salt, hashedExt))
                    {
                        ext = ".docx";
                    }
                    else if (SHA256Hash.compareHash(".mp3", salt, hashedExt))
                    {
                        ext = ".mp3";
                    }
                    else if (SHA256Hash.compareHash(".zip", salt, hashedExt))
                    {
                        ext = ".zip";
                    }
                    else if (SHA256Hash.compareHash(".png", salt, hashedExt))
                    {
                        ext = ".png";
                    }
                    else if (SHA256Hash.compareHash(".dfl", salt, hashedExt))
                    {
                        ext = ".dfl";
                    }
                    else if (SHA256Hash.compareHash(".xlsx", salt, hashedExt))
                    {
                        ext = ".xlsx";
                    }
                    else if (SHA256Hash.compareHash(".pptx", salt, hashedExt))
                    {
                        ext = ".pptx";
                    }
                    else if (SHA256Hash.compareHash(".mp4", salt, hashedExt))
                    {
                        ext = ".mp4";
                    }
                    else if (SHA256Hash.compareHash(".gif", salt, hashedExt))
                    {
                        ext = ".gif";
                    }
                    else if (SHA256Hash.compareHash(".svg", salt, hashedExt))
                    {
                        ext = ".svg";
                    }
                    else if (SHA256Hash.compareHash(".html", salt, hashedExt))
                    {
                        ext = ".html";
                    }
                    else if (SHA256Hash.compareHash(".mov", salt, hashedExt))
                    {
                        ext = ".mov";
                    }
                    else if (SHA256Hash.compareHash(".wav", salt, hashedExt))
                    {
                        ext = ".wav";
                    }
                    else
                    {
                        return null;
                    }

                    string outFile = Path.Combine(destinationPath, Path.ChangeExtension(file.Name, ext));
                    ICryptoTransform transform = aes.CreateDecryptor(hashedkey, iv);
                    //Output File Stream to generate decrypted file
                    using (var outputFileStream = new FileStream(outFile, FileMode.Create))
                    {
                        int count = 0;
                        int offset = 0;

                        int blockSizeBytes = aes.BlockSize / 8;
                        byte[] data = new byte[blockSizeBytes];

                        inFileStream.Seek(startOfCipher, SeekOrigin.Begin);
                        //Decrypt all the bytes of content
                        try
                        {
                            using (var outputCryptoStream = new CryptoStream(outputFileStream, transform, CryptoStreamMode.Write))
                            {
                                do
                                {
                                    count = inFileStream.Read(data, 0, blockSizeBytes);
                                    offset += count;
                                    outputCryptoStream.Write(data, 0, count);
                                } while (count > 0);
                                outputCryptoStream.FlushFinalBlock();
                            }
                            return outFile;
                        }
                        catch (Exception ex)
                        {
                            File.Delete(outFile);
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static byte[] EncryptByte(byte[] plainBytes, string pass)
        {
            //generate salt for hashing
            var salt = generateBytes();
            var IV = generateBytes();
            //hash the key
            var hashedKey = SHA256Hash.Hash(pass, salt);

            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Mode = CipherMode.CBC;
                    aes.BlockSize = 128;
                    aes.Padding = PaddingMode.PKCS7;

                    using (var encryptor = aes.CreateEncryptor(hashedKey, IV))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                var cipherTextBytes = salt;
                                cipherTextBytes = cipherTextBytes.Concat(IV).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return cipherTextBytes;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static byte[] DecryptByte(byte[] cipherByte, string pass)
        {
            var salt = cipherByte.Take(16).ToArray();
            var IV = cipherByte.Skip(16).Take(16).ToArray();
            var cipherTextBytes = cipherByte.Skip((32)).Take(cipherByte.Length - 32).ToArray();

            var hashedkey = SHA256Hash.Hash(pass, salt);

            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.BlockSize = 128;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (var decryptor = aes.CreateDecryptor(hashedkey, IV))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainBytes = new byte[cipherByte.Length];
                                var decryptByteCount = cryptoStream.Read(plainBytes, 0, plainBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return plainBytes.SubArray(0, decryptByteCount);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        private static byte [] generateBytes()
        {
            //generate 128bits 
            var randomBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                //fill randomBytes with random values
                rng.GetBytes(randomBytes);
                return randomBytes;
            }
        }


        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
