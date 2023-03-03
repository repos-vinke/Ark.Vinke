﻿// FwkServantView.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, December 31

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
    public class FwkServantView : FwkServantBasic, IFwkServiceView
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkServantView(FwkEnvironment environment)
            : base(environment)
        {
        }

        public FwkServantView(FwkEnvironment environment, LazyDatabase database)
            : base(environment, database)
        {
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
            return (FwkDataViewResponse)InvokeService("Format", dataViewRequest);
        }

        /// <summary>
        /// Validate read the view
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataViewResponse ValidateRead(FwkDataViewRequest dataViewRequest)
        {
            return (FwkDataViewResponse)InvokeService("ValidateRead", dataViewRequest);
        }

        /// <summary>
        /// Read the view
        /// </summary>
        /// <param name="dataViewRequest">The request data</param>
        /// <returns>The response data</returns>
        public FwkDataViewResponse Read(FwkDataViewRequest dataViewRequest)
        {
            return (FwkDataViewResponse)InvokeService("Read", dataViewRequest);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
