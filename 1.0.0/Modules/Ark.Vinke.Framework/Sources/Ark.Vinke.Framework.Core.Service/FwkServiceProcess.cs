﻿// FwkServiceProcess.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, May 15

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
    public class FwkServiceProcess : FwkServiceBasic, IFwkServiceProcess
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkServiceProcess(FwkEnvironment environment)
            : base(environment)
        {
        }

        public FwkServiceProcess(FwkEnvironment environment, LazyDatabase database)
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
        public override FwkDataBasicResponse Init(FwkDataBasicRequest dataBasicRequest)
        {
            try
            {
                this.Operation = "Init";

                FwkDataProcessResponse dataProcessResponse = (FwkDataProcessResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

                if (this.IsDatabaseOwner == true)
                {
                    this.Database.OpenConnection();
                    this.Database.BeginTransaction();
                }

                InternalInit((FwkDataProcessRequest)dataBasicRequest, dataProcessResponse);

                if (this.IsDatabaseOwner == true)
                {
                    this.Database.CommitTransaction();
                    this.Database.CloseConnection();
                }

                return dataProcessResponse;
            }
            catch
            {
                if (this.IsDatabaseOwner == true)
                {
                    if (this.Database.InTransaction == true)
                        this.Database.RollbackTransaction();

                    this.Database.CloseConnection();
                }

                throw;
            }
        }

        /// <summary>
        /// Next step of service
        /// </summary>
        /// <param name="dataProcessRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataProcessResponse Next(FwkDataProcessRequest dataProcessRequest)
        {
            try
            {
                this.Operation = "Next";

                FwkDataProcessResponse dataProcessResponse = (FwkDataProcessResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

                if (this.IsDatabaseOwner == true)
                {
                    this.Database.OpenConnection();
                    this.Database.BeginTransaction();
                }

                InternalNext(dataProcessRequest, dataProcessResponse);

                if (this.IsDatabaseOwner == true)
                {
                    this.Database.CommitTransaction();
                    this.Database.CloseConnection();
                }

                return dataProcessResponse;
            }
            catch
            {
                if (this.IsDatabaseOwner == true)
                {
                    if (this.Database.InTransaction == true)
                        this.Database.RollbackTransaction();

                    this.Database.CloseConnection();
                }

                throw;
            }
        }

        /// <summary>
        /// Execute the service
        /// </summary>
        /// <param name="dataProcessRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataProcessResponse Execute(FwkDataProcessRequest dataProcessRequest)
        {
            try
            {
                this.Operation = "Execute";

                FwkDataProcessResponse dataProcessResponse = (FwkDataProcessResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

                if (this.IsDatabaseOwner == true)
                {
                    this.Database.OpenConnection();
                    this.Database.BeginTransaction();
                }

                InternalExecute(dataProcessRequest, dataProcessResponse);

                if (this.IsDatabaseOwner == true)
                {
                    this.Database.CommitTransaction();
                    this.Database.CloseConnection();
                }

                return dataProcessResponse;
            }
            catch
            {
                if (this.IsDatabaseOwner == true)
                {
                    if (this.Database.InTransaction == true)
                        this.Database.RollbackTransaction();

                    this.Database.CloseConnection();
                }

                throw;
            }
        }

        /// <summary>
        /// Internal service init
        /// </summary>
        /// <param name="dataProcessRequest">The request data</param>
        /// <param name="dataProcessResponse">The response data</param>
        protected void InternalInit(FwkDataProcessRequest dataProcessRequest, FwkDataProcessResponse dataProcessResponse)
        {
            PerformLoad(dataProcessRequest, dataProcessResponse);
        }

        /// <summary>
        /// Internal service next
        /// </summary>
        /// <param name="dataProcessRequest">The request data</param>
        /// <param name="dataProcessResponse">The response data</param>
        protected void InternalNext(FwkDataProcessRequest dataProcessRequest, FwkDataProcessResponse dataProcessResponse)
        {
            PerformNext(dataProcessRequest, dataProcessResponse);
        }

        /// <summary>
        /// Internal service execute
        /// </summary>
        /// <param name="dataProcessRequest">The request data</param>
        /// <param name="dataProcessResponse">The response data</param>
        protected void InternalExecute(FwkDataProcessRequest dataProcessRequest, FwkDataProcessResponse dataProcessResponse)
        {
            PerformExecute(dataProcessRequest, dataProcessResponse);
        }

        /// <summary>
        /// Perform service next
        /// </summary>
        /// <param name="dataProcessRequest">The request data</param>
        /// <param name="dataProcessResponse">The response data</param>
        protected void PerformNext(FwkDataProcessRequest dataProcessRequest, FwkDataProcessResponse dataProcessResponse)
        {
            BeforePerformNext(dataProcessRequest, dataProcessResponse);

            #region Before OnNext plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginProcess iPluginProcess in this.IPlugins)
                    iPluginProcess.NextPluginProcessBeforeEventHandler?.Invoke(this, new FwkPluginProcessBeforeEventArgs(dataProcessRequest, dataProcessResponse));
            }

            #endregion Before OnNext plugins

            OnNext(dataProcessRequest, dataProcessResponse);

            #region After OnNext plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginProcess iPluginProcess in this.IPlugins)
                    iPluginProcess.NextPluginProcessAfterEventHandler?.Invoke(this, new FwkPluginProcessAfterEventArgs(dataProcessRequest, dataProcessResponse));
            }

            #endregion After OnNext plugins

            AfterPerformNext(dataProcessRequest, dataProcessResponse);
        }

        /// <summary>
        /// Perform service execute
        /// </summary>
        /// <param name="dataProcessRequest">The request data</param>
        /// <param name="dataProcessResponse">The response data</param>
        protected void PerformExecute(FwkDataProcessRequest dataProcessRequest, FwkDataProcessResponse dataProcessResponse)
        {
            BeforePerformExecute(dataProcessRequest, dataProcessResponse);

            #region Before OnExecute plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginProcess iPluginProcess in this.IPlugins)
                    iPluginProcess.ExecutePluginProcessBeforeEventHandler?.Invoke(this, new FwkPluginProcessBeforeEventArgs(dataProcessRequest, dataProcessResponse));
            }

            #endregion Before OnExecute plugins

            OnExecute(dataProcessRequest, dataProcessResponse);

            #region After OnExecute plugins

            if (this.IPlugins != null)
            {
                foreach (IFwkPluginProcess iPluginProcess in this.IPlugins)
                    iPluginProcess.ExecutePluginProcessAfterEventHandler?.Invoke(this, new FwkPluginProcessAfterEventArgs(dataProcessRequest, dataProcessResponse));
            }

            #endregion After OnExecute plugins

            AfterPerformExecute(dataProcessRequest, dataProcessResponse);
        }

        /// <summary>
        /// On service format
        /// </summary>
        /// <param name="dataProcessRequest">The request data</param>
        /// <param name="dataProcessResponse">The response data</param>
        protected virtual void OnNext(FwkDataProcessRequest dataProcessRequest, FwkDataProcessResponse dataProcessResponse)
        {
        }

        /// <summary>
        /// On service validate read
        /// </summary>
        /// <param name="dataProcessRequest">The request data</param>
        /// <param name="dataProcessResponse">The response data</param>
        protected virtual void OnExecute(FwkDataProcessRequest dataProcessRequest, FwkDataProcessResponse dataProcessResponse)
        {
        }

        /// <summary>
        /// Before perform service format
        /// </summary>
        /// <param name="dataProcessRequest">The request data</param>
        /// <param name="dataProcessResponse">The response data</param>
        private void BeforePerformNext(FwkDataProcessRequest dataProcessRequest, FwkDataProcessResponse dataProcessResponse)
        {
        }

        /// <summary>
        /// After perform service format
        /// </summary>
        /// <param name="dataProcessRequest">The request data</param>
        /// <param name="dataProcessResponse">The response data</param>
        private void AfterPerformNext(FwkDataProcessRequest dataProcessRequest, FwkDataProcessResponse dataProcessResponse)
        {
        }

        /// <summary>
        /// Before perform service validate read
        /// </summary>
        /// <param name="dataProcessRequest">The request data</param>
        /// <param name="dataProcessResponse">The response data</param>
        private void BeforePerformExecute(FwkDataProcessRequest dataProcessRequest, FwkDataProcessResponse dataProcessResponse)
        {
        }

        /// <summary>
        /// After perform service validate read
        /// </summary>
        /// <param name="dataProcessRequest">The request data</param>
        /// <param name="dataProcessResponse">The response data</param>
        private void AfterPerformExecute(FwkDataProcessRequest dataProcessRequest, FwkDataProcessResponse dataProcessResponse)
        {
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
