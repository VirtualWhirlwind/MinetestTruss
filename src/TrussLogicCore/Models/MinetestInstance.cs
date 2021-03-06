﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualWhirlwind.Truss.Logic.Models
{
    public class MinetestInstance
    {
        #region Fields
        protected Guid _Id = Guid.Empty;
        #endregion

        #region Properties
        public Guid Id
        {
            get
            {
                if (_Id == Guid.Empty) { _Id = Guid.NewGuid(); }
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        public string Name { get; set; }

        public string BasePath { get; set; }
        #endregion

        #region Methods
        public bool Launch()
        {
            bool Result = false;

            if (Directory.Exists(BasePath))
            {
                //string Execute = Path.Combine(BasePath, "bin", "");
                string[] Executables = new string[] {
                    "pending", // Linux
                    "minetest.exe", // Windows
                    "pending" // Mac
                };

                int Index = 0;
                string Execute = "";

                do
                {
                    Execute = Path.Combine(BasePath, "bin", Executables[Index]);
                    if (File.Exists(Execute))
                    {
                        Process Prc = new Process();
                        Prc.StartInfo.FileName = Execute;
                        Prc.Start();
                        Result = true;
                    }
                    Index++;
                } while (Result == false && Index < Executables.Length);
            }

            return Result;
        }
        #endregion
    }
}
