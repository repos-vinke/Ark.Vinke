// SysLoginService.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 02

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Text;
using System.Security.Claims;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.IdentityModel.Tokens;

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
    public class SysLoginService : FwkService, ISysLoginService
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysLoginService(FwkEnvironment environment)
            : base(environment)
        {
        }

        public SysLoginService(FwkEnvironment environment, LazyDatabase database)
            : base(environment, database)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="loginDataRequest">The request data</param>
        /// <returns>The response data</returns>
        public SysLoginDataResponse Authenticate(SysLoginDataRequest loginDataRequest)
        {
            try
            {
                this.Operation = "Authenticate";

                SysLoginDataResponse loginDataResponse = (SysLoginDataResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

                // At this service the inherit database object will always be null

                InternalAuthenticate(loginDataRequest, loginDataResponse);

                // At this service the inherit database object will always be null

                return loginDataResponse;
            }
            catch
            {
                // At this service the inherit database object will always be null

                throw;
            }
        }

        /// <summary>
        /// Internal authenticate
        /// </summary>
        /// <param name="loginDataRequest">The request data</param>
        /// <param name="loginDataResponse">The response data</param>
        protected void InternalAuthenticate(SysLoginDataRequest loginDataRequest, SysLoginDataResponse loginDataResponse)
        {
            PerformAuthenticate(loginDataRequest, loginDataResponse);
        }

        /// <summary>
        /// Perform authenticate
        /// </summary>
        /// <param name="loginDataRequest">The request data</param>
        /// <param name="loginDataResponse">The response data</param>
        protected void PerformAuthenticate(SysLoginDataRequest loginDataRequest, SysLoginDataResponse loginDataResponse)
        {
            BeforePerformAuthenticate(loginDataRequest, loginDataResponse);

            #region Before OnAuthenticate plugins

            if (this.IPlugins != null)
            {
                foreach (ISysLoginPlugin iLoginPlugin in this.IPlugins)
                    iLoginPlugin.AuthenticatePluginBeforeEventHandler?.Invoke(this, new SysLoginPluginBeforeEventArgs(loginDataRequest, loginDataResponse));
            }

            #endregion Before OnAuthenticate plugins

            OnAuthenticate(loginDataRequest, loginDataResponse);

            #region After OnAuthenticate plugins

            if (this.IPlugins != null)
            {
                foreach (ISysLoginPlugin iLoginPlugin in this.IPlugins)
                    iLoginPlugin.AuthenticatePluginAfterEventHandler?.Invoke(this, new SysLoginPluginAfterEventArgs(loginDataRequest, loginDataResponse));
            }

            #endregion After OnAuthenticate plugins

            AfterPerformAuthenticate(loginDataRequest, loginDataResponse);
        }

        /// <summary>
        /// On authenticate
        /// </summary>
        /// <param name="loginDataRequest">The request data</param>
        /// <param name="loginDataResponse">The response data</param>
        protected virtual void OnAuthenticate(SysLoginDataRequest loginDataRequest, SysLoginDataResponse loginDataResponse)
        {
            SysAuthenticationDataRequest authenticationDataRequest = new SysAuthenticationDataRequest();
            authenticationDataRequest.Content.DatabaseAlias = loginDataRequest.Content.DatabaseAlias;
            authenticationDataRequest.Content.DomainCode = loginDataRequest.Content.DomainCode;
            authenticationDataRequest.Content.Username = loginDataRequest.Content.Username;
            authenticationDataRequest.Content.Password = loginDataRequest.Content.Password;

            if (LibConfigurationService.DynamicXml["Ark.Vinke.Framework"]["Database"].Elements.ContainsKey(loginDataRequest.Content.DatabaseAlias) == false)
                throw new LibException(Properties.SysResourcesCoreService.SysExceptionAuthenticationFailed, Properties.SysResourcesCoreService.SysCaptionDenied);

            this.Environment.DatabaseAlias = loginDataRequest.Content.DatabaseAlias;
            SysAuthenticationService authenticationService = new SysAuthenticationService(this.Environment);
            SysAuthenticationDataResponse authenticationDataResponse = authenticationService.Authenticate(authenticationDataRequest);

            loginDataResponse.Content.Token = authenticationDataResponse.Content.Token;

            if (loginDataResponse.Content.Token == null)
                throw new LibException(Properties.SysResourcesCoreService.SysExceptionAuthenticationFailed, Properties.SysResourcesCoreService.SysCaptionDenied);
        }

        /// <summary>
        /// Before perform authenticate
        /// </summary>
        /// <param name="loginDataRequest">The request data</param>
        /// <param name="loginDataResponse">The response data</param>
        private void BeforePerformAuthenticate(SysLoginDataRequest loginDataRequest, SysLoginDataResponse loginDataResponse)
        {
        }

        /// <summary>
        /// After perform authenticate
        /// </summary>
        /// <param name="loginDataRequest">The request data</param>
        /// <param name="loginDataResponse">The response data</param>
        private void AfterPerformAuthenticate(SysLoginDataRequest loginDataRequest, SysLoginDataResponse loginDataResponse)
        {
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
