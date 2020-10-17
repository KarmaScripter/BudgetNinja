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
    using System.Threading;

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
            Record = new Builder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.LeaveProjectionId );
            RpioCode = new Element( Record, Field.RpioCode );
            EmployeeNumber = new Element( Record, Field.EmployeeNumber );
            FirstName = new Element( Record, Field.FirstName );
            LastName = new Element( Record, Field.LastName );
            HumanResourceOrganizationCode = new Element( Record, Field.HumanResourceOrganizationCode );
            HumanResourceOrganizationName = new Element( Record, Field.HumanResourceOrganizationName );
            WorkCode = new Element( Record, Field.WorkCode );
            YearToDateEarned = new Amount( Record, Numeric.YearToDateEarned );
            YearToDateUsed = new Amount( Record, Numeric.YearToDateUsed );
            MaxLeaveCarryover = new Amount( Record, Numeric.MaxLeaveCarryover );
            ProjectedPayPeriod = new Amount( Record, Numeric.ProjectedPayPeriod );
            ProjectedAnnual = new Amount( Record, Numeric.ProjectedAnnual );
            UseOrLose = new Amount( Record, Numeric.UseOrLose );
            AvailableHours = new Amount( Record, Numeric.AvailableHours );
            Args = Record.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Leave"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The builder.
        /// </param>
        public Leave( IBuilder builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.LeaveProjectionId );
            RpioCode = new Element( Record, Field.RpioCode );
            EmployeeNumber = new Element( Record, Field.EmployeeNumber );
            FirstName = new Element( Record, Field.FirstName );
            LastName = new Element( Record, Field.LastName );
            HumanResourceOrganizationCode = new Element( Record, Field.HumanResourceOrganizationCode );
            HumanResourceOrganizationName = new Element( Record, Field.HumanResourceOrganizationName );
            WorkCode = new Element( Record, Field.WorkCode );
            YearToDateEarned = new Amount( Record, Numeric.YearToDateEarned );
            YearToDateUsed = new Amount( Record, Numeric.YearToDateUsed );
            MaxLeaveCarryover = new Amount( Record, Numeric.MaxLeaveCarryover );
            ProjectedPayPeriod = new Amount( Record, Numeric.ProjectedPayPeriod );
            ProjectedAnnual = new Amount( Record, Numeric.ProjectedAnnual );
            UseOrLose = new Amount( Record, Numeric.UseOrLose );
            AvailableHours = new Amount( Record, Numeric.AvailableHours );
            Args = Record.ToDictionary();
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
            Record = datarow;
            ID = new Key( Record, PrimaryKey.LeaveProjectionId );
            RpioCode = new Element( Record, Field.RpioCode );
            EmployeeNumber = new Element( Record, Field.EmployeeNumber );
            FirstName = new Element( Record, Field.FirstName );
            LastName = new Element( Record, Field.LastName );
            HumanResourceOrganizationCode = new Element( Record, Field.HumanResourceOrganizationCode );
            HumanResourceOrganizationName = new Element( Record, Field.HumanResourceOrganizationName );
            WorkCode = new Element( Record, Field.WorkCode );
            YearToDateEarned = new Amount( Record, Numeric.YearToDateEarned );
            YearToDateUsed = new Amount( Record, Numeric.YearToDateUsed );
            MaxLeaveCarryover = new Amount( Record, Numeric.MaxLeaveCarryover );
            ProjectedPayPeriod = new Amount( Record, Numeric.ProjectedPayPeriod );
            ProjectedAnnual = new Amount( Record, Numeric.ProjectedAnnual );
            UseOrLose = new Amount( Record, Numeric.UseOrLose );
            AvailableHours = new Amount( Record, Numeric.AvailableHours );
            Args = Record.ToDictionary();
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
                return YearToDateEarned?.GetFunding() > -1.0
                    ? YearToDateEarned
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return YearToDateUsed?.GetFunding() > -1.0
                    ? YearToDateUsed
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return MaxLeaveCarryover?.GetFunding() > -1.0
                    ? MaxLeaveCarryover
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return ProjectedPayPeriod?.GetFunding() > -1.0
                    ? ProjectedPayPeriod
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return ProjectedAnnual?.GetFunding() > -1.0D
                    ? ProjectedAnnual
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
                return AvailableHours?.GetFunding() > -1.0
                    ? AvailableHours
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }

        public IAmount GetAnnualHours()
        {
            try
            {
                return AnnualHours?.GetFunding() > -1.0
                    ? AnnualHours
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
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
            if( Verify.Input( HumanResourceOrganizationCode?.GetValue() ) )
            {
                try
                {
                    var args = new Dictionary<string, object>
                    {
                        [ $"{Field.HumanResourceOrganizationCode}" ] =
                            HumanResourceOrganizationCode?.GetValue()
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

            return default;
        }

        /// <summary>
        /// The GetWorkCode.
        /// </summary>
        /// <returns>
        /// The <see cref = "IWorkCode"/> .
        /// </returns>
        public IWorkCode GetWorkCode()
        {
            if( Verify.Input( WorkCode?.GetValue() ) )
            {
                try
                {
                    var args = new Dictionary<string, object>
                    {
                        [ $"{Field.WorkCode}" ] = WorkCode?.GetValue()
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

            return default;
        }

        /// <summary>
        /// The GetResourcePlanningOfficeCode.
        /// </summary>
        /// <returns>
        /// The <see cref = "string"/> .
        /// </returns>
        public IElement GetRpioCode()
        {
            if( Verify.Input( RpioCode?.GetValue() ) )
            {
                try
                {
                    return Verify.Input( RpioCode?.GetValue() )
                        ? RpioCode
                        : default;
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
        /// The GetResourcePlanningOffice.
        /// </summary>
        /// <returns>
        /// .
        /// </returns>
        public IResourcePlanningOffice GetResourcePlanningOffice()
        {
            if( Verify.Input( RpioCode?.GetValue() ) )
            {
                try
                {
                    var dict = new Dictionary<string, object>
                    {
                        [ $"{Field.RpioCode}" ] = RpioCode?.GetValue()
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
                    return default;
                }
            }

            return default;
        }
    }
}
