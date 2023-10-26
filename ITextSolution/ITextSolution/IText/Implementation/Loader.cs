using IText.Interface;

namespace IText.Implementation
{
    public class Loader : ILoader
    {
        private Info _info;

        public Loader(Info info)
        {
            _info = info;
        }
        
        public void LoadSettingInfo()
        {
            
        }
    }
}