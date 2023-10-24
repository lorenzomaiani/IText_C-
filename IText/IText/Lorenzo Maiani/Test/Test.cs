using IText.Lorenzo_Maiani.IText.File;
using IText.Lorenzo_Maiani.IText.SaveFileController;
using System;

namespace IText.Lorenzo_Maiani.Test
{
    class Test
    {
        public static void Main(string[] args)
        {
            OpenFileDialog dialog = new OpenFileDialog();


        }

        private void Test1()
        {
            Console.WriteLine("Inserire il path del file");
            string path = Console.ReadLine();
            Console.WriteLine("Inserire il nome del file");
            string name = Console.ReadLine();

            FileModel file = new FileModel(path,name);

            SaveFileController saveFileController = new SaveFileController(file.GetFilePath(), file.GetFileName());
            saveFileController.CreateAFile();
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " + "\n "+
                "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut " + "\n " +
                "enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut " + "\n " +
                "aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in " + "\n " +
                "voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint" + "\n " +
                " occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit" + "\n " +
                " anim id est laborum.";

            saveFileController.SaveOnFile(text);

        }

        
    }
}
