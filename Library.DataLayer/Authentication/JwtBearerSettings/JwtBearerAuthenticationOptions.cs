namespace Library.Infrastructure.Authentication.JwtBearerSettings
{
    public class JwtBearerAuthenticationOptions
    {
        public bool ValidateIssuer { get; set; }
        public bool ValidateAudience { get; set; }
        public bool ValidateLifetime { get; set; }
        public bool ValidateIssuerSigningKey { get; set; }
        public string? ValidIssuer { get; set; }
        public string? ValidAudience { get; set; }
        public string JwtSigningKey { get; set; }
        public int ClockSkewSeconds { get; set; }
    }
}
