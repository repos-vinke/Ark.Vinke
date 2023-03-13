// LibExtensions.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2023, February 08

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Globalization;
using System.Collections.Generic;

using Lazy.Vinke;

using Ark.Vinke.Library;
using System.Runtime.CompilerServices;

namespace Ark.Vinke.Library.Core
{
    public static class LibExtensions
    {
        #region System.Data.DataTable

        public static DataTable FilterDistinct(this DataTable dataTable, String[] fields)
        {
            return dataTable.DefaultView.ToTable(true, fields);
        }

        public static DataTable FilterByRowState(this DataTable dataTable, DataRowState dataRowState)
        {
            if (dataTable == null)
                return null;

            DataTable dataTableFiltered = dataTable.Clone();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRowState.HasFlag(dataRow.RowState) == true)
                    dataTableFiltered.ImportRow(dataRow);
            }

            return dataTableFiltered;
        }

        public static DataRow[] FilterByDataRow(this DataTable dataTable, DataRow dataRow, String[] columnArray)
        {
            if (dataTable == null)
                return null;

            if (dataRow == null || columnArray == null || columnArray.Length == 0)
                return dataTable.Select();

            String filter = String.Empty;
            foreach (String column in columnArray)
                filter += column + " = '" + LazyConvert.ToString(dataRow[column]) + "' and ";
            filter = filter.Remove(filter.Length - 5, 5);

            return dataTable.Select(filter);
        }

        #endregion System.Data.DataTable

        #region System.Data.DataRow

        public static DataRow Clone(this DataRow dataRow, String[] columns)
        {
            if (dataRow == null)
                return null;
            
            if (columns == null || columns.Length == 0)
                return null;
            
            DataTable dataTable = new DataTable(dataRow.Table.TableName);
            DataRow dataRowCloned = dataTable.NewRow();
            
            foreach (String column in columns)
            {
                if (dataRow.Table.Columns.Contains(column) == true)
                {
                    dataTable.Columns.Add(column, dataRow[column].GetType());
                    dataRowCloned[column] = dataRow[column];
                }
            }
            
            dataTable.Rows.Add(dataRowCloned);
            dataTable.AcceptChanges();
            
            return dataRowCloned;
        }

        #endregion System.Data.DataRow
    }
}