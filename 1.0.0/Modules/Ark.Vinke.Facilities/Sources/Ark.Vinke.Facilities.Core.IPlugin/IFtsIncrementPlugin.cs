// IFtsIncrementPlugin.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 12

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

namespace Ark.Vinke.Facilities.Core.IPlugin
{
    public interface IFtsIncrementPlugin : IFwkPlugin
    {
        FtsIncrementPluginBeforeEventHandler ValidateNextPluginBeforeEventHandler { get; }

        FtsIncrementPluginAfterEventHandler ValidateNextPluginAfterEventHandler { get; }

        FtsIncrementPluginBeforeEventHandler ValidateFixPluginBeforeEventHandler { get; }

        FtsIncrementPluginAfterEventHandler ValidateFixPluginAfterEventHandler { get; }

        FtsIncrementPluginBeforeEventHandler NextPluginBeforeEventHandler { get; }

        FtsIncrementPluginAfterEventHandler NextPluginAfterEventHandler { get; }

        FtsIncrementPluginBeforeEventHandler FixPluginBeforeEventHandler { get; }

        FtsIncrementPluginAfterEventHandler FixPluginAfterEventHandler { get; }
    }

    #region EventArgs

    public class FtsIncrementPluginBeforeEventArgs : FwkPluginBeforeEventArgs
    {
        public FtsIncrementPluginBeforeEventArgs()
        {
        }

        public FtsIncrementPluginBeforeEventArgs(FtsIncrementDataRequest dataRequest, FtsIncrementDataResponse dataResponse)
            : base(dataRequest, dataResponse)
        {
        }
    }

    public class FtsIncrementPluginAfterEventArgs : FwkPluginAfterEventArgs
    {
        public FtsIncrementPluginAfterEventArgs()
        {
        }

        public FtsIncrementPluginAfterEventArgs(FtsIncrementDataRequest dataRequest, FtsIncrementDataResponse dataResponse)
            : base(dataRequest, dataResponse)
        {
        }
    }

    #endregion EventArgs

    #region EventHandlers

    public delegate void FtsIncrementPluginBeforeEventHandler(Object sender, FtsIncrementPluginBeforeEventArgs args);

    public delegate void FtsIncrementPluginAfterEventHandler(Object sender, FtsIncrementPluginAfterEventArgs args);

    #endregion EventHandlers
}
