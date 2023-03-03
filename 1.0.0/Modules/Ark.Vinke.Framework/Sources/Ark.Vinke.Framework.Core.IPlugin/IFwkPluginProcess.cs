// IFwkPluginProcess.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, May 15

using System;
using System.Xml;
using System.Data;

using Lazy.Vinke;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;
using Ark.Vinke.Framework;
using Ark.Vinke.Framework.Core;
using Ark.Vinke.Framework.Core.Data;

namespace Ark.Vinke.Framework.Core.IPlugin
{
    public interface IFwkPluginProcess : IFwkPluginBasic
    {
        FwkPluginProcessBeforeEventHandler NextPluginProcessBeforeEventHandler { get; }
        FwkPluginProcessAfterEventHandler NextPluginProcessAfterEventHandler { get; }

        FwkPluginProcessBeforeEventHandler ExecutePluginProcessBeforeEventHandler { get; }
        FwkPluginProcessAfterEventHandler ExecutePluginProcessAfterEventHandler { get; }
    }

    #region EventArgs

    public class FwkPluginProcessBeforeEventArgs : FwkPluginBasicBeforeEventArgs
    {
        public FwkPluginProcessBeforeEventArgs()
        {
        }

        public FwkPluginProcessBeforeEventArgs(FwkDataProcessRequest dataProcessRequest, FwkDataProcessResponse dataProcessResponse)
            : base(dataProcessRequest, dataProcessResponse)
        {
        }
    }

    public class FwkPluginProcessAfterEventArgs : FwkPluginBasicAfterEventArgs
    {
        public FwkPluginProcessAfterEventArgs()
        {
        }

        public FwkPluginProcessAfterEventArgs(FwkDataProcessRequest dataProcessRequest, FwkDataProcessResponse dataProcessResponse)
            : base(dataProcessRequest, dataProcessResponse)
        {
        }
    }

    #endregion EventArgs

    #region EventHandlers

    public delegate void FwkPluginProcessBeforeEventHandler(Object sender, FwkPluginProcessBeforeEventArgs args);

    public delegate void FwkPluginProcessAfterEventHandler(Object sender, FwkPluginProcessAfterEventArgs args);

    #endregion EventHandlers
}
