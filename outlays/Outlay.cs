// <copyright file = "Outlay.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The issuance of checks, disbursement of cash, or electronic transfer of funds
    /// made to liquidate a federal obligation. Outlays also occur when interest on the
    /// Treasury debt held by the public accrues and when the government issues bonds,
    /// notes, debentures, monetary credits, or other cash-equivalent instruments in
    /// order to liquidate obligations. Also, under credit reform, the credit subsidy
    /// cost is recorded as an outlay when a direct or guaranteed loan is disbursed. An
    /// outlay is not recorded for repayment of debt principal, disbursements to the
    /// public by federal credit programs for direct loan obligations and loan
    /// guarantee commitments made in fiscal year 1992 or later, disbursements from
    /// deposit funds, and refunds of receipts that result from overpayments. Outlays
    /// during a fiscal year may be for payment of obligations incurred in prior years
    /// (prior-year obligations) or in the same year. Outlays, therefore, flow in part
    /// from unexpended balances of prior-year budgetary resources and in part from
    /// budgetary resources provided for the year in which the money is spent. Outlays
    /// are stated both gross and net of offsetting collections. (See Offsetting
    /// Collections under Collections.) Total government outlays include outlays of off
    /// budget federal entities. (See also Expenditure; Expense.)
    /// </summary>
    /// <seealso cref = "IDataBuilder"/>
    /// <seealso cref = "IBudgetLevel"/>
    /// <seealso cref = "IProgramElement"/>
    /// <seealso cref = "IOutlay"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeProtected.Global" ) ]
    [ SuppressMessage( "ReSharper", "AssignNullToNotNullAttribute" ) ]
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToConstant.Global" ) ]
    public class Outlay : Cost
    {
        /// <summary>
        /// Gets or sets the authority data.
        /// </summary>
        /// <value>
        /// The authority data.
        /// </value>
        private protected CostAccount _prc;

        /// <summary>
        /// 
        /// </summary>
        private protected Source _source;

        /// <summary>
        /// Initializes a new instance of the <see cref = "Outlay"/> class.
        /// </summary>
        public Outlay()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Outlay"/> class.
        /// </summary>
        /// <param name = "query" >
        /// </param>
        public Outlay( IQuery query )
        {
            _records = new DataBuilder( query )?.GetRecord();
            _id = new Key( _records, PrimaryKey.OutlayId );
            _programProjectCode = new Element( _records, Field.ProgramProjectCode );
            _programAreaCode = new Element( _records, Field.ProgramAreaCode );
            Commitments = new Amount( _records, Numeric.Commitments );
            OpenCommitments = new Amount( _records, Numeric.OpenCommitments );
            Obligations = new Amount( _records, Numeric.Obligations );
            Deobligations = new Amount( _records, Numeric.Deobligations );
            ULO = new Amount( _records, Numeric.ULO );
            Balance = new Amount( _records, Numeric.Balance );
            _data = _records?.ToDictionary();
            Type = OutlayType.All;
            SetExpenseType( Type );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Outlay"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// </param>
        public Outlay( IBuilder builder )
        {
            _records = builder?.GetRecord();
            _id = new Key( _records, PrimaryKey.OutlayId );
            _programProjectCode = new Element( _records, Field.ProgramProjectCode );
            _programAreaCode = new Element( _records, Field.ProgramAreaCode );
            Commitments = new Amount( _records, Numeric.Commitments );
            OpenCommitments = new Amount( _records, Numeric.OpenCommitments );
            Obligations = new Amount( _records, Numeric.Obligations );
            Deobligations = new Amount( _records, Numeric.Deobligations );
            ULO = new Amount( _records, Numeric.ULO );
            Balance = new Amount( _records, Numeric.Balance );
            _data = _records?.ToDictionary();
            Type = OutlayType.All;
            SetExpenseType( Type );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Outlay"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dr.
        /// </param>
        public Outlay( DataRow dataRow )
        {
            _records = dataRow;
            _id = new Key( _records, PrimaryKey.OutlayId );
            _programProjectCode = new Element( _records, Field.ProgramProjectCode );
            _programAreaCode = new Element( _records, Field.ProgramAreaCode );
            Commitments = new Amount( _records, Numeric.Commitments );
            OpenCommitments = new Amount( _records, Numeric.OpenCommitments );
            Obligations = new Amount( _records, Numeric.Obligations );
            Deobligations = new Amount( _records, Numeric.Deobligations );
            ULO = new Amount( _records, Numeric.ULO );
            Balance = new Amount( _records, Numeric.Balance );
            _data = _records?.ToDictionary();
            Type = OutlayType.All;
            SetExpenseType( Type );
        }
        
        /// <summary>
        /// Gets the outlay identifier.
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
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "T:_system.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            try
            {
                return Verify.Input( _accountCode?.GetValue() )
                    ? _accountCode?.GetValue()
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the data builder.
        /// </summary>
        /// <returns>
        /// </returns>
        public IBuilder GetBuilder()
        {
            try
            {
                return Verify.Map( _data )
                    ? new Builder( _source, _data )
                    : default( Builder );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IBuilder );
            }
        }
    }
}
