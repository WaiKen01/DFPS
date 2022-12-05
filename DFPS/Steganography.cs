using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace DFPS
{
    public static class Steganography
    {
        public static string Hide(FileInfo secretFile, FileInfo coverFile, string pass, string destinationPath)
        {
            byte[] secretFileBytes = File.ReadAllBytes(secretFile.FullName);
            string secretFileType = secretFile.Extension;
            byte[] coverFileBytes = File.ReadAllBytes(coverFile.FullName);

            try
            {
                var cipherBytes = AESEncryption.EncryptByte(secretFileBytes, pass);
                //generate ID Block
                var generatedIDBlock = GenerateIDBlock(secretFileBytes, secretFileType, coverFileBytes);
                //Append cipherBytes + encrypted generated ID block 
                var cipherBytesWithIdBlock = cipherBytes.Concat(AESEncryption.EncryptByte(generatedIDBlock, pass)).ToArray();
                string outFile = Path.Combine(destinationPath, coverFile.Name);
                File.WriteAllBytes(outFile, coverFileBytes.Concat(cipherBytesWithIdBlock).ToArray());
                File.Delete(secretFile.FullName);
                return outFile;
            } 
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string Extract(FileInfo stegoFile, string pass, string destinationPath)
        {
            var stegoFileBytes = File.ReadAllBytes(stegoFile.FullName);
            try
            {
                //retrieve ID Block
                var retrievedIdBlockString = Encoding.ASCII.GetString(AESEncryption.DecryptByte(stegoFileBytes.Skip(stegoFileBytes.Length - 128).ToArray(), pass)).Split('|');
                if (retrievedIdBlockString.Length != 3)
                {
                    return "corrupted";
                }
                var retrievedHash = retrievedIdBlockString[0];
                var hiddenFileType = retrievedIdBlockString[1].ToLower();
                var keyIndex = Convert.ToInt32(retrievedIdBlockString[2]);

                //retrieve Cipher Bytes  + ID block
                var retrievedCipherBytesWithIdBlock = stegoFileBytes.Skip(keyIndex).ToArray();
                var retrievedCipherBytes = retrievedCipherBytesWithIdBlock.Take(retrievedCipherBytesWithIdBlock.Length - 128).ToArray();
                
                var retrievedSecretBytes = AESEncryption.DecryptByte(retrievedCipherBytes, pass);
                if (retrievedHash != SHA256Hash.generateHash(retrievedSecretBytes))
                {
                    return "modified";
                }
    
                string outFile = Path.Combine(destinationPath, Path.ChangeExtension(DateTime.Now.ToString("yyyyMMddHHmmss"), hiddenFileType));
                File.WriteAllBytes(outFile, retrievedSecretBytes);
                return outFile;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static byte [] GenerateIDBlock(byte[] secretFileBytes, string secretFileType, byte[] coverFileBytes)
        {
            var hashBlock = SHA256Hash.generateHash(secretFileBytes);
            var generatedIdString = hashBlock + "|" + secretFileType + "|";
            var stegoFileKeyIndex = coverFileBytes.Length.ToString().PadLeft(80 - generatedIdString.Length, '0');
            var generatedIDBlock = Encoding.ASCII.GetBytes(generatedIdString + stegoFileKeyIndex);
            return generatedIDBlock;
        }
    }
}
