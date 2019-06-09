using ShopAccessApp.BackEnd.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAccessApp.BackEnd.Logics
{
    static public class UserManagement
    {
        static public UserType LoginAs(string login, string password)
        {
            users localUser = UserAccessor.GetByUsername(login);
            if (localUser.password == password)
            {
                return (UserType)localUser.access_level;
            }
            else
            {
                throw new Exception("Wrong password!");
            }
        }

        static public UserType RegisterAs(string login, string password, string registrationKey)
        {
            var localRegistration = RegistrationAccessor.GetByActivationCode(registrationKey);
            if (localRegistration != null)
            {
                UserAccessor.CreateNew(new users()
                {
                    username = login,
                    password = password,
                    access_level = localRegistration.access_level
                });
                RegistrationAccessor.DeleteByActivationCode(registrationKey);
                return (UserType)localRegistration.access_level;
            }
            else
            {
                throw new Exception($"Registration Key {registrationKey} does not exist!");
            }
        }
    }
}
