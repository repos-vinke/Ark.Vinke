// FwkConnectorView.cs
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
    public class FwkConnectorView : FwkConnectorBasic
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkConnectorView()
        {
            this.Route = "Ark.Vinke.Framework/Core.Server/FwkServerView";
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Format the view
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataViewResponse Format(FwkDataViewRequest dataViewRequest)
        {
            return (FwkDataViewResponse)InvokeServer("Format", dataViewRequest, HttpMethod.Post);
        }

        /// <summary>
        /// Validate read the view
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataViewResponse ValidateRead(FwkDataViewRequest dataViewRequest)
        {
            return (FwkDataViewResponse)InvokeServer("ValidateRead", dataViewRequest, HttpMethod.Post);
        }

        /// <summary>
        /// Read the view
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataViewResponse Read(FwkDataViewRequest dataViewRequest)
        {
            return (FwkDataViewResponse)InvokeServer("Read", dataViewRequest, HttpMethod.Post);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}