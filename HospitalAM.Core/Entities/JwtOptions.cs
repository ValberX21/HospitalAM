﻿namespace HospitalAM.Core.Entities
{
    public sealed class JwtOptions
    {
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;          
        public int ExpirationMinutes { get; set; } = 60;
    }
}
