// LibAuthenticationSecret.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, August 31

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Globalization;
using System.Collections.Generic;

using Lazy.Vinke;

using Ark.Vinke.Library;

namespace Ark.Vinke.Library.Core
{
    public class LibAuthenticationSecret
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public LibAuthenticationSecret()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        
        public String Token { get; set; }

        public String Username { get; set; }

        public String Password { get; set; }

        #endregion Properties
    }
}