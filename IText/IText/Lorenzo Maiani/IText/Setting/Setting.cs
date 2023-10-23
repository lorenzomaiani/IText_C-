using System;

namespace IText.Lorenzo_Maiani.IText.Setting
{
    class Setting
    {
        private static Setting instance;
        private string mainDirectory;
        private string font;
        private Theme theme;

        private Setting() 
        {
            mainDirectory = "";
            font = "";
            theme = Theme.LIGHT;
        }

        public static Setting GetInstance()
        {
            if( instance == null)
            {
                instance = new Setting();
            }
            return instance;
        }

        public string GetMainDirectory()
        {
            return this.mainDirectory;
        }

        public void SetMainDirectory(string mainDirectory)
        {
            this.mainDirectory = mainDirectory;
        }

        public string GetFont()
        {
            return this.font;
        }

        public void SetFont(string font)
        {
            this.font = font;
        }

        public Theme GetTheme()
        {
            return this.theme;
        }

        public void SetTheme(Theme theme)
        {
            this.theme = theme;
        }



    }
}
