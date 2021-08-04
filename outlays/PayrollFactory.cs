// <copyright file = "PayrollFactory.cs" company = "Terry D. Eppler">
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
    /// <seealso cref = "PayrollBase"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassNeverInstantiated.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class PayrollFactory : PayrollHours
    {
        /// <summary>
        /// The payroll
        /// </summary>
        private readonly IPayrollBase _payroll;
        
        /// <summary>
        /// Initializes a new instance of the <see cref = "PayrollFactory"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public PayrollFactory( IQuery query )
        {
            _payroll = new PayrollHours( query );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "PayrollFactory"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public PayrollFactory( IBuilder builder )
        {
            _payroll = new PayrollHours( builder );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "PayrollFactory"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public PayrollFactory( DataRow data )
        {
            _payroll = new PayrollHours( data );
        }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the payroll hours identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IKey GetId()
        {
            try
            {
                return _payroll?.GetId();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IKey );
            }
        }

        /// <summary>
        /// Gets the resource planning office code.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IElement GetRpioCode()
        {
            try
            {
                return _payroll?.GetRpioCode();
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
        public override IElement GetPayPeriod()
        {
            try
            {
                return _payroll?.GetPayPeriod();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the calendar date.
        /// </summary>
        /// <returns>
        /// </returns>
        public override ITime GetCalendarDate()
        {
            try
            {
                return _payroll.GetCalendarDate();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
            }
        }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <returns>
        /// </returns>
        public override ITime GetStartDate()
        {
            try
            {
                return _payroll.GetStartDate();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
            }
        }

        /// <summary>
        /// Gets the end date.
        /// </summary>
        /// <returns>
        /// </returns>
        public override ITime GetEndDate()
        {
            try
            {
                return _payroll.GetEndDate();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( ITime );
            }
        }

        /// <summary>
        /// Gets the employee number.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IElement GetEmployeeNumber()
        {
            try
            {
                return _payroll?.GetEmployeeNumber();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the human resource organization code.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IElement GetHrOrgCode()
        {
            try
            {
                return _payroll?.GetHrOrgCode();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the name of the Human Resource Organization.
        /// </summary>
        /// <returns>
        /// string
        /// </returns>
        public override IElement GetHrOrgName()
        {
            try
            {
                return _payroll?.GetHrOrgName();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the work code.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IElement GetWorkCode()
        {
            try
            {
                return _payroll?.GetWorkCode();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the reporting code.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IElement GetReportingCode()
        {
            try
            {
                return _payroll?.GetReportingCode();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the reporting code description.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IElement GetReportingCodeName()
        {
            try
            {
                return _payroll?.GetReportingCodeName();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IElement );
            }
        }

        /// <summary>
        /// Gets the hours.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IAmount GetHours()
        {
            try
            {
                return _payroll?.GetHours();
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }
    }
}
