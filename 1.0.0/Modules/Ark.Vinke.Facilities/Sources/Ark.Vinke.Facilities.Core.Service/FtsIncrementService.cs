// FtsIncrementService.cs
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

            if (incrementDataRequest.Content.ControllerTableParentKeyFields == null || incrementDataRequest.Content.ControllerTableParentKeyFields.Count == 0)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementControllerTableParentKeyFieldsNullOrZeroLenght, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.ControllerTableParentKeyFields.ContainsKey("IdDomain") == false)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementControllerTableParentKeyFieldsIdDomainMissing, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (LazyConvert.ToInt16(incrementDataRequest.Content.ControllerTableParentKeyFields["IdDomain"], -1) != this.Environment.Domain.IdDomain)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementControllerTableParentKeyFieldsIdDomainInvalid, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldInvalid);

            if (String.IsNullOrWhiteSpace(incrementDataRequest.Content.ControllerTableIncrementField) == true)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementControllerTableIncrementFieldNullOrEmpty, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.DataTable != null)
            {
                if (incrementDataRequest.Content.DataTable.Columns.Contains(incrementDataRequest.Content.TableKeyField) == false)
                    throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementDataTableIncrementKeyMissing, new Object[] { incrementDataRequest.Content.TableKeyField }, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

                foreach (KeyValuePair<String, Object> keyValuePair in incrementDataRequest.Content.ControllerTableParentKeyFields)
                {
                    if (incrementDataRequest.Content.DataTable.Columns.Contains(keyValuePair.Key) == false)
                        throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementDataTableParentKeyMissing, new Object[] { keyValuePair.Key }, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);
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

            if (incrementDataRequest.Content.ControllerTableParentKeyFields == null || incrementDataRequest.Content.ControllerTableParentKeyFields.Count == 0)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementControllerTableParentKeyFieldsNullOrZeroLenght, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.ControllerTableParentKeyFields.ContainsKey("IdDomain") == false)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementControllerTableParentKeyFieldsIdDomainMissing, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (LazyConvert.ToInt16(incrementDataRequest.Content.ControllerTableParentKeyFields["IdDomain"], -1) != this.Environment.Domain.IdDomain)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementControllerTableParentKeyFieldsIdDomainInvalid, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldInvalid);

            if (String.IsNullOrWhiteSpace(incrementDataRequest.Content.ControllerTableIncrementField) == true)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementControllerTableIncrementFieldNullOrEmpty, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);

            if (incrementDataRequest.Content.DataTable != null)
            {
                foreach (KeyValuePair<String, Object> keyValuePair in incrementDataRequest.Content.ControllerTableParentKeyFields)
                {
                    if (incrementDataRequest.Content.DataTable.Columns.Contains(keyValuePair.Key) == false)
                        throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementDataTableParentKeyMissing, new Object[] { keyValuePair.Key }, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldMissing);
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
            String[] keyFields = null;
            Object[] keyValues = null;

            /* Increment must happend outside transaction to avoid data conflicts caused by rollbacks */
            LazyDatabase internalDatabase = (LazyDatabase)LazyActivator.Local.CreateInstance(this.Database.GetType(), new Object[] { this.Database.ConnectionString });
            internalDatabase.OpenConnection();

            if (incrementDataRequest.Content.DataTable == null)
            {
                if (incrementDataRequest.Content.IdTable >= 0)
                {
                    keyFields = new String[incrementDataRequest.Content.ControllerTableParentKeyFields.Count + 1];
                    incrementDataRequest.Content.ControllerTableParentKeyFields.Keys.ToArray<String>().CopyTo(keyFields, 1);
                    keyFields[0] = "IdTable";

                    keyValues = new Object[incrementDataRequest.Content.ControllerTableParentKeyFields.Count + 1];
                    incrementDataRequest.Content.ControllerTableParentKeyFields.Values.ToArray<Object>().CopyTo(keyValues, 1);
                    keyValues[0] = incrementDataRequest.Content.IdTable;
                }
                else
                {
                    keyFields = incrementDataRequest.Content.ControllerTableParentKeyFields.Keys.ToArray<String>();
                    keyValues = incrementDataRequest.Content.ControllerTableParentKeyFields.Values.ToArray<Object>();
                }

                incrementDataResponse.Content.Ids = internalDatabase.IncrementRange(
                    incrementDataRequest.Content.ControllerTableName, keyFields, keyValues,
                    incrementDataRequest.Content.ControllerTableIncrementField, incrementDataRequest.Content.Range);
            }
            else
            {
                incrementDataResponse.Content.DataTable = incrementDataRequest.Content.DataTable.Copy();

                DataTable dataTableDistinct = incrementDataResponse.Content.DataTable.FilterDistinct(
                    incrementDataRequest.Content.ControllerTableParentKeyFields.Keys.ToArray<String>());

                foreach (DataRow dataRowDistinct in dataTableDistinct.Rows)
                {
                    if (LazyConvert.ToInt16(dataRowDistinct["IdDomain"], -1) != this.Environment.Domain.IdDomain)
                        throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementDataTableParentKeyFieldsIdDomainInvalid, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldInvalid);

                    String filter = String.Empty;
                    foreach (KeyValuePair<String, Object> keyValuePair in incrementDataRequest.Content.ControllerTableParentKeyFields)
                    {
                        filter += keyValuePair.Key + " = " + LazyConvert.ToString(dataRowDistinct[keyValuePair.Key]) + " and ";
                        incrementDataRequest.Content.ControllerTableParentKeyFields[keyValuePair.Key] = dataRowDistinct[keyValuePair.Key];
                    }
                    filter = filter.Remove(filter.LastIndexOf(" and "), 5);

                    DataRow[] dataRowArray = incrementDataResponse.Content.DataTable.Select(filter);
                    incrementDataRequest.Content.Range = dataRowArray.Length;

                    if (incrementDataRequest.Content.IdTable >= 0)
                    {
                        keyFields = new String[incrementDataRequest.Content.ControllerTableParentKeyFields.Count + 1];
                        incrementDataRequest.Content.ControllerTableParentKeyFields.Keys.ToArray<String>().CopyTo(keyFields, 1);
                        keyFields[0] = "IdTable";

                        keyValues = new Object[incrementDataRequest.Content.ControllerTableParentKeyFields.Count + 1];
                        incrementDataRequest.Content.ControllerTableParentKeyFields.Values.ToArray<Object>().CopyTo(keyValues, 1);
                        keyValues[0] = incrementDataRequest.Content.IdTable;
                    }
                    else
                    {
                        keyFields = incrementDataRequest.Content.ControllerTableParentKeyFields.Keys.ToArray<String>();
                        keyValues = incrementDataRequest.Content.ControllerTableParentKeyFields.Values.ToArray<Object>();
                    }

                    Int32[] ids = internalDatabase.IncrementRange(
                        incrementDataRequest.Content.ControllerTableName, keyFields, keyValues,
                        incrementDataRequest.Content.ControllerTableIncrementField, incrementDataRequest.Content.Range);

                    for (int i = 0; i < dataRowArray.Length; i++)
                        dataRowArray[i][incrementDataRequest.Content.TableKeyField] = ids[i];
                }
            }

            internalDatabase.CloseConnection();
        }

        /// <summary>
        /// On fix ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        protected virtual void OnFix(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            String[] keyFields = null;
            Object[] keyValues = null;

            /* Increment must happend outside transaction to avoid data conflicts caused by rollbacks */
            LazyDatabase internalDatabase = (LazyDatabase)LazyActivator.Local.CreateInstance(this.Database.GetType(), new Object[] { this.Database.ConnectionString });
            internalDatabase.OpenConnection();

            if (incrementDataRequest.Content.DataTable == null)
            {
                keyFields = incrementDataRequest.Content.ControllerTableParentKeyFields.Keys.ToArray<String>();
                keyValues = incrementDataRequest.Content.ControllerTableParentKeyFields.Values.ToArray<Object>();

                String keyFieldsString = String.Empty;
                foreach (String keyField in keyFields)
                    keyFieldsString += keyField + " = :" + keyField + " and ";
                keyFieldsString = keyFieldsString.Remove(keyFieldsString.Length - 5, 5);

                String sql = "select max(" + incrementDataRequest.Content.TableKeyField + ") from " + incrementDataRequest.Content.TableName + " where " + keyFieldsString;
                Int32 maxId = LazyConvert.ToInt32(internalDatabase.QueryValue(sql, keyValues, keyFields), 0);

                if (incrementDataRequest.Content.IdTable >= 0)
                {
                    keyFields = new String[incrementDataRequest.Content.ControllerTableParentKeyFields.Count + 1];
                    incrementDataRequest.Content.ControllerTableParentKeyFields.Keys.ToArray<String>().CopyTo(keyFields, 1);
                    keyFields[0] = "IdTable";

                    keyValues = new Object[incrementDataRequest.Content.ControllerTableParentKeyFields.Count + 1];
                    incrementDataRequest.Content.ControllerTableParentKeyFields.Values.ToArray<Object>().CopyTo(keyValues, 1);
                    keyValues[0] = incrementDataRequest.Content.IdTable;
                }

                internalDatabase.Upsert(incrementDataRequest.Content.ControllerTableName,
                    new String[] { incrementDataRequest.Content.ControllerTableIncrementField },
                    new Object[] { maxId },
                    keyFields,
                    keyValues);
            }
            else
            {
                keyFields = incrementDataRequest.Content.ControllerTableParentKeyFields.Keys.ToArray<String>();

                String keyFieldsString = String.Empty;
                foreach (String keyField in keyFields)
                    keyFieldsString += keyField + " = :" + keyField + " and ";
                keyFieldsString = keyFieldsString.Remove(keyFieldsString.Length - 5, 5);

                String sql = "select max(" + incrementDataRequest.Content.TableKeyField + ") from " + incrementDataRequest.Content.TableName + " where " + keyFieldsString;

                DataTable dataTableDistinct = incrementDataRequest.Content.DataTable.FilterDistinct(
                    incrementDataRequest.Content.ControllerTableParentKeyFields.Keys.ToArray<String>());

                foreach (DataRow dataRowDistinct in dataTableDistinct.Rows)
                {
                    if (LazyConvert.ToInt16(dataRowDistinct["IdDomain"], -1) != this.Environment.Domain.IdDomain)
                        throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementDataTableParentKeyFieldsIdDomainInvalid, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldInvalid);

                    foreach (KeyValuePair<String, Object> keyValuePair in incrementDataRequest.Content.ControllerTableParentKeyFields)
                        incrementDataRequest.Content.ControllerTableParentKeyFields[keyValuePair.Key] = dataRowDistinct[keyValuePair.Key];

                    keyValues = incrementDataRequest.Content.ControllerTableParentKeyFields.Values.ToArray<Object>();

                    Int32 maxId = LazyConvert.ToInt32(internalDatabase.QueryValue(sql, keyValues, keyFields), 0);

                    if (incrementDataRequest.Content.IdTable >= 0)
                    {
                        keyFields = new String[incrementDataRequest.Content.ControllerTableParentKeyFields.Count + 1];
                        incrementDataRequest.Content.ControllerTableParentKeyFields.Keys.ToArray<String>().CopyTo(keyFields, 1);
                        keyFields[0] = "IdTable";

                        keyValues = new Object[incrementDataRequest.Content.ControllerTableParentKeyFields.Count + 1];
                        incrementDataRequest.Content.ControllerTableParentKeyFields.Values.ToArray<Object>().CopyTo(keyValues, 1);
                        keyValues[0] = incrementDataRequest.Content.IdTable;
                    }

                    internalDatabase.Upsert(incrementDataRequest.Content.ControllerTableName,
                        new String[] { incrementDataRequest.Content.ControllerTableIncrementField },
                        new Object[] { maxId },
                        keyFields,
                        keyValues);
                }
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
