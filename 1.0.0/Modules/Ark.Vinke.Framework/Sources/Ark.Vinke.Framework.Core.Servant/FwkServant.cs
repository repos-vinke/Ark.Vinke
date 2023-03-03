// FwkServant.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 19

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Reflection;

using Lazy.Vinke;
using Lazy.Vinke.Database;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;
using Ark.Vinke.Framework;
using Ark.Vinke.Framework.Core;
using Ark.Vinke.Framework.Core.Data;
using Ark.Vinke.Framework.Core.IService;

namespace Ark.Vinke.Framework.Core.Servant
{
    public class FwkServant : IFwkService
    {
        #region Variables

        private IFwkService iService;

        #endregion Variables

        #region Constructors

        public FwkServant(FwkEnvironment environment)
        {
            #region Create service

            String assemblyFileName = this.GetType().Namespace.Replace("Servant", "Service");
            String assemblyFolderName = assemblyFileName.ToLower();
            String classFullName = this.GetType().FullName.Replace("Servant", "Service");

            this.iService = (IFwkService)LazyActivator.Local.CreateInstance(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.Net60.Path, assemblyFileName + ".dll"),
                classFullName, new Object[] { environment });

            #endregion Create service
        }

        public FwkServant(FwkEnvironment environment, LazyDatabase database)
        {
            #region Create service

            String assemblyFileName = this.GetType().Namespace.Replace("Servant", "Service");
            String assemblyFolderName = assemblyFileName.ToLower();
            String classFullName = this.GetType().FullName.Replace("Servant", "Service");

            this.iService = (IFwkService)LazyActivator.Local.CreateInstance(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.Net60.Path, assemblyFileName + ".dll"),
                classFullName, new Object[] { environment, database });

            #endregion Create service
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Invoke the service method
        /// </summary>
        /// <param name="methodName">The service method name</param>
        /// <param name="dataRequest">The service method request data</param>
        /// <returns>The service method response data</returns>
        protected FwkDataResponse InvokeService(String methodName, FwkDataRequest dataRequest)
        {
            MethodInfo methodInfo = this.iService.GetType().GetMethod(methodName);
            return (FwkDataResponse)methodInfo.Invoke(this.iService, new Object[] { dataRequest });
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
