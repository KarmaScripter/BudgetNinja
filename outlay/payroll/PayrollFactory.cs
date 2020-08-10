// // <copyright file = "PayrollFactory.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "PayrollBase"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassNeverInstantiated.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class PayrollFactory : PayrollHours
    {
        // ***************************************************************************************************************************
        // *********************************************    FIELDS      **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The payroll
        /// </summary>
        private readonly IPayrollBase Payroll;

        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "PayrollFactory"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public PayrollFactory( IQuery query )
        {
            Payroll = new PayrollHours( query );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "PayrollFactory"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public PayrollFactory( IBuilder builder )
        {
            Payroll = new PayrollHours( builder );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "PayrollFactory"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public PayrollFactory( DataRow data )
        {
            Payroll = new PayrollHours( data );
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
                return Payroll?.GetId();
            }
            catch( Exception ex )
            {
                PayrollFactory.Fail( ex );
                return default;
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
                return Payroll?.GetRpioCode();
            }
            catch( Exception ex )
            {
                PayrollFactory.Fail( ex );
                return default;
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
                return Payroll?.GetPayPeriod();
            }
            catch( Exception ex )
            {
                PayrollFactory.Fail( ex );
                return default;
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
                return Payroll.GetCalendarDate();
            }
            catch( Exception ex )
            {
                PayrollFactory.Fail( ex );
                return default;
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
                return Payroll.GetStartDate();
            }
            catch( Exception ex )
            {
                PayrollFactory.Fail( ex );
                return default;
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
                return Payroll.GetEndDate();
            }
            catch( Exception ex )
            {
                PayrollFactory.Fail( ex );
                return default;
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
                return Payroll?.GetEmployeeNumber();
            }
            catch( Exception ex )
            {
                PayrollFactory.Fail( ex );
                return default;
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
                return Payroll?.GetHrOrgCode();
            }
            catch( Exception ex )
            {
                PayrollFactory.Fail( ex );
                return default;
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
                return Payroll?.GetHrOrgName();
            }
            catch( Exception ex )
            {
                PayrollFactory.Fail( ex );
                return default;
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
                return Payroll?.GetWorkCode();
            }
            catch( Exception ex )
            {
                PayrollFactory.Fail( ex );
                return default;
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
                return Payroll?.GetReportingCode();
            }
            catch( Exception ex )
            {
                PayrollFactory.Fail( ex );
                return default;
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
                return Payroll?.GetReportingCodeName();
            }
            catch( Exception ex )
            {
                PayrollFactory.Fail( ex );
                return default;
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
                return Payroll?.GetHours();
            }
            catch( Exception ex )
            {
                PayrollFactory.Fail( ex );
                return default;
            }
        }
    }
}
