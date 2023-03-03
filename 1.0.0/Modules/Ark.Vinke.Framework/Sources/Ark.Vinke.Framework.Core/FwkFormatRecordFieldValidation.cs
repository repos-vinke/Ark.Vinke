﻿// FwkFormatRecordFieldValidation.cs
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
    public class FwkFormatRecordFieldValidation
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatRecordFieldValidation()
        {
            this.Culture = LibGlobalization.Culture;
        }

        public FwkFormatRecordFieldValidation(LibCulture culture)
        {
            this.Culture = culture;
        }

        #endregion Constructors

        #region Methods

        public virtual Boolean Validate(Object value, String objectName = null)
        {
            return true;
        }

        #endregion Methods

        #region Properties

        [LazyJsonAttributePropertyIgnore()]
        public LibCulture Culture { get; set; }

        [LazyJsonAttributePropertyIgnore()]
        public String Reason { get; set; }

        #endregion Properties
    }

    public class FwkFormatRecordFieldValidationAllowedValues : FwkFormatRecordFieldValidation
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatRecordFieldValidationAllowedValues()
        {
        }

        public FwkFormatRecordFieldValidationAllowedValues(LibCulture culture, Object[] allowedValues)
            : base(culture)
        {
            this.AllowedValues = allowedValues;
        }

        #endregion Constructors

        #region Methods

        public override Boolean Validate(Object value, String objectName = null)
        {
            if (value == null || value == DBNull.Value || LazyConvert.ToString(value, "NotEmpty") == String.Empty)
            {
                if (this.AllowedValues == null && this.AllowedValues.Length == 0)
                    return true;

                SetReason(objectName);

                return false;
            }
            else
            {
                if (this.AllowedValues != null && this.AllowedValues.Length > 0)
                {
                    foreach (Object allowedValue in this.AllowedValues)
                    {
                        // Case LazyConvert unable to cast the values to String, its means that this validation cannot be performed for this values types
                        if (LazyConvert.ToString(value, String.Empty) == LazyConvert.ToString(allowedValue, String.Empty))
                            return true;
                    }
                }

                SetReason(objectName);

                return false;
            }
        }

        private void SetReason(String objectName)
        {
            String allowedValuesString = String.Empty;

            if (this.AllowedValues != null)
            {
                for (int i = 0; i < this.AllowedValues.Length; i++)
                    allowedValuesString = LazyConvert.ToString(this.AllowedValues[i], String.Empty) + ", ";
                allowedValuesString = allowedValuesString.Remove(allowedValuesString.Length - 2, 2);
            }

            this.Reason = String.Format(LibGlobalization.GetTranslation(Properties.FwkResourcesCore.FwkExceptionRecordFieldValidationAllowedValues, this.Culture), objectName, allowedValuesString);
        }

        #endregion Methods

        #region Properties

        public Object[] AllowedValues { get; set; }

        #endregion Properties
    }

    public class FwkFormatRecordFieldValidationHigherThan : FwkFormatRecordFieldValidation
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatRecordFieldValidationHigherThan()
        {
        }

        public FwkFormatRecordFieldValidationHigherThan(LibCulture culture, Decimal value)
            : base(culture)
        {
            this.Value = value;
        }

        #endregion Constructors

        #region Methods

        public override Boolean Validate(Object value, String objectName = null)
        {
            if (value == null || value == DBNull.Value)
                return true; // Unable to validate

            try
            {
                if (LazyConvert.ToDecimal(value) <= this.Value)
                {
                    this.Reason = String.Format(LibGlobalization.GetTranslation(Properties.FwkResourcesCore.FwkExceptionRecordFieldValidationHigherThan, this.Culture), objectName, this.Value);

                    return false; // Validation failed
                }

                return true; // Validation successed
            }
            catch
            {
                return true; // Unable to validate
            }
        }

        #endregion Methods

        #region Properties

        [LazyJsonAttributePropertyRename("HigherThan")]
        public Decimal Value { get; set; }

        #endregion Properties
    }

    public class FwkFormatRecordFieldValidationHigherEqualThan : FwkFormatRecordFieldValidation
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatRecordFieldValidationHigherEqualThan()
        {
        }

        public FwkFormatRecordFieldValidationHigherEqualThan(LibCulture culture, Decimal value)
            : base(culture)
        {
            this.Value = value;
        }

        #endregion Constructors

        #region Methods

        public override Boolean Validate(Object value, String objectName = null)
        {
            if (value == null || value == DBNull.Value)
                return true; // Unable to validate

            try
            {
                if (LazyConvert.ToDecimal(value) < this.Value)
                {
                    this.Reason = String.Format(LibGlobalization.GetTranslation(Properties.FwkResourcesCore.FwkExceptionRecordFieldValidationHigherEqualThan, this.Culture), objectName, this.Value);

                    return false; // Validation failed
                }

                return true; // Validation successed
            }
            catch
            {
                return true; // Unable to validate
            }
        }

        #endregion Methods

        #region Properties

        [LazyJsonAttributePropertyRename("HigherThan")]
        public Decimal Value { get; set; }

        #endregion Properties
    }
}
