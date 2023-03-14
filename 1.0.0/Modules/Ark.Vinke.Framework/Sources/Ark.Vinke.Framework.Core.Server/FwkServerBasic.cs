// FwkServerBasic.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

using System;
using System.Xml;
using System.Data;
using System.Reflection;

using Microsoft.AspNetCore.Mvc;

using Lazy.Vinke;
using Lazy.Vinke.Json;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;
using Ark.Vinke.Library.Core.Server;
using Ark.Vinke.Framework;
using Ark.Vinke.Framework.Core;
using Ark.Vinke.Framework.Core.Data;
using Ark.Vinke.Framework.Core.IServer;
using Ark.Vinke.Framework.Core.IService;

namespace Ark.Vinke.Framework.Core.Server
{
    [ApiController]
    [Route("Ark.Vinke.Framework/Core.Server/[controller]")]
    public class FwkServerBasic : FwkServer, IFwkServerBasic
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkServerBasic()
        {
        }

        #endregion Constructors

        #region Methods

        [HttpPost]
        [Route("Init")]
        /// <summary>
        /// Initialize the service
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        public String Init([FromBody] String dataRequestString)
        {
            return InvokeService("Init", dataRequestString);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}