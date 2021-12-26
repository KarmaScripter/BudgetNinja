// <copyright file = "WorkCodeBase.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "IPayrollCostData"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public abstract class WorkCodeBase
    {
        /// <summary>
        /// Gets the Data.
        /// </summary>
        /// <value>
        /// The Data.
        /// </value>
        public DataRow Record { get; set; }

        /// <summary>
        /// Gets or sets the work code identifier.
        /// </summary>
        /// <value>
        /// The work code identifier.
        /// </value>
        public IKey ID { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public IElement Code { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public IElement Name { get; set; }

        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        /// <value>
        /// The short name.
        /// </value>
        public IElement ShortName { get; set; }

        /// <summary>
        /// Gets or sets the notifications.
        /// </summary>
        /// <value>
        /// The notifications.
        /// </value>
        public IElement Notification { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public IElement Status { get; set; }

        /// <summary>
        /// Gets or sets the pay period.
        /// </summary>
        /// <value>
        /// The pay period.
        /// </value>
        public IElement PayPeriod { get; set; }

        /// <summary>
        /// Gets or sets the bbfy.
        /// </summary>
        /// <value>
        /// The bbfy.
        /// </value>
        public IElement BFY { get; set; }

        /// <summary>
        /// Gets or sets the fund code.
        /// </summary>
        /// <value>
        /// The fund code.
        /// </value>
        public IElement FundCode { get; set; }

        /// <summary>
        /// Gets or sets the foc code.
        /// </summary>
        /// <value>
        /// The foc code.
        /// </value>
        public IElement FocCode { get; set; }

        /// <summary>
        /// Gets or sets the approval date.
        /// </summary>
        /// <value>
        /// The approval date.
        /// </value>
        public DateTime ApprovalDate { get; set; }

        /// <summary>
        /// Gets or sets the cost org code.
        /// </summary>
        /// <value>
        /// The cost org code.
        /// </value>
        public IElement CostOrgCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the cost org.
        /// </summary>
        /// <value>
        /// The name of the cost org.
        /// </value>
        public IElement CostOrgName { get; set; }

        /// <summary>
        /// Gets or sets the rc code.
        /// </summary>
        /// <value>
        /// The rc code.
        /// </value>
        public IElement RcCode { get; set; }

        /// <summary>
        /// Gets or sets the account code.
        /// </summary>
        /// <value>
        /// The account code.
        /// </value>
        public IElement AccountCode { get; set; }

        /// <summary>
        /// Gets or sets the project code.
        /// </summary>
        /// <value>
        /// The project code.
        /// </value>
        public IElement ProjectCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the project code.
        /// </summary>
        /// <value>
        /// The name of the project code.
        /// </value>
        public IElement ProjectCodeName { get; set; }
        
        /// <summary>
        /// Gets the approval date.
        /// </summary>
        /// <returns>
        /// </returns>
        public DateTime GetApprovalDate()
        {
            try
            {
                return ApprovalDate != default( DateTime )
                    ? ApprovalDate
                    : default( DateTime );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DateTime );
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
                    return default( IElement );
                }
            }

            return default( IElement );
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
                    return default( IElement );
                }
            }

            return default( IElement );
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
                var _element = ( (IProgramElement)this ).GetCode();

                return Verify.Input( _element.GetValue() )
                    ? _element
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                return string.IsNullOrEmpty( Notification.GetValue() )
                    ? Notification
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
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
                    : default( IElement );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText( ex.Message );
            _error?.ShowDialog();
        }
    }
}
