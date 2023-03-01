// LibAuthenticationServer.cs
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
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Lazy.Vinke;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;

namespace Ark.Vinke.Library.Core.Server
{
    public class LibAuthenticationServer
    {
        #region Variables

        private readonly RequestDelegate next;
        private static ILibAuthenticationServer iAuthenticationServer;

        #endregion Variables

        #region Constructors

        public LibAuthenticationServer(RequestDelegate next)
        {
            this.next = next;

            if (iAuthenticationServer == null)
            {
                String assemblyFolderName = LibConfigurationServer.DynamicXml["Ark.Vinke.Library"]["Security"]["Authentication"].Attribute["Assembly"].Replace(".dll", String.Empty).ToLower();
                String assemblyFileName = LibConfigurationServer.DynamicXml["Ark.Vinke.Library"]["Security"]["Authentication"].Attribute["Assembly"];
                String assemblyVersion = LibConfigurationServer.DynamicXml["Ark.Vinke.Library"]["Security"]["Authentication"].Attribute["Version"];
                String classFullName = LibConfigurationServer.DynamicXml["Ark.Vinke.Library"]["Security"]["Authentication"].Attribute["Class"];

                if (String.IsNullOrEmpty(assemblyFileName) == false && String.IsNullOrEmpty(classFullName) == false)
                {
                    iAuthenticationServer = (ILibAuthenticationServer)LazyActivator.Local.CreateInstance(Path.Combine(
                        LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].Version[assemblyVersion].Lib.Net60.Path, assemblyFileName),
                        classFullName);
                }
            }
        }

        #endregion Constructors

        #region Methods

        public async Task Invoke(HttpContext context)
        {
            if (iAuthenticationServer != null)
                iAuthenticationServer.Authenticate(context);

            await this.next(context);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}