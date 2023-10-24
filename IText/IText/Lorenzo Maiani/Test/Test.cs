using IText.Lorenzo_Maiani.IText.File;
using IText.Lorenzo_Maiani.IText.SaveFileController;
using System;
using System.IO;

namespace IText.Lorenzo_Maiani.Test
{
    class Test
    {
        public static void Main(string[] args)
        {
            Test t = new Test();
            //t.TestCreate();
            t.TestWrite();
        }

        private void TestCreate()
        {
            Console.WriteLine("Inserire path del File.txt da creare");
            string path = Console.ReadLine();
            string[] infoPath = path.Split("\\");
            string name = infoPath[infoPath.Length-1];
            LogInfoFile(name, path);
            FileModel file = new FileModel(path,name);
            SaveFileController saveFileController = new SaveFileController(file.GetFilePath(), file.GetFileName());
            saveFileController.CreateAFile();
        }  

        private void TestWrite()
        {
            Console.WriteLine("Inserire path del File.txt su cui scrivere");
            string path = Console.ReadLine();
            string[] infoPath = path.Split("\\");
            string name = infoPath[infoPath.Length - 1];
            LogInfoFile(name, path);
            FileModel file = new FileModel(path, name);
            SaveFileController saveFileController = new SaveFileController(file.GetFilePath(), file.GetFileName());
            string mess = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            if(saveFileController.IsAlreadyExist())
            {
                saveFileController.SaveOnFile(mess);
            }
            else
            {
                Console.WriteLine("Il file non esiste, occorre prima crealro");
            }
        }

        private static void LogInfoFile(string name, string path)
        {
            Console.WriteLine("Info:");
            Console.WriteLine("Nome file: " + name);
            Console.WriteLine("Path del file: " + path);
        }
    }
}
