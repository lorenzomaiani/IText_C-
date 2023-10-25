using System;

namespace IText.Interface
{
    public interface ISaveFileController
    {
        bool CreateAFile();

        bool IsAlreadyExist();

        void SaveOnFile(string mess);
    }
}