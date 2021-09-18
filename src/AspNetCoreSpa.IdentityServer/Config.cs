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
                new IdentityResources.OpenId()
                //new IdentityResources.Profile(),
                //new IdentityResources.Email()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("api1", "Backend Access")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "js",
                    ClientName = "VueApi JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = { "http://localhost:3000/callback" },
                    PostLogoutRedirectUris = { "http://localhost:3000" },
                    AllowedCorsOrigins = { "http://localhost:3000" },

                    AllowedScopes =
                    {
                        "api1"
                    }
                }
            };
    }
}