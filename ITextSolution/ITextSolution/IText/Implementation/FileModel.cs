using System;

namespace IText.Implementation
{
    public class FileModel
    {
        private string _path;
        private string _name;
        private DateTime _date;

        public FileModel(string path, string name)
        {
            this._name = name;
            this._path = path;
        }

        public void SetFilePath(string path)
        {
            this._path = path;
        }

        public void SetName(string name)
        {
            this._name = name;
        }

        public string GetFileName()
        {
            return this._name;
        }

        public string GetFilePath()
        {
            return this._path;
        }

        public override bool Equals(Object o)
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
            return this._path.Equals(fileModel.GetFilePath()) && this._name.Equals(fileModel.GetFileName());
        }
    }
}