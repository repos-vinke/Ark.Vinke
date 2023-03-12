// FtsIncrementConnector.cs
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
using Ark.Vinke.Framework.Core.Connector;

using Ark.Vinke.Facilities;
using Ark.Vinke.Facilities.Core;
using Ark.Vinke.Facilities.Core.Data;
using Ark.Vinke.Facilities.Core.IServer;

namespace Ark.Vinke.Facilities.Core.Connector
{
    public class FtsIncrementConnector : FwkConnector
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FtsIncrementConnector()
        {
            this.Route = "Ark.Vinke.Facilities/Core.Server/FtsIncrementServer";
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Validate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The increment request data</param>
        /// <returns>The increment response data</returns>
        public FtsIncrementDataResponse ValidateNext(FtsIncrementDataRequest incrementDataRequest)
        {
            return (FtsIncrementDataResponse)InvokeServer("ValidateNext", incrementDataRequest, HttpMethod.Post);
        }

        /// <summary>
        /// Validate fix ids
        /// </summary>
        /// <param name="incrementDataRequest">The increment request data</param>
        /// <returns>The increment response data</returns>
        public FtsIncrementDataResponse ValidateFix(FtsIncrementDataRequest incrementDataRequest)
        {
            return (FtsIncrementDataResponse)InvokeServer("ValidateFix", incrementDataRequest, HttpMethod.Post);
        }

        /// <summary>
        /// Next ids
        /// </summary>
        /// <param name="incrementDataRequest">The increment request data</param>
        /// <returns>The increment response data</returns>
        public FtsIncrementDataResponse Next(FtsIncrementDataRequest incrementDataRequest)
        {
            return (FtsIncrementDataResponse)InvokeServer("Next", incrementDataRequest, HttpMethod.Post);
        }

        /// <summary>
        /// Fix ids
        /// </summary>
        /// <param name="incrementDataRequest">The increment request data</param>
        /// <returns>The increment response data</returns>
        public FtsIncrementDataResponse Fix(FtsIncrementDataRequest incrementDataRequest)
        {
            return (FtsIncrementDataResponse)InvokeServer("Fix", incrementDataRequest, HttpMethod.Post);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}