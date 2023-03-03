// IFwkPlugin.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 19

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
    public interface IFwkPlugin
    {
    }

    #region EventArgs

    public class FwkPluginBeforeEventArgs : EventArgs
    {
        public FwkPluginBeforeEventArgs()
        {
        }

        public FwkPluginBeforeEventArgs(FwkDataRequest dataRequest, FwkDataResponse dataResponse)
        {
            this.DataRequest = dataRequest;
            this.DataResponse = dataResponse;
        }

        public FwkDataRequest DataRequest { get; set; }
        public FwkDataResponse DataResponse { get; set; }
    }

    public class FwkPluginAfterEventArgs : EventArgs
    {
        public FwkPluginAfterEventArgs()
        {
        }

        public FwkPluginAfterEventArgs(FwkDataRequest dataRequest, FwkDataResponse dataResponse)
        {
            this.DataRequest = dataRequest;
            this.DataResponse = dataResponse;
        }

        public FwkDataRequest DataRequest { get; set; }
        public FwkDataResponse DataResponse { get; set; }
    }

    #endregion EventArgs

    #region EventHandlers

    public delegate void FwkPluginBeforeEventHandler(Object sender, FwkPluginBeforeEventArgs args);

    public delegate void FwkPluginAfterEventHandler(Object sender, FwkPluginAfterEventArgs args);

    #endregion EventHandlers
}
