using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Erp_Biscuiterie_Back.Utils.Helpers
{
    public class Crypto
    {
        public static string EncryptPassword(string Password)
        {
            //Define String Builder
            StringBuilder Encvalue = new StringBuilder();
            MD5CryptoServiceProvider crypto = new MD5CryptoServiceProvider();
            //Change password into Bytes
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(Password);
            bs = crypto.ComputeHash(bs);

            foreach (byte b in bs)
            {
                //append into String Builder with hexadecimal format
                Encvalue.Append(b.ToString("x2").ToLower());
            }

            return Encvalue.ToString();
        }
    }
}
