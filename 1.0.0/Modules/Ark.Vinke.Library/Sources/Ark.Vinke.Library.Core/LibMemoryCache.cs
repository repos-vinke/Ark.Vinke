// LibMemoryCache.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2022, February 25

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Globalization;
using System.Runtime.Caching;
using System.Collections.Generic;

using Lazy.Vinke;

using Ark.Vinke.Library;

namespace Ark.Vinke.Library.Core
{
    public static class LibMemoryCache
    {
        #region Consts

        internal const int DEFAULT_SLIDING_EXPIRATION = 120;

        #endregion Consts

        #region Variables

        private static LibMemoryCacheModule module;

        #endregion Variables

        #region Methods
        #endregion Methods

        #region Properties

        public static LibMemoryCacheModule Module
        {
            get
            {
                if (module == null)
                    module = new LibMemoryCacheModule();

                return module;
            }
        }

        #endregion Properties
    }

    public class LibMemoryCacheModule
    {
        #region Variables

        private Dictionary<String, LibMemoryCacheElement> elementDictionary;

        #endregion Variables

        #region Constructors

        internal LibMemoryCacheModule()
        {
            this.elementDictionary = new Dictionary<String, LibMemoryCacheElement>();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties

        #region Indexers

        public LibMemoryCacheElement this[String key]
        {
            get
            {
                if (this.elementDictionary.ContainsKey(key) == false)
                    this.elementDictionary.Add(key, new LibMemoryCacheElement());

                return this.elementDictionary[key];
            }
        }

        #endregion Indexers
    }

    public class LibMemoryCacheElement
    {
        #region Variables

        private LibMemoryCacheContainer container;

        #endregion Variables

        #region Constructors

        internal LibMemoryCacheElement()
        {
            this.container = new LibMemoryCacheContainer();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public LibMemoryCacheContainer Container
        {
            get { return this.container; }
        }

        #endregion Properties
    }

    public class LibMemoryCacheContainer
    {
        #region Variables
        #endregion Variables

        #region Constructors

        internal LibMemoryCacheContainer()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties

        #region Indexers

        public LibMemoryCacheNode this[String key]
        {
            get
            {
                if (MemoryCache.Default.Contains(key) == false)
                {
                    String slidingExpiration = LibConfiguration.DynamicXml["Ark.Vinke.Library.Core"]["MemoryCache"]["SlidingExpiration"].Attribute["Seconds"];

                    if (String.IsNullOrWhiteSpace(slidingExpiration) == true)
                    {
                        slidingExpiration = LazyConvert.ToString(LibMemoryCache.DEFAULT_SLIDING_EXPIRATION);

                        LibConfiguration.DynamicXml["Ark.Vinke.Library.Core"]["MemoryCache"]["SlidingExpiration"].Attribute["Seconds"] = slidingExpiration;
                        LibConfiguration.Save();
                    }

                    CacheItem cacheItem = new CacheItem(key, new LibMemoryCacheNode());
                    CacheItemPolicy cacheItemPolicy = new CacheItemPolicy() { SlidingExpiration = new TimeSpan(0, 0, LazyConvert.ToInt32(slidingExpiration, LibMemoryCache.DEFAULT_SLIDING_EXPIRATION)) };

                    MemoryCache.Default.Add(cacheItem, cacheItemPolicy);
                }

                return (LibMemoryCacheNode)MemoryCache.Default[key];
            }
        }

        #endregion Indexers
    }

    public class LibMemoryCacheNode
    {
        #region Variables

        private LibMemoryCacheItem item;

        #endregion Variables

        #region Constructors

        internal LibMemoryCacheNode()
        {
            this.item = new LibMemoryCacheItem();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public LibMemoryCacheItem Item
        {
            get { return this.item; }
        }

        #endregion Properties
    }

    public class LibMemoryCacheItem
    {
        #region Variables

        private Dictionary<String, LibMemoryCacheItem> itemDictionary;

        #endregion Variables

        #region Constructors

        internal LibMemoryCacheItem()
        {
            this.itemDictionary = new Dictionary<String, LibMemoryCacheItem>();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Object Value { get; set; }

        #endregion Properties

        #region Indexers

        public LibMemoryCacheItem this[String key]
        {
            get
            {
                if (this.itemDictionary.ContainsKey(key) == false)
                    this.itemDictionary.Add(key, new LibMemoryCacheItem());

                return this.itemDictionary[key];
            }
        }

        #endregion Indexers
    }
}