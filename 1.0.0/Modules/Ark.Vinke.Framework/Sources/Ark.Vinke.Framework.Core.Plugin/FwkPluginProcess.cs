// FwkPluginProcess.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, May 29

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

namespace Ark.Vinke.Framework.Core.Plugin
{
    public class FwkPluginProcess : FwkPluginBasic, IFwkPluginProcess
    {
        #region Variables

        protected FwkPluginProcessBeforeEventHandler nextPluginProcessBeforeEventHandler;
        protected FwkPluginProcessAfterEventHandler nextPluginProcessAfterEventHandler;
        protected FwkPluginProcessBeforeEventHandler executePluginProcessBeforeEventHandler;
        protected FwkPluginProcessAfterEventHandler executePluginProcessAfterEventHandler;

        #endregion Variables

        #region Constructors

        public FwkPluginProcess(LazyDatabase database)
            : base(database)
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public FwkPluginProcessBeforeEventHandler NextPluginProcessBeforeEventHandler { get { return this.nextPluginProcessBeforeEventHandler; } }

        public FwkPluginProcessAfterEventHandler NextPluginProcessAfterEventHandler { get { return this.nextPluginProcessAfterEventHandler; } }

        public FwkPluginProcessBeforeEventHandler ExecutePluginProcessBeforeEventHandler { get { return this.executePluginProcessBeforeEventHandler; } }

        public FwkPluginProcessAfterEventHandler ExecutePluginProcessAfterEventHandler { get { return this.executePluginProcessAfterEventHandler; } }

        #endregion Properties
    }
}