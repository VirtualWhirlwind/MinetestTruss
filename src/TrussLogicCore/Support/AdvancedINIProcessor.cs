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
		public static IAdvancedINI Read(string filePath, IAdvancedINI readInto = null)
		{
			if (readInto == null)
			{
				readInto = new AdvancedINI();
			}
			readInto.Clear();

			// TODO: determine most efficient cross framework file reading method
			string Contents = null;
			try
			{
				Contents = File.ReadAllText(filePath);
			}
			catch
			{

			}

			if (!string.IsNullOrWhiteSpace(Contents))
			{
				var Lines = Contents.Split(new char[] { '\n' }).ToList();

			}

			return readInto;
		}

		public static bool Save(string filePath, IAdvancedINI toSave)
		{
			bool Result = false;

			if (toSave != null)
			{
				StringBuilder Output = new StringBuilder();


				try
				{
					File.WriteAllText(filePath, Output.ToString());
				}
				catch
				{

				}
			}

			return Result;
		}
		#endregion

	}
}
