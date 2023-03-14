// FwkConnector.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2023, March 12

using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using Lazy.Vinke;
using Lazy.Vinke.Json;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;
using Ark.Vinke.Library.Core.Connector;

using Ark.Vinke.Framework;
using Ark.Vinke.Framework.Core;
using Ark.Vinke.Framework.Core.Data;
using Ark.Vinke.Framework.Core.IServer;

namespace Ark.Vinke.Framework.Core.Connector
{
    public class FwkConnector
    {
        #region Variables

        private Type dataResponseType;

        private LazyJsonWriterOptions jsonWriterOptions;
        private LazyJsonReaderOptions jsonReaderOptions;
        private LazyJsonSerializerOptions serializerOptions;
        private LazyJsonDeserializerOptions deserializerOptions;

        #endregion Variables

        #region Constructors

        public FwkConnector()
        {
            #region Initialize data type

            Type type = this.GetType();

            String assemblyFileName = type.Namespace.Replace("Connector", "Data");
            String assemblyFolderName = assemblyFileName.ToLower();
            String classFullName = type.FullName.Replace("Connector", "Data") + "Response";

            this.dataResponseType = LazyActivator.Local.GetType(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.Net60.Path, assemblyFileName + ".dll"),
                classFullName);

            #endregion Initialize data type
            
            this.Route = "Ark.Vinke.Framework/Core.Server/FwkServer";
            
            this.DeserializerOptions.Item<LazyJsonDeserializerOptionsDateTime>().Format = LibStringFormat.DateTime.ISO8601Z;
            this.SerializerOptions.Item<LazyJsonSerializerOptionsDateTime>().Format = LibStringFormat.DateTime.ISO8601Z;
            
            this.JsonWriterOptions.Indent = false;
        }

        #endregion Constructors

        #region Methods

        protected virtual FwkDataResponse InvokeServer(String methodName, FwkDataRequest dataRequest, HttpMethod httpMethod)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(LibSessionConnector.ServerUrl);

            if (LibSessionConnector.AuthenticationMode == LibAuthenticationMode.Token)
            {
                httpClient.DefaultRequestHeaders.Add("Token", LibSessionConnector.Parameters["Token"]);
                httpClient.DefaultRequestHeaders.Add("Culture", LibSessionConnector.Parameters["Culture"]);
            }
            else if (LibSessionConnector.AuthenticationMode == LibAuthenticationMode.Credential)
            {
                httpClient.DefaultRequestHeaders.Add("DatabaseAlias", LibSessionConnector.Parameters["DatabaseAlias"]);
                httpClient.DefaultRequestHeaders.Add("DomainCode", LibSessionConnector.Parameters["DomainCode"]);
                httpClient.DefaultRequestHeaders.Add("Username", LibSessionConnector.Parameters["Username"]);
                httpClient.DefaultRequestHeaders.Add("Password", LibSessionConnector.Parameters["Password"]);
                httpClient.DefaultRequestHeaders.Add("Culture", LibSessionConnector.Parameters["Culture"]);
            }
            else
            {
                httpClient.DefaultRequestHeaders.Add("Culture", LibSessionConnector.Parameters["Culture"]);
            }

            String json = LazyJsonSerializer.Serialize(dataRequest, serializerOptions: this.serializerOptions, jsonWriterOptions: this.jsonWriterOptions);
            ByteArrayContent byteArrayContent = new ByteArrayContent(Encoding.UTF8.GetBytes(json));

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, this.Route + "/" + methodName);
            httpRequestMessage.Content = byteArrayContent;

            Task<HttpResponseMessage> httpResponseMessage = httpClient.SendAsync(httpRequestMessage);

            json = httpResponseMessage.Result.Content.ReadAsStringAsync().Result;
            return (FwkDataResponse)LazyJsonDeserializer.Deserialize(json, this.dataResponseType, deserializerOptions: this.deserializerOptions, jsonReaderOptions: this.jsonReaderOptions);
        }

        #endregion Methods

        #region Properties

        protected String Route { get; set; }

        protected LazyJsonWriterOptions JsonWriterOptions
        {
            get
            {
                if (this.jsonWriterOptions == null)
                    this.jsonWriterOptions = new LazyJsonWriterOptions();

                return this.jsonWriterOptions;
            }
        }

        protected LazyJsonReaderOptions JsonReaderOptions
        {
            get
            {
                if (this.jsonReaderOptions == null)
                    this.jsonReaderOptions = new LazyJsonReaderOptions();

                return this.jsonReaderOptions;
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

        protected LazyJsonDeserializerOptions DeserializerOptions
        {
            get
            {
                if (this.deserializerOptions == null)
                    this.deserializerOptions = new LazyJsonDeserializerOptions();

                return this.deserializerOptions;
            }
        }

        #endregion Properties
    }
}