using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VirtualWhirlwind.Truss.Logic.Support
{
    public interface IAdvancedINI
    {
        IAdvancedINI Parent { get; set; }
        List<KeyValuePair<string, object>> Values { get; set; }
        string FilePath { get; set; }

        bool Read();
        bool Read(string filePath);
        bool Save();
        bool Save(string filePath);
    }

    public class AdvancedINI : IAdvancedINI
    {
        #region Properties
        public IAdvancedINI Parent { get; set; }

        public List<KeyValuePair<string, object>> Values { get; set; }

        public string FilePath { get; set; }
        #endregion

        #region Methods
        public bool Read()
        {
            bool Result = false;
            if (Parent != null)
            {
                Result = Parent.Read();
            }
            else
            {
                // TODO: determine most efficient cross framework file reading method
                string Contents = null;
                try
                {
                    Contents = File.ReadAllText(FilePath);
                }
                catch
                {

                }

                if (!string.IsNullOrWhiteSpace(Contents))
                {
                    var Lines = Contents.Split(new char[] { '\n' });
                }
            }

            return Result;
        }

        public bool Read(string filePath)
        {
            bool Result = false;
            if (Parent != null)
            {
                Result = Parent.Read(filePath);
            }
            else
            {
                if (File.Exists(filePath)) { FilePath = filePath; }
                if (!string.IsNullOrWhiteSpace(FilePath)) { Read(); }
            }

            return Result;
        }

        public bool Save()
        {
            bool Result = false;
            if (Parent != null)
            {
                Result = Parent.Save();
            }
            else
            {

            }

            return Result;
        }

        public bool Save(string filePath)
        {
            bool Result = false;
            if (Parent != null)
            {
                Result = Parent.Save(filePath);
            }
            else
            {
                FilePath = filePath;
                Save();
            }

            return Result;
        }
        #endregion
    }
}
