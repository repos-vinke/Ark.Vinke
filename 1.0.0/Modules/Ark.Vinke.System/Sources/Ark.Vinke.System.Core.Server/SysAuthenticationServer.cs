// SysAuthenticationServer.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

using System;
using System.Xml;
using System.Data;
using System.Linq;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

using Lazy.Vinke;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;
using Ark.Vinke.Library.Core.Server;
using Ark.Vinke.Framework;
using Ark.Vinke.Framework.Core;
using Ark.Vinke.Framework.Core.Data;
using Ark.Vinke.Framework.Core.IServer;
using Ark.Vinke.Framework.Core.IService;
using Ark.Vinke.Framework.Core.Server;
using Ark.Vinke.Facilities;
using Ark.Vinke.Facilities.Core;
using Ark.Vinke.Facilities.Core.Data;
using Ark.Vinke.Facilities.Core.IServer;
using Ark.Vinke.Facilities.Core.IService;
using Ark.Vinke.Facilities.Core.Server;
using Ark.Vinke.System;
using Ark.Vinke.System.Core;
using Ark.Vinke.System.Core.Data;
using Ark.Vinke.System.Core.IServer;
using Ark.Vinke.System.Core.IService;

namespace Ark.Vinke.System.Core.Server
{
    public class SysAuthenticationServer : FwkServer, ISysAuthenticationServer, ILibAuthenticationServer
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthenticationServer()
        {
            this.DataRequestType = typeof(SysAuthenticationDataRequest);
            this.DataResponseType = typeof(SysAuthenticationDataResponse);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="context">The request context</param>
        public void Authenticate(HttpContext context)
        {
            String headerToken = LazyConvert.ToString(context.Request.Headers["Token"], null);

            if (String.IsNullOrEmpty(headerToken) == false)
            {
                SysAuthenticationDataRequest authenticationDataRequest = new SysAuthenticationDataRequest();
                authenticationDataRequest.Content.Token = headerToken;

                SysAuthenticationDataResponse authenticationDataResponse = (SysAuthenticationDataResponse)InvokeService("Authenticate", authenticationDataRequest, context);

                if (authenticationDataResponse.Scope.StatusCode == LazyAttribute.GetCustomAttributeFromEnumValue<LazyAttributeGeneric>(FwkScopeStatus.Success).Code)
                {
                    if (authenticationDataResponse.Content.IdDomain > -1 && authenticationDataResponse.Content.IdUser > -1)
                    {
                        context.Items["DatabaseAlias"] = authenticationDataResponse.Content.DatabaseAlias;
                        context.Items["IdDomain"] = authenticationDataResponse.Content.IdDomain;
                        context.Items["IdUser"] = authenticationDataResponse.Content.IdUser;
                    }
                }
            }
            else
            {
                String headerDatabaseAlias = LazyConvert.ToString(context.Request.Headers["DatabaseAlias"], null);
                String headerDomainCode = LazyConvert.ToString(context.Request.Headers["DomainCode"], null);
                String headerUsername = LazyConvert.ToString(context.Request.Headers["Username"], null);
                String headerPassword = LazyConvert.ToString(context.Request.Headers["Password"], null);

                if (String.IsNullOrEmpty(headerDatabaseAlias) == false && String.IsNullOrEmpty(headerDomainCode) == false && String.IsNullOrEmpty(headerUsername) == false && String.IsNullOrEmpty(headerPassword) == false)
                {
                    context.Items["DatabaseAlias"] = headerDatabaseAlias;

                    SysAuthenticationDataRequest authenticationDataRequest = new SysAuthenticationDataRequest();
                    authenticationDataRequest.Content.DatabaseAlias = headerDatabaseAlias;
                    authenticationDataRequest.Content.DomainCode = headerDomainCode;
                    authenticationDataRequest.Content.Username = headerUsername;
                    authenticationDataRequest.Content.Password = headerPassword;

                    SysAuthenticationDataResponse authenticationDataResponse = (SysAuthenticationDataResponse)InvokeService("Authenticate", authenticationDataRequest, context);

                    if (authenticationDataResponse.Scope.StatusCode == LazyAttribute.GetCustomAttributeFromEnumValue<LazyAttributeGeneric>(FwkScopeStatus.Success).Code)
                    {
                        if (authenticationDataResponse.Content.IdDomain > -1 && authenticationDataResponse.Content.IdUser > -1)
                        {
                            context.Items["IdDomain"] = authenticationDataResponse.Content.IdDomain;
                            context.Items["IdUser"] = authenticationDataResponse.Content.IdUser;
                            context.Response.Headers["Token"] = authenticationDataResponse.Content.Token;
                        }
                    }
                }
            }
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
