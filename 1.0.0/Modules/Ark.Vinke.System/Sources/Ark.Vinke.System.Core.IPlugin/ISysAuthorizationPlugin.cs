// ISysAuthorizationPlugin.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

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
    public interface ISysAuthorizationPlugin : IFwkPlugin
    {
        SysAuthorizationPluginBeforeEventHandler AuthorizePluginBeforeEventHandler { get; }
        SysAuthorizationPluginAfterEventHandler AuthorizePluginAfterEventHandler { get; }
    }

    #region EventArgs

    public class SysAuthorizationPluginBeforeEventArgs : FwkPluginBeforeEventArgs
    {
        public SysAuthorizationPluginBeforeEventArgs()
        {
        }

        public SysAuthorizationPluginBeforeEventArgs(SysAuthorizationDataRequest dataRequest, SysAuthorizationDataResponse dataResponse)
            : base(dataRequest, dataResponse)
        {
        }
    }

    public class SysAuthorizationPluginAfterEventArgs : FwkPluginAfterEventArgs
    {
        public SysAuthorizationPluginAfterEventArgs()
        {
        }

        public SysAuthorizationPluginAfterEventArgs(SysAuthorizationDataRequest dataRequest, SysAuthorizationDataResponse dataResponse)
            : base(dataRequest, dataResponse)
        {
        }
    }

    #endregion EventArgs

    #region EventHandlers

    public delegate void SysAuthorizationPluginBeforeEventHandler(Object sender, SysAuthorizationPluginBeforeEventArgs args);

    public delegate void SysAuthorizationPluginAfterEventHandler(Object sender, SysAuthorizationPluginAfterEventArgs args);

    #endregion EventHandlers
}
