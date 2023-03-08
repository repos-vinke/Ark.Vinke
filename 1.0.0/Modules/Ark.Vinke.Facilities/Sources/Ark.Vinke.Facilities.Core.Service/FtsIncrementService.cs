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
        /// Validate generate next ids
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
        /// Generate next ids
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
        /// Internal validate generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        protected void InternalValidateNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            PerformValidateNext(incrementDataRequest, incrementDataResponse);
        }

        /// <summary>
        /// Internal generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        protected void InternalNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            PerformValidateNext(incrementDataRequest, incrementDataResponse);
            PerformNext(incrementDataRequest, incrementDataResponse);
        }

        /// <summary>
        /// Perform validate generate next ids
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
        /// Perform generate next ids
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
        /// On validate generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        protected virtual void OnValidateNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            if (String.IsNullOrEmpty(incrementDataRequest.Content.TableName) == false && String.IsNullOrWhiteSpace(incrementDataRequest.Content.TableKeyField) == true)
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

            if (incrementDataRequest.Content.DataTable == null && incrementDataRequest.Content.Range < 1)
                throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementRangeLowerThanOne, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldInvalid);

            if (String.IsNullOrEmpty(incrementDataRequest.Content.TableName) == false)
            {
                String sql = "select IdTable from FtsIncrementTable where TableName = :TableName";
                incrementDataRequest.Content.IdTable = LazyConvert.ToInt16(this.Database.QueryValue(
                    sql, new Object[] { incrementDataRequest.Content.TableName }, new String[] { "TableName" }), -1);

                if (incrementDataRequest.Content.IdTable == -1)
                    throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementTableNameNotFound, new Object[] { incrementDataRequest.Content.TableName }, Properties.FtsResourcesCoreService.FtsCaptionTableNotFound);
            }
            else
            {
                String sql = "select 1 from FtsIncrementControllerTable where ControllerTableName = :ControllerTableName";
                Boolean isFacilitiesTableStructure = this.Database.QueryFind(sql, new Object[] { incrementDataRequest.Content.ControllerTableName }, new String[] { "ControllerTableName" });

                if (isFacilitiesTableStructure == true)
                    throw new LibException(Properties.FtsResourcesCoreService.FtsExceptionIncrementControllerTableNameFacilitiesStruct, new Object[] { incrementDataRequest.Content.ControllerTableName }, Properties.FtsResourcesCoreService.FtsCaptionRequiredFieldInvalid);
            }
        }

        /// <summary>
        /// On generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        protected virtual void OnNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
            String[] keyFields = null;
            Object[] keyValues = null;

            if (incrementDataRequest.Content.DataTable == null)
            {
                if (String.IsNullOrWhiteSpace(incrementDataRequest.Content.TableName) == false)
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

                incrementDataResponse.Content.Ids = this.Database.IncrementRange(
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
                    String filter = String.Empty;
                    foreach (KeyValuePair<String, Object> keyValuePair in incrementDataRequest.Content.ControllerTableParentKeyFields)
                    {
                        filter += keyValuePair.Key + " = " + LazyConvert.ToString(dataRowDistinct[keyValuePair.Key]) + " and ";
                        incrementDataRequest.Content.ControllerTableParentKeyFields[keyValuePair.Key] = dataRowDistinct[keyValuePair.Key];
                    }
                    filter = filter.Remove(filter.LastIndexOf(" and "), 5);

                    DataRow[] dataRowArray = incrementDataResponse.Content.DataTable.Select(filter);
                    incrementDataRequest.Content.Range = dataRowArray.Length;

                    if (String.IsNullOrWhiteSpace(incrementDataRequest.Content.TableName) == false)
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

                    Int32[] ids = this.Database.IncrementRange(
                        incrementDataRequest.Content.ControllerTableName, keyFields, keyValues,
                        incrementDataRequest.Content.ControllerTableIncrementField, incrementDataRequest.Content.Range);

                    for (int i = 0; i < dataRowArray.Length; i++)
                        dataRowArray[i][incrementDataRequest.Content.TableKeyField] = ids[i];
                }
            }
        }

        /// <summary>
        /// Before perform validate generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        private void BeforePerformValidateNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
        }

        /// <summary>
        /// After perform validate generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        private void AfterPerformValidateNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
        }

        /// <summary>
        /// Before perform generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        private void BeforePerformNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
        }

        /// <summary>
        /// After perform generate next ids
        /// </summary>
        /// <param name="incrementDataRequest">The request data</param>
        /// <param name="incrementDataResponse">The response data</param>
        private void AfterPerformNext(FtsIncrementDataRequest incrementDataRequest, FtsIncrementDataResponse incrementDataResponse)
        {
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
