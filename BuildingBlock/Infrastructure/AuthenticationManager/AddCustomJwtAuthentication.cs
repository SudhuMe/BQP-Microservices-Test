using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;


namespace Infrastructure.AuthenticationManager;

public static class CustomJwtAuthExtension
{
    public static void AddCustomJwtAuthentication(this IServiceCollection services,  string secret, string issuer)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(jwt =>
        {
            var key = Encoding.ASCII.GetBytes("ThisIsASecretForTestingMicroServicesBase");
            
            jwt.SaveToken = true;
            jwt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = issuer,
                ValidAudiences = new List<string>() { "BQPTest.com" },
                ValidateAudience = true,
                RequireExpirationTime = true,
                ValidateLifetime = true
            };
        });

    }
}
