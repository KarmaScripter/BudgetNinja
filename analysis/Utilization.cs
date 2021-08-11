// <copyright file = "Utilization.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class Utilization
    {
        /// <summary>
        /// Initializes a new instance of the <see cref = "Utilization"/> class.
        /// </summary>
        public Utilization()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Utilization"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public Utilization( IQuery query )
        {
            _record = new Builder( query )?.GetRecord();
            _id = new Key( _record, PrimaryKey.UtilizationId );
            _rpio = _record[ $"{Field.RpioCode}" ].ToString();
            _bfy = _record[ $"{Field.BFY}" ].ToString();
            _fundCode = _record[ $"{Field.FundCode}" ].ToString();
            _ahCode = _record[ $"{Field.AhCode}" ].ToString();
            _orgCode = _record[ $"{Field.OrgCode}" ].ToString();
            _accountCode = _record[ $"{Field.AccountCode}" ].ToString();
            _rcCode = _record[ $"{Field.RcCode}" ].ToString();
            _bocCode = _record[ $"{Field.BocCode}" ].ToString();
            _authority = new Amount( _record, Numeric.Authority );
            _budgeted = new Amount( _record, Numeric.Budgeted );
            _posted = new Amount( _record, Numeric.Posted );
            _carryIn = new Amount( _record, Numeric.CarryIn );
            _carryOut = new Amount( _record, Numeric.CarryOut );
            _commitments = new Amount( _record, Numeric.Commitments );
            _openCommitments = new Amount( _record, Numeric.OpenCommitments );
            _obligations = new Amount( _record, Numeric.Obligations );
            _ulo = new Amount( _record, Numeric.ULO );
            _rate = new Amount( _record, Numeric.Rate );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Utilization"/> class.
        /// </summary>
        /// <param name = "databuilder" >
        /// The databuilder.
        /// </param>
        public Utilization( IDataAccess databuilder )
            : this()
        {
            _record = databuilder?.GetRecord();
            _id = new Key( _record, PrimaryKey.UtilizationId );
            _rpio = _record?[ $"{Field.RpioCode}" ].ToString();
            _bfy = _record?[ $"{Field.BFY}" ].ToString();
            _fundCode = _record?[ $"{Field.FundCode}" ].ToString();
            _ahCode = _record?[ $"{Field.AhCode}" ].ToString();
            _orgCode = _record?[ $"{Field.OrgCode}" ].ToString();
            _accountCode = _record?[ $"{Field.AccountCode}" ].ToString();
            _rcCode = _record?[ $"{Field.RcCode}" ].ToString();
            _bocCode = _record?[ $"{Field.BocCode}" ].ToString();
            _authority = new Amount( _record, Numeric.Authority );
            _budgeted = new Amount( _record, Numeric.Budgeted );
            _posted = new Amount( _record, Numeric.Posted );
            _carryIn = new Amount( _record, Numeric.CarryIn );
            _carryOut = new Amount( _record, Numeric.CarryOut );
            _commitments = new Amount( _record, Numeric.Commitments );
            _openCommitments = new Amount( _record, Numeric.OpenCommitments );
            _obligations = new Amount( _record, Numeric.Obligations );
            _ulo = new Amount( _record, Numeric.ULO );
            _rate = new Amount( _record, Numeric.Rate );
            _args = _record?.ToDictionary();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Utilization"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public Utilization( DataRow data )
            : this()
        {
            _record = data;
            _id = new Key( _record, PrimaryKey.UtilizationId );
            _rpio = _record[ $"{Field.RpioCode}" ].ToString();
            _bfy = _record[ $"{Field.BFY}" ].ToString();
            _fundCode = _record[ $"{Field.FundCode}" ].ToString();
            _ahCode = _record[ $"{Field.AhCode}" ].ToString();
            _orgCode = _record[ $"{Field.OrgCode}" ].ToString();
            _accountCode = _record[ $"{Field.AccountCode}" ].ToString();
            _rcCode = _record[ $"{Field.RcCode}" ].ToString();
            _bocCode = _record[ $"{Field.BocCode}" ].ToString();
            _authority = new Amount( _record, Numeric.Authority );
            _budgeted = new Amount( _record, Numeric.Budgeted );
            _posted = new Amount( _record, Numeric.Posted );
            _carryIn = new Amount( _record, Numeric.CarryIn );
            _carryOut = new Amount( _record, Numeric.CarryOut );
            _commitments = new Amount( _record, Numeric.Commitments );
            _openCommitments = new Amount( _record, Numeric.OpenCommitments );
            _obligations = new Amount( _record, Numeric.Obligations );
            _ulo = new Amount( _record, Numeric.ULO );
            _rate = new Amount( _record, Numeric.Rate );
        }

        // **********************************************************************************************************************
        // *************************************************   PROPERTIES   *****************************************************
        // **********************************************************************************************************************

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        private const Source _source = Source.Utilization;

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        private protected IDictionary<string, object> _args;

        /// <summary>
        /// Gets the rc code.
        /// </summary>
        /// <value>
        /// The rc code.
        /// </value>
        private protected string _rcCode;

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private protected readonly DataRow _record;

        /// <summary>
        /// Gets or sets the outlays.
        /// </summary>
        /// <value>
        /// The outlays.
        /// </value>
        private protected IEnumerable<T> _outlays;

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        private protected IKey _id;

        /// <summary>
        /// Gets the rpio.
        /// </summary>
        /// <value>
        /// The rpio.
        /// </value>
        private string _rpio;

        /// <summary>
        /// Gets the ah code.
        /// </summary>
        /// <value>
        /// The ah code.
        /// </value>
        private protected string _ahCode;

        /// <summary>
        /// Gets the org code.
        /// </summary>
        /// <value>
        /// The org code.
        /// </value>
        private protected string _orgCode;

        /// <summary>
        /// Gets the account code.
        /// </summary>
        /// <value>
        /// The account code.
        /// </value>
        private protected string _accountCode;

        /// <summary>
        /// Gets the bfy.
        /// </summary>
        /// <value>
        /// The bfy.
        /// </value>
        private protected string _bfy;

        /// <summary>
        /// Gets the fund code.
        /// </summary>
        /// <value>
        /// The fund code.
        /// </value>
        private protected string _fundCode;

        /// <summary>
        /// Gets or sets the program project code.
        /// </summary>
        /// <value>
        /// The program project code.
        /// </value>
        private protected string _programProjectCode;

        /// <summary>
        /// Gets or sets the program area code.
        /// </summary>
        /// <value>
        /// The program area code.
        /// </value>
        private protected string _programAreaCode;

        /// <summary>
        /// Gets the boc code.
        /// </summary>
        /// <value>
        /// The boc code.
        /// </value>
        private protected string _bocCode;

        /// <summary>
        /// Gets or sets the foc code.
        /// </summary>
        /// <value>
        /// The foc code.
        /// </value>
        private protected string _focCode;

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        private protected IAmount _balance;

        /// <summary>
        /// Gets the authority.
        /// </summary>
        /// <value>
        /// The authority.
        /// </value>
        private protected IAmount _authority;

        /// <summary>
        /// Gets the budgeted.
        /// </summary>
        /// <value>
        /// The budgeted.
        /// </value>
        private protected IAmount _budgeted;

        /// <summary>
        /// Gets the posted.
        /// </summary>
        /// <value>
        /// The posted.
        /// </value>
        private protected IAmount _posted;

        /// <summary>
        /// Gets the carry in.
        /// </summary>
        /// <value>
        /// The carry in.
        /// </value>
        private protected IAmount _carryIn;

        /// <summary>
        /// Gets the carry out.
        /// </summary>
        /// <value>
        /// The carry out.
        /// </value>
        private protected IAmount _carryOut;

        /// <summary>
        /// Gets the commitments.
        /// </summary>
        /// <value>
        /// The commitments.
        /// </value>
        private protected IAmount _commitments;

        /// <summary>
        /// Gets the open commitments.
        /// </summary>
        /// <value>
        /// The open commitments.
        /// </value>
        private protected IAmount _openCommitments;

        /// <summary>
        /// Gets the obligations.
        /// </summary>
        /// <value>
        /// The obligations.
        /// </value>
        private protected IAmount _obligations;

        /// <summary>
        /// Gets the ulo.
        /// </summary>
        /// <value>
        /// The ulo.
        /// </value>
        private protected IAmount _ulo;

        /// <summary>
        /// Gets the rate.
        /// </summary>
        /// <value>
        /// The rate.
        /// </value>
        private protected readonly IAmount _rate;
        
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref = "string"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            try
            {
                return _rate.GetFunding() > -1.0
                    ? _rate.GetFunding().ToString( "P" )
                    : string.Empty;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> GetArgs()
        {
            if( _record != null )
            {
                try
                {
                    return _record.ToDictionary().Any()
                        ? _record.ToDictionary()
                        : default( IDictionary<string, object> );
                }
                catch( SystemException ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var _error = new Error( ex );
            _error?.SetText();
            _error?.ShowDialog();
        }
    }
}
