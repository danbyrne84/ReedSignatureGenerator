using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ReedSignatureGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignatureController : ControllerBase
    {
        [HttpGet]
        public string Get([FromQuery] string token, [FromQuery] string stringToSign)
        {
            var hmacsha1 = new HMACSHA1(new Guid(token).ToByteArray());  // instantiate HMAC SHA1 with byte[]
            byte[] byteArray = System.Text.Encoding.ASCII.GetBytes(stringToSign);
            var computedHash = hmacsha1.ComputeHash(byteArray);

            var calculatedSignature = Convert.ToBase64String(computedHash);

            return calculatedSignature;
        }
    }
}
