using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Playlist.Web.Utilities
{
    public static class PasswordUtilities
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Calculate the hash of the password
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                //Convert the bytes of the hash into a hexadecimal string. 
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}