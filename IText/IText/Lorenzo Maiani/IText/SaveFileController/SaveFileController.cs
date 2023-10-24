
using IText.Lorenzo_Maiani.IText.File;
using System;
using System.IO;

namespace IText.Lorenzo_Maiani.IText.SaveFileController
{
    class SaveFileController
    {
        private FileModel fileModel;


        public SaveFileController(string path, string name)
        {
            this.fileModel = new FileModel(path, name);
        }

        public Boolean CreateAFile()
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
                    var fs = System.IO.File.Create(this.fileModel.GetFilePath());
                    Console.WriteLine("Creazione del file avvenuta con successo");
                    return fs != null ? true : false;

                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public Boolean IsAlreadyExist()
        {
            return System.IO.File.Exists(this.fileModel.GetFilePath());
        }

        public void SaveOnFile(String mess)
        {
            OperationOnFile(mess);
        }
       


        public void OperationOnFile(String mess)
        {
            try
            {
                StreamWriter strW = new StreamWriter(this.fileModel.GetFilePath());
                strW.WriteLine(mess);
                Console.WriteLine("Scrittura completata");
            }
            catch (IOException e)
            {
                Console.WriteLine("Errore - impossibile salvare sul file -> " + e.Message);
            }
        }
    }
}
