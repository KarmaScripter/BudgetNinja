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
            _record = new DataBuilder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.PayrollHoursId );
            _rpioCode = new Element( _record, Field.RpioCode );
            _payPeriod = new Element( _record, Field.PayPeriod );
            _employeeNumber = new Element( _record, Field.EmployeeNumber );
            _firstName = new Element( _record, Field.FirstName );
            _lastName = new Element( _record, Field.LastName );
            _humanResourceOrganizationCode = new Element( _record, Field.HumanResourceOrganizationCode );
            _humanResourceOrganizationName = new Element( _record, Field.HumanResourceOrganizationName );
            _reportingCode = new Element( _record, Field.ReportingCode );
            _reportingCodeName = new Element( _record, Field.ReportingCodeName );
            _workCode = new Element( _record, Field.WorkCode );
            _calendarDate = new Time( _record, EventDate.CalendarDate );
            _startDate = new Time( _record, EventDate.StartDate );
            _endDate = new Time( _record, EventDate.EndDate );
            _hours = new Amount( _record, Numeric.Hours );
            _args = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "PayrollHours"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public PayrollHours( IBuilder builder )
        {
            _record = builder?.GetRecord();
            _id = new Key( _record, PrimaryKey.PayrollHoursId );
            _rpioCode = new Element( _record, Field.RpioCode );
            _payPeriod = new Element( _record, Field.PayPeriod );
            _employeeNumber = new Element( _record, Field.EmployeeNumber );
            _firstName = new Element( _record, Field.FirstName );
            _lastName = new Element( _record, Field.LastName );
            _humanResourceOrganizationCode = new Element( _record, Field.HumanResourceOrganizationCode );
            _humanResourceOrganizationName = new Element( _record, Field.HumanResourceOrganizationName );
            _reportingCode = new Element( _record, Field.ReportingCode );
            _reportingCodeName = new Element( _record, Field.ReportingCodeName );
            _workCode = new Element( _record, Field.WorkCode );
            _calendarDate = new Time( _record, EventDate.CalendarDate );
            _startDate = new Time( _record, EventDate.StartDate );
            _endDate = new Time( _record, EventDate.EndDate );
            _hours = new Amount( _record, Numeric.Hours );
            _args = _record?.ToDictionary();
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
            _record = datarow;
            _id = new Key( _record, PrimaryKey.PayrollHoursId );
            _rpioCode = new Element( _record, Field.RpioCode );
            _payPeriod = new Element( _record, Field.PayPeriod );
            _employeeNumber = new Element( _record, Field.EmployeeNumber );
            _firstName = new Element( _record, Field.FirstName );
            _lastName = new Element( _record, Field.LastName );
            _humanResourceOrganizationCode = new Element( _record, Field.HumanResourceOrganizationCode );
            _humanResourceOrganizationName = new Element( _record, Field.HumanResourceOrganizationName );
            _reportingCode = new Element( _record, Field.ReportingCode );
            _reportingCodeName = new Element( _record, Field.ReportingCodeName );
            _workCode = new Element( _record, Field.WorkCode );
            _calendarDate = new Time( _record, EventDate.CalendarDate );
            _startDate = new Time( _record, EventDate.StartDate );
            _endDate = new Time( _record, EventDate.EndDate );
            _hours = new Amount( _record, Numeric.Hours );
            _args = _record?.ToDictionary();
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
                return Verify.Map( _args )
                    ? _args
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
                return Verify.Key( _id )
                    ? _id
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
                return Verify.Input( _rpioCode?.GetValue() )
                    ? _rpioCode
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
                return Verify.Input( _payPeriod?.GetValue() )
                    ? _payPeriod
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
                return Verify.Time( _calendarDate )
                    ? _calendarDate
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
                return Verify.Time( _startDate )
                    ? _startDate
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
                return Verify.Time( _endDate )
                    ? _endDate
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
                return Verify.Element( _humanResourceOrganizationCode )
                    ? _humanResourceOrganizationCode
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
                return Verify.Element( _humanResourceOrganizationName )
                    ? _humanResourceOrganizationName
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
                return Verify.Element( _workCode )
                    ? _workCode
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
                return Verify.Element( _reportingCode )
                    ? _reportingCode
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
                return Verify.Element( _reportingCodeName )
                    ? _reportingCodeName
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
                return _hours?.GetFunding() > -1.0
                    ? _hours
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
            if( _record.ToDictionary() != null
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
