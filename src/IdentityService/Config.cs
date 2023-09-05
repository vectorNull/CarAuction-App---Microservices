using Duende.IdentityServer.Models;

namespace IdentityService;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("carAuctionApp", "Car Auction App full access"),
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                // Development only
                ClientId = "postman",
                ClientName = "Postman",
                AllowedScopes = { "openid", "profile", "carAuctionApp" },
                RedirectUris = { "https//www.getpostman.com/oauth2/callback" },
                ClientSecrets = new[] { new Secret("NotASecret".Sha256()) },
                AllowedGrantTypes = { GrantType.ResourceOwnerPassword }
            },
            new Client
            {
                ClientId = "nextApp",
                ClientName = "nextApp",
                ClientSecrets = { new Secret("SoSecret!".Sha256()) },
                AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                RequirePkce = false,
                RedirectUris = { "http://localhost:3000/api/v1/auth/callback/id-server" },
                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "carAuctionApp" },
                AccessTokenLifetime = 3600*24*30
            }
        };
}
