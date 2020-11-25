﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using DatabaseConnection;
using Microsoft.EntityFrameworkCore;

namespace FlexApp.User
{
    public static class LogIn
    {           
        public static string Login(string username, string password)
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
                Status.Customer = Status.ct.Customers.Where(x => x.
                    Login.Username == username && x.
                    Login.Password == password)
                    .First();

                Status.IsLoggedIn = true;

                return Helper.Message.LoginSuccessful;
            }
            catch
            {
                return Helper.Message.LoginFailedWrongUsernameOrPassword;
            }
        }       
    }
}
