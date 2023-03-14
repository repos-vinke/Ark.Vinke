// FwkServerView.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, December 31

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
    public class FwkServerView : FwkServerBasic, IFwkServerView
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkServerView()
        {
        }

        #endregion Constructors

        #region Methods

        [HttpPost]
        [Route("Format")]
        /// <summary>
        /// Format the view
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        public String Format([FromBody] String dataRequestString)
        {
            return InvokeService("Format", dataRequestString);
        }

        [HttpPost]
        [Route("ValidateRead")]
        /// <summary>
        /// Validate read the view
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        public String ValidateRead([FromBody] String dataRequestString)
        {
            return InvokeService("ValidateRead", dataRequestString);
        }

        [HttpPost]
        [Route("Read")]
        /// <summary>
        /// Read the view
        /// </summary>
        /// <param name="dataRequestString">The request data string</param>
        /// <returns>The response data string</returns>
        public String Read([FromBody] String dataRequestString)
        {
            return InvokeService("Read", dataRequestString);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}