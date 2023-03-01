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

namespace Ark.Vinke.Library
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

        #endregion System.Data.DataTable
    }
}
