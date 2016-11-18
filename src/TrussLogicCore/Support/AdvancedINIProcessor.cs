using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualWhirlwind.Truss.Logic.Support
{
    public static class AdvancedINIProcessor
    {
        #region Methods
        public static IAdvancedINI ReadFromFile(string filePath, IAdvancedINI readInto = null)
        {
            // TODO: determine most efficient cross framework file reading method
            string Contents = null;
            try
            {
                Contents = File.ReadAllText(filePath);
            }
            catch
            {
                // TODO: Log error here
            }

            return Read(Contents, readInto);
        }

        public static IAdvancedINI Read(string contents, IAdvancedINI readInto = null)
        {
            if (readInto == null)
            {
                readInto = new AdvancedINI();
            }
            readInto.Clear();


            if (!string.IsNullOrWhiteSpace(contents))
            {
                var Lines = contents.Split(new char[] { '\n' }).ToList();
                string[] Parts;

                List<IAdvancedINI> Tree = new List<IAdvancedINI>();
                Tree.Add(readInto);

                int TreeIndex = 0;
                Lines.ForEach(e =>
                {
                    if (!string.IsNullOrWhiteSpace(e.Trim()))
                    {
                        Parts = e.Split(new char[] { '=' }, 2);
                        for (int i = 0; i < Parts.Length; i++)
                        {
                            Parts[i] = Parts[i].Trim();
                        }

                        if (Parts.Length == 2)
                        {
                            if (Parts[1] == "{")
                            {
                                Tree.Add(new AdvancedINI());
                                TreeIndex++;
                                Tree[TreeIndex-1].Values.Add(new KeyValuePair<string, object>(Parts[0], Tree[TreeIndex]));
                            }
                            else
                            {
                                Tree[TreeIndex].Values.Add(new KeyValuePair<string, object>(Parts[0], Parts[1]));
                            }
                        }
                        else if (Parts.Length == 1)
                        {
                            if (Parts[0] == "}")
                            {
                                Tree.RemoveAt(TreeIndex);
                                TreeIndex--;
                            }
                            else
                            {
                                Tree[TreeIndex].Values.Add(new KeyValuePair<string, object>(Parts[0], null));
                            }
                        }
                    }
                });
            }

            return readInto;
        }

        public static bool SaveToFile(string filePath, IAdvancedINI toSave)
        {
            bool Result = false;

            string Content = Save(toSave);
            if (!string.IsNullOrWhiteSpace(Content))
            {
                try
                {
                    File.WriteAllText(filePath, Content);
                    Result = true;
                }
                catch
                {
                    // TODO: Log error here
                }
            }

            return Result;
        }

        public static string Save(IAdvancedINI toSave)
        {
            if (toSave != null)
            {
                StringBuilder Output = new StringBuilder();
                IterateValues(toSave.Values, ref Output, 0);
                return Output.ToString();
            }

            return null;
        }

        private static void IterateValues(List<KeyValuePair<string, object>> values, ref StringBuilder output, int indent)
        {
            foreach (KeyValuePair<string, object> kvp in values)
            {
                if (kvp.Value is IAdvancedINI)
                {
                    output.AppendFormat("{1}{0} = {{\n", kvp.Key, new string('\t', indent));
                    IterateValues(((IAdvancedINI)kvp.Value).Values, ref output, indent + 1);
                    output.AppendFormat("{0}}}\n", new string('\t', indent));
                }
                else if (kvp.Value == null)
                {
                    output.AppendFormat("{1}{0}\n", kvp.Key, new string('\t', indent));
                }
                else
                {
                    output.AppendFormat("{2}{0} = {1}\n", kvp.Key, kvp.Value.ToString(), new string('\t', indent));
                }
            }
        }
        #endregion
    }
}
