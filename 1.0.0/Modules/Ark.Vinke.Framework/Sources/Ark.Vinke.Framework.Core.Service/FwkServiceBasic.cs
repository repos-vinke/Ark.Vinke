// FwkServiceBasic.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Lazy.Vinke;
using Lazy.Vinke.Json;
using Lazy.Vinke.Database;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;
using Ark.Vinke.Library.Core.Service;
using Ark.Vinke.Framework;
using Ark.Vinke.Framework.Core;
using Ark.Vinke.Framework.Core.Data;
using Ark.Vinke.Framework.Core.IPlugin;
using Ark.Vinke.Framework.Core.IService;

namespace Ark.Vinke.Framework.Core.Service
{
    public class FwkServiceBasic : FwkService, IFwkServiceBasic
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkServiceBasic(FwkEnvironment environment)
            : base(environment)
        {
        }

        public FwkServiceBasic(FwkEnvironment environment, LazyDatabase database)
            : base(environment, database)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Initialize the service
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <returns>The response data</returns>
        public virtual FwkDataBasicResponse Init(FwkDataBasicRequest dataBasicRequest)
        {
            try
            {
                this.Operation = "Init";

                FwkDataBasicResponse dataBasicResponse = (FwkDataBasicResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

                if (this.IsDatabaseOwner == true)
                {
                    this.Database.OpenConnection();
                    this.Database.BeginTransaction();
                }

                InternalInit(dataBasicRequest, dataBasicResponse);

                if (this.IsDatabaseOwner == true)
                {
                    this.Database.CommitTransaction();
                    this.Database.CloseConnection();
                }

                return dataBasicResponse;
            }
            catch
            {
                if (this.IsDatabaseOwner == true)
                {
                    if (this.Database.InTransaction == true)
                        this.Database.RollbackTransaction();

                    if (this.Database.IsConnectionOpen == true)
                        this.Database.CloseConnection();
                }

                throw;
            }
        }

        /// <summary>
        /// Load the service
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataBasicResponse Load(FwkDataBasicRequest dataBasicRequest)
        {
            try
            {
                this.Operation = "Load";

                FwkDataBasicResponse dataBasicResponse = (FwkDataBasicResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

                if (this.IsDatabaseOwner == true)
                {
                    this.Database.OpenConnection();
                    this.Database.BeginTransaction();
                }

                InternalLoad(dataBasicRequest, dataBasicResponse);

                if (this.IsDatabaseOwner == true)
                {
                    this.Database.CommitTransaction();
                    this.Database.CloseConnection();
                }

                return dataBasicResponse;
            }
            catch
            {
                if (this.IsDatabaseOwner == true)
                {
                    if (this.Database.InTransaction == true)
                        this.Database.RollbackTransaction();

                    if (this.Database.IsConnectionOpen == true)
                        this.Database.CloseConnection();
                }

                throw;
            }
        }

        /// <summary>
        /// Internal service init
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <param name="dataBasicResponse">The response data</param>
        protected void InternalInit(FwkDataBasicRequest dataBasicRequest, FwkDataBasicResponse dataBasicResponse)
        {
            PerformLoad(dataBasicRequest, dataBasicResponse);
        }

        /// <summary>
        /// Internal service load
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <param name="dataBasicResponse">The response data</param>
        protected void InternalLoad(FwkDataBasicRequest dataBasicRequest, FwkDataBasicResponse dataBasicResponse)
        {
            PerformLoad(dataBasicRequest, dataBasicResponse);
        }

        /// <summary>
        /// Perform service load
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <param name="dataBasicResponse">The response data</param>
        protected void PerformLoad(FwkDataBasicRequest dataBasicRequest, FwkDataBasicResponse dataBasicResponse)
        {
            BeforePerformLoad(dataBasicRequest, dataBasicResponse);

            #region Before OnLoad plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginBasic iPluginBasic in this.IPlugins)
                    iPluginBasic.LoadPluginBasicBeforeEventHandler?.Invoke(this, new FwkPluginBasicBeforeEventArgs(dataBasicRequest, dataBasicResponse));
            }

            #endregion Before OnLoad plugins

            OnLoad(dataBasicRequest, dataBasicResponse);

            #region After OnLoad plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginBasic iPluginBasic in this.IPlugins)
                    iPluginBasic.LoadPluginBasicAfterEventHandler?.Invoke(this, new FwkPluginBasicAfterEventArgs(dataBasicRequest, dataBasicResponse));
            }

            #endregion After OnLoad plugins

            AfterPerformLoad(dataBasicRequest, dataBasicResponse);
        }

        /// <summary>
        /// On service load
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <param name="dataBasicResponse">The response data</param>
        protected virtual void OnLoad(FwkDataBasicRequest dataBasicRequest, FwkDataBasicResponse dataBasicResponse)
        {
        }

        /// <summary>
        /// Before perform service load
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <param name="dataBasicResponse">The response data</param>
        private void BeforePerformLoad(FwkDataBasicRequest dataBasicRequest, FwkDataBasicResponse dataBasicResponse)
        {
        }

        /// <summary>
        /// After perform service load
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <param name="dataBasicResponse">The response data</param>
        private void AfterPerformLoad(FwkDataBasicRequest dataBasicRequest, FwkDataBasicResponse dataBasicResponse)
        {
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
