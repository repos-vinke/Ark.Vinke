// IFwkServiceBasic.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2020, November 22

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
    public interface IFwkServiceBasic : IFwkService
    {
        FwkDataBasicResponse Init(FwkDataBasicRequest dataBasicRequest);

        FwkDataBasicResponse Load(FwkDataBasicRequest dataBasicRequest);
    }
}
