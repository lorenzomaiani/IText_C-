using System;
using System.IO;
using IText.Implementation;
using IText.Interface;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Test
{
    public class Tests
    {
        private static readonly string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        private static char _sep = Path.DirectorySeparatorChar;
        private string _mainDirectory = home + _sep + "Documents";
        private string _font = "Arial";
        private Theme _theme = Theme.LIGHT;
        string _mess = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        
        [Test]
        public void CreateFile()
        {
            string path = home + _sep + "Documents" + _sep + "File.txt";
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
            string path = home + _sep + "Documents" + _sep + "File.txt";
            string[] infoPath = path.Split("\\");
            string name = infoPath[infoPath.Length - 1];
            FileModel file = new FileModel(path, name);
            ISaveFileController saveFileController = new SaveFileController(file.GetFilePath(), file.GetFileName());
            if(saveFileController.IsAlreadyExist())
            {
                saveFileController.SaveOnFile(_mess);
            }
            else
            {
                Console.WriteLine("Il file non esiste, occorre prima crealro");
            }
        }

        [Test]
        public void ReadFromFile()
        {
            string path = home + _sep + "Documents" + _sep + "File.txt"; 
            string[] infoPath = path.Split("\\");
            string name = infoPath[infoPath.Length - 1];
            FileModel file = new FileModel(path, name);
            IOpenFileController openFileController = new OpenFileController(file.GetFilePath(), file.GetFileName());
            if (openFileController.IsAExistFile())
            {
                Assert.Equals(_mess, openFileController.ReadFromFile());
            }
        }

        [Test]
        public void UseSettingAsSingleton()
        {
            Setting setting = Setting.GetInstance();
            Setting anotherSetting = Setting.GetInstance();
            Assert.AreEqual(anotherSetting.GetMainDirectory(), setting.GetMainDirectory());
            Assert.AreEqual(anotherSetting.GetFont(), setting.GetFont());
            anotherSetting.SetTheme(Theme.DARK);
            // are still equals because setting is a singleton, one instance for all the object
            Assert.AreEqual(anotherSetting.GetTheme(), setting.GetTheme());
        }

        [Test]
        public void WriteSettingInfo()
        {
            Setting setting = Setting.GetInstance();
            setting.SetMainDirectory(_mainDirectory);
            setting.SetTheme(_theme);
            setting.SetFont(_font);
            Info info = new Info();
            info.Setting = setting;
            ISaver saver = new Saver(info);
            saver.SaveSettingInfo("Setting.txt", home + _sep + "Documents" + _sep + "Setting");
        }

        [Test]
        public void ReadSettingInfo()
        {
            Info info = new Info();
            Setting setting = Setting.GetInstance();
            // here info has nothigs settle
            Assert.Null(info.Setting);
            // instantiate setting
            info.Setting = setting;
            ILoader loader = new Loader(info);
            // load info from file
            loader.LoadSettingInfo(home + _sep + "Documents" + _sep + "Setting", "Setting.txt");
            Assert.AreEqual(_mainDirectory, info.Setting.GetMainDirectory());
            Assert.AreEqual(_font, info.Setting.GetFont());
            Assert.AreEqual(_theme, info.Setting.GetTheme());
        }
        
        
    }
}