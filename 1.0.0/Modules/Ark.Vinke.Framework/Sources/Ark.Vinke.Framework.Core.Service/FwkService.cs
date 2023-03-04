// FwkService.cs
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
using System.Collections.Generic;

using Lazy.Vinke;
using Lazy.Vinke.Json;
using Lazy.Vinke.Database;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;
using Ark.Vinke.Library.Core.Service;
using Ark.Vinke.Framework;
using Ark.Vinke.Framework.Core;
using Ark.Vinke.Framework.Core.Data;
using Ark.Vinke.Framework.Core.IPlugin;
using Ark.Vinke.Framework.Core.IService;

namespace Ark.Vinke.Framework.Core.Service
{
    public class FwkService : IFwkService
    {
        #region Variables

        private String operation;
        private LazyDatabase database;
        private FwkEnvironment environment;
        private List<IFwkPlugin> iPluginList;
        private Boolean isDatabaseOwner;
        private Type dataResponseType;

        #endregion Variables

        #region Constructors

        public FwkService(FwkEnvironment environment)
        {
            this.environment = environment;

            if (this.environment != null && String.IsNullOrWhiteSpace(this.environment.DatabaseAlias) == false)
            {
                #region Initialize database

                LibDynamicXmlElement dynXmlElementDatabaseSettings = LibConfigurationService.DynamicXml["Ark.Vinke.Framework"]["Database"][environment.DatabaseAlias]["Settings"];

                //String databaseDbms = dynXmlElementDatabaseSettings.Attribute["Dbms"];
                String databaseAssembly = dynXmlElementDatabaseSettings.Attribute["Assembly"];
                String databaseClass = dynXmlElementDatabaseSettings.Attribute["Class"];
                String databaseVersion = dynXmlElementDatabaseSettings.Attribute["Version"];
                String databaseConnectionString = dynXmlElementDatabaseSettings["ConnectionString"].Text;
                String databaseAssemblyFolderName = databaseAssembly.Replace(".dll", String.Empty).ToLower();

                this.database = (LazyDatabase)LazyActivator.Local.CreateInstance(Path.Combine(
                    LibDirectory.Root.Bin.AssemblyFolder[databaseAssemblyFolderName].Version[databaseVersion].Lib.Net60.Path, databaseAssembly),
                    databaseClass, new Object[] { databaseConnectionString });

                this.isDatabaseOwner = true;

                #endregion Initialize database

                if (this.environment.Domain != null)
                {
                    String sql = null;
                    DataTable dataTable = null;

                    this.database.OpenConnection();

                    #region Initialize environment

                    if (String.IsNullOrWhiteSpace(this.environment.Domain.CodDomain) == true)
                    {
                        #region Initialize domain

                        sql = "select CodDomain, Name from FwkDomain where IdDomain = :IdDomain";
                        dataTable = this.database.QueryTable(sql, "FwkDomain", new Object[] { this.environment.Domain.IdDomain });

                        if (dataTable.Rows.Count > 0)
                        {
                            this.environment.Domain.CodDomain = LazyConvert.ToString(dataTable.Rows[0]["CodDomain"]);
                            this.environment.Domain.Name = LazyConvert.ToString(dataTable.Rows[0]["Name"]);
                        }

                        #endregion Initialize domain
                    }

                    if (this.environment.User != null)
                    {
                        if (String.IsNullOrWhiteSpace(this.environment.User.Username) == true)
                        {
                            #region Initialize user

                            sql = "select Username, DisplayName from FwkUser where IdDomain = :IdDomain and IdUser = :IdUser";
                            dataTable = this.database.QueryTable(sql, "FwkUser", new Object[] { this.environment.User.IdDomain, this.environment.User.IdUser });

                            if (dataTable.Rows.Count > 0)
                            {
                                this.environment.User.Username = LazyConvert.ToString(dataTable.Rows[0]["Username"]);
                                this.environment.User.DisplayName = LazyConvert.ToString(dataTable.Rows[0]["DisplayName"]);
                            }

                            #endregion Initialize user

                            #region Initialize user context

                            if (this.environment.UserContext == null)
                                this.environment.UserContext = new FwkUserContext();

                            sql = "select Field, ValueInt16, ValueInt32, ValueString from FwkUserContext where IdDomain = :IdDomain and IdUser = :IdUser";
                            dataTable = this.database.QueryTable(sql, "FwkUserContext", new Object[] { this.environment.User.IdDomain, this.environment.User.IdUser });

                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                String field = LazyConvert.ToString(dataRow["Field"]);

                                this.environment.UserContext[field].ValueInt16 = LazyConvert.ToInt16(dataRow["ValueInt16"], 0);
                                this.environment.UserContext[field].ValueInt32 = LazyConvert.ToInt32(dataRow["ValueInt32"], 0);
                                this.environment.UserContext[field].ValueString = LazyConvert.ToString(dataRow["ValueString"], null);
                            }

                            #endregion Initialize user context
                        }
                    }

                    #endregion Initialize environment

                    #region Initialize plugins

                    sql = "select PluginClass from FwkServicePlugin where IdDomain = :IdDomain and ServiceClass = :ServiceClass and Enabled = '1' order by Priority";
                    dataTable = this.database.QueryTable(sql, "FwkServicePlugin", new Object[] { this.environment.Domain.IdDomain, this.GetType().FullName });

                    if (dataTable.Rows.Count > 0)
                        this.iPluginList = new List<IFwkPlugin>();

                    foreach (DataRow dataRowPlugin in dataTable.Rows)
                    {
                        try
                        {
                            String pluginClass = LazyConvert.ToString(dataRowPlugin["PluginClass"]);
                            String pluginFileName = pluginClass.Substring(0, pluginClass.LastIndexOf('.')).Replace("Plugin", "Service");
                            String pluginFolderName = pluginFileName.ToLower();

                            IFwkPlugin iPlugin = (IFwkPlugin)LazyActivator.Local.CreateInstance(Path.Combine(
                                LibDirectory.Root.Bin.AssemblyFolder[pluginFolderName].CurrentVersion.Lib.Net60.Path, pluginFileName + ".dll"),
                                pluginClass, new Object[] { this.database });

                            this.iPluginList.Add(iPlugin);
                        }
                        catch
                        {
                            /* Nothing to do here yet */
                        }
                    }

                    #endregion Initialize plugins

                    this.database.CloseConnection();
                }
            }

