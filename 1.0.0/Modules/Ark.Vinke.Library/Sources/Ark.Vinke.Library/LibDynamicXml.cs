// LibDynamicXml.cs
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
using System.Globalization;
using System.Collections.Generic;

using Lazy.Vinke;

namespace Ark.Vinke.Library
{
    public class LibDynamicXml
    {
        #region Variables

        private Dictionary<String, LibDynamicXmlElement> projectDictionary;

        #endregion Variables

        #region Constructors

        public LibDynamicXml()
        {
            this.projectDictionary = new Dictionary<String, LibDynamicXmlElement>();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Load dynamic xml
        /// </summary>
        /// <param name="xml">The xml</param>
        /// <param name="xPathDynamicXml">The xPath of the dynamic xml element</param>
        public void LoadDynamicXml(LazyXml xml, String xPathDynamicXml)
        {
            XmlNodeList xmlNodeProjectList = xml.ReadNodeChildList(xPathDynamicXml);

            foreach (XmlNode xmlNodeProject in xmlNodeProjectList)
            {
                LoadDynamicXmlNode(xml, xmlNodeProject, this[xmlNodeProject.Name]);

                XmlAttributeCollection xmlAttributeCollection = xml.ReadNodeAttributeList(xmlNodeProject);
                foreach (XmlAttribute attribute in xmlAttributeCollection)
                    this[xmlNodeProject.Name].Attribute[attribute.Name] = attribute.Value;
            }

            xmlNodeProjectList = null;
        }

        /// <summary>
        /// Load dynamic xml node
        /// </summary>
        /// <param name="xml">The xml</param>
        /// <param name="xmlNode">The xml node</param>
        /// <param name="element">The dynamic xml element</param>
        private void LoadDynamicXmlNode(LazyXml xml, XmlNode xmlNode, LibDynamicXmlElement element)
        {
            XmlNodeList xmlNodeElementList = xml.ReadNodeChildList(xmlNode);

            if (xmlNodeElementList.Count > 0)
            {
                if (xmlNodeElementList[0].NodeType == XmlNodeType.Text)
                {
                    element.Text = xmlNode.InnerText;
                }
                else
                {
                    foreach (XmlNode xmlNodeElement in xmlNodeElementList)
                    {
                        LoadDynamicXmlNode(xml, xmlNodeElement, element[xmlNodeElement.Name]);

                        XmlAttributeCollection xmlAttributeCollection = xml.ReadNodeAttributeList(xmlNodeElement);
                        foreach (XmlAttribute attribute in xmlAttributeCollection)
                            element[xmlNodeElement.Name].Attribute[attribute.Name] = attribute.Value;
                    }
                }
            }

            xmlNodeElementList = null;
        }

        /// <summary>
        /// Save dynamic xml
        /// </summary>
        public void SaveDynamicXml(LazyXml xml, XmlNode xmlNodeDynamicXml)
        {
            foreach (KeyValuePair<String, LibDynamicXmlElement> project in this.projectDictionary)
            {
                XmlNode xmlNodeProject = xml.WriteNode(xmlNodeDynamicXml, project.Key);

                SaveDynamicXmlNode(xml, xmlNodeProject, project.Value);

                foreach (KeyValuePair<String, String> attribute in project.Value.Attribute.Collection)
                    xml.WriteNodeAttribute(xmlNodeProject, attribute.Key, attribute.Value);
            }
        }

        /// <summary>
        /// Save dynamic xml node
        /// </summary>
        /// <param name="xml">The xml</param>
        /// <param name="xmlNode">The xml node</param>
        /// <param name="element">The dynamic xml element</param>
        private void SaveDynamicXmlNode(LazyXml xml, XmlNode xmlNode, LibDynamicXmlElement element)
        {
            foreach (KeyValuePair<String, LibDynamicXmlElement> childElement in element.Elements)
            {
                XmlNode xmlNodeChildElement = xml.WriteNode(xmlNode, childElement.Key);

                SaveDynamicXmlNode(xml, xmlNodeChildElement, childElement.Value);

                if (childElement.Value.NodeType == XmlNodeType.Text)
                    xmlNodeChildElement.InnerText = childElement.Value.Text;

                foreach (KeyValuePair<String, String> attribute in childElement.Value.Attribute.Collection)
                    xml.WriteNodeAttribute(xmlNodeChildElement, attribute.Key, attribute.Value);
            }
        }

        #endregion Methods

        #region Properties

        public Dictionary<String, LibDynamicXmlElement> Projects
        {
            get { return this.projectDictionary; }
        }

        #endregion Properties

        #region Indexers

        public LibDynamicXmlElement this[String project]
        {
            get
            {
                if (this.projectDictionary.ContainsKey(project) == false)
                    this.projectDictionary.Add(project, new LibDynamicXmlElement(project));

                return this.projectDictionary[project];
            }
            set
            {
                if (this.projectDictionary.ContainsKey(project) == false)
                    this.projectDictionary.Add(project, value);
                else
                    this.projectDictionary[project] = value;
            }
        }

        #endregion Indexers
    }
}
