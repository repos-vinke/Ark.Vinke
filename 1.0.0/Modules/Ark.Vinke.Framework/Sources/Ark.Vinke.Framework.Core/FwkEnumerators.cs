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

    public enum FwkEditableEnum
    {
        [LazyAttributeGeneric("NV", "Never")]
        Never = 0,

        [LazyAttributeGeneric("AD", "Added")]
        Added = 1,

        [LazyAttributeGeneric("MD", "Modified")]
        Modified = 2,

        [LazyAttributeGeneric("AL", "Always")]
        Always = 3
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

    public enum FwkDefaultValueEnum
    {
        [LazyAttributeGeneric("NV", "Never")]
        Never = 0,

        [LazyAttributeGeneric("AD", "Added")]
        Added = 1,

        [LazyAttributeGeneric("MD", "Modified")]
        Modified = 2,

        [LazyAttributeGeneric("AL", "Always")]
        Always = 3
    }

    public enum FwkAlignmentEnum
    {
        [LazyAttributeGeneric("DF", "Default")]
        Default = 0,

        [LazyAttributeGeneric("TL", "TopLeft")]
        TopLeft = 11,

        [LazyAttributeGeneric("TC", "TopCenter")]
        TopCenter = 12,

        [LazyAttributeGeneric("TR", "TopRight")]
        TopRight = 13,

        [LazyAttributeGeneric("ML", "MiddleLeft")]
        MiddleLeft = 21,

        [LazyAttributeGeneric("MC", "MiddleCenter")]
        MiddleCenter = 22,

        [LazyAttributeGeneric("MR", "MiddleRight")]
        MiddleRight = 23,

        [LazyAttributeGeneric("BL", "BottomLeft")]
        BottomLeft = 31,

        [LazyAttributeGeneric("BC", "BottomCenter")]
        BottomCenter = 32,

        [LazyAttributeGeneric("BR", "BottomRight")]
        BottomRight = 33
    }
}
