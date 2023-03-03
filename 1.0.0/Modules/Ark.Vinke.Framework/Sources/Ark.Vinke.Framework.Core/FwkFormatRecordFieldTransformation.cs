// FwkFormatRecordFieldTransformation.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2023, February 09

using System;
using System.Xml;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;

using Lazy.Vinke;
using Lazy.Vinke.Json;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;

namespace Ark.Vinke.Framework.Core
{
    public class FwkFormatRecordFieldTransformation
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatRecordFieldTransformation()
        {
        }

        #endregion Constructors

        #region Methods

        public virtual Object Transform(Object value)
        {
            return value;
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class FwkFormatRecordFieldTransformationTruncate : FwkFormatRecordFieldTransformation
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatRecordFieldTransformationTruncate()
        {
            this.Lenght = 0;
        }

        public FwkFormatRecordFieldTransformationTruncate(Int32 lenght)
        {
            this.Lenght = lenght;
        }

        #endregion Constructors

        #region Methods

        public override Object Transform(Object value)
        {
            if (value != null && value != DBNull.Value)
            {
                if (value.GetType() == typeof(String))
                {
                    String valueString = LazyConvert.ToString(value);

                    if (valueString.Length > this.Lenght)
                        return valueString.Substring(0, this.Lenght);
                }
            }

            return value;
        }

        #endregion Methods

        #region Properties

        [LazyJsonAttributePropertyRename("Truncate")]
        public Int32 Lenght { get; set; }

        #endregion Properties
    }
}
