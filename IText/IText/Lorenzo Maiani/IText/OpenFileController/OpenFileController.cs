using IText.Lorenzo_Maiani.IText.File;
using System;
using System.IO;

namespace IText.Lorenzo_Maiani.IText.OpenFileController
{
    class OpenFileController
    {
        private FileModel fileToOpen;

        public OpenFileController(string path, string name)
        {
            this.fileToOpen = new FileModel(path, name);
        }

        public Boolean IsAFile()
        {
            return System.IO.File.Exists(this.fileToOpen.GetFilePath()+this.fileToOpen.GetFileName());
        }

        public string ReadFromFile()
        {
            return OperationOnFile();
        }

        public string OperationOnFile()
        {
            string text = "";
            try
            {
                string line = "";
                StreamReader reader = new StreamReader(this.fileToOpen.GetFilePath() + this.fileToOpen.GetFileName());
                while((line = reader.ReadLine()) != null)
                {
                    text += line;
                }
                return text;
            } 
            catch (IOException e)
            {
                Console.WriteLine("Errore - impossibili leggere dal file: " + this.fileToOpen.GetFileName() + this.fileToOpen.GetFileName());
                return null;
            }
        }
    }
}
