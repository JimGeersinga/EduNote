using System;
using System.Collections.Generic;
using System.Text;

namespace EduNote.API.EF.Helpers
{
    public class Encryption
    {
        public static string HashPassword(string password)
        {
           return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool Verify(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
