﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace DFPS
{
    public static class Steganography
    {
        public static void Stegano(FileInfo secretFile, FileInfo coverFile, string pass, string destinationPath)
        {
            byte[] secretFileBytes = File.ReadAllBytes(secretFile.FullName);
            string secretFileType = secretFile.Extension;
            byte[] coverFileBytes = File.ReadAllBytes(coverFile.FullName);

            try
            {
                var cipherBytes = AESEncryption.EncryptByte(secretFileBytes, pass);
                var generatedIDBlock = GenerateIDBlock(secretFileBytes, secretFileType, coverFileBytes);
                var cipherBytesWithIdBlock = cipherBytes.Concat(AESEncryption.EncryptByte(generatedIDBlock, pass)).ToArray();
                string outFile = Path.Combine(destinationPath, coverFile.Name);
                File.WriteAllBytes(outFile, coverFileBytes.Concat(cipherBytesWithIdBlock).ToArray());
            } 
            catch (Exception ex)
            {

            }
        }

        public static void Extract(FileInfo stegoFile, string pass, string destinationPath)
        {
            var stegoFileBytes = File.ReadAllBytes(stegoFile.FullName);
            var retrievedIdBlockString = Encoding.ASCII.GetString(AESEncryption.DecryptByte(stegoFileBytes.Skip(stegoFileBytes.Length - 112).ToArray(), pass)).Split('|');
            if (retrievedIdBlockString.Length != 3) throw new Exception("File is corrupted or invalid");
            var retrievedHash = retrievedIdBlockString[0];
            var hiddenFileType = retrievedIdBlockString[1].ToLower();
            var keyIndex = Convert.ToInt32(retrievedIdBlockString[2]);
            
            var retrievedCipherBytesWithIdBlock = stegoFileBytes.Skip(keyIndex).ToArray();
            var retrievedCipherBytes = retrievedCipherBytesWithIdBlock.Take(retrievedCipherBytesWithIdBlock.Length - 112).ToArray();
            
            var retrievedSecretBytes = AESEncryption.DecryptByte(retrievedCipherBytes, pass);
            if (retrievedHash != SHA256Hash.generateHash(retrievedSecretBytes)) throw new Exception("File has been modified");

            string secretFile = Path.Combine(destinationPath, stegoFile.Name);
            File.WriteAllBytes(stegoFile.FullName, retrievedSecretBytes);
        }

        private static byte [] GenerateIDBlock(byte[] secretFileBytes, string secretFileType, byte[] coverFileBytes)
        {
            var hashBlock = SHA256Hash.generateHash(secretFileBytes);
            var generatedIdString = hashBlock + "|" + secretFileType + "|";
            var stegoFileKeyIndex = coverFileBytes.Length.ToString().PadLeft(64 - generatedIdString.Length, '0');
            var generatedIDBlock = Encoding.ASCII.GetBytes(generatedIdString + stegoFileKeyIndex);
            return generatedIDBlock;
        }
    }
}