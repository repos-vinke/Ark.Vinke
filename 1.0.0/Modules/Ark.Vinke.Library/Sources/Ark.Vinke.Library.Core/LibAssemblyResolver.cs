// LibAssemblyResolver.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, June 13

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Reflection;
using System.Globalization;
using System.Collections.Generic;

using Lazy.Vinke;

using Ark.Vinke.Library;

namespace Ark.Vinke.Library.Core
{
    public static class LibAssemblyResolver
    {
        #region Variables
        #endregion Variables

        #region Methods

        public static Assembly Resolve(Object sender, ResolveEventArgs args)
        {
            String assemblyPath = null;
            String assemblyFileName = args.Name.Substring(0, args.Name.IndexOf(','));
            String assemblyFolderName = assemblyFileName.ToLower();
            String assemblyVersion = args.Name.Substring(args.Name.IndexOf("Version=") + 8);
            assemblyVersion = assemblyVersion.Substring(0, assemblyVersion.IndexOf(','));
            assemblyVersion = assemblyVersion.Substring(0, assemblyVersion.LastIndexOf('.'));
            
            if (Directory.Exists(Path.Combine(LibDirectory.Root.Bin.Path, assemblyFolderName)) == false)
                return null;

            assemblyPath = Path.Combine(LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].Version[assemblyVersion].Lib.Net60.Path, assemblyFileName) + ".dll";

            if (File.Exists(assemblyPath) == false)
            {
                assemblyPath = Path.Combine(LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].Version[assemblyVersion].Lib.NetStandard20.Path, assemblyFileName) + ".dll";

                if (File.Exists(assemblyPath) == false)
                {
                    assemblyPath = Path.Combine(LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].Version[assemblyVersion].Lib.Net60Windows70.Path, assemblyFileName) + ".dll";

                    if (File.Exists(assemblyPath) == false)
                        return null;
                }
            }

            return Assembly.LoadFrom(assemblyPath);
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}