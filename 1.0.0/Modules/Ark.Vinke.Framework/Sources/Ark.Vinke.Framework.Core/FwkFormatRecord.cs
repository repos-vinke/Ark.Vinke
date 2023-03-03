// FwkFormatRecord.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 28

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
    public class FwkFormatRecord
    {
        #region Variables

        private String currentTable;
        private String currentField;
        private Dictionary<String, FwkFormatRecordTable> recordTableList;

        #endregion Variables

        #region Constructors

        public FwkFormatRecord()
        {
            this.recordTableList = new Dictionary<String, FwkFormatRecordTable>();
        }

        #endregion Constructors

        #region Methods

        public void SetTable(String name, Boolean required = true)
        {
            this.currentTable = name;
            this.currentField = null;

            if (this.recordTableList.ContainsKey(this.currentTable) == false)
                this.recordTableList.Add(this.currentTable, new FwkFormatRecordTable());

            this.recordTableList[this.currentTable].Required = required;
        }

        public void SetField(String name, String origin = null)
        {
            this.currentField = name;

            if (this.recordTableList[this.currentTable].RecordFields.ContainsKey(this.currentField) == false)
                this.recordTableList[this.currentTable].RecordFields.Add(this.currentField, new FwkFormatRecordField());

            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.Name = name;
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.Origin = origin == null ? this.currentTable : origin;
        }

        public void SetFieldAttributes(Type type, String caption = null,
            FwkBooleanEnum nullable = FwkBooleanEnum.True, FwkBooleanEnum editable = FwkBooleanEnum.True,
            FwkBooleanEnum visible = FwkBooleanEnum.True, FwkConstraintEnum constraint = FwkConstraintEnum.None,
            String[] uniqueKeys = null, Object defaultValue = null, Boolean skipValidations = false)
        {
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.Type = type;
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.Caption = caption;
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.Nullable = nullable;
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.Editable = editable;
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.Visible = visible;
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.Constraint = constraint;
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.UniqueKeys = uniqueKeys;
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.DefaultValue = defaultValue;
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.SkipValidations = skipValidations;
        }

        public void SetFieldValidation(FwkFormatRecordFieldValidation recordFieldValidation)
        {
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Validations.Add(recordFieldValidation);
        }

        public void SetFieldTransformation(FwkFormatRecordFieldTransformation recordFieldTransformation)
        {
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Transformations.Add(recordFieldTransformation);
        }

        #endregion Methods

        #region Properties

        public Dictionary<String, FwkFormatRecordTable> RecordTableList
        {
            get { return this.recordTableList; }
            set { this.recordTableList = value; }
        }

        #endregion Properties
    }

    public class FwkFormatRecordTable
    {
        #region Variables

        private Boolean required;
        private Dictionary<String, FwkFormatRecordField> recordFieldList;

        #endregion Variables

        #region Constructors

        public FwkFormatRecordTable()
        {
            this.required = true;
            this.recordFieldList = new Dictionary<String, FwkFormatRecordField>();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Boolean Required
        {
            get { return this.required; }
            set { this.required = value; }
        }

        public Dictionary<String, FwkFormatRecordField> RecordFields
        {
            get { return this.recordFieldList; }
            set { this.recordFieldList = value; }
        }

        #endregion Properties
    }

    public class FwkFormatRecordField
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatRecordField()
        {
            this.Attributes = new FwkFormatRecordFieldAttribute();
            this.Validations = new List<FwkFormatRecordFieldValidation>();
            this.Transformations = new List<FwkFormatRecordFieldTransformation>();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public FwkFormatRecordFieldAttribute Attributes { get; set; }

        public List<FwkFormatRecordFieldValidation> Validations { get; set; }

        public List<FwkFormatRecordFieldTransformation> Transformations { get; set; }

        #endregion Properties
    }

    public class FwkFormatRecordFieldAttribute
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatRecordFieldAttribute()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        [LazyJsonAttributePropertyIgnore()]
        public Type Type { get; set; }

        [LazyJsonAttributePropertyRename("Type")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public String TypeName { get { return Type == null ? null : Type.Name; } }

        public String Name { get; set; }

        public String Origin { get; set; }

        public String Caption { get; set; }

        [LazyJsonAttributePropertyIgnore()]
        public FwkBooleanEnum Nullable { get; set; }

        [LazyJsonAttributePropertyRename("Nullable")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Boolean NullableValue { get { return Nullable == FwkBooleanEnum.True ? true : false; } }

        [LazyJsonAttributePropertyIgnore()]
        public FwkBooleanEnum Editable { get; set; }

        [LazyJsonAttributePropertyRename("Editable")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Boolean EditableValue { get { return Editable == FwkBooleanEnum.True ? true : false; } }

        [LazyJsonAttributePropertyIgnore()]
        public FwkBooleanEnum Visible { get; set; }

        [LazyJsonAttributePropertyRename("Visible")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Boolean VisibleValue { get { return Visible == FwkBooleanEnum.True ? true : false; } }

        [LazyJsonAttributePropertyIgnore()]
        public FwkConstraintEnum Constraint { get; set; }

        [LazyJsonAttributePropertyRename("Constraint")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public String ConstraintName { get { return Enum.GetName(typeof(FwkConstraintEnum), Constraint); } }

        public String[] UniqueKeys { get; set; }

        public Object DefaultValue { get; set; }

        public Boolean SkipValidations { get; set; }

        #endregion Properties
    }
}
