using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Utilities
{
    public class UtilitiesManager
    {
        public byte[] encryptPassword(string password)
        {
            SHA512 sha512 = SHA512Managed.Create();

            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha512.ComputeHash(bytes);

            return hash;
        }
    }
}
