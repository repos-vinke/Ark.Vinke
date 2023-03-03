// FwkEnvironment.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 01

using System;
using System.Xml;
using System.Data;

using Lazy.Vinke;
using Lazy.Vinke.Json;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;

namespace Ark.Vinke.Framework.Core
{
    public class FwkEnvironment
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkEnvironment()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        
        public LibCulture Culture { get; set; }

        public String DatabaseAlias { get; set; }

        public FwkDomain Domain { get; set; }

        public FwkUser User { get; set; }

        public FwkUserContext UserContext { get; set; }

        #endregion Properties
    }
}