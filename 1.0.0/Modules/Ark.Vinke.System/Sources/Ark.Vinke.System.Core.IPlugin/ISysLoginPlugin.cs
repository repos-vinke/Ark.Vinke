// ISysLoginPlugin.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 02

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
    public interface ISysLoginPlugin : IFwkPlugin
    {
        SysLoginPluginBeforeEventHandler AuthenticatePluginBeforeEventHandler { get; }
        SysLoginPluginAfterEventHandler AuthenticatePluginAfterEventHandler { get; }
    }

    #region EventArgs

    public class SysLoginPluginBeforeEventArgs : FwkPluginBeforeEventArgs
    {
        public SysLoginPluginBeforeEventArgs()
        {
        }

        public SysLoginPluginBeforeEventArgs(SysLoginDataRequest dataRequest, SysLoginDataResponse dataResponse)
            : base(dataRequest, dataResponse)
        {
        }
    }

    public class SysLoginPluginAfterEventArgs : FwkPluginAfterEventArgs
    {
        public SysLoginPluginAfterEventArgs()
        {
        }

        public SysLoginPluginAfterEventArgs(SysLoginDataRequest dataRequest, SysLoginDataResponse dataResponse)
            : base(dataRequest, dataResponse)
        {
        }
    }

    #endregion EventArgs

    #region EventHandlers

    public delegate void SysLoginPluginBeforeEventHandler(Object sender, SysLoginPluginBeforeEventArgs args);

    public delegate void SysLoginPluginAfterEventHandler(Object sender, SysLoginPluginAfterEventArgs args);

    #endregion EventHandlers
}
