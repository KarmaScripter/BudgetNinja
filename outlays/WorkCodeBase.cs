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
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private protected DataRow _records;

        /// <summary>
        /// Gets or sets the work code identifier.
        /// </summary>
        /// <value>
        /// The work code identifier.
        /// </value>
        private protected IKey _id;

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        private protected IElement _code;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        private protected IElement _name;

        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        /// <value>
        /// The short name.
        /// </value>
        private protected IElement _shortName;

        /// <summary>
        /// Gets or sets the notifications.
        /// </summary>
        /// <value>
        /// The notifications.
        /// </value>
        private protected IElement _notifications;

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        private protected IElement _status;

        /// <summary>
        /// Gets or sets the pay period.
        /// </summary>
        /// <value>
        /// The pay period.
        /// </value>
        private protected IElement _payPeriod;

        /// <summary>
        /// Gets or sets the bbfy.
        /// </summary>
        /// <value>
        /// The bbfy.
        /// </value>
        private protected IElement _bbfy;

        /// <summary>
        /// Gets or sets the fund code.
        /// </summary>
        /// <value>
        /// The fund code.
        /// </value>
        private protected IElement _fundCode;

        /// <summary>
        /// Gets or sets the foc code.
        /// </summary>
        /// <value>
        /// The foc code.
        /// </value>
        private protected IElement _focCode;

        /// <summary>
        /// Gets or sets the approval date.
        /// </summary>
        /// <value>
        /// The approval date.
        /// </value>
        private protected DateTime _approvalDate;

        /// <summary>
        /// Gets or sets the cost org code.
        /// </summary>
        /// <value>
        /// The cost org code.
        /// </value>
        private protected IElement _costOrgCode;

        /// <summary>
        /// Gets or sets the name of the cost org.
        /// </summary>
        /// <value>
        /// The name of the cost org.
        /// </value>
        private protected IElement _costOrgName;

        /// <summary>
        /// Gets or sets the rc code.
        /// </summary>
        /// <value>
        /// The rc code.
        /// </value>
        private protected IElement _rcCode;

        /// <summary>
        /// Gets or sets the account code.
        /// </summary>
        /// <value>
        /// The account code.
        /// </value>
        private protected IElement _accountCode;

        /// <summary>
        /// Gets or sets the project code.
        /// </summary>
        /// <value>
        /// The project code.
        /// </value>
        private protected IElement _projectCode;

        /// <summary>
        /// Gets or sets the name of the project code.
        /// </summary>
        /// <value>
        /// The name of the project code.
        /// </value>
        private protected IElement _projectCodeName;
        
        /// <summary>
        /// Gets the approval date.
        /// </summary>
        /// <returns>
        /// </returns>
        public DateTime GetApprovalDate()
        {
            try
            {
                return _approvalDate != default( DateTime )
                    ? _approvalDate
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
            if( Verify.Input( _projectCode?.GetValue() ) )
            {
                try
                {
                    return _projectCode;
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
            if( Verify.Input( _projectCodeName?.GetValue() ) )
            {
                try
                {
                    return _projectCodeName;
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
                return Verify.Key( _id )
                    ? _id.GetIndex()
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
                return Verify.Input( _name.GetValue() )
                    ? _name
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
                return Verify.Input( _shortName.GetValue() )
                    ? _shortName
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
                return Verify.Input( _status.GetValue() )
                    ? _status
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
                return string.IsNullOrEmpty( _notifications.GetValue() )
                    ? _notifications
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
                return string.IsNullOrEmpty( _payPeriod.GetValue() )
                    ? _payPeriod
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
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}
