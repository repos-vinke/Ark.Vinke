// LibConfigurationServer.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 25

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Lazy.Vinke;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;

namespace Ark.Vinke.Library.Core.Server
{
    public static class LibConfigurationServer
    {
        #region Consts

        private const string ARK_VINKE_LIBRARY_CORE_SERVER_XML = "Ark.Vinke.Library.Core.Server.xml";

        #endregion Consts

        #region Variables

        private static LibDynamicXml dynamicXml;

        #endregion Variables

        #region Methods

        /// <summary>
        /// Load the configuration from file
        /// </summary>
        public static void Load()
        {
            if (dynamicXml == null)
                dynamicXml = new LibDynamicXml();

            #region Initialize configuration file

            // If configuration file not exists will be created a new one with default values
            if (File.Exists(Path.Combine(LibDirectory.Root.Dat.Path, ARK_VINKE_LIBRARY_CORE_SERVER_XML)) == false)
                Save();

            #endregion Initialize configuration file

            #region Load xml

            LazyXml xml = new LazyXml();

            xml.Open(Path.Combine(LibDirectory.Root.Dat.Path, ARK_VINKE_LIBRARY_CORE_SERVER_XML));

            LoadDynamicXml(xml);

            xml = null;

            #endregion Load xml
        }

        /// <summary>
        /// Save the configuration to file
        /// </summary>
        public static void Save()
        {
            if (dynamicXml == null)
                dynamicXml = new LibDynamicXml();

            #region Initialize default values

            #region DynamicXml

            #region Ark.Vinke.Library/Security/Preflight

            if (dynamicXml["Ark.Vinke.Library"]["Security"]["Preflight"].Attribute["Assembly"] == String.Empty)
                dynamicXml["Ark.Vinke.Library"]["Security"]["Preflight"].Attribute["Assembly"] = String.Empty;

            if (dynamicXml["Ark.Vinke.Library"]["Security"]["Preflight"].Attribute["Class"] == String.Empty)
                dynamicXml["Ark.Vinke.Library"]["Security"]["Preflight"].Attribute["Class"] = String.Empty;

            #endregion Ark.Vinke.Library/Security/Preflight

            #region Ark.Vinke.Library/Security/Authentication

            if (dynamicXml["Ark.Vinke.Library"]["Security"]["Authentication"].Attribute["Assembly"] == String.Empty)
                dynamicXml["Ark.Vinke.Library"]["Security"]["Authentication"].Attribute["Assembly"] = String.Empty;

            if (dynamicXml["Ark.Vinke.Library"]["Security"]["Authentication"].Attribute["Class"] == String.Empty)
                dynamicXml["Ark.Vinke.Library"]["Security"]["Authentication"].Attribute["Class"] = String.Empty;

            #endregion Ark.Vinke.Library/Security/Authentication

            #region Ark.Vinke.Library/Security/Authorization

            if (dynamicXml["Ark.Vinke.Library"]["Security"]["Authorization"].Attribute["Assembly"] == String.Empty)
                dynamicXml["Ark.Vinke.Library"]["Security"]["Authorization"].Attribute["Assembly"] = String.Empty;

            if (dynamicXml["Ark.Vinke.Library"]["Security"]["Authorization"].Attribute["Class"] == String.Empty)
                dynamicXml["Ark.Vinke.Library"]["Security"]["Authorization"].Attribute["Class"] = String.Empty;

            #endregion Ark.Vinke.Library/Security/Authorization

            #endregion DynamicXml

            #endregion Initialize default values

            #region Save xml

            LazyXml xml = new LazyXml();

            xml.New();

            XmlNode xmlNodeRoot = xml.WriteRoot("Ark.Vinke.Library.Core.Server");

            SaveDynamicXml(xml, xmlNodeRoot);

            xml.Save(Path.Combine(LibDirectory.Root.Dat.Path, ARK_VINKE_LIBRARY_CORE_SERVER_XML));

            xmlNodeRoot = null;
            xml = null;

            #endregion Save xml
        }

        /// <summary>
        /// Load dynamic xml
        /// </summary>
        /// <param name="xml">The xml</param>
        private static void LoadDynamicXml(LazyXml xml)
        {
            dynamicXml.LoadDynamicXml(xml, "/Ark.Vinke.Library.Core.Server/DynamicXml");
        }

        /// <summary>
        /// Save dynamic xml
        /// </summary>
        /// <param name="xml">The xml</param>
        /// <param name="xmlNodeRoot">The xml root node</param>
        private static void SaveDynamicXml(LazyXml xml, XmlNode xmlNodeRoot)
        {
            XmlNode xmlNodeDynamicXml = xml.WriteNode(xmlNodeRoot, "DynamicXml");

            dynamicXml.SaveDynamicXml(xml, xmlNodeDynamicXml);

            xmlNodeDynamicXml = null;
        }

        #endregion Methods

        #region Properties

        public static LibDynamicXml DynamicXml
        {
            get
            {
                if (dynamicXml == null)
                    Load();

                return dynamicXml;
            }
            set { dynamicXml = value; }
        }

        #endregion Properties
    }
}
