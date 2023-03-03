// FwkServantBasic.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

using System;
using System.Xml;
using System.Data;
using System.Reflection;

using Lazy.Vinke;
using Lazy.Vinke.Database;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;
using Ark.Vinke.Framework;
using Ark.Vinke.Framework.Core;
using Ark.Vinke.Framework.Core.Data;
using Ark.Vinke.Framework.Core.IService;

namespace Ark.Vinke.Framework.Core.Servant
{
    public class FwkServantBasic : FwkServant, IFwkServiceBasic
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkServantBasic(FwkEnvironment environment)
            : base(environment)
        {
        }

        public FwkServantBasic(FwkEnvironment environment, LazyDatabase database)
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
        public FwkDataBasicResponse Init(FwkDataBasicRequest dataBasicRequest)
        {
            return (FwkDataBasicResponse)InvokeService("Init", dataBasicRequest);
        }
        
        /// <summary>
        /// Load the service
        /// </summary>
        /// <param name="dataBasicRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataBasicResponse Load(FwkDataBasicRequest dataBasicRequest)
        {
            return (FwkDataBasicResponse)InvokeService("Load", dataBasicRequest);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
