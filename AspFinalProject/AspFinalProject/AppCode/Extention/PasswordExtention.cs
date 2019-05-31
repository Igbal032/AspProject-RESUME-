﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AspFinalProject
{
    public static class PasswordExtention
    {
           public static string HashPassword(string password)
        {

            byte[] byteArray = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashArray = new SHA256Managed().ComputeHash(byteArray);
            string hashedPassword = ASCIIEncoding.ASCII.GetString(hashArray);
            return hashedPassword;
        }

        public static bool CheckPassword(string password, string hashedpassword)
        {
            return HashPassword(password) == hashedpassword;
        }
    }
}