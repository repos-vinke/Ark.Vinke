﻿// LibDirectory.cs
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
using System.Globalization;
using System.Collections.Generic;

using Lazy.Vinke;

using Ark.Vinke.Library;

namespace Ark.Vinke.Library.Core
{
    public static class LibDirectory
    {
        #region Variables
        #endregion Variables

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties

        #region InternalClass

        public static class Root
        {
            #region Variables
            #endregion Variables

            #region Methods
            #endregion Methods

            #region Properties

            public static String Path
            {
                get { return AppDomain.CurrentDomain.BaseDirectory; }
            }

            #endregion Properties

            #region InternalClass

            public static class Bin
            {
                #region Variables

                private static LibDirectoryAssemblyFolder assemblyFolder;

                #endregion Variables

                #region Methods
                #endregion Methods

                #region Properties

                public static String Path
                {
                    get
                    {
                        /* Must use System.IO.Path.Combine to be compatible on Windows and Linux */
                        return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bin");
                    }
                }

                public static LibDirectoryAssemblyFolder AssemblyFolder
                {
                    get
                    {
                        if (assemblyFolder == null)
                            assemblyFolder = new LibDirectoryAssemblyFolder(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bin"));

                        return assemblyFolder;
                    }
                }

                #endregion Properties
            }

            public static class Config
            {
                #region Variables
                #endregion Variables

                #region Methods
                #endregion Methods

                #region Properties

                public static String Path
                {
                    get { return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config"); }
                }

                #endregion Properties
            }

            public static class Resources
            {
                #region Variables
                #endregion Variables

                #region Methods
                #endregion Methods

                #region Properties

                public static String Path
                {
                    get { return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources"); }
                }

                #endregion Properties

                #region InternalClass

                public static class Languages
                {
                    #region Variables
                    #endregion Variables

                    #region Methods
                    #endregion Methods

                    #region Properties

                    public static String Path
                    {
                        get { return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Languages"); }
                    }

                    #endregion Properties
                }

                #endregion InternalClass
            }

            #endregion InternalClass
        }

        #endregion InternalClass
    }

    public class LibDirectoryAssemblyFolder
    {
        #region Variables

        private String path;
        private Dictionary<String, LibDirectoryAssemblyFolderItem> assemblyFolderItemDictionary;

        #endregion Variables

        #region Constructors

        public LibDirectoryAssemblyFolder(String path)
        {
            this.path = path;
            this.assemblyFolderItemDictionary = new Dictionary<String, LibDirectoryAssemblyFolderItem>();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties

        #region Indexers

        public LibDirectoryAssemblyFolderItem this[String name]
        {
            get
            {
                if (this.assemblyFolderItemDictionary.ContainsKey(name) == false)
                    this.assemblyFolderItemDictionary.Add(name, new LibDirectoryAssemblyFolderItem(System.IO.Path.Combine(this.path, name)));

                return this.assemblyFolderItemDictionary[name];
            }
        }

        #endregion Indexers
    }

    public class LibDirectoryAssemblyFolderItem
    {
        #region Variables

        private String path;
        private LibDirectoryAssemblyVersion assemblyVersion;

        #endregion Variables

        #region Constructors

        public LibDirectoryAssemblyFolderItem(String path)
        {
            this.path = path;
            this.assemblyVersion = new LibDirectoryAssemblyVersion(this.path);
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public String Path
        {
            get { return this.path; }
        }

        public LibDirectoryAssemblyVersion Version
        {
            get { return this.assemblyVersion; }
        }

        public LibDirectoryAssemblyVersionItem CurrentVersion
        {
            /* The current version will be the first folder found on this directory */
            get { return Version[System.IO.Path.GetFileName(Directory.GetDirectories(this.path, "*", SearchOption.TopDirectoryOnly)[0])]; }
        }

        #endregion Properties
    }

    public class LibDirectoryAssemblyVersion
    {
        #region Variables

        private String path;
        private Dictionary<String, LibDirectoryAssemblyVersionItem> assemblyVersionItemDictionary;

        #endregion Variables

        #region Constructors

        public LibDirectoryAssemblyVersion(String path)
        {
            this.path = path;
            this.assemblyVersionItemDictionary = new Dictionary<String, LibDirectoryAssemblyVersionItem>();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties

        #region Indexers

        public LibDirectoryAssemblyVersionItem this[String value]
        {
            get
            {
                if (this.assemblyVersionItemDictionary.ContainsKey(value) == false)
                    this.assemblyVersionItemDictionary.Add(value, new LibDirectoryAssemblyVersionItem(System.IO.Path.Combine(this.path, value)));

                return this.assemblyVersionItemDictionary[value];
            }
        }

        #endregion Indexers
    }

    public class LibDirectoryAssemblyVersionItem
    {
        #region Variables

        private String path;
        private LibDirectoryAssemblyVersionLib assemblyVersionLib;

        #endregion Variables

        #region Constructors

        public LibDirectoryAssemblyVersionItem(String path)
        {
            this.path = path;
            this.assemblyVersionLib = new LibDirectoryAssemblyVersionLib(System.IO.Path.Combine(this.path, "lib"));
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public String Path
        {
            get { return this.path; }
        }

        public LibDirectoryAssemblyVersionLib Lib
        {
            get { return this.assemblyVersionLib; }
        }

        #endregion Properties
    }

    public class LibDirectoryAssemblyVersionLib
    {
        #region Variables

        private String path;
        private LibDirectoryAssemblyVersionLibItem net60;
        private LibDirectoryAssemblyVersionLibItem net60windows70;
        private LibDirectoryAssemblyVersionLibItem netStandard20;

        #endregion Variables

        #region Constructors

        public LibDirectoryAssemblyVersionLib(String path)
        {
            this.path = path;
            this.net60 = new LibDirectoryAssemblyVersionLibItem(System.IO.Path.Combine(path, "net6.0"));
            this.net60windows70 = new LibDirectoryAssemblyVersionLibItem(System.IO.Path.Combine(path, "net6.0-windows7.0"));
            this.netStandard20 = new LibDirectoryAssemblyVersionLibItem(System.IO.Path.Combine(path, "netstandard2.0"));
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public LibDirectoryAssemblyVersionLibItem Net60
        {
            get { return this.net60; }
        }

        /* Path for NetCore Windows Desktop App are placed like this on Deps.Json */
        public LibDirectoryAssemblyVersionLibItem Net60Windows70
        {
            get { return this.net60windows70; }
        }

        public LibDirectoryAssemblyVersionLibItem NetStandard20
        {
            get { return this.netStandard20; }
        }

        #endregion Properties
    }

    public class LibDirectoryAssemblyVersionLibItem
    {
        #region Variables

        private String path;

        #endregion Variables

        #region Constructors

        public LibDirectoryAssemblyVersionLibItem(String path)
        {
            this.path = path;
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public String Path
        {
            get { return this.path; }
        }

        #endregion Properties
    }
}