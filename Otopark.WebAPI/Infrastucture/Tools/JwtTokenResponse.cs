﻿namespace Otopark.WebAPI.Infrastucture.Tools
{
    public class JwtTokenResponse
    {
        public JwtTokenResponse(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}
