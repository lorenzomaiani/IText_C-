namespace IText.Implementation
{
    public class Setting
    {
        private static Setting _instance;
        private string _mainDirectory;
        private string _font;
        private Theme _theme;

        private Setting() 
        {
            _mainDirectory = "";
            _font = "";
            _theme = Theme.LIGHT;
        }

        public static Setting GetInstance()
        {
            if( _instance == null)
            {
                _instance = new Setting();
            }
            return _instance;
        }

        public string GetMainDirectory()
        {
            return this._mainDirectory;
        }

        public void SetMainDirectory(string mainDirectory)
        {
            this._mainDirectory = mainDirectory;
        }

        public string GetFont()
        {
            return this._font;
        }

        public void SetFont(string font)
        {
            this._font = font;
        }

        public Theme GetTheme()
        {
            return this._theme;
        }

        public void SetTheme(Theme theme)
        {
            this._theme = theme;
        }
    }
}