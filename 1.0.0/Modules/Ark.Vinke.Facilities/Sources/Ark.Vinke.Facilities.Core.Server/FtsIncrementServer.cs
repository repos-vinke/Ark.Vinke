// FtsIncrementServer.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 12

using System;
using System.Xml;
using System.Data;
using System.Reflection;

using Microsoft.AspNetCore.Mvc;

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

namespace Ark.Vinke.Facilities.Core.Server
{
    [ApiController]
    [Route("Ark.Vinke.Facilities/Core.Server/[controller]")]
    public class FtsIncrementServer : FwkServer, IFtsIncrementServer
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FtsIncrementServer()
        {
        }

        #endregion Constructors

        #region Methods

        [HttpPost]
        [Route("ValidateNext")]
        /// <summary>
        /// Validate next ids
        /// </summary>
        /// <param name="incrementDataRequestString">The increment request data string</param>
        /// <returns>The increment response data string</returns>
        public String ValidateNext([FromBody] String incrementDataRequestString)
        {
            return InvokeService("ValidateNext", incrementDataRequestString);
        }

        [HttpPost]
        [Route("ValidateFix")]
        /// <summary>
        /// Validate fix ids
        /// </summary>
        /// <param name="incrementDataRequestString">The increment request data string</param>
        /// <returns>The increment response data string</returns>
        public String ValidateFix([FromBody] String incrementDataRequestString)
        {
            return InvokeService("ValidateFix", incrementDataRequestString);
        }

        [HttpPost]
        [Route("Next")]
        /// <summary>
        /// Next ids
        /// </summary>
        /// <param name="incrementDataRequestString">The increment request data string</param>
        /// <returns>The increment response data string</returns>
        public String Next([FromBody] String incrementDataRequestString)
        {
            return InvokeService("Next", incrementDataRequestString);
        }

        [HttpPost]
        [Route("Fix")]
        /// <summary>
        /// Fix ids
        /// </summary>
        /// <param name="incrementDataRequestString">The increment request data string</param>
        /// <returns>The increment response data string</returns>
        public String Fix([FromBody] String incrementDataRequestString)
        {
            return InvokeService("Fix", incrementDataRequestString);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}