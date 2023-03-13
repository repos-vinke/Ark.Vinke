// LibSessionConnector.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2023, March 12

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Lazy.Vinke;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;

namespace Ark.Vinke.Library.Core.Connector
{
    public static class LibSessionConnector
    {
        #region Variables

        private static LibSessionConnectorParameter parameter;
        private static Dictionary<Type, Object> itemDictionary;

        #endregion Variables

        #region Methods

        public static T Item<T>()
        {
            if (itemDictionary == null)
                itemDictionary = new Dictionary<Type, Object>();

            if (itemDictionary.ContainsKey(typeof(T)) == false)
                itemDictionary.Add(typeof(T), LazyActivator.Local.CreateInstance(typeof(T)));

            return (T)itemDictionary[typeof(T)];
        }

        public static void Item<T>(T item)
        {
            if (itemDictionary == null)
                itemDictionary = new Dictionary<Type, Object>();
            
            if (itemDictionary.ContainsKey(typeof(T)) == false)
                itemDictionary.Add(typeof(T), item);
            else
                itemDictionary[typeof(T)] = item;
        }

        #endregion Methods

        #region Properties

        public static String ServerUrl { get; set; }

        public static LibAuthenticationMode AuthenticationMode { get; set; }

        public static LibSessionConnectorParameter Parameters
        {
            get
            {
                if (parameter == null)
                    parameter = new LibSessionConnectorParameter();

                return parameter;
            }
        }

        #endregion Properties
    }

    public class LibSessionConnectorParameter
    {
        #region Variables

        private Dictionary<String, String> parameterDictionary;

        #endregion Variables

        #region Constructor

        public LibSessionConnectorParameter()
        {
            this.parameterDictionary = new Dictionary<String, String>();
        }

        #endregion Constructor

        #region Methods

        public void Clear()
        {
            this.parameterDictionary.Clear();
        }

        #endregion Methods

        #region Properties
        #endregion Properties

        #region Indexers

        public String this[String name]
        {
            get
            {
                if (this.parameterDictionary.ContainsKey(name) == false)
                    this.parameterDictionary.Add(name, null);

                return this.parameterDictionary[name];
            }
            set
            {
                if (this.parameterDictionary.ContainsKey(name) == false)
                    this.parameterDictionary.Add(name, value);
                else
                    this.parameterDictionary[name] = value;
            }
        }

        #endregion Indexers
    }
}