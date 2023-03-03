﻿// IFwkServiceRecord.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, December 31

using System;
using System.Xml;
using System.Data;

using Lazy.Vinke;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;
using Ark.Vinke.Framework;
using Ark.Vinke.Framework.Core;
using Ark.Vinke.Framework.Core.Data;

namespace Ark.Vinke.Framework.Core.IService
{
    public interface IFwkServiceRecord : IFwkServiceBasic
    {
        FwkDataRecordResponse Format(FwkDataRecordRequest dataRecordRequest);

        FwkDataRecordResponse ValidateRead(FwkDataRecordRequest dataRecordRequest);

        FwkDataRecordResponse ValidateInsert(FwkDataRecordRequest dataRecordRequest);

        FwkDataRecordResponse ValidateIndate(FwkDataRecordRequest dataRecordRequest);

        FwkDataRecordResponse ValidateUpdate(FwkDataRecordRequest dataRecordRequest);

        FwkDataRecordResponse ValidateUpsert(FwkDataRecordRequest dataRecordRequest);

        FwkDataRecordResponse ValidateDelete(FwkDataRecordRequest dataRecordRequest);

        FwkDataRecordResponse Read(FwkDataRecordRequest dataRecordRequest);

        FwkDataRecordResponse Insert(FwkDataRecordRequest dataRecordRequest);

        FwkDataRecordResponse Indate(FwkDataRecordRequest dataRecordRequest);

        FwkDataRecordResponse Update(FwkDataRecordRequest dataRecordRequest);

        FwkDataRecordResponse Upsert(FwkDataRecordRequest dataRecordRequest);

        FwkDataRecordResponse Delete(FwkDataRecordRequest dataRecordRequest);
    }
}
