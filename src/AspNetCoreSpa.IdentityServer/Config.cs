// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;

namespace AspNetCoreSpa.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("backApi", "Back API")
            };

        public static IEnumerable<ApiResource> GetApiResources =>
            new List<ApiResource> 
            { 
                new ApiResource("backApi", "Back API") 
                { 
                    Scopes = { "backApi" } 
                } 
            };
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName = "Angular-Client",
                    ClientId = "angular-client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string>{ "http://localhost:8080/signin-callback", "http://localhost:8080/assets/silent-callback.html" },
                    //RedirectUris = new List<string>{ "http://localhost:4200/signin-callback", "http://localhost:4200/assets/silent-callback.html" },
                    RequirePkce = true,
                    AllowAccessTokensViaBrowser = true,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "backApi"
                    },
                    RequireClientSecret = false,
                    AllowedCorsOrigins = new List<string>{"http://localhost:8080"},
                    PostLogoutRedirectUris = new List<string> { "http://localhost:8080/signout-callback" },
                    //AllowedCorsOrigins = new List<string>{"http://localhost:4200"},
                    //PostLogoutRedirectUris = new List<string> { "http://localhost:4200/signout-callback" },
                    RequireConsent = false,
                    AccessTokenLifetime = 600
                }
            };
    }
}