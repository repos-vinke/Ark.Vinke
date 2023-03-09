﻿// FtsIncrementService.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 12

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Linq;
using System.Collections.Generic;

using Lazy.Vinke;
using Lazy.Vinke.Database;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;
using Ark.Vinke.Library.Core.Service;
using Ark.Vinke.Framework;
using Ark.Vinke.Framework.Core;
using Ark.Vinke.Framework.Core.Data;
using Ark.Vinke.Framework.Core.IPlugin;
using Ark.Vinke.Framework.Core.IService;
using Ark.Vinke.Framework.Core.Service;
using Ark.Vinke.Facilities;
using Ark.Vinke.Facilities.Core;
using Ark.Vinke.Facilities.Core.Data;
using Ark.Vinke.Facilities.Core.IPlugin;
using Ark.Vinke.Facilities.Core.IService;
using static System.Net.WebRequestMethods;
using System.Security.Cryptography;

namespace Ark.Vinke.Facilities.Core.Service
{
    public class FtsIncrementService : FwkService, IFtsIncrementService
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FtsIncrementService(FwkEnvironment environment)
            : base(environment)
        {
        }

        public FtsIncrementService(FwkEnvironment environment, LazyDatabase database)
            : base(environment, database)
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Validate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <returns>The response data</returns>
        public FtsIncrementDataResponse ValidateNext(FtsIncrementDataRequest incrementDataRequest)
        {
            try
            {
                this.Operation = "ValidateNext";

                FtsIncrementDataResponse incrementDataResponse = (FtsIncrementDataResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

                if (this.IsDatabaseOwner == true)
                {
                    this.Database.OpenConnection();
                    this.Database.BeginTransaction();
                }

                InternalValidateNext(incrementDataRequest, incrementDataResponse);

                if (this.IsDatabaseOwner == true)
                {
                    this.Database.CommitTransaction();
                    this.Database.CloseConnection();
                }

                return incrementDataResponse;
            }
            catch
            {
                if (this.IsDatabaseOwner == true)
                {
                    if (this.Database.InTransaction == true)
                        this.Database.RollbackTransaction();

                    if (this.Database.IsConnectionOpen == true)
                        this.Database.CloseConnection();
                }

                throw;
            }
        }

        /// <summary>
        /// Validate fix ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <returns>The response data</returns>
        public FtsIncrementDataResponse ValidateFix(FtsIncrementDataRequest incrementDataRequest)
        {
            try
            {
                this.Operation = "ValidateFix";

                FtsIncrementDataResponse incrementDataResponse = (FtsIncrementDataResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

                if (this.IsDatabaseOwner == true)
                {
                    this.Database.OpenConnection();
                    this.Database.BeginTransaction();
                }

                InternalValidateFix(incrementDataRequest, incrementDataResponse);

                if (this.IsDatabaseOwner == true)
                {
                    this.Database.CommitTransaction();
                    this.Database.CloseConnection();
                }

                return incrementDataResponse;
            }
            catch
            {
                if (this.IsDatabaseOwner == true)
                {
                    if (this.Database.InTransaction == true)
                        this.Database.RollbackTransaction();

                    if (this.Database.IsConnectionOpen == true)
                        this.Database.CloseConnection();
                }

                throw;
            }
        }

        /// <summary>
        /// Next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <returns>The response data</returns>
        public FtsIncrementDataResponse Next(FtsIncrementDataRequest incrementDataRequest)
        {
            try
            {
                this.Operation = "Next";

                FtsIncrementDataResponse incrementDataResponse = (FtsIncrementDataResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

                if (this.IsDatabaseOwner == true)
                {
                    this.Database.OpenConnection();
                    this.Database.BeginTransaction();
                }

                InternalNext(incrementDataRequest, incrementDataResponse);

                if (this.IsDatabaseOwner == true)
                {
                    this.Database.CommitTransaction();
                    this.Database.CloseConnection();
                }

                return incrementDataResponse;
            }
            catch
            {
                if (this.IsDatabaseOwner == true)
                {
                    if (this.Database.InTransaction == true)
                        this.Database.RollbackTransaction();

                    if (this.Database.IsConnectionOpen == true)
                        this.Database.CloseConnection();
                }

                throw;
            }
        }

        /// <summary>
        /// Fix ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <returns>The response data</returns>
        public FtsIncrementDataResponse Fix(FtsIncrementDataRequest incrementDataRequest)
        {
            try
            {
                this.Operation = "Fix";

                FtsIncrementDataResponse incrementDataResponse = (FtsIncrementDataResponse)LazyActivator.Local.CreateInstance(this.DataResponseType);

                if (this.IsDatabaseOwner == true)
                {
                    this.Database.OpenConnection();
                    this.Database.BeginTransaction();
                }

                InternalFix(incrementDataRequest, incrementDataResponse);

                if (this.IsDatabaseOwner == true)
                {
                    this.Database.CommitTransaction();
                    this.Database.CloseConnection();
                }

                return incrementDataResponse;
            }
            catch
            {
                if (this.IsDatabaseOwner == true)
                {
                    if (this.Database.InTransaction == true)
                        this.Database.RollbackTransaction();

                    if (this.Database.IsConnectionOpen == true)
                        this.Database.CloseConnection();
                }

                throw;
            }
        }

        /// <summary>
        /// Internal validate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        protected void InternalValidateNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            PerformValidateNext(incrementDataRequest, incrementDataResponse);
        }

        /// <summary>
        /// Internal validate fix ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        protected void InternalValidateFix(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            PerformValidateFix(incrementDataRequest, incrementDataResponse);
        }

        /// <summary>
        /// Internal next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        protected void InternalNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            PerformValidateNext(incrementDataRequest, incrementDataResponse);
            PerformNext(incrementDataRequest, incrementDataResponse);
        }

