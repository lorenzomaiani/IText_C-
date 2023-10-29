using System;
using System.IO;
using IText.Interface;

namespace IText.Implementation
{
    public class Loader : ILoader
    {
        private Info _info;
        

        public Loader(Info info)
        {
            _info = info;
        }
        
        public void LoadSettingInfo(string directoryPath, string fileName)
        {
            string filePath = directoryPath + Path.DirectorySeparatorChar + fileName;
            if (File.Exists(filePath))
            {
                string[] settingInfo = ReadSettingInfoFromFile(filePath).Split('\n');
                _info.Setting.SetMainDirectory(settingInfo[0]);
                _info.Setting.SetFont(settingInfo[1]);
                if ("LIGHT".Equals(settingInfo[2]))
                {
                    _info.Setting.SetTheme(Theme.LIGHT);
                }
                else
                {
                    _info.Setting.SetTheme(Theme.DARK);
                }
              
            }
            
            
        }

        private string ReadSettingInfoFromFile(string path)
        {
            string text = "";
            try
            {
                StreamReader reader = new StreamReader(path);
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    text += line + '\n';
                }
                reader.Close();
                return text;
                
            } 
            catch (IOException e)
            {
                Console.WriteLine("Errore - impossibili leggere dal file");
                return null;
            }
        }
    }
}