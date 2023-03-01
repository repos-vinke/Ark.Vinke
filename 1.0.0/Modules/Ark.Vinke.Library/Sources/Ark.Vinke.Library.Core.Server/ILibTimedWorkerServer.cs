// ILibTimedWorkerServer.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 17

using System;
using System.Xml;
using System.Data;

using Lazy.Vinke;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;

namespace Ark.Vinke.Library.Core.Server
{
    public interface ILibTimedWorkerServer
    {
        void Execute(Object data);
    }
}