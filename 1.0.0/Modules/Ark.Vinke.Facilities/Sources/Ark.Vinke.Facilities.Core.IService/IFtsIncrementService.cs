// IFtsIncrementService.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 12

using System;
using System.Xml;
using System.Data;

using Lazy.Vinke;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;
using Ark.Vinke.Framework;
using Ark.Vinke.Framework.Core;
using Ark.Vinke.Framework.Core.Data;
using Ark.Vinke.Framework.Core.IService;
using Ark.Vinke.Facilities;
using Ark.Vinke.Facilities.Core;
using Ark.Vinke.Facilities.Core.Data;

namespace Ark.Vinke.Facilities.Core.IService
{
    public interface IFtsIncrementService : IFwkService
    {
        FtsIncrementDataResponse ValidateNext(FtsIncrementDataRequest incrementDataRequest);

        FtsIncrementDataResponse Next(FtsIncrementDataRequest incrementDataRequest);
    }
}
