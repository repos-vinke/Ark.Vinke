// FwkServer.cs
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

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Lazy.Vinke;
using Lazy.Vinke.Json;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;
using Ark.Vinke.Library.Core.Server;
using Ark.Vinke.Framework;
using Ark.Vinke.Framework.Core;
using Ark.Vinke.Framework.Core.Data;
using Ark.Vinke.Framework.Core.IServer;
using Ark.Vinke.Framework.Core.IService;

namespace Ark.Vinke.Framework.Core.Server
{
    [ApiController]
    [Route("Ark.Vinke.Framework/Core.Server/[controller]")]
    public class FwkServer : ControllerBase, IFwkServer
    {
        #region Variables

        private LazyJsonReaderOptions jsonReaderOptions;
        private LazyJsonWriterOptions jsonWriterOptions;
        private LazyJsonDeserializerOptions deserializerOptions;
        private LazyJsonSerializerOptions serializerOptions;

        #endregion Variables

        #region Constructors

        public FwkServer()
        {
            if (this.GetType() == typeof(FwkServer))
            {
                this.DataRequestType = typeof(FwkDataRequest);
                this.DataResponseType = typeof(FwkDataResponse);
            }
            
            this.DeserializerOptions.Item<LazyJsonDeserializerOptionsDateTime>().Format = LibStringFormat.DateTime.ISO8601Z;
            this.SerializerOptions.Item<LazyJsonSerializerOptionsDateTime>().Format = LibStringFormat.DateTime.ISO8601Z;
            
            this.JsonWriterOptions.Indent = false;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Invoke the service method
        /// </summary>
        /// <param name="methodName">The service method name</param>
        /// <param name="dataRequestString">The service method request data string</param>
        /// <returns>The service method response data string</returns>
        protected String InvokeService(String methodName, String dataRequestString)
        {
            return InvokeService(methodName, dataRequestString, this.HttpContext);
        }

        /// <summary>
        /// Invoke the service method
        /// </summary>
        /// <param name="methodName">The service method name</param>
        /// <param name="dataRequestString">The service method request data string</param>
        /// <param name="context">The http context</param>
        /// <returns>The service method response data string</returns>
        protected String InvokeService(String methodName, String dataRequestString, HttpContext context)
        {
            context.Response.ContentType = "application/json;charset=utf-8";
            return InvokeService(methodName, dataRequestString, CreateEnvironment(context));
        }

        /// <summary>
        /// Invoke the service method
        /// </summary>
        /// <param name="methodName">The service method name</param>
        /// <param name="dataRequestString">The service method request data string</param>
        /// <param name="environment">The service environment</param>
        /// <returns>The service method response data string</returns>
        protected String InvokeService(String methodName, String dataRequestString, FwkEnvironment environment)
        {
            try
            {
                IFwkService iService = CreateService(environment);

                MethodInfo methodInfo = iService.GetType().GetMethod(methodName);
                FwkDataRequest dataRequest = (FwkDataRequest)LazyJsonDeserializer.Deserialize(dataRequestString, this.DataRequestType, deserializerOptions: this.deserializerOptions, jsonReaderOptions: this.jsonReaderOptions);
                FwkDataResponse dataResponse = (FwkDataResponse)methodInfo.Invoke(iService, new Object[] { dataRequest });

                #region Write response scope success

                if (String.IsNullOrEmpty(dataResponse.Scope.StatusCode) == true)
                    dataResponse.Scope.StatusCode = LazyAttribute.GetCustomAttributeFromEnumValue<LazyAttributeGeneric>(FwkScopeStatus.Success).Code;

                if (String.IsNullOrEmpty(dataResponse.Scope.StatusName) == true)
                    dataResponse.Scope.StatusName = LazyAttribute.GetCustomAttributeFromEnumValue<LazyAttributeGeneric>(FwkScopeStatus.Success).Name;

                if (String.IsNullOrEmpty(dataResponse.Scope.StatusCaption) == true)
                    dataResponse.Scope.StatusCaption = LibGlobalization.GetTranslation(Properties.FwkResourcesCoreServer.FwkCaptionSuccess, environment.Culture);

                if (String.IsNullOrEmpty(dataResponse.Scope.StatusMessage) == true)
                    dataResponse.Scope.StatusMessage = LibGlobalization.GetTranslation(Properties.FwkResourcesCoreServer.FwkMessageSuccess, environment.Culture);

                #endregion Write response scope success

                return LazyJsonSerializer.Serialize(dataResponse, serializerOptions: this.serializerOptions, jsonWriterOptions: this.jsonWriterOptions);
            }
            catch (Exception exp)
            {
                FwkDataResponse dataResponse = (FwkDataResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

                #region Write response scope error

                dataResponse.Scope.StatusCode = LazyAttribute.GetCustomAttributeFromEnumValue<LazyAttributeGeneric>(FwkScopeStatus.Error).Code;
                dataResponse.Scope.StatusName = LazyAttribute.GetCustomAttributeFromEnumValue<LazyAttributeGeneric>(FwkScopeStatus.Error).Name;
                dataResponse.Scope.StatusCaption = LibException.GetExceptionCaption(exp.GetBaseException(), environment.Culture);
                dataResponse.Scope.StatusMessage = LibException.GetExceptionMessage(exp.GetBaseException(), environment.Culture);

                #endregion Write response scope error

                return LazyJsonSerializer.Serialize(dataResponse, serializerOptions: this.serializerOptions, jsonWriterOptions: this.jsonWriterOptions);
            }
        }

        /// <summary>
        /// Invoke the service method
        /// </summary>
        /// <param name="methodName">The service method name</param>
        /// <param name="dataRequest">The service method request data</param>
        /// <returns>The service method response data</returns>
        protected FwkDataResponse InvokeService(String methodName, FwkDataRequest dataRequest)
        {
            return InvokeService(methodName, dataRequest, this.HttpContext);
        }

        /// <summary>
        /// Invoke the service method
        /// </summary>
        /// <param name="methodName">The service method name</param>
        /// <param name="dataRequest">The service method request data</param>
        /// <param name="context">The http context</param>
        /// <returns>The service method response data</returns>
        protected FwkDataResponse InvokeService(String methodName, FwkDataRequest dataRequest, HttpContext context)
        {
            return InvokeService(methodName, dataRequest, CreateEnvironment(context));
        }

        /// <summary>
        /// Invoke the service method
        /// </summary>
        /// <param name="methodName">The service method name</param>
        /// <param name="dataRequest">The service method request data</param>
        /// <param name="environment">The service environment</param>
        /// <returns>The service method response data</returns>
        protected FwkDataResponse InvokeService(String methodName, FwkDataRequest dataRequest, FwkEnvironment environment)
        {
            try
            {
                IFwkService iService = CreateService(environment);

                MethodInfo methodInfo = iService.GetType().GetMethod(methodName);
                FwkDataResponse dataResponse = (FwkDataResponse)methodInfo.Invoke(iService, new Object[] { dataRequest });

                #region Write response scope success

                if (String.IsNullOrEmpty(dataResponse.Scope.StatusCode) == true)
                    dataResponse.Scope.StatusCode = LazyAttribute.GetCustomAttributeFromEnumValue<LazyAttributeGeneric>(FwkScopeStatus.Success).Code;

                if (String.IsNullOrEmpty(dataResponse.Scope.StatusName) == true)
                    dataResponse.Scope.StatusName = LazyAttribute.GetCustomAttributeFromEnumValue<LazyAttributeGeneric>(FwkScopeStatus.Success).Name;

                if (String.IsNullOrEmpty(dataResponse.Scope.StatusCaption) == true)
                    dataResponse.Scope.StatusCaption = LibGlobalization.GetTranslation(Properties.FwkResourcesCoreServer.FwkCaptionSuccess, environment.Culture);

                if (String.IsNullOrEmpty(dataResponse.Scope.StatusMessage) == true)
                    dataResponse.Scope.StatusMessage = LibGlobalization.GetTranslation(Properties.FwkResourcesCoreServer.FwkMessageSuccess, environment.Culture);

                #endregion Write response scope success

                return dataResponse;
            }
            catch (Exception exp)
            {
                FwkDataResponse dataResponse = (FwkDataResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

                #region Write response scope error

                dataResponse.Scope.StatusCode = LazyAttribute.GetCustomAttributeFromEnumValue<LazyAttributeGeneric>(FwkScopeStatus.Error).Code;
                dataResponse.Scope.StatusName = LazyAttribute.GetCustomAttributeFromEnumValue<LazyAttributeGeneric>(FwkScopeStatus.Error).Name;
                dataResponse.Scope.StatusCaption = LibException.GetExceptionCaption(exp.InnerException == null ? exp : exp.InnerException, environment.Culture);
                dataResponse.Scope.StatusMessage = LibException.GetExceptionMessage(exp.InnerException == null ? exp : exp.InnerException, environment.Culture);

                #endregion Write response scope error

                return dataResponse;
            }
        }

        /// <summary>
        /// Create environment
        /// </summary>
        /// <param name="context"></param>
        private FwkEnvironment CreateEnvironment(HttpContext context)
        {
            FwkEnvironment environment = new FwkEnvironment();

            #region Initialize culture

            String culture = null;
            if (context.Request.Headers.ContainsKey("Culture") == true)
                culture = LazyConvert.ToString(context.Request.Headers["Culture"], null);

            try { environment.Culture = new LibCulture(culture); }
            catch { environment.Culture = LibGlobalization.Culture; }

            #endregion Initialize culture

            #region Initialize database alias

            if (context.Items.ContainsKey("DatabaseAlias") == true)
                environment.DatabaseAlias = LazyConvert.ToString(context.Items["DatabaseAlias"]);

            #endregion Initialize database alias

            if (context.Items.ContainsKey("IdDomain") == true)
            {
                #region Initialize domain

                environment.Domain = new FwkDomain();
                environment.Domain.IdDomain = LazyConvert.ToInt16(context.Items["IdDomain"]);

                #endregion Initialize domain

                if (context.Items.ContainsKey("IdUser") == true)
                {
                    #region Initialize user

                    environment.User = new FwkUser();
                    environment.User.IdDomain = environment.Domain.IdDomain;
                    environment.User.IdUser = LazyConvert.ToInt32(context.Items["IdUser"]);

                    #endregion Initialize user

                    #region Initialize user context

                    environment.UserContext = new FwkUserContext();
                    environment.UserContext["IdDomain"].ValueInt16 = environment.Domain.IdDomain;

                    #endregion Initialize user context
                }
            }

            return environment;
        }

        /// <summary>
        /// Create service
        /// </summary>
        /// <param name="environment">The service environment</param>
        /// <returns>The service</returns>
        private IFwkService CreateService(FwkEnvironment environment)
        {
            String assemblyFileName = this.GetType().Namespace.Replace("Server", "Service");
            String assemblyFolderName = assemblyFileName.ToLower();
            String classFullName = this.GetType().FullName.Replace("Server", "Service");

            return (IFwkService)LazyActivator.Local.CreateInstance(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.Net60.Path, assemblyFileName + ".dll"),
                classFullName, new Object[] { environment });
        }

        #endregion Methods

        #region Properties

        protected Type DataRequestType { get; set; }

        protected Type DataResponseType { get; set; }

        protected LazyJsonReaderOptions JsonReaderOptions
        {
            get
            {
                if (this.jsonReaderOptions == null)
                    this.jsonReaderOptions = new LazyJsonReaderOptions();

                return this.jsonReaderOptions;
            }
        }

        protected LazyJsonWriterOptions JsonWriterOptions
        {
            get
            {
                if (this.jsonWriterOptions == null)
                    this.jsonWriterOptions = new LazyJsonWriterOptions();

                return this.jsonWriterOptions;
            }
        }

        protected LazyJsonDeserializerOptions DeserializerOptions
        {
            get
            {
                if (this.deserializerOptions == null)
                    this.deserializerOptions = new LazyJsonDeserializerOptions();

                return this.deserializerOptions;
            }
        }

        protected LazyJsonSerializerOptions SerializerOptions
        {
            get
            {
                if (this.serializerOptions == null)
                    this.serializerOptions = new LazyJsonSerializerOptions();

                return this.serializerOptions;
            }
        }

        #endregion Properties
    }
}
