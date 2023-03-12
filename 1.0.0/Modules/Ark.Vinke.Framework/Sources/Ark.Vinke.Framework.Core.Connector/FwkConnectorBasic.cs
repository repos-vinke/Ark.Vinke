// FwkConnectorBasic.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2023, March 12

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Net.Http;
using System.Collections.Generic;

using Lazy.Vinke;
using Lazy.Vinke.Json;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;
using Ark.Vinke.Library.Core.Connector;

using Ark.Vinke.Framework;
using Ark.Vinke.Framework.Core;
using Ark.Vinke.Framework.Core.Data;
using Ark.Vinke.Framework.Core.IServer;

namespace Ark.Vinke.Framework.Core.Connector
{
    public class FwkConnectorBasic : FwkConnector
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkConnectorBasic()
        {
            this.Route = "Ark.Vinke.Framework/Core.Server/FwkServerBasic";
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataBasicResponse Init(FwkDataBasicRequest dataBasicRequest)
        {
            return (FwkDataBasicResponse)InvokeServer("Init", dataBasicRequest, HttpMethod.Post);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}