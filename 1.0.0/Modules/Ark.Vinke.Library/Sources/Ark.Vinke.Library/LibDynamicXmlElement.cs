﻿// LibDynamicXmlElement.cs
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
    public class LibDynamicXmlElement
    {
        #region Variables

        private String text;
        private Dictionary<String, LibDynamicXmlElement> elementDictionary;

        #endregion Variables

        #region Constructors

        public LibDynamicXmlElement(String name)
        {
            this.elementDictionary = new Dictionary<String, LibDynamicXmlElement>();

            this.Attribute = new LibDynamicXmlAttribute();

            this.NodeType = XmlNodeType.Element;

            this.Name = name;
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public String Name { get; set; }

        public String Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
                this.NodeType = String.IsNullOrEmpty(value) ? XmlNodeType.Element : XmlNodeType.Text;
            }
        }

        public XmlNodeType NodeType { get; set; }

        public LibDynamicXmlAttribute Attribute { get; set; }

        public Dictionary<String, LibDynamicXmlElement> Elements
        {
            get { return this.elementDictionary; }
        }

        #endregion Properties

        #region Indexers

        public LibDynamicXmlElement this[String name]
        {
            get
            {
                if (this.elementDictionary.ContainsKey(name) == false)
                    this.elementDictionary.Add(name, new LibDynamicXmlElement(name));

                return this.elementDictionary[name];
            }
            set
            {
                if (this.elementDictionary.ContainsKey(name) == false)
                    this.elementDictionary.Add(name, value);
                else
                    this.elementDictionary[name] = value;
            }
        }

        #endregion Indexers
    }
}