// <copyright file = "ControlNumber.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

// ReSharper disable UnusedMember.Global

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// </summary>
    /// <seealso cref = "IDataBuilder"/>
    /// <seealso cref = "IControlNumber"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class ControlNumber : BudgetNumber, IControlNumber
    {
        /// <summary>
        /// Initializes a new instance of the <see cref = "ControlNumber"/> class.
        /// </summary>
        public ControlNumber()
        {
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "T:BudgetExecution.ControlNumber"/> class.
        /// </summary>
        public ControlNumber( IQuery query )
        {
            _record = new DataBuilder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.ControlNumberId );
            _rpio = new Element( _record, Field.RpioCode );
            _fundCode = new Element( _record, Field.FundCode );
            _rcCode = new Element( _record, Field.RcCode );
            _bfy = new Element( _record, Field.BFY );
            _divisionName = new Element( _record, Field.DivisionName );
            _dateIssued = new Time( _record, EventDate.DateIssued );
            _regionControlNumber = new Element( _record, Field.RegionControlNumber );
            _fundControlNumber = new Element( _record, Field.FundControlNumber );
            _divisionControlNumber = new Element( _record, Field.DivisionControlNumber );
            _budgetControlNumber = SetBudgetControlNumber();
            _args = _record?.ToDictionary();
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "T:BudgetExecution.ControlNumber"/> class.
        /// </summary>
        public ControlNumber( IBuilder builder )
        {
            _record = builder?.GetRecord();
            _id = new Key( _record, PrimaryKey.ControlNumberId );
            _rpio = new Element( _record, Field.RpioCode );
            _fundCode = new Element( _record, Field.FundCode );
            _rcCode = new Element( _record, Field.RcCode );
            _bfy = new Element( _record, Field.BFY );
            _divisionName = new Element( _record, Field.DivisionName );
            _dateIssued = new Time( _record, EventDate.DateIssued );
            _regionControlNumber = new Element( _record, Field.RegionControlNumber );
            _fundControlNumber = new Element( _record, Field.FundControlNumber );
            _divisionControlNumber = new Element( _record, Field.DivisionControlNumber );
            _budgetControlNumber = SetBudgetControlNumber();
            _args = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ControlNumber"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The data.
        /// </param>
        public ControlNumber( DataRow datarow )
        {
            _record = datarow;
            _id = new Key( _record, PrimaryKey.ControlNumberId );
            _rpio = new Element( _record, Field.RpioCode );
            _fundCode = new Element( _record, Field.FundCode );
            _rcCode = new Element( _record, Field.RcCode );
            _bfy = new Element( _record, Field.BFY );
            _divisionName = new Element( _record, Field.DivisionName );
            _dateIssued = new Time( _record, EventDate.DateIssued );
            _regionControlNumber = new Element( _record, Field.RegionControlNumber );
            _fundControlNumber = new Element( _record, Field.FundControlNumber );
            _divisionControlNumber = new Element( _record, Field.DivisionControlNumber );
            _budgetControlNumber = SetBudgetControlNumber();
            _args = datarow.ToDictionary();
        }

        /// <summary>
        /// Gets the budget control number.
        /// </summary>
        /// <value>
        /// The budget control number.
        /// </value>
        private readonly string _budgetControlNumber;
        
        /// <summary>
        /// Sets the budget control number.
        /// </summary>
        /// <returns>
        /// </returns>
        private string SetBudgetControlNumber()
        {
            try
            {
                var _year = _bfy?.GetValue()
                    ?.Substring( 2, 2 );

                var _fund = _fundControlNumber
                    ?.ToString()
                    ?.PadLeft( 3, '0' );

                var _division = _divisionControlNumber
                    ?.ToString()
                    ?.PadLeft( 3, '0' );

                return
                    $@"{_rpio}-{_bfy}-{_year}{_fundCode}-{_fund}"
                    + $@"-{_divisionName}-{_division}"
                    ?? string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>
        /// Gets the budget control number.
        /// </summary>
        /// <returns>
        /// </returns>
        public string GetBudgetControlNumber()
        {
            try
            {
                return Verify.Input( _budgetControlNumber )
                    ? _budgetControlNumber
                    : default( string );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <inheritdoc/>
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "T:_system.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if( _record != null )
            {
                try
                {
                    return _budgetControlNumber;
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
        /// Gets the control number identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public IKey GetId()
        {
            try
            {
                return Verify.Key( _id )
                    ? _id
                    : default( IKey );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IKey );
            }
        }

        /// <summary>
        /// Gets the budget fiscal year.
        /// </summary>
        /// <returns>
        /// </returns>
        public IBudgetFiscalYear GetBudgetFiscalYear()
        {
            try
            {
                return Verify.Input( _bfy.GetValue() )
                    ? new BudgetFiscalYear( _bfy.GetValue() )
                    : default( BudgetFiscalYear );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IBudgetFiscalYear );
            }
        }

        /// <summary>
        /// Gets the resource planning office code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IResourcePlanningOffice GetResourcePlanningOffice()
        {
            if( Verify.Input( _rpio.GetValue() ) )
            {
                try
                {
                    var _dictionary = new Dictionary<string, object>
                    {
                        [ $"{Field.RpioCode}" ] = _rpio.GetValue()
                    };

                    var _connection = new ConnectionBuilder( Source.ResourcePlanningOffices, Provider.SQLite );
                    var _statement = new SqlStatement( _connection, _dictionary, SQL.SELECT );
                    using var _query = new Query( _connection, _statement );

                    return _query != null
                        ? new ResourcePlanningOffice( _query )
                        : default( ResourcePlanningOffice );
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
