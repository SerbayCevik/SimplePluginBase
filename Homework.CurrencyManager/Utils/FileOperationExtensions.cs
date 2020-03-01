﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Homework.CurrencyManagement.Utils
{
  public static class FileOperationExtensions
    {
        /// <summary>
        /// Saves output file operation
        /// </summary>
        /// <param name="val"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns>Return saves output file status </returns>
        public static bool TrySave(this string val,string path,string fileName)
        {
            try
            {
                using (StreamWriter wrt = new StreamWriter(File.Open(Path.Combine(path, fileName), FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)))
                {
                    wrt.Write(val);
                    wrt.Flush();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw new Exception("An exception occurred while saving file...");
            }
        }
    }
}
