// SysLoginServer.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 02

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
    [ApiController]
    [Route("Ark.Vinke.System/Core.Server/[controller]")]
    public class SysLoginServer : FwkServer, ISysLoginServer
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysLoginServer()
        {
        }

        #endregion Constructors

        #region Methods

        [HttpPost]
        [AllowAnonymous()]
        [Route("Authenticate")]
        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="loginDataRequestString">The login request data string</param>
        /// <returns>The login response data string</returns>
        public String Authenticate([FromBody] String loginDataRequestString)
        {
            return InvokeService("Authenticate", loginDataRequestString);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}