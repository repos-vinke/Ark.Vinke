// LibSessionClient.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2023, March 12

using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Lazy.Vinke;
using Lazy.Vinke.Windows;
using Lazy.Vinke.Windows.Forms;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;
using Ark.Vinke.Library.Core.Connector;

namespace Ark.Vinke.Library.Core.Client
{
    public static class LibSessionClient
    {
        #region Variables
        #endregion Variables

        #region Methods

        public static T Item<T>()
        {
            return LibSessionConnector.Item<T>();
        }

        #endregion Methods

        #region Properties

        public static String ServerUrl
        {
            get { return LibSessionConnector.ServerUrl; }
            set { LibSessionConnector.ServerUrl = value; }
        }

        public static LibAuthenticationMode AuthenticationMode
        {
            get { return LibSessionConnector.AuthenticationMode; }
            set { LibSessionConnector.AuthenticationMode = value; }
        }

        public static LibSessionConnectorParameter Parameters
        {
            get { return LibSessionConnector.Parameters; }
        }

        #endregion Properties
    }
}