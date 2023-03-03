﻿// IFwkPluginView.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, December 31

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
    public interface IFwkPluginView : IFwkPluginBasic
    {
        FwkPluginViewBeforeEventHandler FormatPluginViewBeforeEventHandler { get; }
        FwkPluginViewAfterEventHandler FormatPluginViewAfterEventHandler { get; }

        FwkPluginViewBeforeEventHandler ValidateReadPluginViewBeforeEventHandler { get; }
        FwkPluginViewAfterEventHandler ValidateReadPluginViewAfterEventHandler { get; }

        FwkPluginViewBeforeEventHandler ReadPluginViewBeforeEventHandler { get; }
        FwkPluginViewAfterEventHandler ReadPluginViewAfterEventHandler { get; }
    }

    #region EventArgs

    public class FwkPluginViewBeforeEventArgs : FwkPluginBasicBeforeEventArgs
    {
        public FwkPluginViewBeforeEventArgs()
        {
        }

        public FwkPluginViewBeforeEventArgs(FwkDataViewRequest dataViewRequest, FwkDataViewResponse dataViewResponse)
            : base(dataViewRequest, dataViewResponse)
        {
        }
    }

    public class FwkPluginViewAfterEventArgs : FwkPluginBasicAfterEventArgs
    {
        public FwkPluginViewAfterEventArgs()
        {
        }

        public FwkPluginViewAfterEventArgs(FwkDataViewRequest dataViewRequest, FwkDataViewResponse dataViewResponse)
            : base(dataViewRequest, dataViewResponse)
        {
        }
    }

    #endregion EventArgs

    #region EventHandlers

    public delegate void FwkPluginViewBeforeEventHandler(Object sender, FwkPluginViewBeforeEventArgs args);

    public delegate void FwkPluginViewAfterEventHandler(Object sender, FwkPluginViewAfterEventArgs args);

    #endregion EventHandlers
}
