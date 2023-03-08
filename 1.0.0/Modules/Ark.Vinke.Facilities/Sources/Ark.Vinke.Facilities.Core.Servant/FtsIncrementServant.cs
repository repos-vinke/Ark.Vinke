// FtsIncrementServant.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 12

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

namespace Ark.Vinke.Facilities.Core.Servant
{
    public class FtsIncrementServant : FwkServant, IFtsIncrementService
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FtsIncrementServant(FwkEnvironment environment)
            : base(environment)
        {
        }

        public FtsIncrementServant(FwkEnvironment environment, LazyDatabase database)
            : base(environment, database)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Validate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The increment request data</param>
        /// <returns>The increment response data</returns>
        public FtsIncrementDataResponse ValidateNext(FtsIncrementDataRequest incrementDataRequest)
        {
            return (FtsIncrementDataResponse)InvokeService("ValidateNext", incrementDataRequest);
        }

        /// <summary>
        /// Validate fix ids
        /// </summary>
        /// <param name="incrementDataRequest">The increment request data</param>
        /// <returns>The increment response data</returns>
        public FtsIncrementDataResponse ValidateFix(FtsIncrementDataRequest incrementDataRequest)
        {
            return (FtsIncrementDataResponse)InvokeService("ValidateFix", incrementDataRequest);
        }

        /// <summary>
        /// Next ids
        /// </summary>
        /// <param name="incrementDataRequest">The increment request data</param>
        /// <returns>The increment response data</returns>
        public FtsIncrementDataResponse Next(FtsIncrementDataRequest incrementDataRequest)
        {
            return (FtsIncrementDataResponse)InvokeService("Next", incrementDataRequest);
        }

        /// <summary>
        /// Fix ids
        /// </summary>
        /// <param name="incrementDataRequest">The increment request data</param>
        /// <returns>The increment response data</returns>
        public FtsIncrementDataResponse Fix(FtsIncrementDataRequest incrementDataRequest)
        {
            return (FtsIncrementDataResponse)InvokeService("Fix", incrementDataRequest);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
