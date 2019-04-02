using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects_Engineers_Data;
using Utilities;

namespace Projects_Engineers_BusinessRule
{
    public class UserManager
    {
        IDataAccess<PE_User> contextUser;
        UtilitiesManager objUtilities = new UtilitiesManager();

        public UserManager(IDataAccess<PE_User> contextUser)
        {
            this.contextUser = contextUser;
        }

        public List<PE_User> readUsers()
        {
            List<PE_User> users = contextUser.Collection().ToList();

            return users;
        }

        public PE_User readUser(int Id)
        {
            PE_User usr = contextUser.Find(Id);

            return usr;
        }

        public PE_User readUserCredentials(string email, string password)
        {
            PE_User usr = (from user in contextUser.Collection().Where(x => x.Email.Equals(email) && x.Password.Equals(objUtilities.encryptPassword(password)))
                           select user).FirstOrDefault();

            return usr;
        }

        public void addUser(PE_User usr, string password)
        {
            usr.Password = objUtilities.encryptPassword(password);
            contextUser.Insert(usr);
            contextUser.Commit();
        }

        public void deleteUser(int Id)
        {
            PE_User usr = contextUser.Find(Id);

            if (usr != null)
            {
                contextUser.Delete(usr.Id);
                contextUser.Commit();
            }
        }

        public void updateUser(PE_User usr)
        {
            contextUser.Update(usr);
            contextUser.Commit();
        }
    }
}
