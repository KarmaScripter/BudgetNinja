// <copyright file = "PayrollHours.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref = "PayrollBase"/>
    /// <seealso cref = "ISource"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Global" ) ]
    public class PayrollHours : PayrollBase, ISource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref = "PayrollHours"/> class.
        /// </summary>
        public PayrollHours()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "PayrollHours"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public PayrollHours( IQuery query )
        {
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.PayrollHoursId );
            RpioCode = new Element( Record, Field.RpioCode );
            PayPeriod = new Element( Record, Field.PayPeriod );
            EmployeeNumber = new Element( Record, Field.EmployeeNumber );
            FirstName = new Element( Record, Field.FirstName );
            LastName = new Element( Record, Field.LastName );
            HrOrgCode = new Element( Record, Field.HumanResourceOrganizationCode );
            HrOrgName = new Element( Record, Field.HumanResourceOrganizationName );
            ReportingCode = new Element( Record, Field.ReportingCode );
            ReportingCodeName = new Element( Record, Field.ReportingCodeName );
            WorkCode = new Element( Record, Field.WorkCode );
            CalendarDate = new Time( Record, EventDate.CalendarDate );
            StartDate = new Time( Record, EventDate.StartDate );
            EndDate = new Time( Record, EventDate.EndDate );
            Hours = new Amount( Record, Numeric.Hours );
            Args = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "PayrollHours"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public PayrollHours( IBuilder builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.PayrollHoursId );
            RpioCode = new Element( Record, Field.RpioCode );
            PayPeriod = new Element( Record, Field.PayPeriod );
            EmployeeNumber = new Element( Record, Field.EmployeeNumber );
            FirstName = new Element( Record, Field.FirstName );
            LastName = new Element( Record, Field.LastName );
            HrOrgCode = new Element( Record, Field.HumanResourceOrganizationCode );
            HrOrgName = new Element( Record, Field.HumanResourceOrganizationName );
            ReportingCode = new Element( Record, Field.ReportingCode );
            ReportingCodeName = new Element( Record, Field.ReportingCodeName );
            WorkCode = new Element( Record, Field.WorkCode );
            CalendarDate = new Time( Record, EventDate.CalendarDate );
            StartDate = new Time( Record, EventDate.StartDate );
            EndDate = new Time( Record, EventDate.EndDate );
            Hours = new Amount( Record, Numeric.Hours );
            Args = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "PayrollHours"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The datarow.
        /// </param>
        public PayrollHours( DataRow datarow )
            : this()
        {
            Record = datarow;
            ID = new Key( Record, PrimaryKey.PayrollHoursId );
            RpioCode = new Element( Record, Field.RpioCode );
            PayPeriod = new Element( Record, Field.PayPeriod );
            EmployeeNumber = new Element( Record, Field.EmployeeNumber );
            FirstName = new Element( Record, Field.FirstName );
            LastName = new Element( Record, Field.LastName );
            HrOrgCode = new Element( Record, Field.HumanResourceOrganizationCode );
            HrOrgName = new Element( Record, Field.HumanResourceOrganizationName );
            ReportingCode = new Element( Record, Field.ReportingCode );
            ReportingCodeName = new Element( Record, Field.ReportingCodeName );
            WorkCode = new Element( Record, Field.WorkCode );
            CalendarDate = new Time( Record, EventDate.CalendarDate );
            StartDate = new Time( Record, EventDate.StartDate );
            EndDate = new Time( Record, EventDate.EndDate );
            Hours = new Amount( Record, Numeric.Hours );
            Args = Record?.ToDictionary();
        }
        
        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private protected readonly Source _source = Source.PayrollHours;
        
        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <returns>
        /// </returns>
        public Source GetSource()
        {
            try
            {
                return Validate.Source( _source )
                    ? _source
                    : Source.NS;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Source.NS;
            }
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        public new IDictionary<string, object> ToDictionary()
        {
            try
            {
                return Verify.Map( Args )
                    ? Args
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }

        /// <summary>
        /// Gets the payroll hours identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IKey GetId()
        {
            try
            {
                return Verify.Key( ID )
                    ? ID
                    : Key.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Key.Default;
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
                return Verify.Input( RpioCode?.GetValue() )
                    ? RpioCode
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
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
                return Verify.Input( PayPeriod?.GetValue() )
                    ? PayPeriod
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
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
                return Verify.Time( CalendarDate )
                    ? CalendarDate
                    : Time.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Time.Default;
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
                return Verify.Time( StartDate )
                    ? StartDate
                    : Time.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Time.Default;
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
                return Verify.Time( EndDate )
                    ? EndDate
                    : Time.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Time.Default;
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
                return Verify.Element( HrOrgCode )
                    ? HrOrgCode
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
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
                return Verify.Element( HrOrgName )
                    ? HrOrgName
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
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
                return Verify.Element( WorkCode )
                    ? WorkCode
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
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
                return Verify.Element( ReportingCode )
                    ? ReportingCode
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
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
                return Verify.Element( ReportingCodeName )
                    ? ReportingCodeName
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
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
                return Hours?.GetFunding() > -1.0
                    ? Hours
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <param name = "firstname" >
        /// The firstname.
        /// </param>
        /// <param name = "lastname" >
        /// The lastname.
        /// </param>
        /// <returns>
        /// </returns>
        private IDictionary<string, object> GetArgs( string firstname, string lastname )
        {
            if( Record.ToDictionary() != null
                && Verify.Input( firstname )
                && Verify.Input( lastname ) )
            {
                try
                {
                    var dict = new Dictionary<string, object>
                    {
                        [ Field.FirstName.ToString() ] = firstname,
                        [ Field.LastName.ToString() ] = lastname
                    };

                    return dict.Any()
                        ? dict
                        : default( Dictionary<string, object> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <param name = "employee" >
        /// The employee.
        /// </param>
        /// <returns>
        /// </returns>
        private IDictionary<string, object> GetArgs( IPerson employee )
        {
            if( Verify.Input( employee?.GetFirstName()?.GetValue() )
                && Verify.Input( employee?.GetLastName()?.GetValue() ) )
            {
                try
                {
                    var _dictionary = new Dictionary<string, object>
                    {
                        [ Field.FirstName.ToString() ] = employee?.GetFirstName(),
                        [ Field.LastName.ToString() ] = employee?.GetLastName()
                    };

                    return _dictionary.Any()
                        ? _dictionary
                        : default( Dictionary<string, object> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }
    }
}
