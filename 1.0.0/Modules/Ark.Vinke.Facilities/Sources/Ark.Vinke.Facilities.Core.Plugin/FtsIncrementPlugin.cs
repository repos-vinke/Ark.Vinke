// FtsIncrementPlugin.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2023, March 03

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
using Ark.Vinke.Framework.Core.Plugin;
using Ark.Vinke.Facilities;
using Ark.Vinke.Facilities.Core;
using Ark.Vinke.Facilities.Core.Data;
using Ark.Vinke.Facilities.Core.IPlugin;

namespace Ark.Vinke.Facilities.Core.Plugin
{
    public class FtsIncrementPlugin : FwkPlugin, IFtsIncrementPlugin
    {
        #region Variables

        protected FtsIncrementPluginBeforeEventHandler validateNextPluginBeforeEventHandler;
        protected FtsIncrementPluginAfterEventHandler validateNextPluginAfterEventHandler;
        protected FtsIncrementPluginBeforeEventHandler nextPluginBeforeEventHandler;
        protected FtsIncrementPluginAfterEventHandler nextPluginAfterEventHandler;

        #endregion Variables

        #region Constructors

        public FtsIncrementPlugin(LazyDatabase database)
            : base(database)
        {
        }

        #endregion Constructors

        #region Methods

        protected virtual void OnValidateNextPluginBeforeEventHandler(Object sender, FtsIncrementPluginBeforeEventArgs args)
        {
        }

        protected virtual void OnValidateNextPluginAfterEventHandler(Object sender, FtsIncrementPluginAfterEventArgs args)
        {
        }

        protected virtual void OnNextPluginBeforeEventHandler(Object sender, FtsIncrementPluginBeforeEventArgs args)
        {
        }

        protected virtual void OnNextPluginAfterEventHandler(Object sender, FtsIncrementPluginAfterEventArgs args)
        {
        }

        #endregion Methods

        #region Properties

        public FtsIncrementPluginBeforeEventHandler ValidateNextPluginBeforeEventHandler { get { return this.validateNextPluginBeforeEventHandler; } }

        public FtsIncrementPluginAfterEventHandler ValidateNextPluginAfterEventHandler { get { return this.validateNextPluginAfterEventHandler; } }

        public FtsIncrementPluginBeforeEventHandler NextPluginBeforeEventHandler { get { return this.nextPluginBeforeEventHandler; } }

        public FtsIncrementPluginAfterEventHandler NextPluginAfterEventHandler { get { return this.nextPluginAfterEventHandler; } }

        #endregion Properties
    }
}