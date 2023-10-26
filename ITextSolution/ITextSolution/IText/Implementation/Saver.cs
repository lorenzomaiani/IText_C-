using System.Transactions;
using IText.Interface;

namespace IText.Implementation
{
    public class Saver : ISaver
    {
        private Info _info;

        public Saver(Info info)
        {
            _info = info;
        }
        
        
        public void SaveSettingInfo()
        {
            
        }
    }
}