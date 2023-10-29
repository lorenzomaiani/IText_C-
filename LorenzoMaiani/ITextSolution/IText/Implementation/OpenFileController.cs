using System;
using System.IO;
using IText.Interface;

namespace IText.Implementation
{
    public class OpenFileController : IOpenFileController
    {
        private FileModel _fileModel;

        public OpenFileController(string path, string name)
        {
            _fileModel = new FileModel(path, name);
        }
        
        public bool IsAExistFile()
        {
            return System.IO.File.Exists(_fileModel.GetFilePath() + _fileModel.GetFileName());
        }

        public string ReadFromFile()
        {
            return OperationOnFile();
        }
        
        private string OperationOnFile()
        {
            string text = "";
            try
            {
                string line = "";
                StreamReader reader = new StreamReader(_fileModel.GetFilePath() + _fileModel.GetFileName());
                while((line = reader.ReadLine()) != null)
                {
                    text += line;
                }
                return text;
            } 
            catch (IOException e)
            {
                Console.WriteLine("Errore - impossibili leggere dal file: " + _fileModel.GetFileName() + _fileModel.GetFileName());
                return null;
            }
        }
    }
}