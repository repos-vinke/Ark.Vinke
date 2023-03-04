// LibAuthorizationServer.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Reflection;

using Microsoft.AspNetCore.Mvc.Filters;

using Lazy.Vinke;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;

namespace Ark.Vinke.Library.Core.Server
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class LibAuthorizationServer : Attribute, IAuthorizationFilter
    {
        #region Variables

        private static ILibAuthorizationServer iAuthorizationServer;

        #endregion Variables

        #region Constructors

        public LibAuthorizationServer()
        {
            if (iAuthorizationServer == null)
            {
                String assemblyFolderName = LibConfigurationServer.DynamicXml["Ark.Vinke.Library"]["Security"]["Authorization"].Attribute["Assembly"].Replace(".dll", String.Empty).ToLower();
                String assemblyFileName = LibConfigurationServer.DynamicXml["Ark.Vinke.Library"]["Security"]["Authorization"].Attribute["Assembly"];
                String classFullName = LibConfigurationServer.DynamicXml["Ark.Vinke.Library"]["Security"]["Authorization"].Attribute["Class"];

                if (String.IsNullOrEmpty(assemblyFileName) == false && String.IsNullOrEmpty(classFullName) == false)
                {
                    iAuthorizationServer = (ILibAuthorizationServer)LazyActivator.Local.CreateInstance(Path.Combine(
                        LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.Net60.Path, assemblyFileName),
                        classFullName);
                }
            }
        }

        #endregion Constructors

        #region Methods

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (iAuthorizationServer != null)
                iAuthorizationServer.Authorize(context);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}