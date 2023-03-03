// SysAuthorizationService.cs
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
using System.Text;
using System.Security.Claims;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.IdentityModel.Tokens;

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
using Ark.Vinke.Framework.Core.Service;
using Ark.Vinke.Facilities;
using Ark.Vinke.Facilities.Core;
using Ark.Vinke.Facilities.Core.Data;
using Ark.Vinke.Facilities.Core.IPlugin;
using Ark.Vinke.Facilities.Core.IService;
using Ark.Vinke.Facilities.Core.Service;
using Ark.Vinke.System;
using Ark.Vinke.System.Core;
using Ark.Vinke.System.Core.Data;
using Ark.Vinke.System.Core.IPlugin;
using Ark.Vinke.System.Core.IService;

namespace Ark.Vinke.System.Core.Service
{
    public class SysAuthorizationService : FwkService, ISysAuthorizationService
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAuthorizationService(FwkEnvironment environment)
            : base(environment)
        {
        }

        public SysAuthorizationService(FwkEnvironment environment, LazyDatabase database)
            : base(environment, database)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Authorize
        /// </summary>
        /// <param name="authorizationDataRequest">The authorization request data</param>
        /// <returns>The authorization response data</returns>
        public SysAuthorizationDataResponse Authorize(SysAuthorizationDataRequest authorizationDataRequest)
        {
            try
            {
                this.Operation = "Authorize";

                SysAuthorizationDataResponse authorizationDataResponse = new SysAuthorizationDataResponse();

                if (this.IsDatabaseOwner == true)
                {
                    this.Database.OpenConnection();
                    this.Database.BeginTransaction();
                }

                InternalAuthorize(authorizationDataRequest, authorizationDataResponse);

                if (this.IsDatabaseOwner == true)
                {
                    this.Database.CommitTransaction();
                    this.Database.CloseConnection();
                }

                return authorizationDataResponse;
            }
            catch
            {
                if (this.IsDatabaseOwner == true)
                {
                    this.Database.RollbackTransaction();
                    this.Database.CloseConnection();
                }

                throw;
            }
        }

        /// <summary>
        /// Internal service authorization
        /// </summary>
        /// <param name="authorizationDataRequest">The authorization request data</param>
        /// <param name="authorizationDataResponse">The authorization response data</param>
        protected void InternalAuthorize(SysAuthorizationDataRequest authorizationDataRequest, SysAuthorizationDataResponse authorizationDataResponse)
        {
            PerformAuthorize(authorizationDataRequest, authorizationDataResponse);
        }

        /// <summary>
        /// Perform service authorization
        /// </summary>
        /// <param name="authorizationDataRequest">The authorization request data</param>
        /// <param name="authorizationDataResponse">The authorization response data</param>
        protected void PerformAuthorize(SysAuthorizationDataRequest authorizationDataRequest, SysAuthorizationDataResponse authorizationDataResponse)
        {
            BeforePerformAuthorize(authorizationDataRequest, authorizationDataResponse);

            #region BeforeAuthorize

            if (this.IPlugins != null)
            {
                foreach (ISysAuthorizationPlugin iAuthorizationPlugin in this.IPlugins)
                    iAuthorizationPlugin.AuthorizePluginBeforeEventHandler?.Invoke(this, new SysAuthorizationPluginBeforeEventArgs(authorizationDataRequest, authorizationDataResponse));
            }

            #endregion BeforeAuthorize

            OnAuthorize(authorizationDataRequest, authorizationDataResponse);

            #region AfterAuthorize

            if (this.IPlugins != null)
            {
                foreach (ISysAuthorizationPlugin iAuthorizationPlugin in this.IPlugins)
                    iAuthorizationPlugin.AuthorizePluginAfterEventHandler?.Invoke(this, new SysAuthorizationPluginAfterEventArgs(authorizationDataRequest, authorizationDataResponse));
            }

            #endregion AfterAuthorize

            AfterPerformAuthorize(authorizationDataRequest, authorizationDataResponse);
        }

        /// <summary>
        /// Authorize
        /// </summary>
        /// <param name="authorizationDataRequest">The authorization request data</param>
        /// <param name="authorizationDataResponse">The authorization response data</param>
        protected virtual void OnAuthorize(SysAuthorizationDataRequest authorizationDataRequest, SysAuthorizationDataResponse authorizationDataResponse)
        {
            #region Authorization Query

            String sqlAuthorization = @"
                select 1 
                from FwkBranchRoleUser 
	                inner join FwkBranchRoleAction 
		                on FwkBranchRoleUser.IdDomain = FwkBranchRoleAction.IdDomain 
                        and FwkBranchRoleUser.IdBranch = FwkBranchRoleAction.IdBranch 
                        and FwkBranchRoleUser.IdRole = FwkBranchRoleAction.IdRole 
	                inner join FwkUserContext 
		                on FwkBranchRoleUser.IdDomain = FwkUserContext.IdDomain 
                        and FwkBranchRoleUser.IdBranch = FwkUserContext.ValueInt16 
                        and FwkBranchRoleUser.IdUser = FwkUserContext.IdUser 
                where FwkBranchRoleUser.IdDomain = :IdDomain 
	                and FwkUserContext.Field = 'IdBranch' 
                    and FwkBranchRoleUser.IdUser = :IdUser 
                    and FwkBranchRoleAction.CodModule = :CodModule 
                    and FwkBranchRoleAction.CodFeature = :CodFeature 
                    and FwkBranchRoleAction.CodAction = :CodAction ";

            #endregion Authorization Query

            authorizationDataResponse.Content.Authorized =
                this.Database.QueryFind(sqlAuthorization, new Object[] {
                    authorizationDataRequest.Content.IdDomain,
                    authorizationDataRequest.Content.IdUser,
                    authorizationDataRequest.Content.CodModule,
                    authorizationDataRequest.Content.CodFeature,
                    authorizationDataRequest.Content.CodAction });
        }

        /// <summary>
        /// Before perform service authorization
        /// </summary>
        /// <param name="authorizationDataRequest">The authorization request data</param>
        /// <param name="authorizationDataResponse">The authorization response data</param>
        private void BeforePerformAuthorize(SysAuthorizationDataRequest authorizationDataRequest, SysAuthorizationDataResponse authorizationDataResponse)
        {
        }

        /// <summary>
        /// After perform service authorization
        /// </summary>
        /// <param name="authorizationDataRequest">The authorization request data</param>
        /// <param name="authorizationDataResponse">The authorization response data</param>
        private void AfterPerformAuthorize(SysAuthorizationDataRequest authorizationDataRequest, SysAuthorizationDataResponse authorizationDataResponse)
        {
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
