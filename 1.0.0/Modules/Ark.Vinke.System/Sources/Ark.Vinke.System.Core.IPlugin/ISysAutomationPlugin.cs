// ISysAutomationPlugin.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 21

using System;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Lazy.Vinke;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;
using Ark.Vinke.Framework;
using Ark.Vinke.Framework.Core;
using Ark.Vinke.Framework.Core.Data;
using Ark.Vinke.Framework.Core.IPlugin;
using Ark.Vinke.Facilities;
using Ark.Vinke.Facilities.Core;
using Ark.Vinke.Facilities.Core.Data;
using Ark.Vinke.Facilities.Core.IPlugin;
using Ark.Vinke.System;
using Ark.Vinke.System.Core;
using Ark.Vinke.System.Core.Data;

namespace Ark.Vinke.System.Core.IPlugin
{
    public interface ISysAutomationPlugin : IFwkPlugin
    {
        SysAutomationPluginBeforeEventHandler ExecutePluginBeforeEventHandler { get; }
        SysAutomationPluginAfterEventHandler ExecutePluginAfterEventHandler { get; }
    }

    #region EventArgs

    public class SysAutomationPluginBeforeEventArgs : FwkPluginBeforeEventArgs
    {
        public SysAutomationPluginBeforeEventArgs()
        {
        }

        public SysAutomationPluginBeforeEventArgs(SysAutomationDataRequest dataRequest, SysAutomationDataResponse dataResponse)
            : base(dataRequest, dataResponse)
        {
        }
    }

    public class SysAutomationPluginAfterEventArgs : FwkPluginAfterEventArgs
    {
        public SysAutomationPluginAfterEventArgs()
        {
        }

        public SysAutomationPluginAfterEventArgs(SysAutomationDataRequest dataRequest, SysAutomationDataResponse dataResponse)
            : base(dataRequest, dataResponse)
        {
        }
    }

    #endregion EventArgs

    #region EventHandlers

    public delegate void SysAutomationPluginBeforeEventHandler(Object sender, SysAutomationPluginBeforeEventArgs args);

    public delegate void SysAutomationPluginAfterEventHandler(Object sender, SysAutomationPluginAfterEventArgs args);

    #endregion EventHandlers
}
