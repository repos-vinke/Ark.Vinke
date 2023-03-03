// ISysAuthenticationPlugin.cs
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
    public interface ISysAuthenticationPlugin : IFwkPlugin
    {
        SysAuthenticationPluginBeforeEventHandler AuthenticatePluginBeforeEventHandler { get; }
        SysAuthenticationPluginAfterEventHandler AuthenticatePluginAfterEventHandler { get; }
    }

    #region EventArgs

    public class SysAuthenticationPluginBeforeEventArgs : FwkPluginBeforeEventArgs
    {
        public SysAuthenticationPluginBeforeEventArgs()
        {
        }

        public SysAuthenticationPluginBeforeEventArgs(SysAuthenticationDataRequest dataRequest, SysAuthenticationDataResponse dataResponse)
            : base(dataRequest, dataResponse)
        {
        }
    }

    public class SysAuthenticationPluginAfterEventArgs : FwkPluginAfterEventArgs
    {
        public SysAuthenticationPluginAfterEventArgs()
        {
        }

        public SysAuthenticationPluginAfterEventArgs(SysAuthenticationDataRequest dataRequest, SysAuthenticationDataResponse dataResponse)
            : base(dataRequest, dataResponse)
        {
        }
    }

    #endregion EventArgs

    #region EventHandlers

    public delegate void SysAuthenticationPluginBeforeEventHandler(Object sender, SysAuthenticationPluginBeforeEventArgs args);

    public delegate void SysAuthenticationPluginAfterEventHandler(Object sender, SysAuthenticationPluginAfterEventArgs args);

    #endregion EventHandlers
}
