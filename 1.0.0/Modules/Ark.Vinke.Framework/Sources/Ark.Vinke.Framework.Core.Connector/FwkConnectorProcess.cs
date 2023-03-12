// FwkConnectorProcess.cs
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
    public class FwkConnectorProcess : FwkConnectorBasic
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkConnectorProcess()
        {
            this.Route = "Ark.Vinke.Framework/Core.Server/FwkServerProcess";
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Next process step data
        /// </summary>
        /// <param name="dataProcessRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataProcessResponse Next(FwkDataProcessRequest dataProcessRequest)
        {
            return (FwkDataProcessResponse)InvokeServer("Next", dataProcessRequest, HttpMethod.Post);
        }

        /// <summary>
        /// Execute the process
        /// </summary>
        /// <param name="dataProcessRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataProcessResponse Execute(FwkDataProcessRequest dataProcessRequest)
        {
            return (FwkDataProcessResponse)InvokeServer("Execute", dataProcessRequest, HttpMethod.Post);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}