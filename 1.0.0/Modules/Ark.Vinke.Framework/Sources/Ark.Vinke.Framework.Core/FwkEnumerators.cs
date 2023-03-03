// FwkEnumerators.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 27

using System;
using System.Xml;
using System.Data;

using Lazy.Vinke;
using Lazy.Vinke.Json;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;

namespace Ark.Vinke.Framework.Core
{
    public enum FwkScopeStatus
    {
        [LazyAttributeGeneric("10", "Success")]
        Success = 10,

        [LazyAttributeGeneric("20", "Warning")]
        Warning = 20,

        [LazyAttributeGeneric("70", "Error")]
        Error = 70
    }

    public enum FwkBooleanEnum
    {
        [LazyAttributeGeneric("F", "False")]
        False = 0,

        [LazyAttributeGeneric("T", "True")]
        True = 1
    }

    public enum FwkConstraintEnum
    {
        [LazyAttributeGeneric("PA", "ParentKey")]
        ParentKey = 10,

        [LazyAttributeGeneric("PK", "PrimaryKey")]
        PrimaryKey = 20,

        [LazyAttributeGeneric("IK", "IncrementKey")]
        IncrementKey = 30,

        [LazyAttributeGeneric("UK", "UniqueKey")]
        UniqueKey = 40,

        [LazyAttributeGeneric("NN", "None")]
        None = 70
    }
}