        /// <summary>
        /// Internal fix ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        protected void InternalFix(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            PerformValidateFix(incrementDataRequest, incrementDataResponse);
            PerformFix(incrementDataRequest, incrementDataResponse);
        }

        /// <summary>
        /// Perform validate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        protected void PerformValidateNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            BeforePerformValidateNext(incrementDataRequest, incrementDataResponse);

            #region Before OnValidateNext plugins

            if (this.IPlugins != null)
            {
                foreach (IFtsIncrementPlugin iIncrementPlugin in this.IPlugins)
                    iIncrementPlugin.ValidateNextPluginBeforeEventHandler?.Invoke(this, new FtsIncrementPluginBeforeEventArgs(incrementDataRequest, incrementDataResponse));
            }

            #endregion Before OnValidateNext plugins

            OnValidateNext(incrementDataRequest, incrementDataResponse);

            #region After OnValidateNext plugins

            if (this.IPlugins != null)
            {
                foreach (IFtsIncrementPlugin iIncrementPlugin in this.IPlugins)
                    iIncrementPlugin.ValidateNextPluginAfterEventHandler?.Invoke(this, new FtsIncrementPluginAfterEventArgs(incrementDataRequest, incrementDataResponse));
            }

            #endregion After OnValidateNext plugins

            AfterPerformValidateNext(incrementDataRequest, incrementDataResponse);
        }

        /// <summary>
        /// Perform validate fix ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        protected void PerformValidateFix(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            BeforePerformValidateFix(incrementDataRequest, incrementDataResponse);

            #region Before OnValidateFix plugins

            if (this.IPlugins != null)
            {
                foreach (IFtsIncrementPlugin iIncrementPlugin in this.IPlugins)
                    iIncrementPlugin.ValidateFixPluginBeforeEventHandler?.Invoke(this, new FtsIncrementPluginBeforeEventArgs(incrementDataRequest, incrementDataResponse));
            }

            #endregion Before OnValidateFix plugins

            OnValidateFix(incrementDataRequest, incrementDataResponse);

            #region After OnValidateFix plugins

            if (this.IPlugins != null)
            {
                foreach (IFtsIncrementPlugin iIncrementPlugin in this.IPlugins)
                    iIncrementPlugin.ValidateFixPluginAfterEventHandler?.Invoke(this, new FtsIncrementPluginAfterEventArgs(incrementDataRequest, incrementDataResponse));
            }

            #endregion After OnValidateFix plugins

            AfterPerformValidateFix(incrementDataRequest, incrementDataResponse);
        }

        /// <summary>
        /// Perform next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        protected void PerformNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            BeforePerformNext(incrementDataRequest, incrementDataResponse);

            #region Before OnNext plugins

            if (this.IPlugins != null)
            {
                foreach (IFtsIncrementPlugin iIncrementPlugin in this.IPlugins)
                    iIncrementPlugin.NextPluginBeforeEventHandler?.Invoke(this, new FtsIncrementPluginBeforeEventArgs(incrementDataRequest, incrementDataResponse));
            }

            #endregion Before OnNext plugins

            OnNext(incrementDataRequest, incrementDataResponse);

            #region After OnNext plugins

            if (this.IPlugins != null)
            {
                foreach (IFtsIncrementPlugin iIncrementPlugin in this.IPlugins)
                    iIncrementPlugin.NextPluginAfterEventHandler?.Invoke(this, new FtsIncrementPluginAfterEventArgs(incrementDataRequest, incrementDataResponse));
            }

            #endregion After OnNext plugins

            AfterPerformNext(incrementDataRequest, incrementDataResponse);
        }

        /// <summary>
        /// Perform fix ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        protected void PerformFix(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            BeforePerformFix(incrementDataRequest, incrementDataResponse);

            #region Before OnFix plugins

            if (this.IPlugins != null)
            {
                foreach (IFtsIncrementPlugin iIncrementPlugin in this.IPlugins)
                    iIncrementPlugin.FixPluginBeforeEventHandler?.Invoke(this, new FtsIncrementPluginBeforeEventArgs(incrementDataRequest, incrementDataResponse));
            }

            #endregion Before OnFix plugins

            OnFix(incrementDataRequest, incrementDataResponse);

            #region After OnFix plugins

            if (this.IPlugins != null)
            {
                foreach (IFtsIncrementPlugin iIncrementPlugin in this.IPlugins)
                    iIncrementPlugin.FixPluginAfterEventHandler?.Invoke(this, new FtsIncrementPluginAfterEventArgs(incrementDataRequest, incrementDataResponse));
            }

            #endregion After OnFix plugins

            AfterPerformFix(incrementDataRequest, incrementDataResponse);
        }

        /// <summary>
        /// On validate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        protected virtual void OnValidateNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            if (String.IsNullOrWhiteSpace(incrementDataRequest.Content.TableName) == true)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementTableNameNullOrEmpty, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (String.IsNullOrWhiteSpace(incrementDataRequest.Content.TableKeyField) == true)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementTableKeyFieldNullOrEmpty, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (String.IsNullOrWhiteSpace(incrementDataRequest.Content.ControllerTableName) == true)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementControllerTableNameNullOrEmpty, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (String.IsNullOrWhiteSpace(incrementDataRequest.Content.ControllerTableKeyField) == true)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementControllerTableKeyFieldNullOrEmpty, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.TableParentKeyFields == null || incrementDataRequest.Content.TableParentKeyFields.Count == 0)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementTableParentKeyFieldsNullOrZeroLenght, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.TableParentKeyFields.Contains("IdDomain") == false)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementTableParentKeyFieldsIdDomainMissing, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.TableParentKeyFields.IndexOf("IdDomain") != 0)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementTableParentKeyFieldsIdDomainNotFirstItem, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.ControllerTableParentKeyFields == null || incrementDataRequest.Content.ControllerTableParentKeyFields.Count == 0)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementControllerTableParentKeyFieldsNullOrZeroLenght, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.ControllerTableParentKeyFields.Contains("IdDomain") == false)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementControllerTableParentKeyFieldsIdDomainMissing, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.ControllerTableParentKeyFields.IndexOf("IdDomain") != 0)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementControllerTableParentKeyFieldsIdDomainNotFirstItem, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.ParentKeyValues == null || incrementDataRequest.Content.ParentKeyValues.Count == 0)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementParentKeyValuesNullOrZeroLenght, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (LazyConvert.ToInt16(incrementDataRequest.Content.ParentKeyValues[0]) != this.Environment.Domain.IdDomain)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementParentKeyValuesIdDomainInvalid, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.DataTable != null)
            {
                if (incrementDataRequest.Content.DataTable.Columns.Contains(incrementDataRequest.Content.TableKeyField) == false)
                    throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementDataTableKeyFieldMissing, new Object[] { incrementDataRequest.Content.TableKeyField }, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

                foreach (String parentKey in incrementDataRequest.Content.TableParentKeyFields)
                {
                    if (incrementDataRequest.Content.DataTable.Columns.Contains(parentKey) == false)
                        throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementDataTableParentKeyFieldMissing, new Object[] { parentKey }, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);
                }
            }

            if (incrementDataRequest.Content.Range < 1 && incrementDataRequest.Content.DataTable == null)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementRangeLowerThanOne, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldInvalid);

            String sql = "select 1 from FtsIncrementControllerTable where ControllerTableName = :ControllerTableName";
            Boolean isFacilitiesControllerTable = this.Database.QueryFind(sql, new Object[] { incrementDataRequest.Content.ControllerTableName }, new String[] { "ControllerTableName" });

            if (isFacilitiesControllerTable == true)
            {
                sql = "select IdTable from FtsIncrementTable where TableName = :TableName";
                incrementDataRequest.Content.IdTable = LazyConvert.ToInt16(this.Database.QueryValue(
                    sql, new Object[] { incrementDataRequest.Content.TableName }, new String[] { "TableName" }), -1);

                if (incrementDataRequest.Content.IdTable == -1)
                    throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementTableNameNotFound, new Object[] { incrementDataRequest.Content.TableName }, Properties.FtsResourcesCoreService.FtsCaptionTableNotFound);
            }
        }

        /// <summary>
        /// On validate fix ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        protected virtual void OnValidateFix(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            if (String.IsNullOrWhiteSpace(incrementDataRequest.Content.TableName) == true)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementTableNameNullOrEmpty, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (String.IsNullOrWhiteSpace(incrementDataRequest.Content.TableKeyField) == true)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementTableKeyFieldNullOrEmpty, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (String.IsNullOrWhiteSpace(incrementDataRequest.Content.ControllerTableName) == true)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementControllerTableNameNullOrEmpty, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (String.IsNullOrWhiteSpace(incrementDataRequest.Content.ControllerTableKeyField) == true)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementControllerTableKeyFieldNullOrEmpty, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.TableParentKeyFields == null || incrementDataRequest.Content.TableParentKeyFields.Count == 0)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementTableParentKeyFieldsNullOrZeroLenght, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.TableParentKeyFields.Contains("IdDomain") == false)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementTableParentKeyFieldsIdDomainMissing, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.TableParentKeyFields.IndexOf("IdDomain") != 0)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementTableParentKeyFieldsIdDomainNotFirstItem, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.ControllerTableParentKeyFields == null || incrementDataRequest.Content.ControllerTableParentKeyFields.Count == 0)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementControllerTableParentKeyFieldsNullOrZeroLenght, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.ControllerTableParentKeyFields.Contains("IdDomain") == false)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementControllerTableParentKeyFieldsIdDomainMissing, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.ControllerTableParentKeyFields.IndexOf("IdDomain") != 0)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementControllerTableParentKeyFieldsIdDomainNotFirstItem, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.ParentKeyValues == null || incrementDataRequest.Content.ParentKeyValues.Count == 0)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementParentKeyValuesNullOrZeroLenght, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (LazyConvert.ToInt16(incrementDataRequest.Content.ParentKeyValues[0]) != this.Environment.Domain.IdDomain)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementParentKeyValuesIdDomainInvalid, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.DataTable != null)
            {
                foreach (String parentKey in incrementDataRequest.Content.TableParentKeyFields)
                {
                    if (incrementDataRequest.Content.DataTable.Columns.Contains(parentKey) == false)
                        throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementDataTableParentKeyFieldMissing, new Object[] { parentKey }, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);
                }
            }

            String sql = "select 1 from FtsIncrementControllerTable where ControllerTableName = :ControllerTableName";
            Boolean isFacilitiesControllerTable = this.Database.QueryFind(sql, new Object[] { incrementDataRequest.Content.ControllerTableName }, new String[] { "ControllerTableName" });

            if (isFacilitiesControllerTable == true)
            {
                sql = "select IdTable from FtsIncrementTable where TableName = :TableName";
                incrementDataRequest.Content.IdTable = LazyConvert.ToInt16(this.Database.QueryValue(
                    sql, new Object[] { incrementDataRequest.Content.TableName }, new String[] { "TableName" }), -1);

                if (incrementDataRequest.Content.IdTable == -1)
                    throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementTableNameNotFound, new Object[] { incrementDataRequest.Content.TableName }, Properties.FtsResourcesCoreService.FtsCaptionTableNotFound);
            }
        }

        /// <summary>
        /// On next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        protected virtual void OnNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            if (incrementDataRequest.Content.DataTable == null)
            {
                OnNextSingle(incrementDataRequest, incrementDataResponse);
            }
            else
            {
                OnNextDataTable(incrementDataRequest, incrementDataResponse);
            }
        }

        /// <summary>
        /// On fix ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        protected virtual void OnFix(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            if (incrementDataRequest.Content.DataTable == null)
            {
                OnFixSingle(incrementDataRequest, incrementDataResponse);
            }
            else
            {
                OnFixDataTable(incrementDataRequest, incrementDataResponse);
            }
        }

        /// <summary>
        /// On next ids range
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        private void OnNextSingle(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            String[] parentKeyFieldArray = null;
            Object[] parentKeyValueArray = null;

            if (incrementDataRequest.Content.IdTable >= 0)
            {
                parentKeyFieldArray = new String[incrementDataRequest.Content.ControllerTableParentKeyFields.Count + 1];
                incrementDataRequest.Content.ControllerTableParentKeyFields.ToArray<String>().CopyTo(parentKeyFieldArray, 1);
                parentKeyFieldArray[0] = "IdTable";

                parentKeyValueArray = new Object[incrementDataRequest.Content.ParentKeyValues.Count + 1];
                incrementDataRequest.Content.ParentKeyValues.ToArray<Object>().CopyTo(parentKeyValueArray, 1);
                parentKeyValueArray[0] = incrementDataRequest.Content.IdTable;
            }
            else
            {
                parentKeyFieldArray = incrementDataRequest.Content.ControllerTableParentKeyFields.ToArray<String>();
                parentKeyValueArray = incrementDataRequest.Content.ParentKeyValues.ToArray<Object>();
            }

            LazyDatabase internalDatabase = this.Database.CreateNew();
            internalDatabase.OpenConnection();

            /* Increment must happend outside transaction to avoid data conflicts caused by rollbacks */
            incrementDataResponse.Content.Ids = internalDatabase.IncrementRange(
                incrementDataRequest.Content.ControllerTableName, parentKeyFieldArray, parentKeyValueArray,
                incrementDataRequest.Content.ControllerTableKeyField, incrementDataRequest.Content.Range);

            internalDatabase.CloseConnection();
        }

        /// <summary>
        /// On next ids DataTable
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        private void OnNextDataTable(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            String[] parentKeyFieldArray = null;
            Object[] parentKeyValueArray = null;
            Object[] currentParentKeyValueArray = incrementDataRequest.Content.ParentKeyValues.ToArray<Object>();

            if (incrementDataRequest.Content.IdTable >= 0)
            {
                parentKeyFieldArray = new String[incrementDataRequest.Content.ControllerTableParentKeyFields.Count + 1];
                incrementDataRequest.Content.ControllerTableParentKeyFields.ToArray<String>().CopyTo(parentKeyFieldArray, 1);
                parentKeyFieldArray[0] = "IdTable";

                parentKeyValueArray = new Object[currentParentKeyValueArray.Length + 1];
                parentKeyValueArray[0] = incrementDataRequest.Content.IdTable;
            }
            else
            {
                parentKeyFieldArray = incrementDataRequest.Content.ControllerTableParentKeyFields.ToArray<String>();
            }

            incrementDataResponse.Content.DataTable = incrementDataRequest.Content.DataTable.Copy();

            DataTable dataTableDistinct = incrementDataResponse.Content.DataTable.FilterDistinct(incrementDataRequest.Content.TableParentKeyFields.ToArray<String>());

            LazyDatabase internalDatabase = this.Database.CreateNew();
            internalDatabase.OpenConnection();

            foreach (DataRow dataRowDistinct in dataTableDistinct.Rows)
            {
                if (LazyConvert.ToInt16(dataRowDistinct["IdDomain"], -1) != this.Environment.Domain.IdDomain)
                    throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementDataTableParentKeyFieldsIdDomainInvalid, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldInvalid);

                String filter = String.Empty;
                for (int i = 0; i < incrementDataRequest.Content.TableParentKeyFields.Count; i++)
                {
                    String parentKey = incrementDataRequest.Content.TableParentKeyFields[i];
                    filter += parentKey + " = " + LazyConvert.ToString(dataRowDistinct[parentKey]) + " and ";
                    currentParentKeyValueArray[i] = dataRowDistinct[parentKey];
                }
                filter = filter.Remove(filter.Length - 5, 5);

                DataRow[] dataRowArray = incrementDataResponse.Content.DataTable.Select(filter);

                if (incrementDataRequest.Content.IdTable >= 0)
                {
                    currentParentKeyValueArray.CopyTo(parentKeyValueArray, 1);
                }
                else
                {
                    parentKeyValueArray = currentParentKeyValueArray;
                }

                /* Increment must happend outside transaction to avoid data conflicts caused by rollbacks */
                Int32[] ids = internalDatabase.IncrementRange(
                    incrementDataRequest.Content.ControllerTableName, parentKeyFieldArray, parentKeyValueArray, 
                    incrementDataRequest.Content.ControllerTableKeyField, dataRowArray.Length);
                
                for (int i = 0; i < dataRowArray.Length; i++)
                    dataRowArray[i][incrementDataRequest.Content.TableKeyField] = ids[i];
            }

            internalDatabase.CloseConnection();
        }

        /// <summary>
        /// On fix ids sigle
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        private void OnFixSingle(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            String[] parentKeyFieldArray = incrementDataRequest.Content.TableParentKeyFields.ToArray<String>();
            Object[] parentKeyValueArray = incrementDataRequest.Content.ParentKeyValues.ToArray<Object>();

            String whereClausuleParentKeyString = String.Empty;
            foreach (String parentKeyField in parentKeyFieldArray)
                whereClausuleParentKeyString += parentKeyField + " = :" + parentKeyField + " and ";
            whereClausuleParentKeyString = whereClausuleParentKeyString.Remove(whereClausuleParentKeyString.Length - 5, 5);

            String sql = "select max(" + incrementDataRequest.Content.TableKeyField + ") from " + incrementDataRequest.Content.TableName + " where " + whereClausuleParentKeyString;

            /* Query must happend inside transaction to considered current added keys */
            Int32 maxId = LazyConvert.ToInt32(this.Database.QueryValue(sql, parentKeyValueArray, parentKeyFieldArray), 0);

            if (incrementDataRequest.Content.IdTable >= 0)
            {
                parentKeyFieldArray = new String[incrementDataRequest.Content.ControllerTableParentKeyFields.Count + 1];
                incrementDataRequest.Content.ControllerTableParentKeyFields.ToArray<String>().CopyTo(parentKeyFieldArray, 1);
                parentKeyFieldArray[0] = "IdTable";

                parentKeyValueArray = new Object[incrementDataRequest.Content.ParentKeyValues.Count + 1];
                incrementDataRequest.Content.ParentKeyValues.ToArray<Object>().CopyTo(parentKeyValueArray, 1);
                parentKeyValueArray[0] = incrementDataRequest.Content.IdTable;
            }
            else
            {
                parentKeyFieldArray = incrementDataRequest.Content.ControllerTableParentKeyFields.ToArray<String>();
                parentKeyValueArray = incrementDataRequest.Content.ParentKeyValues.ToArray<Object>();
            }

            String[] fieldArray = new String[parentKeyFieldArray.Length + 1];
            parentKeyFieldArray.CopyTo(fieldArray, 0);
            fieldArray[fieldArray.Length - 1] = incrementDataRequest.Content.ControllerTableKeyField;

            Object[] valueArray = new Object[parentKeyValueArray.Length + 1];
            parentKeyValueArray.CopyTo(valueArray, 0);
            valueArray[valueArray.Length - 1] = maxId;

            LazyDatabase internalDatabase = this.Database.CreateNew();
            internalDatabase.OpenConnection();

            /* Fix must happend outside transaction to avoid data conflicts caused by rollbacks */
            internalDatabase.Upsert(incrementDataRequest.Content.ControllerTableName, fieldArray, valueArray, parentKeyFieldArray, parentKeyValueArray);

            internalDatabase.CloseConnection();
        }

        /// <summary>
        /// On fix ids DataTable
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        private void OnFixDataTable(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            String[] parentKeyFieldArray = null;
            Object[] parentKeyValueArray = null;
            Object[] currentParentKeyValueArray = incrementDataRequest.Content.ParentKeyValues.ToArray<Object>();
            String[] tableParentKeyFieldArray = incrementDataRequest.Content.TableParentKeyFields.ToArray<String>();
            
            if (incrementDataRequest.Content.IdTable >= 0)
            {
                parentKeyFieldArray = new String[incrementDataRequest.Content.ControllerTableParentKeyFields.Count + 1];
                incrementDataRequest.Content.ControllerTableParentKeyFields.ToArray<String>().CopyTo(parentKeyFieldArray, 1);
                parentKeyFieldArray[0] = "IdTable";
                
                parentKeyValueArray = new Object[currentParentKeyValueArray.Length + 1];
                parentKeyValueArray[0] = incrementDataRequest.Content.IdTable;
            }
            else
            {
                parentKeyFieldArray = incrementDataRequest.Content.ControllerTableParentKeyFields.ToArray<String>();
            }
            
            String whereClausuleParentKeyString = String.Empty;
            foreach (String parentKeyField in tableParentKeyFieldArray)
                whereClausuleParentKeyString += parentKeyField + " = :" + parentKeyField + " and ";
            whereClausuleParentKeyString = whereClausuleParentKeyString.Remove(whereClausuleParentKeyString.Length - 5, 5);

            String sql = "select max(" + incrementDataRequest.Content.TableKeyField + ") from " + incrementDataRequest.Content.TableName + " where " + whereClausuleParentKeyString;

            DataTable dataTableDistinct = incrementDataRequest.Content.DataTable.FilterDistinct(tableParentKeyFieldArray);
            
            LazyDatabase internalDatabase = this.Database.CreateNew();
            internalDatabase.OpenConnection();
            
            foreach (DataRow dataRowDistinct in dataTableDistinct.Rows)
            {
                if (LazyConvert.ToInt16(dataRowDistinct["IdDomain"], -1) != this.Environment.Domain.IdDomain)
                    throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementDataTableParentKeyFieldsIdDomainInvalid, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldInvalid);

                for (int i = 0; i < tableParentKeyFieldArray.Length; i++)
                    currentParentKeyValueArray[i] = dataRowDistinct[tableParentKeyFieldArray[i]];

                /* Query must happend inside transaction to considered current added keys */
                Int32 maxId = LazyConvert.ToInt32(this.Database.QueryValue(sql, currentParentKeyValueArray, tableParentKeyFieldArray), 0);
                
                if (incrementDataRequest.Content.IdTable >= 0)
                {
                    currentParentKeyValueArray.CopyTo(parentKeyValueArray, 1);
                }
                else
                {
                    parentKeyValueArray = currentParentKeyValueArray;
                }

                String[] fieldArray = new String[parentKeyFieldArray.Length + 1];
                parentKeyFieldArray.CopyTo(fieldArray, 0);
                fieldArray[fieldArray.Length - 1] = incrementDataRequest.Content.ControllerTableKeyField;

                Object[] valueArray = new Object[parentKeyValueArray.Length + 1];
                parentKeyValueArray.CopyTo(valueArray, 0);
                valueArray[valueArray.Length - 1] = maxId;
                
                /* Fix must happend outside transaction to avoid data conflicts caused by rollbacks */
                internalDatabase.Upsert(incrementDataRequest.Content.ControllerTableName, fieldArray, valueArray, parentKeyFieldArray, parentKeyValueArray);
            }

            internalDatabase.CloseConnection();
        }

        /// <summary>
        /// Before perform validate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        private void BeforePerformValidateNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
        }

        /// <summary>
        /// After perform validate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        private void AfterPerformValidateNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
        }

        /// <summary>
        /// Before perform validate fix ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        private void BeforePerformValidateFix(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
        }

        /// <summary>
        /// After perform validate fix ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        private void AfterPerformValidateFix(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
        }

        /// <summary>
        /// Before perform next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        private void BeforePerformNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
        }

        /// <summary>
        /// After perform next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        private void AfterPerformNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
        }

        /// <summary>
        /// Before perform fix ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        private void BeforePerformFix(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
        }

        /// <summary>
        /// After perform fix ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        private void AfterPerformFix(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
