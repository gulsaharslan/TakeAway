// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace TakeAway.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission"}},
            new ApiResource("ResourceCatalog2"){Scopes={"CatalogReadPermission"}},
            new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"}},
            new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"}},
            new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"}},
            new ApiResource("ResourceBasket"){Scopes={"BasketFullPermission"}},
            new ApiResource("ResourceComment"){Scopes={"CommentFullPermission"}},
            new ApiResource("ResourceMessage"){Scopes={"MessageFullPermission"}},
            new ApiResource("ResourceOselot"){Scopes={"OselotFullPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full Authority For Catalog Operations"),
            new ApiScope("CatalogReadPermission","Catalog Read Operations"),
            new ApiScope("OrderFullPermission","Full Authority For Order Operations"),
            new ApiScope("DiscountFullPermission","Full Authority For Discount Operations"),
            new ApiScope("CargoFullPermission","Full Authority For Cargo Operations"),
            new ApiScope("BasketFullPermission","Full Authority For Basket Operations"),
            new ApiScope("CommentFullPermission","Full Authority For Comment Operations"),
            new ApiScope("MessageFullPermission","Full Authority For Message Operations"),
            new ApiScope("OselotFullPermission","Full Authority For Oselot Operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)

        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {
                ClientId="TakeAwayVisitorId",
                ClientName="TakeAway Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("takeawaysecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission",IdentityServerConstants.LocalApi.ScopeName },
                AllowAccessTokensViaBrowser=true,
            },

            new Client
            {
                ClientId="TakeAwayAdminId",
                ClientName="TakeAway Admin User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("takeawaysecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission","OrderFullPermission","DiscountFullPermission","CargoFullPermission","BasketFullPermission","CommentFullPermission","MessageFullPermission","OselotFullPermission",IdentityServerConstants.LocalApi.ScopeName,IdentityServerConstants.StandardScopes.Email,IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile},
               AccessTokenLifetime=600
            }
        };
    }
}