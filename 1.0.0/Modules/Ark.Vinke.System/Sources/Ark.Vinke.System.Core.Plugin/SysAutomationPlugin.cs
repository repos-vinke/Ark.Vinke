// SysAutomationPlugin.cs
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
    public class SysAutomationPlugin : FwkPlugin, ISysAutomationPlugin
    {
        #region Variables

        protected SysAutomationPluginBeforeEventHandler executePluginBeforeEventHandler;
        protected SysAutomationPluginAfterEventHandler executePluginAfterEventHandler;

        #endregion Variables

        #region Constructors

        public SysAutomationPlugin(LazyDatabase database)
            : base(database)
        {
        }

        #endregion Constructors

        #region Methods

        protected virtual void OnExecutePluginBeforeEventHandler(Object sender, SysAutomationPluginBeforeEventArgs args)
        {
        }

        protected virtual void OnExecutePluginAfterEventHandler(Object sender, SysAutomationPluginAfterEventArgs args)
        {
        }

        #endregion Methods

        #region Properties

        public SysAutomationPluginBeforeEventHandler ExecutePluginBeforeEventHandler { get { return this.executePluginBeforeEventHandler; } }

        public SysAutomationPluginAfterEventHandler ExecutePluginAfterEventHandler { get { return this.executePluginAfterEventHandler; } }

        #endregion Properties
    }
}