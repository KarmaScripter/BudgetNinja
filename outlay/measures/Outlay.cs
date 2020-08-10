// // <copyright file = "Outlay.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

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
    public class Outlay : CostBase
    {
        // ***************************************************************************************************************************
        // *********************************************   CONSTRUCTORS **************************************************************
        // ***************************************************************************************************************************

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
            Record = new DataBuilder( query )?.GetRecord();
            ID = new Key( Record, PrimaryKey.OutlayId );
            ProgramProjectCode = new Element( Record, Field.ProgramProjectCode );
            ProgramAreaCode = new Element( Record, Field.ProgramAreaCode );
            Commitments = new Amount( Record, Numeric.Commitments );
            OpenCommitments = new Amount( Record, Numeric.OpenCommitments );
            Obligations = new Amount( Record, Numeric.Obligations );
            Deobligations = new Amount( Record, Numeric.Deobligations );
            ULO = new Amount( Record, Numeric.ULO );
            Balance = new Amount( Record, Numeric.Balance );
            Data = Record?.ToDictionary();
            Type = ExpenseType.All;
            SetExpenseType( Type );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Outlay"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// </param>
        public Outlay( IBuilder builder )
        {
            Record = builder?.GetRecord();
            ID = new Key( Record, PrimaryKey.OutlayId );
            ProgramProjectCode = new Element( Record, Field.ProgramProjectCode );
            ProgramAreaCode = new Element( Record, Field.ProgramAreaCode );
            Commitments = new Amount( Record, Numeric.Commitments );
            OpenCommitments = new Amount( Record, Numeric.OpenCommitments );
            Obligations = new Amount( Record, Numeric.Obligations );
            Deobligations = new Amount( Record, Numeric.Deobligations );
            ULO = new Amount( Record, Numeric.ULO );
            Balance = new Amount( Record, Numeric.Balance );
            Data = Record?.ToDictionary();
            Type = ExpenseType.All;
            SetExpenseType( Type );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Outlay"/> class.
        /// </summary>
        /// <param name = "datarow" >
        /// The dr.
        /// </param>
        public Outlay( DataRow datarow )
        {
            Record = datarow;
            ID = new Key( Record, PrimaryKey.OutlayId );
            ProgramProjectCode = new Element( Record, Field.ProgramProjectCode );
            ProgramAreaCode = new Element( Record, Field.ProgramAreaCode );
            Commitments = new Amount( Record, Numeric.Commitments );
            OpenCommitments = new Amount( Record, Numeric.OpenCommitments );
            Obligations = new Amount( Record, Numeric.Obligations );
            Deobligations = new Amount( Record, Numeric.Deobligations );
            ULO = new Amount( Record, Numeric.ULO );
            Balance = new Amount( Record, Numeric.Balance );
            Data = Record?.ToDictionary();
            Type = ExpenseType.All;
            SetExpenseType( Type );
        }

        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets or sets the PRC identifier.
        /// </summary>
        /// <value>
        /// The PRC identifier.
        /// </value>
        private protected override IKey ID { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
        protected override Source Source { get; set; } = Source.Outlays;

        /// <summary>
        /// Gets or sets the authority data.
        /// </summary>
        /// <value>
        /// The authority data.
        /// </value>
        private protected CostAccount PRC { get; set; }

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected override IDictionary<string, object> Data { get; set; }

        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the outlay identifier.
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
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "T:System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            try
            {
                return Verify.Input( AccountCode?.GetValue() )
                    ? AccountCode?.GetValue()
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
                return Verify.Map( Data )
                    ? new Builder( Source, Data )
                    : default;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default;
            }
        }
    }
}
