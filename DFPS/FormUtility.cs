using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DFPS
{
    public static class FormUtility
    {
        public static bool validateMatch(string str1, string str2)
        {
            return string.Compare(str1, str2) == 0;
        }
        public static bool validateDestination(string dest)
        {
            return System.IO.Directory.Exists(dest) && dest != "";
        }
        public static bool validateFileExisted(string filePath)
        {
            return System.IO.File.Exists(filePath) && filePath != "";
        }

        public static bool validateFileExtension(string fileName, int length, string ext)
        {
            if (getLast(fileName, length).Equals(ext))
            {
                return true;
            }
            return false;
        }
        public static bool validateIfEmpty(string str)
        {
            return string.IsNullOrEmpty(str);
        }
        public static bool validateLength(string str, int min, int max)
        {
            return str.Length >= min && str.Length <= max;
        }

        public static string getLast(string str, int length)
        {
            if(str.Length >= length)
            {
                return str.Substring(str.Length - length);
            }
            return null;
        }

        public static string fileSize (long size)
        {
            int sizeCheck = 0;
            string sizeWord = "Byte";
            double sizeD = Convert.ToDouble(size);
            for (int i = 0; sizeD >= 1024; i++)
            {
                sizeD = sizeD / 1024;
                sizeCheck++;
            }
            if (sizeCheck == 1)
            {
                sizeWord = "KB";
            }
            else if (sizeCheck == 2)
            {
                sizeWord = "MB";
            }
            else if (sizeCheck == 3)
            {
                sizeWord = "GB";
            }
            return sizeD.ToString("0.##") + sizeWord;
        }

        public static void disableButton(Button button)
        {
            button.Enabled = false;
        }
        public static void reactivateButton(Button button)
        {
            button.Enabled = true;
        }

    }
}