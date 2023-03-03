// SysLoginServant.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 02

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
using Ark.Vinke.Framework.Core.Servant;
using Ark.Vinke.Facilities;
using Ark.Vinke.Facilities.Core;
using Ark.Vinke.Facilities.Core.Data;
using Ark.Vinke.Facilities.Core.IService;
using Ark.Vinke.Facilities.Core.Servant;
using Ark.Vinke.System;
using Ark.Vinke.System.Core;
using Ark.Vinke.System.Core.Data;
using Ark.Vinke.System.Core.IService;

namespace Ark.Vinke.System.Core.Servant
{
    public class SysLoginServant : FwkServant, ISysLoginService
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysLoginServant(FwkEnvironment environment)
            : base(environment)
        {
        }

        public SysLoginServant(FwkEnvironment environment, LazyDatabase database)
            : base(environment, database)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="loginDataRequest">The login request data</param>
        /// <returns>The login response data</returns>
        public SysLoginDataResponse Authenticate(SysLoginDataRequest loginDataRequest)
        {
            return (SysLoginDataResponse)InvokeService("Authenticate", loginDataRequest);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
