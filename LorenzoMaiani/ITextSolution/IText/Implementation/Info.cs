namespace IText.Implementation
{
    public class Info
    {
        private FileModel _fileModel;
        private Setting _setting;

        public FileModel FileModel
        {
            get => _fileModel;
            set => _fileModel = value;
        }

        public Setting Setting
        {
            get => _setting;
            set => _setting = value;
        }
        
        
    }
}