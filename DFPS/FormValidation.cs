using System;
using System.Collections.Generic;
using System.Text;

namespace DFPS
{
    public static class FormValidation
    {
        public static bool validatePassword(string pass, string conpass)
        {
            return pass == conpass;
        }

        public static bool validateDestination(string dest)
        {
            return System.IO.Directory.Exists(dest) && dest != "";
        }
        public static bool validateFileExisted(string filePath)
        {
            return System.IO.File.Exists(filePath) && filePath != "";
        }
    }
}