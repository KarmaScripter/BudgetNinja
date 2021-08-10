// <copyright file = "CostAccount.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// </summary>
    /// <seealso cref = "Cost"/>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    public class CostAccount : Cost, ICostAccount
    {
        /// <summary>
        /// The PRC
        /// </summary>
        private readonly IProgramResultsCode _prc;
        
        /// <summary>
        /// Initializes a new instance of the <see cref = "CostAccount"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The dataRow.
        /// </param>
        public CostAccount( DataRow dataRow )
        {
            _records = dataRow;
            _prc = new ProgramResultsCode( dataRow );
            _id = new Key( _records, PrimaryKey.PrcId );
            _npmCode = new Element( _records, Field.NpmCode );
            _programProjectCode = new Element( _records, Field.ProgramProjectCode );
            _programAreaCode = new Element( _records, Field.ProgramAreaCode );
            _focCode = new Element( _records, Field.FocCode );
            _focName = new Element( _records, Field.FocName );
            _documentType = new Element( _records, Field.DocumentType );
            _documentPrefix = new Element( _records, Field.DocumentPrefix );
            _dcn = new Element( _records, Field.DocumentType );
            _originalActionDate = new Time( _records, EventDate.OriginalActionDate );
            _obligatingDocumentNumber = new Element( _records, Field.ObligatingDocumentNumber );
            _system = new Element( _records, Field.System );
            _transactionNumber = new Element( _records, Field.TransactionNumber );
            _grantNumber = new Element( _records, Field.GrantNumber );
            _commitments = new Amount( _records, Numeric.Commitments );
            _openCommitments = new Amount( _records, Numeric.OpenCommitments );
            _obligations = new Amount( _records, Numeric.Obligations );
            _deobligations = new Amount( _records, Numeric.Deobligations );
            _ulo = new Amount( _records, Numeric.ULO );
            _balance = new Amount( _records, Numeric.Balance );
            _data = _records?.ToDictionary();
        }
        
        /// <summary>
        /// Gets the PRC identifier.
        /// </summary>
        /// <returns>
        /// </returns>
        public override IKey GetId()
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
        /// Gets the finance object class.
        /// </summary>
        /// <returns>
        /// </returns>
        public IFinanceObjectClass GetFinanceObjectClass()
        {
            try
            {
                var _code = _focCode?.GetValue();

                return Verify.Input( _code )
                    ? new FinanceObjectClass( _code )
                    : default( FinanceObjectClass );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IFinanceObjectClass );
            }
        }

        /// <summary>
        /// Gets the national program.
        /// </summary>
        /// <returns>
        /// </returns>
        public INationalProgram GetNationalProgram()
        {
            try
            {
                return Verify.Input( _npmCode?.GetValue() )
                    ? new NationalProgram( _npmCode?.GetValue() )
                    : default( NationalProgram );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( INationalProgram );
            }
        }

        /// <summary>
        /// Gets the program results code.
        /// </summary>
        /// <returns>
        /// </returns>
        public IProgramResultsCode GetProgramResultsCode()
        {
            try
            {
                return _prc?.GetAmount()?.GetFunding() > 0.0
                    ? _prc
                    : default( IProgramResultsCode );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IProgramResultsCode );
            }
        }

        /// <summary>
        /// Gets the program project.
        /// </summary>
        /// <returns>
        /// </returns>
        public IProgramProject GetProgramProject()
        {
            try
            {
                return Verify.Input( _programProjectCode?.GetValue() )
                    ? new ProgramProject( _programProjectCode?.GetValue() )
                    : default( ProgramProject );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IProgramProject );
            }
        }

        /// <summary>
        /// Gets the program area.
        /// </summary>
        /// <returns>
        /// </returns>
        public IProgramArea GetProgramArea()
        {
            try
            {
                return Verify.Input( _programAreaCode?.GetValue() )
                    ? new ProgramArea( _programAreaCode?.GetValue() )
                    : default( ProgramArea );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IProgramArea );
            }
        }
    }
}
