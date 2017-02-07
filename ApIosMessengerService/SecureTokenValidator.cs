using System;
using System.Security.Claims;
using Owin.StatelessAuth;
using System.Collections.Generic;
using Jose;
using Newtonsoft.Json;

namespace ApIosMessengerService
{
    internal class SecureTokenValidator : ITokenValidator
    {
        public ClaimsPrincipal ValidateUser(string token)
        {
            try
            {
                string secretKey = System.Configuration.ConfigurationManager.AppSettings["SecretKey"].ToString();
                byte[] secretKeyBytes = System.Text.Encoding.UTF8.GetBytes(secretKey);
                string json = Jose.JWT.Decode(token, secretKeyBytes, JwsAlgorithm.HS256);
                Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                if (values.Count == 0)
                    return null;
                
                return new ClaimsPrincipal();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}