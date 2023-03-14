// FwkFormatView.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 03

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
    public class FwkFormatView
    {
        #region Variables

        private String currentTable;
        private String currentField;
        private Dictionary<String, FwkFormatViewTable> viewTableList;

        #endregion Variables

        #region Constructors

        public FwkFormatView()
        {
            this.viewTableList = new Dictionary<String, FwkFormatViewTable>();
        }

        #endregion Constructors

        #region Methods

        public void SetTable(String name, Boolean required = true)
        {
            this.currentTable = name;
            this.currentField = null;

            if (this.viewTableList.ContainsKey(this.currentTable) == false)
                this.viewTableList.Add(this.currentTable, new FwkFormatViewTable());

            this.viewTableList[this.currentTable].Required = required;
        }

        public void SetField(String name, String origin = null)
        {
            this.currentField = name;

            if (this.viewTableList[this.currentTable].ViewFields.ContainsKey(this.currentField) == false)
                this.viewTableList[this.currentTable].ViewFields.Add(this.currentField, new FwkFormatViewField());

            this.viewTableList[this.currentTable].ViewFields[this.currentField].Attributes.Name = name;
            this.viewTableList[this.currentTable].ViewFields[this.currentField].Attributes.Origin = origin == null ? this.currentTable : origin;
        }

        public void SetFieldAttributes(Type type, String caption = null,
            FwkBooleanEnum visible = FwkBooleanEnum.True, FwkConstraintEnum constraint = FwkConstraintEnum.None,
            FwkAlignmentEnum displayAlignment = FwkAlignmentEnum.Default, Int32 displayWidth = 100, String displayFormat = null)
        {
            this.viewTableList[this.currentTable].ViewFields[this.currentField].Attributes.Type = type;
            this.viewTableList[this.currentTable].ViewFields[this.currentField].Attributes.Caption = caption;
            this.viewTableList[this.currentTable].ViewFields[this.currentField].Attributes.Visible = visible;
            this.viewTableList[this.currentTable].ViewFields[this.currentField].Attributes.Constraint = constraint;
            this.viewTableList[this.currentTable].ViewFields[this.currentField].Attributes.DisplayAlignment = displayAlignment;
            this.viewTableList[this.currentTable].ViewFields[this.currentField].Attributes.DisplayWidth = displayWidth;
            this.viewTableList[this.currentTable].ViewFields[this.currentField].Attributes.DisplayFormat = displayFormat;
        }

        public void SetFieldValidation(FwkFormatViewFieldValidation recordFieldValidation)
        {
            this.viewTableList[this.currentTable].ViewFields[this.currentField].Validations.Add(recordFieldValidation);
        }

        public void SetFieldTransformation(FwkFormatViewFieldTransformation recordFieldTransformation)
        {
            this.viewTableList[this.currentTable].ViewFields[this.currentField].Transformations.Add(recordFieldTransformation);
        }

        #endregion Methods

        #region Properties

        public Dictionary<String, FwkFormatViewTable> ViewTableList
        {
            get { return this.viewTableList; }
            set { this.viewTableList = value; }
        }

        #endregion Properties
    }

    public class FwkFormatViewTable
    {
        #region Variables

        private Boolean required;
        private Dictionary<String, FwkFormatViewField> recordFieldList;

        #endregion Variables

        #region Constructors

        public FwkFormatViewTable()
        {
            this.required = true;
            this.recordFieldList = new Dictionary<String, FwkFormatViewField>();
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

        public Dictionary<String, FwkFormatViewField> ViewFields
        {
            get { return this.recordFieldList; }
            set { this.recordFieldList = value; }
        }

        #endregion Properties
    }

    public class FwkFormatViewField
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatViewField()
        {
            this.Attributes = new FwkFormatViewFieldAttribute();
            this.Validations = new List<FwkFormatViewFieldValidation>();
            this.Transformations = new List<FwkFormatViewFieldTransformation>();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public FwkFormatViewFieldAttribute Attributes { get; set; }

        public List<FwkFormatViewFieldValidation> Validations { get; set; }

        public List<FwkFormatViewFieldTransformation> Transformations { get; set; }

        #endregion Properties
    }

    public class FwkFormatViewFieldAttribute
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatViewFieldAttribute()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        [LazyJsonAttributePropertyIgnore()]
        public Type Type { get; set; }

        [LazyJsonAttributePropertyRename("Type")]
        public String TypeName { get { return Type == null ? null : Type.Name; } }

        public String Name { get; set; }

        public String Origin { get; set; }

        public String Caption { get; set; }

        [LazyJsonAttributePropertyIgnore()]
        public FwkBooleanEnum Visible { get; set; }

        [LazyJsonAttributePropertyRename("Visible")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Boolean VisibleValue
        {
            get { return Visible == FwkBooleanEnum.True; }
            set { Visible = value == true ? FwkBooleanEnum.True : FwkBooleanEnum.False; }
        }

        [LazyJsonAttributePropertyIgnore()]
        public FwkConstraintEnum Constraint { get; set; }

        [LazyJsonAttributePropertyRename("Constraint")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public String ConstraintName
        {
            get { return LazyAttribute.GetCustomAttributeFromEnumValue<LazyAttributeGeneric>(Constraint).Name; }
            set
            {
                switch (value)
                {
                    case "ParentKey": Constraint = FwkConstraintEnum.ParentKey; break;
                    case "PrimaryKey": Constraint = FwkConstraintEnum.PrimaryKey; break;
                    case "IncrementKey": Constraint = FwkConstraintEnum.IncrementKey; break;
                    case "UniqueKey": Constraint = FwkConstraintEnum.UniqueKey; break;
                    case "None": Constraint = FwkConstraintEnum.None; break;
                }
            }
        }

        [LazyJsonAttributePropertyIgnore()]
        public FwkAlignmentEnum DisplayAlignment { get; set; }

        [LazyJsonAttributePropertyRename("DisplayAlignment")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public String DisplayAlignmentName
        {
            get { return LazyAttribute.GetCustomAttributeFromEnumValue<LazyAttributeGeneric>(DisplayAlignment).Name; }
            set
            {
                switch (value)
                {
                    case "Default": DisplayAlignment = FwkAlignmentEnum.Default; break;
                    case "TopLeft": DisplayAlignment = FwkAlignmentEnum.TopLeft; break;
                    case "TopCenter": DisplayAlignment = FwkAlignmentEnum.TopCenter; break;
                    case "TopRight": DisplayAlignment = FwkAlignmentEnum.TopRight; break;
                    case "MiddleLeft": DisplayAlignment = FwkAlignmentEnum.MiddleLeft; break;
                    case "MiddleCenter": DisplayAlignment = FwkAlignmentEnum.MiddleCenter; break;
                    case "MiddleRight": DisplayAlignment = FwkAlignmentEnum.MiddleRight; break;
                    case "BottomLeft": DisplayAlignment = FwkAlignmentEnum.BottomLeft; break;
                    case "BottomCenter": DisplayAlignment = FwkAlignmentEnum.BottomCenter; break;
                    case "BottomRight": DisplayAlignment = FwkAlignmentEnum.BottomRight; break;
                }
            }
        }

        public String DisplayFormat { get; set; }

        public Int32 DisplayWidth { get; set; }

        #endregion Properties
    }
}
