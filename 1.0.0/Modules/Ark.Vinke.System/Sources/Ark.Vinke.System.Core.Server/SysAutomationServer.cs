// SysAutomationServer.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 21

using System;
using System.Xml;
using System.Data;
using System.Threading;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Lazy.Vinke;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;
using Ark.Vinke.Library.Core.Server;
using Ark.Vinke.Framework;
using Ark.Vinke.Framework.Core;
using Ark.Vinke.Framework.Core.Data;
using Ark.Vinke.Framework.Core.IServer;
using Ark.Vinke.Framework.Core.IService;
using Ark.Vinke.Framework.Core.Server;
using Ark.Vinke.Facilities;
using Ark.Vinke.Facilities.Core;
using Ark.Vinke.Facilities.Core.Data;
using Ark.Vinke.Facilities.Core.IServer;
using Ark.Vinke.Facilities.Core.IService;
using Ark.Vinke.Facilities.Core.Server;
using Ark.Vinke.System;
using Ark.Vinke.System.Core;
using Ark.Vinke.System.Core.Data;
using Ark.Vinke.System.Core.IServer;
using Ark.Vinke.System.Core.IService;

namespace Ark.Vinke.System.Core.Server
{
    public class SysAutomationServer : FwkServer, ISysAutomationServer, ILibTimedWorkerServer
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAutomationServer()
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Execute automation
        /// </summary>
        /// <param name="data">Timer data</param>
        public void Execute(Object data)
        {
            SysAutomationDataRequest automationDataRequest = new SysAutomationDataRequest();
            automationDataRequest.Content.TimedWorkerData = (LibTimedWorkerData)data;

            InvokeService("Execute", automationDataRequest, new FwkEnvironment());
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}