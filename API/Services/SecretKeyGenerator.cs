using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class SecretKeyGenerator
    {
        public SecretKeyGenerator()
        {
        }

        public string GenerateRsaCryptoServiceProviderKey()
        {
            var rsaProvider = new RSACryptoServiceProvider(512);
            SecurityKey key = new RsaSecurityKey(rsaProvider);

            // this._logger.LogInformation(key.ToString())    ;
            return key.ToString();
        }
    }
}