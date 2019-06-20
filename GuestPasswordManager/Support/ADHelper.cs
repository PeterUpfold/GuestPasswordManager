/*
 *
 * Licensed under the Code Project Open License (CPOL) 1.02
 * https://www.codeproject.com/info/cpol10.aspx
 *
 * https://www.codeproject.com/Articles/6848/Active-Directory-object-picker-control
 * 
 */
using System.Collections;
using System.DirectoryServices;

namespace GuestPasswordManager.Support
{
	public class ADHelper
	{
	    /// <summary>
	    /// Reference to logger
	    /// </summary>
	    private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger
	        (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Hashtable _htChildren = new Hashtable();
		private DirectoryEntry entry;

		public ADHelper()
		{
			
		}
		
		public void GetChildEntries()
		{
			GetChildEntries("");
		}

		public void GetChildEntries(string adspath)
		{
			if (adspath.Length > 0)
				entry = new DirectoryEntry(adspath);
			else
				entry = new DirectoryEntry();

			foreach (DirectoryEntry childEntry in entry.Children)
			{
				_htChildren.Add(childEntry.Name, childEntry.Path);
			}				
		}

		public Hashtable Children
		{
			get{ return _htChildren; }
		}
	}
}
