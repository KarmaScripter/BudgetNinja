// // <copyright file = "ControlNumber.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

// ReSharper disable UnusedMember.Global

namespace BudgetExecution
{
    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    /// <summary>
    /// </summary>
    /// <seealso cref = "IDataBuilder"/>
    /// <seealso cref = "IControlNumber"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class ControlNumber : BudgetNumber, IControlNumber
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

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
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.ControlNumberId );
            RPIO = new Element( Record, Field.RpioCode );
            FundCode = new Element( Record, Field.FundCode );
            RcCode = new Element( Record, Field.RcCode );
            BFY = new Element( Record, Field.BFY );
            DivisionName = new Element( Record, Field.DivisionName );
            DateIssued = new Time( Record, Date.DateIssued );
            RegionControlNumber = new Element( Record, Field.RegionControlNumber );
            FundControlNumber = new Element( Record, Field.FundControlNumber );
            DivisionControlNumber = new Element( Record, Field.DivisionControlNumber );
            BudgetControlNumber = SetBudgetControlNumber();
            Args = Record?.ToDictionary();
        }

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref = "T:BudgetExecution.ControlNumber"/> class.
        /// </summary>
        public ControlNumber( IBuilder builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.ControlNumberId );
            RPIO = new Element( Record, Field.RpioCode );
            FundCode = new Element( Record, Field.FundCode );
            RcCode = new Element( Record, Field.RcCode );
            BFY = new Element( Record, Field.BFY );
            DivisionName = new Element( Record, Field.DivisionName );
            DateIssued = new Time( Record, Date.DateIssued );
            RegionControlNumber = new Element( Record, Field.RegionControlNumber );
            FundControlNumber = new Element( Record, Field.FundControlNumber );
            DivisionControlNumber = new Element( Record, Field.DivisionControlNumber );
            BudgetControlNumber = SetBudgetControlNumber();
            Args = Record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "ControlNumber"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The data.
        /// </param>
        public ControlNumber( DataRow datarow )
        {
            Record = datarow;
            ID = new Key( Record, PrimaryKey.ControlNumberId );
            RPIO = new Element( Record, Field.RpioCode );
            FundCode = new Element( Record, Field.FundCode );
            RcCode = new Element( Record, Field.RcCode );
            BFY = new Element( Record, Field.BFY );
            DivisionName = new Element( Record, Field.DivisionName );
            DateIssued = new Time( Record, Date.DateIssued );
            RegionControlNumber = new Element( Record, Field.RegionControlNumber );
            FundControlNumber = new Element( Record, Field.FundControlNumber );
            DivisionControlNumber = new Element( Record, Field.DivisionControlNumber );
            BudgetControlNumber = SetBudgetControlNumber();
            Args = datarow.ToDictionary();
        }

        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets the budget control number.
        /// </summary>
        /// <value>
        /// The budget control number.
        /// </value>
        private string BudgetControlNumber { get; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Sets the budget control number.
        /// </summary>
        /// <returns>
        /// </returns>
        private string SetBudgetControlNumber()
        {
            try
            {
                return
                    $@"{RPIO}-{BFY}-{BFY.GetValue().Substring( 2, 2 )}{FundCode}-{FundControlNumber.ToString().PadLeft( 3, '0' )}"
                    + $@"-{DivisionName}-{DivisionControlNumber.ToString().PadLeft( 3, '0' )}"
                    ?? string.Empty;
            }
            catch( Exception ex )
            {
                ControlNumber.Fail( ex );
                return default;
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
                return Verify.Input( BudgetControlNumber )
                    ? BudgetControlNumber
                    : default;
            }
            catch( Exception ex )
            {
                ControlNumber.Fail( ex );
                return default;
            }
        }

        /// <inheritdoc/>
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "T:System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if( Record != null )
            {
                try
                {
                    return BudgetControlNumber;
                }
                catch( Exception ex )
                {
                    ControlNumber.Fail( ex );
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
                return Verify.Key( ID )
                    ? ID
                    : default;
            }
            catch( Exception ex )
            {
                ControlNumber.Fail( ex );
                return default;
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
                return Verify.Input( BFY.GetValue() )
                    ? new BudgetFiscalYear( BFY.GetValue() )
                    : default;
            }
            catch( Exception ex )
            {
                ControlNumber.Fail( ex );
                return default;
            }
        }

        /// <summary>
        /// Gets the resource planning office code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IResourcePlanningOffice GetResourcePlanningOffice()
        {
            if( Verify.Input( RPIO.GetValue() ) )
            {
                try
                {
                    var args = new Dictionary<string, object>
                    {
                        [ $"{Field.RpioCode}" ] = RPIO.GetValue()
                    };

                    var connection = new ConnectionBuilder( Source.ResourcePlanningOffices, Provider.SQLite );
                    var sqlstatement = new SqlStatement( connection, args, SQL.SELECT );
                    using var query = new Query( connection, sqlstatement );

                    return query != null
                        ? new ResourcePlanningOffice( query )
                        : default;
                }
                catch( Exception ex )
                {
                    ControlNumber.Fail( ex );
                    return default;
                }
            }

            return default;
        }
    }
}
