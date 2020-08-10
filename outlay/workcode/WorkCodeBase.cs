// <copyright file = "WorkCodeBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "IPayrollCostData"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public abstract class WorkCodeBase
    {
        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private protected DataRow Record { get; set; }

        /// <summary>
        /// Gets or sets the work code identifier.
        /// </summary>
        /// <value>
        /// The work code identifier.
        /// </value>
        private protected IKey ID { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        private protected IElement Code { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private protected IElement Name { get; set; }

        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        /// <value>
        /// The short name.
        /// </value>
        private protected IElement ShortName { get; set; }

        /// <summary>
        /// Gets or sets the notifications.
        /// </summary>
        /// <value>
        /// The notifications.
        /// </value>
        private protected IElement Notifications { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        private protected IElement Status { get; set; }

        /// <summary>
        /// Gets or sets the pay period.
        /// </summary>
        /// <value>
        /// The pay period.
        /// </value>
        private protected IElement PayPeriod { get; set; }

        /// <summary>
        /// Gets or sets the bbfy.
        /// </summary>
        /// <value>
        /// The bbfy.
        /// </value>
        private protected IElement BBFY { get; set; }

        /// <summary>
        /// Gets or sets the fund code.
        /// </summary>
        /// <value>
        /// The fund code.
        /// </value>
        private protected IElement FundCode { get; set; }

        /// <summary>
        /// Gets or sets the foc code.
        /// </summary>
        /// <value>
        /// The foc code.
        /// </value>
        private protected IElement FocCode { get; set; }

        /// <summary>
        /// Gets or sets the approval date.
        /// </summary>
        /// <value>
        /// The approval date.
        /// </value>
        private protected DateTime ApprovalDate { get; set; }

        /// <summary>
        /// Gets or sets the cost org code.
        /// </summary>
        /// <value>
        /// The cost org code.
        /// </value>
        private protected IElement CostOrgCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the cost org.
        /// </summary>
        /// <value>
        /// The name of the cost org.
        /// </value>
        private protected IElement CostOrgName { get; set; }

        /// <summary>
        /// Gets or sets the rc code.
        /// </summary>
        /// <value>
        /// The rc code.
        /// </value>
        private protected IElement RcCode { get; set; }

        /// <summary>
        /// Gets or sets the account code.
        /// </summary>
        /// <value>
        /// The account code.
        /// </value>
        private protected IElement AccountCode { get; set; }

        /// <summary>
        /// Gets or sets the project code.
        /// </summary>
        /// <value>
        /// The project code.
        /// </value>
        private protected IElement ProjectCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the project code.
        /// </summary>
        /// <value>
        /// The name of the project code.
        /// </value>
        private protected IElement ProjectCodeName { get; set; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the approval date.
        /// </summary>
        /// <returns>
        /// </returns>
        public DateTime GetApprovalDate()
        {
            try
            {
                return ApprovalDate != default
                    ? ApprovalDate
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the project code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetProjectCode()
        {
            if( Verify.Input( ProjectCode?.GetValue() ) )
            {
                try
                {
                    return ProjectCode;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the name of the project code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetProjectCodeName()
        {
            if( Verify.Input( ProjectCodeName?.GetValue() ) )
            {
                try
                {
                    return ProjectCodeName;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Gets the work code identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public int GetWorkCodeId()
        {
            try
            {
                return Verify.Key( ID )
                    ? ID.GetIndex()
                    : -1;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return -1;
            }
        }

        /// <summary>
        /// Gets the work code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetWorkCode()
        {
            try
            {
                var code = ( (IProgramElement)this ).GetCode();

                return Verify.Input( code.GetValue() )
                    ? code
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the name of the work code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetWorkCodeName()
        {
            try
            {
                return Verify.Input( Name.GetValue() )
                    ? Name
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the short name.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetShortName()
        {
            try
            {
                return Verify.Input( ShortName.GetValue() )
                    ? ShortName
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetStatus()
        {
            try
            {
                return Verify.Input( Status.GetValue() )
                    ? Status
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the notifications.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetNotifications()
        {
            try
            {
                return string.IsNullOrEmpty( Notifications.GetValue() )
                    ? Notifications
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the pay period.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetPayPeriod()
        {
            try
            {
                return string.IsNullOrEmpty( PayPeriod.GetValue() )
                    ? PayPeriod
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}
