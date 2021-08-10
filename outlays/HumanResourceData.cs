// <copyright file = "HumanResourceData.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="EmploymentBase" />
    /// <seealso cref="IHumanResourceData" />
    /// <seealso cref="ISource" />
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Local" ) ]
    public class HumanResourceData : EmploymentBase, IHumanResourceData, ISource
    {
        /// <summary>
        /// The source
        /// </summary>
        private const Source _source = Source.WorkforceData;
        
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private readonly DataRow _records;

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private readonly IDictionary<string, object> _args;

        /// <summary>
        /// Gets the workforce data identifier.
        /// </summary>
        /// <value>
        /// The workforce data identifier.
        /// </value>
        private readonly IKey _id;

        /// <summary>
        /// Gets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        private readonly IElement _status;

        /// <summary>
        /// Gets the job title.
        /// </summary>
        /// <value>
        /// The job title.
        /// </value>
        private readonly IElement _jobTitle;

        /// <summary>
        /// Gets the occupational series.
        /// </summary>
        /// <value>
        /// The occupational series.
        /// </value>
        private readonly IElement _occupationalSeries;

        /// <summary>
        /// Gets the grade.
        /// </summary>
        /// <value>
        /// The grade.
        /// </value>
        private readonly IElement _grade;

        /// <summary>
        /// Gets the step.
        /// </summary>
        /// <value>
        /// The step.
        /// </value>
        private readonly IElement _step;

        /// <summary>
        /// Gets the compensation rate.
        /// </summary>
        /// <value>
        /// The compensation rate.
        /// </value>
        private readonly IAmount _compensationRate;

        /// <summary>
        /// Initializes a new instance of the <see cref = "HumanResourceData"/> class.
        /// </summary>
        public HumanResourceData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "HumanResourceData"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public HumanResourceData( IQuery query )
        {
            _records = new DataBuilder( query )?.GetRecord();
            _id = new Key( _records, PrimaryKey.WorkforceDataId );
            _employeeNumber = new Element( _records, Field.EmployeeNumber );
            _firstName = new Element( _records, Field.FirstName );
            _lastName = new Element( _records, Field.LastName );
            _status = new Element( _records, Field.Status );
            _jobTitle = new Element( _records, Field.JobTitle );
            _occupationalSeries = new Element( _records, Field.OccupationalSeries );
            _humanResourceOrganizationCode = new Element( _records, Field.HumanResourceOrganizationCode );
            _humanResourceOrganizationName = new Element( _records, Field.HumanResourceOrganizationName );
            _grade = new Element( _records, Field.Grade );
            _step = new Element( _records, Field.Step );
            _appointmentAuthority = new Element( _records, Field.AppointmentAuthority );
            _appointmentType = new Element( _records, Field.AppointmentType );
            _bargainingUnit = new Element( _records, Field.BargainingUnit );
            _retirementPlan = new Element( _records, Field.RetirementPlan );
            _hireDate = new Time( _records, EventDate.HireDate );
            _serviceDate = new Time( _records, EventDate.ServiceDate );
            _wigiDueDate = new Time( _records, EventDate.WigiDueDate );
            _gradeEntryDate = new Time( _records, EventDate.GradeEntryDate );
            _stepEntryDate = new Time( _records, EventDate.StepEntryDate );
            _compensationRate = new Amount( _records, Numeric.CompensationRate );
            _args = _records.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "HumanResourceData"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public HumanResourceData( IBuilder builder )
        {
            _records = builder?.GetRecord();
            _id = new Key( _records, PrimaryKey.WorkforceDataId );
            _employeeNumber = new Element( _records, Field.EmployeeNumber );
            _firstName = new Element( _records, Field.FirstName );
            _lastName = new Element( _records, Field.LastName );
            _status = new Element( _records, Field.Status );
            _jobTitle = new Element( _records, Field.JobTitle );
            _occupationalSeries = new Element( _records, Field.OccupationalSeries );
            _humanResourceOrganizationCode = new Element( _records, Field.HumanResourceOrganizationCode );
            _humanResourceOrganizationName = new Element( _records, Field.HumanResourceOrganizationName );
            _grade = new Element( _records, Field.Grade );
            _step = new Element( _records, Field.Step );
            _appointmentAuthority = new Element( _records, Field.AppointmentAuthority );
            _appointmentType = new Element( _records, Field.AppointmentType );
            _bargainingUnit = new Element( _records, Field.BargainingUnit );
            _retirementPlan = new Element( _records, Field.RetirementPlan );
            _hireDate = new Time( _records, EventDate.HireDate );
            _serviceDate = new Time( _records, EventDate.ServiceDate );
            _wigiDueDate = new Time( _records, EventDate.WigiDueDate );
            _gradeEntryDate = new Time( _records, EventDate.GradeEntryDate );
            _stepEntryDate = new Time( _records, EventDate.StepEntryDate );
            _compensationRate = new Amount( _records, Numeric.CompensationRate );
            _args = _records.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "HumanResourceData"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public HumanResourceData( DataRow data )
            : this()
        {
            _records = data;
            _id = new Key( _records, PrimaryKey.WorkforceDataId );
            _employeeNumber = new Element( _records, Field.EmployeeNumber );
            _firstName = new Element( _records, Field.FirstName );
            _lastName = new Element( _records, Field.LastName );
            _status = new Element( _records, Field.Status );
            _jobTitle = new Element( _records, Field.JobTitle );
            _occupationalSeries = new Element( _records, Field.OccupationalSeries );
            _humanResourceOrganizationCode = new Element( _records, Field.HumanResourceOrganizationCode );
            _humanResourceOrganizationName = new Element( _records, Field.HumanResourceOrganizationName );
            _grade = new Element( _records, Field.Grade );
            _step = new Element( _records, Field.Step );
            _appointmentAuthority = new Element( _records, Field.AppointmentAuthority );
            _appointmentType = new Element( _records, Field.AppointmentType );
            _bargainingUnit = new Element( _records, Field.BargainingUnit );
            _retirementPlan = new Element( _records, Field.RetirementPlan );
            _hireDate = new Time( _records, EventDate.HireDate );
            _serviceDate = new Time( _records, EventDate.ServiceDate );
            _wigiDueDate = new Time( _records, EventDate.WigiDueDate );
            _gradeEntryDate = new Time( _records, EventDate.GradeEntryDate );
            _stepEntryDate = new Time( _records, EventDate.StepEntryDate );
            _compensationRate = new Amount( _records, Numeric.CompensationRate );
            _args = _records.ToDictionary();
        }
        
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if( Verify.Element( _firstName )
                && Verify.Element( _lastName ) )
            {
                try
                {
                    return _firstName.GetValue() + " " + _lastName.GetValue();
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return string.Empty;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> ToDictionary()
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
        /// Gets the workforce data identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public IKey GetId()
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
        /// Gets the employee.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEmployee GetEmployee()
        {
            try
            {
                var args = new Dictionary<string, object>
                {
                    [ $"{Field.EmployeeNumber}" ] = _employeeNumber
                };

                var connection = new ConnectionBuilder( Source.Employees, Provider.SQLite );
                var sqlstatement = new SqlStatement( connection, args, SQL.SELECT );
                using var query = new Query( connection, sqlstatement );
                return new Employee( query );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( Employee );
            }
        }

        /// <summary>
        /// Gets the human resource organization.
        /// </summary>
        /// <returns>
        /// </returns>
        public IHumanResourceOrganization GetHumanResourceOrganization()
        {
            try
            {
                var _dictionary = new Dictionary<string, object>
                {
                    [ $"{Field.HumanResourceOrganizationCode}" ] = _humanResourceOrganizationCode
                };

                var _connection = new ConnectionBuilder( Source.HumanResourceOrganizations, Provider.SQLite );
                var _statement = new SqlStatement( _connection, _dictionary, SQL.SELECT );
                using var _query = new Query( _connection, _statement );
                return new HumanResourceOrganization( _query );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( HumanResourceOrganization );
            }
        }

        /// <summary>
        /// Gets the job title.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetJobTitle()
        {
            try
            {
                return Verify.Element( _jobTitle )
                    ? _jobTitle
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the occupational series.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetOccupationalSeries()
        {
            try
            {
                return Verify.Element( _occupationalSeries )
                    ? _occupationalSeries
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
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
                return Verify.Element( _status )
                    ? _status
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the grade.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetGrade()
        {
            try
            {
                return Verify.Element( _grade )
                    ? _grade
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the step.
        /// </summary>
        /// <returns>
        /// </returns>
        public IElement GetStep()
        {
            try
            {
                return Verify.Element( _step )
                    ? _step
                    : Element.Default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return Element.Default;
            }
        }

        /// <summary>
        /// Gets the compensation.
        /// </summary>
        /// <returns>
        /// </returns>
        public IAmount GetCompensation()
        {
            try
            {
                return _compensationRate.GetFunding() > -1.0
                    ? _compensationRate
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

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
                return default( Source );
            }
        }
    }
}
