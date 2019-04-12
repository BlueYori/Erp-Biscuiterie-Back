using Erp_Biscuiterie_Back.Business.Helpers;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Erp_Biscuiterie_Back.Utils.Helpers
{
    public class Crypto
    {

        public static JwtSecurityToken getToken(int roleId)
        {
            //Security key for sign token and validate it later
            string securityKey = GlobalValue.SECRETKEY;

            //Symmetric security key
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            //Signing credentials
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            //Take Right Value for roleid
            var role = ExternalSqlActions.Instance.GetRole(roleId);

            var claim = new List<Claim>();
            claim.Add(new Claim(ClaimTypes.Role, role));

            //Create token
            var token = new JwtSecurityToken(
                    issuer: GlobalValue.ISSUER,
                    audience: GlobalValue.AUDIENCE,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: signingCredentials,
                    claims: claim
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            handler.WriteToken(token);
            return token;
            //return new JwtSecurityTokenHandler().WriteToken(token));
        }

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
