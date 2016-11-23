using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualWhirlwind.Truss.Logic.Models
{
    public interface ITrussSettings
    {
        string SavePath { get; set; }

        Dictionary<Guid, MinetestInstance> Instances { get; set; }

        bool Save();
    }

    public class TrussSettings : ITrussSettings
    {
        #region Constants
        public const string SaveFileName = "TrussConfig.jset";
        #endregion

        #region Properties
        public string SavePath { get; set; }

        public Dictionary<Guid, MinetestInstance> Instances { get; set; }
        #endregion

        #region Methods
        static TrussSettings Load(string path)
        {
            return LoadFromFile(Path.Combine(path, SaveFileName));
        }

        static TrussSettings LoadFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    TrussSettings Result = JsonConvert.DeserializeObject(File.ReadAllText(fileName)) as TrussSettings;
                    return Result;
                }
                catch
                {
                    // TODO: Log error here
                }
            }
            return null;
        }

        public bool Save()
        {
            bool Result = false;

            string Content = JsonConvert.SerializeObject(this);
            try
            {
                File.WriteAllText(Path.Combine(SavePath, SaveFileName), Content);
                Result = true;
            }
            catch
            {
                // TODO: Log error
            }

            return Result;
        }
        #endregion
    }
}
