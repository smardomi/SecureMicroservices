using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
           new Client[]
           {
                   new Client
                   {
                        ClientId = "movieClient",
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                        AllowedScopes = { "movieAPI" }
                   },
                   new Client
                   {
                       ClientId = "movies_mvc_client",
                       ClientName = "Movies MVC Web App",
                       AllowedGrantTypes = GrantTypes.Hybrid,
                       RequirePkce = false,
                       AllowRememberConsent = false,
                       RedirectUris = new List<string>()
                       {
                           "https://localhost:5002/signin-oidc"
                       },
                       PostLogoutRedirectUris = new List<string>()
                       {
                           "https://localhost:5002/signout-callback-oidc"
                       },
                       ClientSecrets = new List<Secret>
                       {
                           new Secret("secret".Sha256())
                       },
                       AllowedScopes = new List<string>
                       {
                           IdentityServerConstants.StandardScopes.OpenId,
                           IdentityServerConstants.StandardScopes.Profile,
                           IdentityServerConstants.StandardScopes.Address,
                           IdentityServerConstants.StandardScopes.Email,
                           "movieAPI",
                           "roles"
                       }
                   }
           };

        public static IEnumerable<ApiScope> ApiScopes =>
           new ApiScope[]
           {
               new ApiScope("movieAPI", "Movie API")
           };

        public static IEnumerable<ApiResource> ApiResources =>
          new ApiResource[]
          {
               //new ApiResource("movieAPI", "Movie API")
          };

        public static IEnumerable<IdentityResource> IdentityResources =>
          new IdentityResource[]
          {
              new IdentityResources.OpenId(),
              new IdentityResources.Profile(),
              new IdentityResources.Address(),
              new IdentityResources.Email(),
              new IdentityResource(
                    "roles",
                    "Your role(s)",
                    new List<string>() { "role" })
          };

        public static List<TestUser> TestUsers
        {
            get
            {
                var address = new
                {
                    street_address = "Jalalie",
                    locality = "Tabriz",
                    postal_code = 5173986375,
                    country = "Iran"
                };

                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "556456456",
                        Username = "saeed",
                        Password = "mardomi",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Saeed Mardomi"),
                            new Claim(JwtClaimTypes.GivenName, "Saeed"),
                            new Claim(JwtClaimTypes.FamilyName, "Mardomi"),
                            new Claim(JwtClaimTypes.Email, "saeedmardomi@hotmail.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://smardomi.ir"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                            new Claim(JwtClaimTypes.Role, "admin")
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "456456546",
                        Username = "Vahid",
                        Password = "mardomi",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Vahid Mardomi"),
                            new Claim(JwtClaimTypes.GivenName, "Vahid"),
                            new Claim(JwtClaimTypes.FamilyName, "Mardomi"),
                            new Claim(JwtClaimTypes.Email, "Vahid@gmail.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://Vahid.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json),
                            new Claim(JwtClaimTypes.Role, "user")
                        }
                    }
                };
            }
        }
    }
}
