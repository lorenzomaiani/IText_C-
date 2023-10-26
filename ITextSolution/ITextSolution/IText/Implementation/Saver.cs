using System;
using System.IO;
using System.Transactions;
using IText.Interface;

namespace IText.Implementation
{
    public class Saver : ISaver
    {
        private Info _info;

        public Saver(Info info)
        {
            _info = info;
        }


        public void SaveSettingInfo(string fileName, string directoryPath)
        {
            FileStream fs = null;
            string filePath = directoryPath + Path.DirectorySeparatorChar + fileName;
            if (!Directory.Exists(directoryPath)  && !File.Exists(filePath))
            {
                Directory.CreateDirectory(directoryPath);
                fs = File.Create(filePath);
                
            }
            WriteSettingInfo(fs);
            
        }

        private void WriteSettingInfo(FileStream fs)
        {
            try
            {
                StreamWriter strW = new StreamWriter(fs);
                strW.WriteLine(_info.Setting.GetMainDirectory());
                strW.WriteLine(_info.Setting.GetFont());
                strW.WriteLine(_info.Setting.GetTheme());
                strW.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("Errore - impossibile salvare sul file -> " + e.Message);
            } catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Errore - impossibile salvare sul file -> " + e.Message);
            }
        }
    }
}