using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VirtualWhirlwind.Truss.Logic.Support
{
    public interface IAdvancedINI
    {
        List<KeyValuePair<string, object>> Values { get; set; }

		void Clear();
	}

	public class AdvancedINI : IAdvancedINI
    {
        #region Properties
        public List<KeyValuePair<string, object>> Values { get; set; }
		#endregion

		#region Methods
		public void Clear()
		{
			Values.Clear();
		}
		#endregion
	}
}
