// SysPreflightServer.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 30

using System;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

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
    public class SysPreflightServer : FwkServer, ISysPreflightServer, ILibPreflightServer
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysPreflightServer()
        {
            this.DataRequestType = typeof(SysPreflightDataRequest);
            this.DataResponseType = typeof(SysPreflightDataResponse);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Preflight
        /// </summary>
        /// <param name="context">The request context</param>
        public void Preflight(HttpContext context)
        {
            SysPreflightDataRequest preflightDataRequest = new SysPreflightDataRequest();

            SysPreflightDataResponse preflightDataResponse = (SysPreflightDataResponse)InvokeService("Preflight", preflightDataRequest, context);

            foreach (KeyValuePair<String, String> header in preflightDataResponse.Content.HttpResponseHeaders)
                context.Response.Headers.Add(header.Key, header.Value);

            context.Response.StatusCode = StatusCodes.Status200OK;
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
