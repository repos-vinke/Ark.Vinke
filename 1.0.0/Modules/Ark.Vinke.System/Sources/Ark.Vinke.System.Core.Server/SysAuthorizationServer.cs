// SysAuthorizationServer.cs
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
using System.Text.Json;
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
    public class SysAuthorizationServer : FwkServer, ISysAuthorizationServer, ILibAuthorizationServer
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthorizationServer()
        {
            this.DataRequestType = typeof(SysAuthorizationDataRequest);
            this.DataResponseType = typeof(SysAuthorizationDataResponse);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Authorize
        /// </summary>
        /// <param name="context">The request context</param>
        public void Authorize(AuthorizationFilterContext context)
        {
            if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().ToList().Count == 0)
            {
                Int32 idDomain = LazyConvert.ToInt32(context.HttpContext.Items["IdDomain"], -1);
                Int32 idUser = LazyConvert.ToInt32(context.HttpContext.Items["IdUser"], -1);

                if (idDomain > -1 && idUser > -1)
                {
                    String[] controllerPath = context.HttpContext.Request.Path.Value.Split('/', StringSplitOptions.RemoveEmptyEntries);

                    SysAuthorizationDataRequest authorizationDataRequest = new SysAuthorizationDataRequest();
                    authorizationDataRequest.Content.IdDomain = idDomain;
                    authorizationDataRequest.Content.IdUser = idUser;
                    authorizationDataRequest.Content.CodModule = controllerPath[0];
                    authorizationDataRequest.Content.CodFeature = controllerPath[1];
                    authorizationDataRequest.Content.CodAction = controllerPath[2];

                    SysAuthorizationDataResponse authorizationDataResponse = (SysAuthorizationDataResponse)InvokeService("Authorize", authorizationDataRequest, context.HttpContext);

                    if (authorizationDataResponse.Content.Authorized == false)
                    {
                        context.Result = Unauthorize(context);
                    }
                }
                else
                {
                    context.Result = Unauthorize(context);
                }
            }
        }

        private JsonResult Unauthorize(AuthorizationFilterContext context)
        {
            #region Initialize culture

            String culture = null;
            if (context.HttpContext.Request.Headers.ContainsKey("Culture") == true)
                culture = LazyConvert.ToString(context.HttpContext.Request.Headers["Culture"], null);

            LibCulture libCulture = null;
            try { libCulture = new LibCulture(culture); }
            catch { libCulture = LibGlobalization.Culture; }

            #endregion Initialize culture

            FwkDataResponse dataResponse = new FwkDataResponse();

            #region Write response scope error

            dataResponse.Scope.StatusCode = LazyAttribute.GetCustomAttributeFromEnumValue<LazyAttributeGeneric>(FwkScopeStatus.Error).Code;
            dataResponse.Scope.StatusName = LazyAttribute.GetCustomAttributeFromEnumValue<LazyAttributeGeneric>(FwkScopeStatus.Error).Name;
            dataResponse.Scope.StatusCaption = LibGlobalization.GetTranslation(Properties.SysResourcesCoreServer.SysCaptionDenied, libCulture);
            dataResponse.Scope.StatusMessage = LibGlobalization.GetTranslation(Properties.SysResourcesCoreServer.SysMessageUnauthorized, libCulture);

            #endregion Write response scope error

            return new JsonResult(dataResponse, new JsonSerializerOptions() { PropertyNamingPolicy = null }) { StatusCode = StatusCodes.Status401Unauthorized };
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
