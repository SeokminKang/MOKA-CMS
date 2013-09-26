using System;
using System.Linq;
using System.Xml.Linq;
using MokaCms.DataAccessFramework;

namespace MokaCms.Services
{
    /// <summary>
    /// This represents the account service entity.
    /// </summary>
    public class AccountService
    {
        /// <summary>
        /// Authenticate a user by username and password.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>Returns <c>True</c>, if authenticated; otherwise returns <c>False</c>.</returns>
        public bool Authenticate(string username, string password)
        {
            var authenticated = false;
            
            using (var context = new MokaCmsDataContext())
            {
                var user = context.Users.
                    SingleOrDefault(p => p.Username.ToLower() == username
                                                             && p.Password == password);
                if (user != null)
                    authenticated = true;

            }

            /*
            var doc = XDocument.Load(@"D:\Development\AliencubeConsulting\OpenSources\MOKA-CMS\Documents\XML Files\Users-justin.xml");

            if (doc.Root == null)
                throw new Exception("Invalid XML");

            authenticated =
                doc.Root.Elements("User")
                    .SingleOrDefault(
                        p =>
                            p.Element("Username").Value.ToLower() == username.ToLower() &&
                            p.Element("Password").Value == password) != null;

             */
            return authenticated;
        }

        public string GetUserRole(string username)
        {
            var result = String.Empty;

            using (var context = new MokaCmsDataContext())
            {
                var role = (from r in context.Roles
                             join ur in context.UserRoles 
                                 on r.RoleId equals ur.RoleId
                             join u in context.Users
                                 on ur.UserId equals u.UserId 
                                 where u.Username.ToLower() == username 
                                     select r).SingleOrDefault();

                if (role != null)
                    result = role.RoleDescription;



            }
            //var result = false;
            /*
            using (var context = new MokaCmsDataContext())
            {
                var user = context.Users.SingleOrDefault(p => p.Username.ToLower() == username );
                var roles = context.Roles.SingleOrDefault(p => p.RoleDescription.ToLower() == userRoles);

                if (user != null && roles !=null)
                    result = true;
            }
            
            */
            return result;
        }
    }
}