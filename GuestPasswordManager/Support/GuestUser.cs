using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using GuestPasswordManager.Properties;

namespace GuestPasswordManager.Support
{
    /// <summary>
    /// Object to hold information about an AD user and SQL Server user
    /// pair for which we will reset the password.
    /// </summary>
    class GuestUser
    {

        /// <summary>
        /// Reference to logger
        /// </summary>
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// A reference to the Active Directory user account.
        /// </summary>
        public UserPrincipal ADUser;

        /// <summary>
        /// The new password that has been set for the user.
        /// </summary>
        public string NewPassword;

        /// <summary>
        /// The email address assigned to the user.
        /// </summary>
        public string EmailAddress;

        /// <summary>
        /// Whether or not the user is enabled or disabled.
        /// </summary>
        public bool? Enabled { get => ADUser.Enabled; set => ADUser.Enabled = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="principal"></param>
        public GuestUser(UserPrincipal principal)
        {
            ADUser = principal;

            EmailAddress = ADUser.EmailAddress;

        }

        /// <summary>
        /// Load a list of supply user accounts from the specified OU container.
        /// </summary>
        /// <param name="ldapString"></param>
        /// <returns></returns>
        public static IEnumerable<GuestUser> LoadGuestUsers(string ldapString)
        {
            IList<GuestUser> userList = new List<GuestUser>();

            if (string.IsNullOrEmpty(ldapString))
            {
                return userList;
            }

            using (DirectorySearcher searcher = new DirectorySearcher(ldapString))
            {
                searcher.Filter = "(objectCategory=user)";
                searcher.SearchRoot = new DirectoryEntry(ldapString);
                searcher.SearchScope = SearchScope.OneLevel;
                searcher.PageSize = 1000;
                foreach (SearchResult result in searcher.FindAll())
                {
                    DirectoryEntry entry = result.GetDirectoryEntry();
                    UserPrincipal user = UserPrincipal.FindByIdentity(new PrincipalContext(ContextType.Domain), IdentityType.DistinguishedName, (string)entry.Properties["distinguishedName"].Value);

                    userList.Add(new GuestUser(user));
                }
            }

            return userList;

        }

        /// <summary>
        /// Generate a random password of <paramref name="length"/> characters length.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateRandomPassword(int length)
        {
            List<string> requiredSets = new List<string>()
            {
                MlkPwgen.Sets.Lower,
                MlkPwgen.Sets.Upper,
                MlkPwgen.Sets.Digits,
                ".-!?%*+",
            };

            return MlkPwgen.PasswordGenerator.GenerateComplex(length, requiredSets, password => 
                (!password.Contains("o") &&
                 !password.Contains("O") &&
                 !password.Contains("I") && 
                 !password.Contains("i") &&
                 !password.Contains("l") &&
                 !password.Contains("1") &&
                 !password.Contains("0"))
            );
        }

        /// <summary>
        /// Set the user's password in both Active Directory and in the MIS.
        /// </summary>
        public void SetPassword(string password)
        {
            ADUser.SetPassword(password); // allow exceptions to bubble up to UI

          
            ADUser.Save();
            NewPassword = password;
        }

        /// <summary>
        /// Return a string representation of the object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (ADUser != null)
            {
                return ADUser.SamAccountName;
            }
            return base.ToString();
        }
    }
}
