using System;
using System.IO;
using IText.Implementation;
using IText.Interface;
using NUnit.Framework;

namespace Test
{
    public class Tests
    {
        private string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        private char sep = Path.DirectorySeparatorChar;
        string mess = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        
        [Test]
        public void CreateFile()
        {
            string path = home + sep + "Documents" + sep + "File.txt";
            string[] infoPath = path.Split("\\");
            string name = infoPath[infoPath.Length - 1];
            FileModel file = new FileModel(path,name);
            SaveFileController saveFileController = new SaveFileController(file.GetFilePath(), file.GetFileName());
            saveFileController.CreateAFile();
            
            Assert.True(File.Exists(path));
        }

        [Test]
        public void WriteOnFile()
        {
            string path = home + sep + "Documents" + sep + "File.txt";
            string[] infoPath = path.Split("\\");
            string name = infoPath[infoPath.Length - 1];
            FileModel file = new FileModel(path, name);
            ISaveFileController saveFileController = new SaveFileController(file.GetFilePath(), file.GetFileName());
            if(saveFileController.IsAlreadyExist())
            {
                saveFileController.SaveOnFile(mess);
            }
            else
            {
                Console.WriteLine("Il file non esiste, occorre prima crealro");
            }
        }

        [Test]
        public void ReadFromFile()
        {
            string path = home + sep + "Documents" + sep + "File.txt"; 
            string[] infoPath = path.Split("\\");
            string name = infoPath[infoPath.Length - 1];
            FileModel file = new FileModel(path, name);
            IOpenFileController openFileController = new OpenFileController(file.GetFilePath(), file.GetFileName());
            if (openFileController.IsAExistFile())
            {
                Assert.Equals(mess, openFileController.ReadFromFile());
            }
        }
        
        
    }
}