// SysPreflightService.cs
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

using Lazy.Vinke;
using Lazy.Vinke.Database;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;
using Ark.Vinke.Library.Core.Service;
using Ark.Vinke.Framework;
using Ark.Vinke.Framework.Core;
using Ark.Vinke.Framework.Core.Data;
using Ark.Vinke.Framework.Core.IPlugin;
using Ark.Vinke.Framework.Core.IService;
using Ark.Vinke.Framework.Core.Service;
using Ark.Vinke.Facilities;
using Ark.Vinke.Facilities.Core;
using Ark.Vinke.Facilities.Core.Data;
using Ark.Vinke.Facilities.Core.IPlugin;
using Ark.Vinke.Facilities.Core.IService;
using Ark.Vinke.Facilities.Core.Servant;
using Ark.Vinke.System;
using Ark.Vinke.System.Core;
using Ark.Vinke.System.Core.Data;
using Ark.Vinke.System.Core.IPlugin;
using Ark.Vinke.System.Core.IService;

namespace Ark.Vinke.System.Core.Service
{
    public class SysPreflightService : FwkService, ISysPreflightService
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysPreflightService(FwkEnvironment environment)
            : base(environment)
        {
        }

        public SysPreflightService(FwkEnvironment environment, LazyDatabase database)
            : base(environment, database)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Preflight
        /// </summary>
        /// <param name="preflightDataRequest">The request data</param>
        /// <returns>The response data</returns>
        public SysPreflightDataResponse Preflight(SysPreflightDataRequest preflightDataRequest)
        {
            try
            {
                this.Operation = "Preflight";

                SysPreflightDataResponse preflightDataResponse = new SysPreflightDataResponse();

                // Must remove this because in this service the inherit database object will always be null
                //if (this.IsDatabaseOwner == true)
                //{
                //    this.Database.OpenConnection();
                //    this.Database.BeginTransaction();
                //}

                InternalPreflight(preflightDataRequest, preflightDataResponse);

                // Must remove this because in this service the inherit database object will always be null
                //if (this.IsDatabaseOwner == true)
                //{
                //    this.Database.CommitTransaction();
                //    this.Database.CloseConnection();
                //}

                return preflightDataResponse;
            }
            catch
            {
                // Must remove this because in this service the inherit database object will always be null
                //if (this.IsDatabaseOwner == true)
                //{
                //    if (this.Database.InTransaction == true)
                //        this.Database.RollbackTransaction();

                //    this.Database.CloseConnection();
                //}

                throw;
            }
        }

        /// <summary>
        /// Internal service preflight
        /// </summary>
        /// <param name="preflightDataRequest">The request data</param>
        /// <param name="preflightDataResponse">The response data</param>
        protected void InternalPreflight(SysPreflightDataRequest preflightDataRequest, SysPreflightDataResponse preflightDataResponse)
        {
            PerformPreflight(preflightDataRequest, preflightDataResponse);
        }

        /// <summary>
        /// Perform service preflight
        /// </summary>
        /// <param name="preflightDataRequest">The request data</param>
        /// <param name="preflightDataResponse">The response data</param>
        protected void PerformPreflight(SysPreflightDataRequest preflightDataRequest, SysPreflightDataResponse preflightDataResponse)
        {
            BeforePerformPreflight(preflightDataRequest, preflightDataResponse);

            #region BeforePreflight

            if (this.IPlugins != null)
            {
                foreach (ISysPreflightPlugin iPreflightPlugin in this.IPlugins)
                    iPreflightPlugin.PreflightPluginBeforeEventHandler?.Invoke(this, new SysPreflightPluginBeforeEventArgs(preflightDataRequest, preflightDataResponse));
            }

            #endregion BeforePreflight

            OnPreflight(preflightDataRequest, preflightDataResponse);

            #region AfterPreflight

            if (this.IPlugins != null)
            {
                foreach (ISysPreflightPlugin iPreflightPlugin in this.IPlugins)
                    iPreflightPlugin.PreflightPluginAfterEventHandler?.Invoke(this, new SysPreflightPluginAfterEventArgs(preflightDataRequest, preflightDataResponse));
            }

            #endregion AfterPreflight

            AfterPerformPreflight(preflightDataRequest, preflightDataResponse);
        }

        /// <summary>
        /// Preflight
        /// </summary>
        /// <param name="preflightDataRequest">The request data</param>
        /// <param name="preflightDataResponse">The response data</param>
        protected virtual void OnPreflight(SysPreflightDataRequest preflightDataRequest, SysPreflightDataResponse preflightDataResponse)
        {
            LibDynamicXmlElement dynamicXmlElementPreflight = LibConfigurationService.DynamicXml["Ark.Vinke.System"]["Security"]["Preflight"]["Response"]["Headers"];

            foreach (KeyValuePair<String, LibDynamicXmlElement> dynamicXmlElementPreflightHeader in dynamicXmlElementPreflight.Elements)
            {
                preflightDataResponse.Content.HttpResponseHeaders.Add(
                    dynamicXmlElementPreflightHeader.Value.Attribute["HeaderKey"],
                    dynamicXmlElementPreflightHeader.Value.Attribute["HeaderValue"]);
            }
        }

        /// <summary>
        /// Before perform service preflight
        /// </summary>
        /// <param name="preflightDataRequest">The request data</param>
        /// <param name="preflightDataResponse">The response data</param>
        private void BeforePerformPreflight(SysPreflightDataRequest preflightDataRequest, SysPreflightDataResponse preflightDataResponse)
        {
        }

        /// <summary>
        /// After perform service preflight
        /// </summary>
        /// <param name="preflightDataRequest">The request data</param>
        /// <param name="preflightDataResponse">The response data</param>
        private void AfterPerformPreflight(SysPreflightDataRequest preflightDataRequest, SysPreflightDataResponse preflightDataResponse)
        {
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
