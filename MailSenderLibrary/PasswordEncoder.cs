﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailSenderLibrary
{
    public static class PasswordEncoder
    {
        public static string Encode(string pwd, int key = 3)
        {
            return new string(pwd.Select(c => (char)(c + key)).ToArray());
        }
        public static string Decode(string pwd, int key = 3)
        {
            return new string(pwd.Select(c => (char)(c - key)).ToArray());
        }
    }
}
