// LibGlobalization.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 15

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Globalization;
using System.Collections.Generic;

using Lazy.Vinke;
using Lazy.Vinke.Json;

using Ark.Vinke.Library;

namespace Ark.Vinke.Library.Core
{
    public static class LibGlobalization
    {
        #region Variables

        private static LibCulture culture;

        #endregion Variables

        #region Methods

        public static String GetTranslation(String jPath)
        {
            return GetTranslation(jPath, Culture);
        }

        public static String GetTranslation(String jPath, LibCulture culture)
        {
            if (String.IsNullOrWhiteSpace(jPath) == true)
                return jPath;

            if (jPath.Contains("{0}$") == false)
                return jPath;

            jPath = String.Format(jPath, culture.Code);
            String[] jPathArray = jPath.Split('$', StringSplitOptions.RemoveEmptyEntries);

            String filePath = Path.Combine(LibDirectory.Root.Res.Languages.Path, jPathArray[0] + ".json");
            if (File.Exists(filePath) == false)
                return jPath;

            LazyJson lazyJson = (LazyJson)LibMemoryCache.Module["Ark.Vinke.Library"].Container["Globalization"].Item[jPathArray[0]].Value;

            if (lazyJson == null)
            {
                try { LibMemoryCache.Module["Ark.Vinke.Library"].Container["Globalization"].Item[jPathArray[0]].Value = lazyJson = LazyJsonReader.Read(File.ReadAllText(filePath)); }
                catch { return jPath; }
            }

            String translation = null;
            try { translation = ((LazyJsonString)lazyJson.Find("$" + jPathArray[1])).Value; }
            catch { return jPath; }

            return translation;
        }

        #endregion Methods

        #region Properties

        public static LibCulture Culture
        {
            get
            {
                if (culture == null)
                    culture = new LibCulture();

                return culture;
            }
        }

        #endregion Properties
    }
}