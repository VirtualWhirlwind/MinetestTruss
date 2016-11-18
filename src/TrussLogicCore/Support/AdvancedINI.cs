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
        #region Fields
        protected List<KeyValuePair<string, object>> _Values = new List<KeyValuePair<string, object>>();
        #endregion

        #region Properties
        public List<KeyValuePair<string, object>> Values
        {
            get
            {
                return _Values;
            }
            set
            {
                _Values = value ?? new List<KeyValuePair<string, object>>();
            }
        }
		#endregion

		#region Methods
		public void Clear()
		{
			Values.Clear();
		}
		#endregion
	}
}
