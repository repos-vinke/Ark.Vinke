// ISysPreflightPlugin.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 30

using System;
using System.Xml;
using System.Data;

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
    public interface ISysPreflightPlugin : IFwkPlugin
    {
        SysPreflightPluginBeforeEventHandler PreflightPluginBeforeEventHandler { get; }
        SysPreflightPluginAfterEventHandler PreflightPluginAfterEventHandler { get; }
    }

    #region EventArgs

    public class SysPreflightPluginBeforeEventArgs : FwkPluginBeforeEventArgs
    {
        public SysPreflightPluginBeforeEventArgs()
        {
        }

        public SysPreflightPluginBeforeEventArgs(SysPreflightDataRequest dataRequest, SysPreflightDataResponse dataResponse)
            : base(dataRequest, dataResponse)
        {
        }
    }

    public class SysPreflightPluginAfterEventArgs : FwkPluginAfterEventArgs
    {
        public SysPreflightPluginAfterEventArgs()
        {
        }

        public SysPreflightPluginAfterEventArgs(SysPreflightDataRequest dataRequest, SysPreflightDataResponse dataResponse)
            : base(dataRequest, dataResponse)
        {
        }
    }

    #endregion EventArgs

    #region EventHandlers

    public delegate void SysPreflightPluginBeforeEventHandler(Object sender, SysPreflightPluginBeforeEventArgs args);

    public delegate void SysPreflightPluginAfterEventHandler(Object sender, SysPreflightPluginAfterEventArgs args);

    #endregion EventHandlers
}
