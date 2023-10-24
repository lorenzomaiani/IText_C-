using System;

namespace IText.Lorenzo_Maiani.IText.File
{
    class FileModel
    {
        private string path;
        private string name;
        private DateTime date;

        public FileModel(string path, string name)
        {
            this.name = name;
            this.path = path;
        }

        public void SetFilePath(string path)
        {
            this.path = path;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetFileName()
        {
            return this.name;
        }

        public string GetFilePath()
        {
            return this.path;
        }

        public override Boolean Equals(Object o)
        {
            if(this == o)
            {
                return true;
            }
            if(o == null || GetType() != o.GetType()) 
            {
                return false;
            }
            FileModel fileModel = (FileModel) o;
            return this.path.Equals(fileModel.GetFilePath()) && this.name.Equals(fileModel.GetFileName());
        }

    }
}