            #region Initialize data response type

            String assemblyFileName = this.GetType().Namespace.Replace("Service", "Data");
            String assemblyFolderName = assemblyFileName.ToLower();
            String classFullName = this.GetType().FullName.Replace("Service", "Data") + "Response";

            this.dataResponseType = LazyActivator.Local.GetType(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.Net60.Path, assemblyFileName + ".dll"),
                classFullName);

            #endregion Initialize data response type
        }

        public FwkService(FwkEnvironment environment, LazyDatabase database)
        {
            this.environment = environment;

            if (this.environment != null)
            {
                #region Initialize database

                this.database = database;
                this.isDatabaseOwner = false;

                #endregion Initialize database

                if (this.environment.Domain != null)
                {
                    String sql = null;
                    DataTable dataTable = null;

                    #region Initialize environment

                    if (String.IsNullOrWhiteSpace(this.environment.Domain.CodDomain) == true)
                    {
                        #region Initialize domain

                        sql = "select CodDomain, Name from FwkDomain where IdDomain = :IdDomain";
                        dataTable = this.database.QueryTable(sql, "FwkDomain", new Object[] { this.environment.Domain.IdDomain });

                        if (dataTable.Rows.Count > 0)
                        {
                            this.environment.Domain.CodDomain = LazyConvert.ToString(dataTable.Rows[0]["CodDomain"]);
                            this.environment.Domain.Name = LazyConvert.ToString(dataTable.Rows[0]["Name"]);
                        }

                        #endregion Initialize domain
                    }

                    if (this.environment.User != null)
                    {
                        if (String.IsNullOrWhiteSpace(this.environment.User.Username) == true)
                        {
                            #region Initialize user

                            sql = "select Username, DisplayName from FwkUser where IdDomain = :IdDomain and IdUser = :IdUser";
                            dataTable = this.database.QueryTable(sql, "FwkUser", new Object[] { this.environment.User.IdDomain, this.environment.User.IdUser });

                            if (dataTable.Rows.Count > 0)
                            {
                                this.environment.User.Username = LazyConvert.ToString(dataTable.Rows[0]["Username"]);
                                this.environment.User.DisplayName = LazyConvert.ToString(dataTable.Rows[0]["DisplayName"]);
                            }

                            #endregion Initialize user

                            #region Initialize user context

                            if (this.environment.UserContext == null)
                                this.environment.UserContext = new FwkUserContext();

                            sql = "select Field, ValueInt16, ValueInt32, ValueString from FwkUserContext where IdDomain = :IdDomain and IdUser = :IdUser";
                            dataTable = this.database.QueryTable(sql, "FwkUserContext", new Object[] { this.environment.User.IdDomain, this.environment.User.IdUser });

                            foreach (DataRow dataRow in dataTable.Rows)
                            {
                                String field = LazyConvert.ToString(dataRow["Field"]);

                                this.environment.UserContext[field].ValueInt16 = LazyConvert.ToInt16(dataRow["ValueInt16"], 0);
                                this.environment.UserContext[field].ValueInt32 = LazyConvert.ToInt32(dataRow["ValueInt32"], 0);
                                this.environment.UserContext[field].ValueString = LazyConvert.ToString(dataRow["ValueString"], null);
                            }

                            #endregion Initialize user context
                        }
                    }

                    #endregion Initialize environment

                    #region Initialize plugins

                    sql = "select PluginClass from FwkServicePlugin where IdDomain = :IdDomain and ServiceClass = :ServiceClass and Enabled = '1' order by Priority";
                    dataTable = this.database.QueryTable(sql, "FwkServicePlugin", new Object[] { this.environment.Domain.IdDomain, this.GetType().FullName });

                    if (dataTable.Rows.Count > 0)
                        this.iPluginList = new List<IFwkPlugin>();

                    foreach (DataRow dataRowPlugin in dataTable.Rows)
                    {
                        try
                        {
                            String pluginClass = LazyConvert.ToString(dataRowPlugin["PluginClass"]);
                            String pluginFileName = pluginClass.Substring(0, pluginClass.LastIndexOf('.')).Replace("Plugin", "Service");
                            String pluginFolderName = pluginFileName.ToLower();

                            IFwkPlugin iPlugin = (IFwkPlugin)LazyActivator.Local.CreateInstance(Path.Combine(
                                LibDirectory.Root.Bin.AssemblyFolder[pluginFolderName].CurrentVersion.Lib.Net60.Path, pluginFileName + ".dll"),
                                pluginClass, new Object[] { this.database });

                            this.iPluginList.Add(iPlugin);
                        }
                        catch
                        {
                            /* Nothing to do here yet */
                        }
                    }

                    #endregion Initialize plugins
                }
            }

            #region Initialize data response type

            String assemblyFileName = this.GetType().Namespace.Replace("Service", "Data");
            String assemblyFolderName = assemblyFileName.ToLower();
            String classFullName = this.GetType().FullName.Replace("Service", "Data") + "Response";

            this.dataResponseType = LazyActivator.Local.GetType(Path.Combine(
                LibDirectory.Root.Bin.AssemblyFolder[assemblyFolderName].CurrentVersion.Lib.Net60.Path, assemblyFileName + ".dll"),
                classFullName);

            #endregion Initialize data response type
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        protected String Operation
        {
            get { return this.operation; }
            set { this.operation = value; }
        }

        protected LazyDatabase Database
        {
            get { return this.database; }
        }

        protected FwkEnvironment Environment
        {
            get { return this.environment; }
        }

        protected List<IFwkPlugin> IPlugins
        {
            get { return this.iPluginList; }
        }

        protected Boolean IsDatabaseOwner
        {
            get { return this.isDatabaseOwner; }
        }

        protected Type DataResponseType
        {
            get { return this.dataResponseType; }
        }

        #endregion Properties
    }
}
