﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using DatabaseConnection;

namespace FlexApp.User
{
    public static class UserCreation
    {          
        public static void CreateNewUser(string fName, string lName, string eMail, string adress, string phoneNo, string userName, string passWord)
        {
            UserSession.ct.Customers.Add(new Customer()
            {
                FirstName = fName,
                LastName = lName,
                Email = eMail,
                Adress = adress,
                PhoneNumber = phoneNo,
                Login = new Login() { Username = userName, Password = Encrypt(passWord) }
            });
            UserSession.ct.SaveChanges();
        }

        public static string Encrypt(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
