// FwkConnectorRecord.cs
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
    public class FwkConnectorRecord : FwkConnectorBasic
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkConnectorRecord()
        {
            this.Route = "Ark.Vinke.Framework/Core.Server/FwkServerRecord";
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Format the record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Format(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeServer("Format", dataRecordRequest, HttpMethod.Post);
        }

        /// <summary>
        /// Validate read the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse ValidateRead(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeServer("ValidateRead", dataRecordRequest, HttpMethod.Post);
        }

        /// <summary>
        /// Validate insert the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse ValidateInsert(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeServer("ValidateInsert", dataRecordRequest, HttpMethod.Put);
        }

        /// <summary>
        /// Validate indate the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse ValidateIndate(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeServer("ValidateIndate", dataRecordRequest, HttpMethod.Put);
        }

        /// <summary>
        /// Validate update the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse ValidateUpdate(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeServer("ValidateUpdate", dataRecordRequest, HttpMethod.Put);
        }

        /// <summary>
        /// Validate upsert the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse ValidateUpsert(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeServer("ValidateUpsert", dataRecordRequest, HttpMethod.Put);
        }

        /// <summary>
        /// Validate delete the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse ValidateDelete(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeServer("ValidateDelete", dataRecordRequest, HttpMethod.Delete);
        }

        /// <summary>
        /// Read the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Read(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeServer("Read", dataRecordRequest, HttpMethod.Post);
        }

        /// <summary>
        /// Insert the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Insert(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeServer("Insert", dataRecordRequest, HttpMethod.Put);
        }

        /// <summary>
        /// Indate the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Indate(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeServer("Indate", dataRecordRequest, HttpMethod.Put);
        }

        /// <summary>
        /// Update the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Update(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeServer("Update", dataRecordRequest, HttpMethod.Put);
        }

        /// <summary>
        /// Upsert the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Upsert(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeServer("Upsert", dataRecordRequest, HttpMethod.Put);
        }

        /// <summary>
        /// Delete the Record
        /// </summary>
        /// <param name="dataRecordRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataRecordResponse Delete(FwkDataRecordRequest dataRecordRequest)
        {
            return (FwkDataRecordResponse)InvokeServer("Delete", dataRecordRequest, HttpMethod.Delete);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}