// SysAuthorizationPlugin.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2023, March 03

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Lazy.Vinke;
using Lazy.Vinke.Database;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;
using Ark.Vinke.Framework;
using Ark.Vinke.Framework.Core;
using Ark.Vinke.Framework.Core.Data;
using Ark.Vinke.Framework.Core.IPlugin;
using Ark.Vinke.Framework.Core.Plugin;
using Ark.Vinke.Facilities;
using Ark.Vinke.Facilities.Core;
using Ark.Vinke.Facilities.Core.Data;
using Ark.Vinke.Facilities.Core.IPlugin;
using Ark.Vinke.Facilities.Core.Plugin;
using Ark.Vinke.System;
using Ark.Vinke.System.Core;
using Ark.Vinke.System.Core.Data;
using Ark.Vinke.System.Core.IPlugin;

namespace Ark.Vinke.System.Core.Plugin
{
    public class SysAuthorizationPlugin : FwkPlugin, ISysAuthorizationPlugin
    {
        #region Variables

        protected SysAuthorizationPluginBeforeEventHandler authorizePluginBeforeEventHandler;
        protected SysAuthorizationPluginAfterEventHandler authorizePluginAfterEventHandler;

        #endregion Variables

        #region Constructors

        public SysAuthorizationPlugin(LazyDatabase database)
            : base(database)
        {
        }

        #endregion Constructors

        #region Methods

        protected virtual void OnAuthorizePluginBeforeEventHandler(Object sender, SysAuthorizationPluginBeforeEventArgs args)
        {
        }

        protected virtual void OnAuthorizePluginAfterEventHandler(Object sender, SysAuthorizationPluginAfterEventArgs args)
        {
        }

        #endregion Methods

        #region Properties

        public SysAuthorizationPluginBeforeEventHandler AuthorizePluginBeforeEventHandler { get { return this.authorizePluginBeforeEventHandler; } }

        public SysAuthorizationPluginAfterEventHandler AuthorizePluginAfterEventHandler { get { return this.authorizePluginAfterEventHandler; } }

        #endregion Properties
    }
}