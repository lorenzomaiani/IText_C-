using System;
using System.IO;
using IText.Interface;

namespace IText.Implementation
{
    public class SaveFileController : ISaveFileController
    {
        private FileModel _fileModel;

        public SaveFileController(string path, string name)
        {
            _fileModel = new FileModel(path, name);
        }
        
        public bool CreateAFile()
        {
            try
            {
                if (IsAlreadyExist())
                {
                    Console.WriteLine("Impossibile creare il file, esso esiste già");
                    return false;
                }
                else
                {
                    FileStream fs = File.Create(_fileModel.GetFilePath());
                    Console.WriteLine("Creazione del file avvenuta con successo");
                    return fs != null;

                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return false;
            } catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool IsAlreadyExist()
        {
            return File.Exists(_fileModel.GetFilePath());
        }

        public void SaveOnFile(string mess)
        {
            OperationOnFile(mess);
        }
        
        private void OperationOnFile(String mess)
        {
            try
            {
                StreamWriter strW = new StreamWriter(new FileStream(_fileModel.GetFilePath(), FileMode.Append));
                strW.WriteLine(mess);
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