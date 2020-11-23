using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using DatabaseConnection;
using Microsoft.EntityFrameworkCore;

namespace FlexApp.User
{
    public static class AppLogin
    {
              
        public static string Login(UserSession user, string username, string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                password = sb.ToString();
            }

            try
            {
                using(Context ct = new Context())
                {
                    user.Customer = ct.Customers.Where(x => x.
                        Login.Username == username && x.
                        Login.Password == password)
                        .First();

                    user.IsLoggedIn = true;
                }
                return Helper.Message.LoginSuccessful;

            }
            catch
            {
                return Helper.Message.LoginFailed;
            }
        }
        
    }
}
