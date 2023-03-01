// LibCulture.cs
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
    public class LibCulture
    {
        #region Variables

        private String code;
        private CultureInfo cultureInfo;

        #endregion Variables

        #region Constructors

        public LibCulture()
        {
            InitializeCulture();
        }

        public LibCulture(String code)
        {
            InitializeCulture(code);
        }

        #endregion Constructors

        #region Methods

        private void InitializeCulture(String code = null)
        {
            if (code == null)
                code = LibConfiguration.DynamicXml["Ark.Vinke.Library.Core"]["Globalization"]["Culture"].Attribute["Code"];

            this.code = code;
            this.code = this.code.Replace("-", String.Empty);
            this.code = this.code[0].ToString().ToUpper() + this.code[1].ToString().ToLower() + this.code[2].ToString().ToUpper() + this.code[3].ToString().ToLower();

            this.cultureInfo = new CultureInfo(this.code.Substring(0, 2) + "-" + this.code.Substring(2, 2));
        }

        #endregion Methods

        #region Properties

        public String Code
        {
            get { return this.code; }
        }
        
        public String NativeCode
        {
            get { return this.cultureInfo.Name; }
        }

        [LazyJsonAttributePropertyIgnore()]
        public String WindowsCode
        {
            get { return this.cultureInfo.ThreeLetterWindowsLanguageName; }
        }

        [LazyJsonAttributePropertyIgnore()]
        public String IsoCodeTwoLetters
        {
            get { return this.cultureInfo.TwoLetterISOLanguageName; }
        }

        [LazyJsonAttributePropertyIgnore()]
        public String IsoCodeThreeLetters
        {
            get { return this.cultureInfo.ThreeLetterISOLanguageName; }
        }
        
        public String DisplayName
        {
            get { return this.cultureInfo.DisplayName; }
        }

        #endregion Properties
    }
}
