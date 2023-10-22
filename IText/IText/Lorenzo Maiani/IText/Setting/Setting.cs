using System;

namespace IText.Lorenzo_Maiani.IText.Setting
{
    class Setting
    {
        private static Setting instance;

        private Setting() 
        {

        }

        public static Setting GetInstance()
        {
            if( instance == null)
            {
                instance = new Setting();
            }
            return instance;
        }
    }
}
