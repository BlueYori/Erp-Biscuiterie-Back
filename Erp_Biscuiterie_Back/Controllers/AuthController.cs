using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Erp_Biscuiterie_Back.Business.Helpers;
using Microsoft.AspNetCore.Authorization;
using Erp_Biscuiterie_Back.Utils.Helpers;

namespace Erp_Biscuiterie_Back.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("token/{roleId}")]
        public ActionResult GetToken(int roleId)
        {

            //Security key for sign token and validate it later
            string securityKey = GlobalValue.SecretKey;

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
                    issuer: GlobalValue.Issuer,
                    audience: GlobalValue.Audience,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: signingCredentials,
                    claims: claim
                );

            //return token
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));

        }

        // GET api/values
        /*[HttpGet]
        [Authorize(Roles ="Administrator")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }*/
    }
}