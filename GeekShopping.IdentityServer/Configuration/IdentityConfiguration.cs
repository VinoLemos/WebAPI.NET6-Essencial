using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace GeekShopping.IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("geek_shopping", "GeekShopping Server"),
                new ApiScope(name: "read", "Read data"),
                new ApiScope(name: "write", "write data"),
                new ApiScope(name: "delete", "Delete data")
            };

        public static IEnumerable<Client> Clients(IConfiguration configuration)=>
            new List<Client>
            {
                new()
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret(configuration["appsettings:IdentityServerSecret"].Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"read", "write", "profile"}
                },
                new()
                {
                    ClientId = "geek_shopping",
                    ClientSecrets = { new Secret(configuration["appsettings:IdentityServerSecret"].Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {"http://localhost:48964/signin-oidc"},
                    PostLogoutRedirectUris = {"http://localhost:48964/signout-callback-oidc"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "geek_shopping"
                    }
                },
            };
    }
}
