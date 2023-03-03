// SysAutomationData.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 21

using System;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Lazy.Vinke;

using Ark.Vinke.Library;
using Ark.Vinke.Library.Core;
using Ark.Vinke.Framework;
using Ark.Vinke.Framework.Core;
using Ark.Vinke.Framework.Core.Data;
using Ark.Vinke.Facilities;
using Ark.Vinke.Facilities.Core;
using Ark.Vinke.Facilities.Core.Data;
using Ark.Vinke.System;
using Ark.Vinke.System.Core;

namespace Ark.Vinke.System.Core.Data
{
    public class SysAutomationDataRequest : FwkDataRequest
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAutomationDataRequest()
        {
            this.scope = new SysAutomationDataRequestScope();
            this.content = new SysAutomationDataRequestContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new SysAutomationDataRequestScope Scope
        {
            get { return (SysAutomationDataRequestScope)this.scope; }
            set { this.scope = value; }
        }

        public new SysAutomationDataRequestContent Content
        {
            get { return (SysAutomationDataRequestContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class SysAutomationDataRequestScope : FwkDataRequestScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAutomationDataRequestScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysAutomationDataRequestContent : FwkDataRequestContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAutomationDataRequestContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public LibTimedWorkerData TimedWorkerData { get; set; }

        #endregion Properties
    }

    public class SysAutomationDataResponse : FwkDataResponse
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAutomationDataResponse()
        {
            this.scope = new SysAutomationDataResponseScope();
            this.content = new SysAutomationDataResponseContent();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public new SysAutomationDataResponseScope Scope
        {
            get { return (SysAutomationDataResponseScope)this.scope; }
            set { this.scope = value; }
        }

        public new SysAutomationDataResponseContent Content
        {
            get { return (SysAutomationDataResponseContent)this.content; }
            set { this.content = value; }
        }

        #endregion Properties
    }

    public class SysAutomationDataResponseScope : FwkDataResponseScope
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAutomationDataResponseScope()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class SysAutomationDataResponseContent : FwkDataResponseContent
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public SysAutomationDataResponseContent()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
