// LibEnumerators.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, August 31

using System;
using System.Xml;
using System.Data;

using Lazy.Vinke;

using Ark.Vinke.Library;

namespace Ark.Vinke.Library.Core
{
    public enum LibAuthenticationMode
    {
        [LazyAttributeGeneric("TK", "Token")]
        Token = 1,

        [LazyAttributeGeneric("CR", "Credential")]
        Credential = 2,

        [LazyAttributeGeneric("AN", "Anonymous")]
        Anonymous = 3
    }
}
