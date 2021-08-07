// <copyright file = "Leave.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines the leave projected for an EPA Employee. An employee may use annual
    /// leave for vacations, rest and relaxation, and personal business or emergencies.
    /// An employee has a right to take annual leave, subject to the right of the
    /// supervisor to schedule the time at which annual leave may be taken. An employee
    /// will receive a lump-sum payment for accumulated and accrued annual leave when
    /// he or she separates from Federal service or enters on active duty in the Armed
    /// Forces and elects to receive a lump-sum payment.
    /// <see cref = "Leave"/>
    /// </summary>
    /// <seealso cref = "LeaveBase"/>
    [ Guid( "964EBEAA-AE6B-4360-9504-AF4175F1F99E" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class Leave : LeaveBase, ILeave
    {
        // ***************************************************************************************************************************
        // ****************************************************  CONSTRUCTORS ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "Leave"/> class.
        /// </summary>
        public Leave()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Leave"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Leave( IQuery query )
        {
            _records = new Builder( query )?.GetRecord();
            _id = new Key( _records, PrimaryKey.LeaveProjectionId );
            _rpioCode = new Element( _records, Field.RpioCode );
            _employeeNumber = new Element( _records, Field.EmployeeNumber );
            _firstName = new Element( _records, Field.FirstName );
            _lastName = new Element( _records, Field.LastName );
            _humanResourceOrganizationCode = new Element( _records, Field.HumanResourceOrganizationCode );
            _humanResourceOrganizationName = new Element( _records, Field.HumanResourceOrganizationName );
            _workCode = new Element( _records, Field.WorkCode );
            _yearToDateEarned = new Amount( _records, Numeric.YearToDateEarned );
            _yearToDateUsed = new Amount( _records, Numeric.YearToDateUsed );
            _maxLeaveCarryover = new Amount( _records, Numeric.MaxLeaveCarryover );
            _projectedPayPeriod = new Amount( _records, Numeric.ProjectedPayPeriod );
            _projectedAnnual = new Amount( _records, Numeric.ProjectedAnnual );
            UseOrLose = new Amount( _records, Numeric.UseOrLose );
            _availableHours = new Amount( _records, Numeric.AvailableHours );
            _args = _records.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Leave"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public Leave( IBuilder builder )
        {
            _records = builder?.GetRecord();
            _id = new Key( _records, PrimaryKey.LeaveProjectionId );
            _rpioCode = new Element( _records, Field.RpioCode );
            _employeeNumber = new Element( _records, Field.EmployeeNumber );
            _firstName = new Element( _records, Field.FirstName );
            _lastName = new Element( _records, Field.LastName );
            _humanResourceOrganizationCode = new Element( _records, Field.HumanResourceOrganizationCode );
            _humanResourceOrganizationName = new Element( _records, Field.HumanResourceOrganizationName );
            _workCode = new Element( _records, Field.WorkCode );
            _yearToDateEarned = new Amount( _records, Numeric.YearToDateEarned );
            _yearToDateUsed = new Amount( _records, Numeric.YearToDateUsed );
            _maxLeaveCarryover = new Amount( _records, Numeric.MaxLeaveCarryover );
            _projectedPayPeriod = new Amount( _records, Numeric.ProjectedPayPeriod );
            _projectedAnnual = new Amount( _records, Numeric.ProjectedAnnual );
            UseOrLose = new Amount( _records, Numeric.UseOrLose );
            _availableHours = new Amount( _records, Numeric.AvailableHours );
            _args = _records.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Leave"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The datarow <see cref = "DataRow"/>
        /// </param>
        public Leave( DataRow datarow )
            : this()
        {
            _records = datarow;
            _id = new Key( _records, PrimaryKey.LeaveProjectionId );
            _rpioCode = new Element( _records, Field.RpioCode );
            _employeeNumber = new Element( _records, Field.EmployeeNumber );
            _firstName = new Element( _records, Field.FirstName );
            _lastName = new Element( _records, Field.LastName );
            _humanResourceOrganizationCode = new Element( _records, Field.HumanResourceOrganizationCode );
            _humanResourceOrganizationName = new Element( _records, Field.HumanResourceOrganizationName );
            _workCode = new Element( _records, Field.WorkCode );
            _yearToDateEarned = new Amount( _records, Numeric.YearToDateEarned );
            _yearToDateUsed = new Amount( _records, Numeric.YearToDateUsed );
            _maxLeaveCarryover = new Amount( _records, Numeric.MaxLeaveCarryover );
            _projectedPayPeriod = new Amount( _records, Numeric.ProjectedPayPeriod );
            _projectedAnnual = new Amount( _records, Numeric.ProjectedAnnual );
            UseOrLose = new Amount( _records, Numeric.UseOrLose );
            _availableHours = new Amount( _records, Numeric.AvailableHours );
            _args = _records.ToDictionary();
        }

        // ***************************************************************************************************************************
        // ****************************************************     METHODS   ********************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// The GetYearToDateEarned.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        public IAmount GetYearToDateEarned()
        {
            try
            {
                return _yearToDateEarned?.GetFunding() > -1.0
                    ? _yearToDateEarned
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// The GetYearToDateUsed.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        public IAmount GetYearToDateUsed()
        {
            try
            {
                return _yearToDateUsed?.GetFunding() > -1.0
                    ? _yearToDateUsed
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// The GetMaxLeaveCarryover.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        public IAmount GetMaxLeaveCarryover()
        {
            try
            {
                return _maxLeaveCarryover?.GetFunding() > -1.0
                    ? _maxLeaveCarryover
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// The GetUseOrLose.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        public IAmount GetUseOrLose()
        {
            try
            {
                return UseOrLose?.GetFunding() > -1.0
                    ? UseOrLose
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// The GetProjectedPayPeriod.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        public IAmount GetProjectedPayPeriod()
        {
            try
            {
                return _projectedPayPeriod?.GetFunding() > -1.0
                    ? _projectedPayPeriod
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// The GetProjectedAnnual.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        public IAmount GetProjectedAnnual()
        {
            try
            {
                return _projectedAnnual?.GetFunding() > -1.0D
                    ? _projectedAnnual
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// The GetAnnualHours.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        public IAmount GetAvailableHours()
        {
            try
            {
                return _availableHours?.GetFunding() > -1.0
                    ? _availableHours
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// Annual Vacation Hours as an IAmount object
        /// </returns>
        public IAmount GetAnnualHours()
        {
            try
            {
                return _annualHours?.GetFunding() > -1.0
                    ? _annualHours
                    : default( IAmount );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IAmount );
            }
        }

        /// <summary>
        /// The GetHumanResourceOrganization.
        /// </summary>
        /// <returns>
        /// The <see cref = "IHumanResourceOrganization"/> .
        /// </returns>
        public IHumanResourceOrganization GetHumanResourceOrganization()
        {
            if( Verify.Input( _humanResourceOrganizationCode?.GetValue() ) )
            {
                try
                {
                    var args = new Dictionary<string, object>
                    {
                        [ $"{Field.HumanResourceOrganizationCode}" ] =
                            _humanResourceOrganizationCode?.GetValue()
                    };

                    var connection = new ConnectionBuilder( Source.HumanResourceOrganizations,
                        Provider.SQLite );

                    var sqlstatement = new SqlStatement( connection, args, SQL.SELECT );
                    using var query = new Query( connection, sqlstatement );
                    return new HumanResourceOrganization( query );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }

            return default( IHumanResourceOrganization );
        }

        /// <summary>
        /// The GetWorkCode.
        /// </summary>
        /// <returns>
        /// The <see cref = "IWorkCode"/> .
        /// </returns>
        public IWorkCode GetWorkCode()
        {
            if( Verify.Input( _workCode?.GetValue() ) )
            {
                try
                {
                    var args = new Dictionary<string, object>
                    {
                        [ $"{Field.WorkCode}" ] = _workCode?.GetValue()
                    };

                    var connection = new ConnectionBuilder( Source.WorkCodes, Provider.SQLite );
                    var sqlstatement = new SqlStatement( connection, args, SQL.SELECT );
                    using var query = new Query( connection, sqlstatement );
                    return new WorkCode( query );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }

            return default( IWorkCode );
        }

        /// <summary>
        /// The GetResourcePlanningOfficeCode.
        /// </summary>
        /// <returns>
        /// The <see cref = "string"/> .
        /// </returns>
        public IElement GetRpioCode()
        {
            if( Verify.Input( _rpioCode?.GetValue() ) )
            {
                try
                {
                    return Verify.Input( _rpioCode?.GetValue() )
                        ? _rpioCode
                        : default( IElement );
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
        /// The GetResourcePlanningOffice.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        public IResourcePlanningOffice GetResourcePlanningOffice()
        {
            if( Verify.Input( _rpioCode?.GetValue() ) )
            {
                try
                {
                    var dict = new Dictionary<string, object>
                    {
                        [ $"{Field.RpioCode}" ] = _rpioCode?.GetValue()
                    };

                    var connectbuilder =
                        new ConnectionBuilder( Source.ResourcePlanningOffices, Provider.SQLite );

                    var sqlstatement = new SqlStatement( connectbuilder, dict, SQL.SELECT );
                    using var query = new Query( connectbuilder, sqlstatement );
                    return new ResourcePlanningOffice( query );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IResourcePlanningOffice );
                }
            }

            return default( IResourcePlanningOffice );
        }
    }
}
